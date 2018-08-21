namespace Alias_genarator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    class Program
    {
        struct Alias
        {
            public string AliNavn;
            public int AliNr;
        }

        static void Main(string[] args)
        {
            string navn = "";
            char[] schar = { ' ' };
            List<Alias> AliasList = new List<Alias>();
            List<string> navneliste = new List<string>();// opretter en string list der hedder navneliste.

            do
            {
                Console.Write("Hvad hedder du? : ");
                navn = StortOgSmaat(Console.ReadLine().Trim()); //variablen navn = indtastning + metoden StortOgSmåt plus trim(fjern mellemrum)
                if (navn != "")
                {
                    string[] delNavn = navn.Split(schar, StringSplitOptions.RemoveEmptyEntries); // opretter en ny string array "delnavn" og gemmer det indtastede navn, og splitter det ved alle mellemrum (schar)
                    string totalNavn = "";
                    foreach (string xnavn in delNavn)// for hvert navn gemt i vores array, kør metoden StortOgSmåt og gem navnet i totalNavn
                    {
                        totalNavn += StortOgSmaat(xnavn);
                    }
                    totalNavn = totalNavn.Trim();//fjerner alle mellemrum fra variablen totalNavn
                    string[] fnavn = totalNavn.Split(); // opretter en string array og gemmer indtastningen af navne, .split splitter alle navne op i seperate arrays
                    string Efternavn = fnavn[fnavn.Length - 1]; // opretter en variable Efternavn, og tjekker længden af fnavn arrayet og tager det sidste navn i arrayet og gemmer den under variablen Efternavn
                    string Fornavn = ""; // opretter en tom string variable kaldet Fornavn.
                    for (int i = 0; i < fnavn.Length - 1; i++)//
                        Fornavn += fnavn[i] + " ";

                    Alias A1;
                    A1.AliNavn = Fornavn.Substring(0, 2) + Efternavn.Substring(0, 2);// tag de første 2 bokstaver af første fornavn og efternavnet
                    A1.AliNr = 0001;// Hvor er mine fucking nuller!?
                    string alinavn = A1.AliNavn;

                    foreach (Alias DelAlias in AliasList)
                    {

                        if (DelAlias.AliNavn == alinavn)
                        {
                            A1.AliNr += 1;
                        }

                    }
                    AliasList.Add(A1);
                    navneliste.Add(Efternavn + ", " + Fornavn + ", " + A1.AliNavn + A1.AliNr);
                }
            } while (navn != "");// kør min "do" imens variablen navn ikke er tom
            navneliste.Sort();//sorter navneliste, når den udskrives vil den vises i alfabetisk rækkefølge
            foreach (string fnavn in navneliste)// for hvert navn i min List gør: udskriv!
            {
                Console.WriteLine(fnavn);
            }

            // her er vores funktion (metode fordi den ligger i en kasse - main)
            string StortOgSmaat(string inavn) //tager de første bokstaver og laver dem store (capslock) og alle andre små.
            {
                if (inavn.Length != 0)
                    return inavn.Substring(0, 1).ToUpper() + inavn.Substring(1).ToLower() + " ";
                else
                    return "";
            }

            Console.ReadKey();
        }
    }
}