using HtmlAgilityPack;
using System;
using System.Globalization;
using System.Net;
using System.Security.Policy;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Web;
using System.IO;


namespace Helper2
{

    // Interface IPrevodnik - třídy, které využivají interface se zavazují k implementaci daných metod.
    public interface IPrevodnik
    {
        Task<bool> VyzkousejAdresu(string url);

        HtmlDocument ZiskejData(string url);

        void ZiskejNazev(HtmlDocument data);

        void ZiskejAnotaci(HtmlDocument data);

        void ZiskejDatumMistoLektora(HtmlDocument data);

        void ZiskejPoznamku(HtmlDocument data);

        void ZiskejOdkaz(HtmlDocument data);

        void ZiskejInfoGaranta(HtmlDocument data);

        HtmlDocument VlozData();

        HtmlDocument VytvorVystup(); //TO DO
    }


    // Třída Pozvanka - slouží jako výstup daých builderů. Při zavolání vytvoří nový Html dokument
    public class Pozvanka
    {
        public HtmlDocument pozvanka;
        public Pozvanka()
        {
            pozvanka = new HtmlDocument();
        }
    }


    // Třída Director představuje ovládací prvek, který koordinuje proces generování pozvánek.
    public class Director
    {
        private IPrevodnik prevodnik;

        // Instance proměnné <c>prevodnik</c> představuje převodník (Builder) použitý v procesu generování pozvánek.
        public Director()
        {
            this.prevodnik = null;
        }


        //Nastavení get a set - pro přeřazení builderů
        public IPrevodnik Prevodnik
        {
            get { return prevodnik; }
            set { prevodnik = value; }
        }


        // Asynchronně vygeneruje pozvánku, pokud je adresa platná. Zavolá na převodníka a ten jí vytvoří.
        // <param name="url">Adresa webové stránky ve formě řetězce (string).</param>
        public async Task VygenerujPozvanku(string url)
        {
            bool dostupnost = await prevodnik.VyzkousejAdresu(url);

            if (dostupnost)
            {
                HtmlDocument data = prevodnik.ZiskejData(url); //Decoded data z metody
                prevodnik.ZiskejNazev(data);
                prevodnik.ZiskejDatumMistoLektora(data);
                prevodnik.ZiskejAnotaci(data);
                prevodnik.ZiskejPoznamku(data);
                prevodnik.ZiskejInfoGaranta(data);
                prevodnik.ZiskejOdkaz(data);
                prevodnik.VytvorVystup();
            }
            else
            {
                Console.WriteLine("Nelze vytvorit pozvanku, adresa neni platna.");
            }
        }

    }


    // Třída implementující rozhraní IPrevodnik pro převod dat o vzdělávací akci na HTML formát pozvánky.
    public class PrevodnikPozvanky : IPrevodnik
    {
        private List<string> outputData;
        public Pozvanka vystup;
        private List<string> titles;


        // Konstruktor třídy PrevodnikPozvanky.
        public PrevodnikPozvanky()
        {
            // Inicializace outputData v konstruktoru
            outputData = new List<string>();
            outputData.Add("<p class=\"custom-no-padding\">Dobrý den,<br><br>srdečně Vás zveme na plánované vzdělávací akce:</p class=\"custom-no-padding\">"); //vložení pozdravu na první místo

            this.vystup = new Pozvanka();
            this.titles = new List<string> { "Mgr.", "Ing.", "Ph.D.", "MBA", "et", "Bc", "DiS." }; //<- asi doplnit..
        }


        // Kolekce obsahující převedená data ve formátu HTML.
        public List<string> OutputData => outputData; //jen pro metodu ZkoukniList


        // Metoda pro výpis obsahu kolekce OutputData pro kontrolu.
        public void ZkoukniList()
        {
            foreach (string item in OutputData)
            {
                Console.WriteLine(item);
                Console.WriteLine(" ");
            }
        } //JEN PRO KONTROLU


        // Metoda pro otestování dostupnosti dané URL adresy.
        // <param name="url">Adresa, která se má otestovat.</param>
        // <returns>True, pokud je adresa dostupná, jinak False.</returns>
        public async Task<bool> VyzkousejAdresu(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                // Přidání hlavičky User-Agent - Aby mi to fakčilo
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");

                //Pokud adresa nezačína dle podmínky, tak se vrací false - handling špatného formátu
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    return false;
                }

                else
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync(url);
                        return response.IsSuccessStatusCode;
                    }
                    catch (HttpRequestException)
                    {
                        return false;
                    }
                }

            }
        }


        // Metoda pro vytvoření prázdného HTML dokumentu. Ten následně slouží k přečtení stránky.
        // <returns>Prázdný HTML dokument.</returns>
        public HtmlDocument VytvorHtml()
        {
            HtmlDocument htmlDoc = new HtmlDocument();

            return htmlDoc;
        } //jenom pro precteni zdrojove HTML



        // Metoda pro získání dekódovaných dat z dané URL adresy.
        // <param name="url">Adresa, ze které se mají data získat.</param>
        // <returns>HTML dokument obsahující dekódovaná data.</returns>
        public HtmlDocument ZiskejData(string url)
        {
            HtmlWeb web = new HtmlWeb(); //nastroj pro nacitani html
            web.OverrideEncoding = Encoding.UTF8; // Zajistí správné kódování

            HtmlDocument htmlDoc = VytvorHtml(); //zavolam metodu, co vraci empty html
            htmlDoc = web.Load(url); //nacte html kod z dane adresy

            /*
            Projede každý uzel HTML + jeho potomky - následně vybere pouze ty, které obsahují text. Následně dojde k dekodování.

            DescendantantsAndSelf <- metoda HTML agility packu -> vrací všechny potomky uzlu společně s tím uzlem

            .Where(n => n.NodeType == HtmlNodeType.Text): Filtruje všechny nalezené uzly na ty, které mají typ uzlu HtmlNodeType.Text
            */

            foreach (var textNode in htmlDoc.DocumentNode.DescendantsAndSelf().Where(n => n.NodeType == HtmlNodeType.Text))
            {
                textNode.InnerHtml = WebUtility.HtmlDecode(textNode.InnerHtml);
            }

            return htmlDoc;
        }


        // Metoda pro získání názvu VP.
        // <param name="data">HTML vstup <- ZiskejData <- zdrojový dokument</param>
        public void ZiskejNazev(HtmlDocument data)
        {

            var classNameElement = data.DocumentNode.SelectSingleNode("//div[@class='article-header']/h1");
            var className = classNameElement?.InnerText.Trim();

            var subnameElement = data.DocumentNode.SelectSingleNode("//div[@class='description item span-7']/h2[1]");
            var subprogramName = subnameElement?.InnerText.Trim();

            string celyNazev;
            if (string.IsNullOrEmpty(subprogramName))
            {
                celyNazev = $"<h1>{className}</h1>";
            }
            else
            {
                celyNazev = $"<h1>{className}: {subprogramName}</h1>";
            }

            celyNazev = Regex.Replace(celyNazev, @"\s+", " "); //da tu ::after pryč
            outputData.Add(celyNazev);
            /*
            foreach (string item in OutputData)
            {
                Console.WriteLine("Nazev VP: ");
                Console.WriteLine(item);
            }
            */
        }



        // Metoda pro získání anotace VP.
        // <param name="data">HTML vstup <- ZiskejData <- zdrojový dokument</param>
        public void ZiskejAnotaci(HtmlDocument data)
        {
            var anotaceElements = data.DocumentNode.SelectNodes("//div[@class='description item span-7']/p");

            if (anotaceElements != null)
            {
                outputData.Add($"<h3>Anotace programu:</h3>");

                foreach (var anotaceElement in anotaceElements)
                {
                    if (anotaceElement != null)
                    {
                        string anotace = HttpUtility.HtmlDecode(anotaceElement.InnerText.Trim());

                        // Nahrazení otazníků a jiných zvláštních znaků
                        anotace = Regex.Replace(anotace, @"\?", " "); // Nahrazení "?" mezerou
                        anotace = Regex.Replace(anotace, @"\u00A0", " "); // Nahrazení neoddělitelné mezery běžnou mezerou
                        anotace = Regex.Replace(anotace, @"[^\w\s.,;:()]", " "); // Odstranění nežádoucích znaků

                        // Debugging: Výpis pro kontrolu
                        Console.WriteLine("Původní anotace:");
                        Console.WriteLine(anotaceElement.InnerText);

                        Console.WriteLine("Upravená anotace:");
                        Console.WriteLine(anotace);

                        if (!string.IsNullOrEmpty(anotace))
                        {
                            outputData.Add($"<p>{anotace}</p>");
                        }
                    }
                }
            }
        }

        // Metoda pro získání poznámky VP.
        // <param name="data">HTML vstup <- ZiskejData <- zdrojový dokument</param>
        public void ZiskejPoznamku(HtmlDocument data)
        {
            var poznamkaElement = data.DocumentNode.SelectSingleNode("//div[@class='description item span-7']/i");
            var poznamka = poznamkaElement?.InnerText.Trim();

            if (!string.IsNullOrEmpty(poznamka))
            {
                // Přidat poznamku do kolekce pouze pokud existuje
                outputData.Add($"<h3>Poznámka:</h3>");
                outputData.Add($"<p>{poznamka} </p>");
            }
            else
            {
                Console.WriteLine("Není poznámka..");
                Console.WriteLine("");
            }
        }


        // Metoda pro získání informací typu: Datum, Místo, Lektor.
        // <param name="data">HTML vstup <- ZiskejData <- zdrojový dokument</param>
        public void ZiskejDatumMistoLektora(HtmlDocument data)
        {
            var datumElement = data.DocumentNode.SelectSingleNode("//p[@class='action-date']");
            var datum = datumElement?.InnerText.Trim();
            datum = Regex.Replace(datum, @"\s+", " ");

            datum = $"<h2> Datum konání: {datum} </h2>";
            Console.WriteLine(datum);

            outputData.Add(datum);


            var mistoElement = data.DocumentNode.SelectSingleNode("//h5[contains(text(),'Místo konání')]/following-sibling::p[1]/strong");
            var misto = mistoElement?.InnerText.Trim();
            misto = Regex.Replace(misto, @"\s+", " ");

            misto = $"<h2> Místo konání: {misto} </h2>";
            Console.WriteLine(misto);
            outputData.Add(misto);

            var lektorElements = data.DocumentNode.SelectNodes("//ul[contains(@class, 'lektori')]/li");

            List<string> lektori = new List<string>();

            // Přidat každého lektora do seznamu
            if (lektorElements != null)
            {
                foreach (var lektorElement in lektorElements)
                {
                    lektori.Add(lektorElement.InnerText.Trim());
                }
            }

            // Spojit všechny lektory do jednoho řetězce, oddělené čárkou
            string lektor_reg = string.Join(", ", lektori);

            string lektor = $"<h2> Lektoři: {lektor_reg} </h2>";
            Console.WriteLine(lektor);
            outputData.Add(lektor);

            // Cena kurzu
            var cenaElement = data.DocumentNode.SelectSingleNode("//p[@class='action-price-sum']");
            var cena = cenaElement?.InnerText.Trim();

            cena = $"<h2> Cena kurzu: {cena} </h2>";
            outputData.Add(cena);



        }



        // Metoda pro získání odkazu na přihlášení.
        // <param name="data">HTML vstup <- ZiskejData <- zdrojový dokument</param>
        public void ZiskejOdkaz(HtmlDocument data)
        {

            var odkazElement = data.DocumentNode.SelectSingleNode("//a[contains(text(), 'Přihlásit se')]");

            if (odkazElement != null)
            {
                var urlAdresa = odkazElement?.GetAttributeValue("href", "");
                outputData.Add($"<a href=\"{urlAdresa}\">Přihlaste se!</a>");
                outputData.Add($"<hr class=\"hr-colored\">");
            }

            else
            {
                outputData.Add($"<h4>Na kurz již neexistuje přihláška!</h4>");
                outputData.Add($"<hr class=\"hr-colored\">");
                Console.WriteLine("NA KURZ SE NELZE PŘIHLÁSIT!");
                //TO-DO nějak ho dropnout z vystupu, pokud ho tam nějakýinteligent hodí
            }

        }



        // Metoda pro získání kontaktů na garanta VP. Metoda obsahuje generátor emailových adres společně s filtrem na vysokoškolské tituly.
        // <param name="data">HTML vstup <- ZiskejData <- zdrojový dokument</param>
        public void ZiskejInfoGaranta(HtmlDocument data) //TO:DO ZJEDNODUŠIT! - POPSAT
        {
            string GetInnerText(HtmlNode node)
            {
                return node?.InnerText.Trim();
            }

            string CleanWhitespace(string input)
            {
                return Regex.Replace(input, @"\s+", " ");
            }

            string FormatOutput(string label, string value)
            {
                return $"<h2>{label}: {value}</h2>";
            }

            // Seznam známých vysokoškolských titulů
            string[] titles = { "Bc.", "MBA.", "Mgr.", "Ing.", "MUDr.", "Ph.D.", "RNDr.", "Doc.", "JUDr.", "Th.D.", "et" };

            // Metoda pro odstranění diakritiky
            string RemoveDiacritics(string input)
            {
                string normalized = input.Normalize(NormalizationForm.FormD);
                StringBuilder sb = new StringBuilder();

                foreach (char c in normalized)
                {
                    if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    {
                        sb.Append(c);
                    }
                }

                return sb.ToString().Normalize(NormalizationForm.FormC);
            }

            var garantElement = data.DocumentNode.SelectSingleNode("//h5[contains(text(),'Garant')]/following-sibling::p[1]/strong");
            var garantText = GetInnerText(garantElement);

            if (!string.IsNullOrEmpty(garantText))
            {
                // Extract garant name
                var garantName = CleanWhitespace(Regex.Match(garantText, @"^[^\n]+").Value);

                // Extract garant phone number
                var garantPhoneMatch = Regex.Match(garantText, @"(\d{3} \d{3} \d{3})");
                var garantPhone = garantPhoneMatch.Success ? garantPhoneMatch.Value : "";

                // Extracting garant email username
                var garantEmailUsername = "";
                var garantNameParts = garantName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (garantNameParts.Length >= 2)
                {
                    // Remove titles from email username
                    var nameWithoutTitles = garantNameParts.Where(part => !titles.Contains(part)).ToArray();

                    // Construct email username
                    garantEmailUsername = nameWithoutTitles[0].ToLower() + "." + nameWithoutTitles[1].ToLower();
                    garantEmailUsername = RemoveDiacritics(garantEmailUsername); // Remove diacritics

                    StringBuilder sb = new StringBuilder(garantEmailUsername);
                    for (int i = 0; i < sb.Length; i++)
                    {
                        if (sb[i] == ',')
                        {
                            sb.Remove(i, 1);
                        }
                    }
                    garantEmailUsername = sb.ToString();
                }

                outputData.Add(FormatOutput("Garant", garantName));
                outputData.Add(FormatOutput("Telefon", garantPhone));
                outputData.Add(FormatOutput("E-mail", garantEmailUsername + "@npi.cz"));
            }
        }



        // Metoda pro převedení output listu do HTML dokumentu. V této metodě přidávám do hlavičky odkaz na CSS soubor pro následnou vyzualizaci.
        // <param name="data">HTML vstup <- ZiskejData <- zdrojový dokument</param>
        // <returns>HTML dokument, jedná se o výslednou pozvánku, která je uložena v adresáři programu.</returns>
        public HtmlDocument VlozData()
        {
            HtmlDocument output = this.vystup.pozvanka;

            try
            {
                output.DocumentNode.InnerHtml = "<!DOCTYPE html><html><head></head><body></body></html>";

                HtmlNode headNode = output.DocumentNode.SelectSingleNode("//head");

                // Přidání UTF-8 meta tagu do hlavičky
                HtmlNode metaCharset = HtmlNode.CreateNode("<meta charset=\"UTF-8\">");
                headNode.AppendChild(metaCharset);

                // Přidání CSS stylů do hlavičky
                HtmlNode nactiCSS = HtmlNode.CreateNode(@"
                <style>
                    body {
                        font-family: Arial, sans-serif;
                        color: #333;
                    }
                    h1 {
                        color: #1e90ff;
                        font-size: 1.7em;
                        text-align: center;
                        margin: 15px 0;
                    }
                    h2 {
                        color: #333;
                        font-size: 1.2em;
                        margin: 10px 0;
                    }
                    p {
                        margin: 10px 0;
                        font-size: 1em;
                        text-align: justify;
                    }
                    .hr-colored {
                        border: none;
                        height: 2px;
                        background-color: #1e90ff;
                    }
                </style>");
                headNode.AppendChild(nactiCSS);

                HtmlNode bodyNode = output.DocumentNode.SelectSingleNode("//body");

                // 🚀 HLAVNÍ OPRAVA - NEPOUŽÍVÁME WebUtility.HtmlEncode, protože chceme HTML správně vykreslit
                foreach (string text in outputData)
                {
                    HtmlNode textNode = HtmlNode.CreateNode(text); // 🚀 Přidáváme HTML obsah přímo
                    bodyNode?.AppendChild(textNode);
                }

                // Debugging: Výpis HTML před uložením
                Console.WriteLine("Vygenerované HTML:");
                Console.WriteLine(output.DocumentNode.OuterHtml);

                // Uložení souboru jako UTF-8
                File.WriteAllText("output_pozvanka.html", output.DocumentNode.OuterHtml, Encoding.UTF8);

                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba: {ex.Message}");
                return output;
            }
        }


        // Jedná se o metodu, která vytváři celou výslednou pozvánku. Následně vrací HTML dokument z metody VlozData.
        // <param name="url">Adresa vzdělávacího programu, který chceme zpracovat.</param>
        // <returns>HTML dokument, jedná se o výslednou pozvánku, která je uložena v adresáři programu.</returns>
        public HtmlDocument VytvorVystup()
        {
            return VlozData();
        }

    }


    // Třída implementující rozhraní IPrevodnik pro převod dat o vzdělávací akci na HTML formát pozvánky - odkaz na Teams.
    public class PrevodnikPripojeni : IPrevodnik
    {
        private List<string> outputData;
        public Pozvanka vystup;

        // Deklarace proměnné pro odkaz na připojení (např. Microsoft Teams)
        public string odkazTeams;

        public PrevodnikPripojeni()
        {
            // Inicializace seznamu pro výstupní HTML data
            outputData = new List<string>();
            outputData.Add("<p class=\"custom-no-padding\">Dobrý den,<br><br>přihlásili jste se na následující vzdělávací program:</p class=\"custom-no-padding\">"); //vložení pozdravu na první místo
            this.vystup = new Pozvanka();
        }

        public async Task<bool> VyzkousejAdresu(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");

                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                    return false;

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
                catch (HttpRequestException)
                {
                    return false;
                }
            }
        }

        public HtmlDocument ZiskejData(string url)
        {
            HtmlWeb web = new HtmlWeb();
            web.OverrideEncoding = Encoding.UTF8; // Zajistí správné kódování

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc = web.Load(url);

            foreach (var textNode in htmlDoc.DocumentNode.DescendantsAndSelf().Where(n => n.NodeType == HtmlNodeType.Text))
            {
                textNode.InnerHtml = WebUtility.HtmlDecode(textNode.InnerHtml);
            }

            return htmlDoc;
        }

        public void ZiskejNazev(HtmlDocument data)
        {
            var classNameElement = data.DocumentNode.SelectSingleNode("//div[@class='article-header']/h1");
            var className = classNameElement?.InnerText.Trim();

            var subnameElement = data.DocumentNode.SelectSingleNode("//div[@class='description item span-7']/h2[1]");
            var subprogramName = subnameElement?.InnerText.Trim();

            string celyNazev = string.IsNullOrEmpty(subprogramName) ? $"<h1>{className}</h1>" : $"<h1>{className}: {subprogramName}</h1>";

            celyNazev = Regex.Replace(celyNazev, @"\s+", " ");
            outputData.Add(celyNazev);
        }

        public void ZiskejAnotaci(HtmlDocument data)
        {
            var anotaceElements = data.DocumentNode.SelectNodes("//div[@class='description item span-7']/p");

            if (anotaceElements != null)
            {
                outputData.Add($"<h3>Anotace programu:</h3>");

                foreach (var anotaceElement in anotaceElements)
                {
                    if (anotaceElement != null)
                    {
                        string anotace = HttpUtility.HtmlDecode(anotaceElement.InnerText.Trim());

                        anotace = Regex.Replace(anotace, @"\?", " ");
                        anotace = Regex.Replace(anotace, @"\u00A0", " ");
                        anotace = Regex.Replace(anotace, @"[^\w\s.,;:()]", " ");

                        Console.WriteLine("Upravená anotace:");
                        Console.WriteLine(anotace);

                        if (!string.IsNullOrEmpty(anotace))
                        {
                            outputData.Add($"<p>{anotace}</p>");
                        }
                    }
                }
            }
        }

        public void ZiskejOdkaz(HtmlDocument data)
        {
            if (!string.IsNullOrEmpty(odkazTeams))
            {
                outputData.Add($"<hr class=\"hr-colored\">");
                outputData.Add($"<h3>Odkaz pro připojení:</h3>");
                outputData.Add($"<a href=\"{odkazTeams}\" class=\"blue-button\">Připojte se!</a>");
            }
            else
            {
                outputData.Add($"<h3>Odkaz pro připojení není k dispozici.</h3>");
                Console.WriteLine("Nebyl přidán odkaz..");
            }

            Console.WriteLine("Obsah outputData po ZiskejOdkaz:");
            foreach (string text in outputData)
            {
                Console.WriteLine(text);
            }
        }

        public HtmlDocument VlozData()
        {
            HtmlDocument output = this.vystup.pozvanka;

            try
            {
                output.DocumentNode.InnerHtml = "<!DOCTYPE html><html><head></head><body></body></html>";

                HtmlNode headNode = output.DocumentNode.SelectSingleNode("//head");

                // Přidání UTF-8 meta tagu
                HtmlNode metaCharset = HtmlNode.CreateNode("<meta charset=\"UTF-8\">");
                headNode.AppendChild(metaCharset);

                // Přidání CSS stylů
                HtmlNode nactiCSS = HtmlNode.CreateNode(@"
            <style>
                body { font-family: Arial, sans-serif; color: #333; }
                h1 { color: #1e90ff; font-size: 1.7em; text-align: center; margin: 15px 0; }
                h2 { color: #333; font-size: 1.2em; margin: 10px 0; }
                p { margin: 10px 0; font-size: 1em; text-align: justify; }
                .hr-colored { border: none; height: 2px; background-color: #1e90ff; }
            </style>");
                headNode.AppendChild(nactiCSS);

                HtmlNode bodyNode = output.DocumentNode.SelectSingleNode("//body");

                if (outputData.Count == 0)
                {
                    Console.WriteLine("❌ Chyba: outputData je prázdné!");
                }
                else
                {
                    foreach (string text in outputData)
                    {
                        HtmlNode textNode = HtmlNode.CreateNode(text);
                        bodyNode?.AppendChild(textNode);
                    }
                }

                Console.WriteLine("Vygenerované HTML:");
                Console.WriteLine(output.DocumentNode.OuterHtml);

                File.WriteAllText("output_pripojeni.html", output.DocumentNode.OuterHtml, Encoding.UTF8);

                return output;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba: {ex.Message}");
                return output;
            }
        }

        public void ZiskejDatumMistoLektora(HtmlDocument data) {
            var datumElement = data.DocumentNode.SelectSingleNode("//p[@class='action-date']");
            var datum = datumElement?.InnerText.Trim();
            datum = Regex.Replace(datum, @"\s+", " ");

            datum = $"<h2> Datum konání: {datum} </h2>";
            Console.WriteLine(datum);

            outputData.Add(datum);


            var mistoElement = data.DocumentNode.SelectSingleNode("//h5[contains(text(),'Místo konání')]/following-sibling::p[1]/strong");
            var misto = mistoElement?.InnerText.Trim();
            misto = Regex.Replace(misto, @"\s+", " ");

            misto = $"<h2> Místo konání: {misto} </h2>";
            Console.WriteLine(misto);
            outputData.Add(misto);

            var lektorElements = data.DocumentNode.SelectNodes("//ul[contains(@class, 'lektori')]/li");

            List<string> lektori = new List<string>();

            // Přidat každého lektora do seznamu
            if (lektorElements != null)
            {
                foreach (var lektorElement in lektorElements)
                {
                    lektori.Add(lektorElement.InnerText.Trim());
                }
            }

            // Spojit všechny lektory do jednoho řetězce, oddělené čárkou
            string lektor_reg = string.Join(", ", lektori);

            string lektor = $"<h2> Lektoři: {lektor_reg} </h2>";
            Console.WriteLine(lektor);
            outputData.Add(lektor);

            // Cena kurzu
            var cenaElement = data.DocumentNode.SelectSingleNode("//p[@class='action-price-sum']");
            var cena = cenaElement?.InnerText.Trim();

            cena = $"<h2> Cena kurzu: {cena} </h2>";
            outputData.Add(cena);
        }

        public void ZiskejPoznamku(HtmlDocument data) { }

        public void ZiskejInfoGaranta(HtmlDocument data)
        {
            outputData.Add($"<h2>Pokud máte jakýkoliv dotaz, tak neváhejte a ozvěte se!</h2>");
        }

        public HtmlDocument VytvorVystup()
        {
            return VlozData();
        }
    }
}