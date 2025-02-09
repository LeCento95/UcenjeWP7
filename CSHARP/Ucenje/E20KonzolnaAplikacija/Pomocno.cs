namespace Ucenje.E20KonzolnaAplikacija
{
    internal class PomocnoRR
    {

        public static bool DEV=false;

        internal static bool UcitajBool(string poruka, string trueValue)
        {
            Console.Write(poruka + ": ");
            return Console.ReadLine().Trim().ToLower() == trueValue;
        }

        internal static DateTime UcitajDatum(string poruka, bool kontrolaPrijeDanasnjegDatuma)
        {
            DateTime d;

            while (true) 
            {
                try
                {
                    Console.WriteLine("Format unosa je yyyy-MM-dd, za današnji datum {0}",
                        DateTime.Now.ToString("yyyy-MM-dd"));
                    if (kontrolaPrijeDanasnjegDatuma)
                    {
                        Console.WriteLine("Uneseni datum ne smije biti prije današnjeg datuma!");
                    }
                    Console.Write(poruka + ": ");
                    d=DateTime.Parse(Console.ReadLine());
                    if (kontrolaPrijeDanasnjegDatuma && d < DateTime.Now)
                    {
                        throw new Exception();
                    }
                    return d;
                }
                catch
                {
                    Console.WriteLine("Unos datuma nije dobar");
                }
            }
        }

        internal static float UcitajDecimalniBroj(string poruka, int min, float max)
        {
            float b;
            while (true)
            {
                try
                {
                    Console.Write(poruka + ": ");
                    b = float.Parse(Console.ReadLine());
                    if(b<min || b > max)
                    {
                        throw new Exception();
                    }
                    return b;
                }
                catch
                {
                    Console.WriteLine("Decimalni broj mora biti u rasponu {0} i {1}",min,max);
                }
            }
        }

        internal static int UcitajRasponBroja(string poruka, int min, int max, int brojOsoba)
        {
            int b;
            while (true) 
            {
                try
                {
                    Console.Write(poruka + ": ");
                    b =int.Parse(Console.ReadLine());
                    if(b<min || b > max)
                    {
                        throw new Exception();
                    }
                    return b;
                }
                catch
                {
                    Console.WriteLine("Unos nije dobar, unos mora biti u rasponu {0} do {1}",min,max);
                }
            }
        }

        internal static string UcitajString(string poruka, int max, bool obavezno)
        {
            string s;
            while (true) 
            {
                Console.Write(poruka + ": ");
                s = Console.ReadLine().Trim();
                if ( (obavezno && s.Length==0) || s.Length > max)
                {
                    Console.WriteLine("Unos obavezan, maksimalno dozvoljeno {0} znakova",max);
                    continue;
                }
                return s;
            }
        }
        /// <summary>
        /// Učitava string vrijednost s konzole uz mogućnost prikaza stare vrijednosti i opcije za odustajanje.
        /// </summary>
        /// <param name="poruka">Poruka koja se prikazuje korisniku.</param>
        /// <param name="max">Maksimalna dozvoljena duljina stringa.</param>
        /// <param name="obavezno">Indikator da li je unos obavezan.</param>
        /// <param name="StaraVrijednost">Stara vrijednost koja se prikazuje korisniku.</param>
        /// <returns>Uneseni string ili stara vrijednost ako je korisnik odustao, unio 0.</returns>
        internal static string UcitajString(string poruka, int max, bool obavezno, string StaraVrijednost)
        {
            string s;
            while (true)
            {
                Console.Write(poruka + "(" + StaraVrijednost + ") 0 za odustani" + ": ");
                s = Console.ReadLine().Trim();
                if (s == "0")
                {
                    return StaraVrijednost;
                }
                if ((obavezno && s.Length == 0) || s.Length > max)
                {
                    Console.WriteLine("Unos obavezan, maksimalno dozvoljeno {0} znakova", max);
                    continue;
                }
                return s;
            }
        }
        internal static string UcitajString(string stara,string poruka, int max, bool obavezno)
        {
            string s;
            while (true)
            {
                Console.Write(poruka + " (" + stara + "): ");
                s = Console.ReadLine().Trim();
                if (s.Length == 0)
                {
                    return stara;
                }
                if ((obavezno && s.Length == 0) || s.Length > max)
                {
                    Console.WriteLine("Unos obavezan, maksimalno dozvoljeno {0} znakova", max);
                    continue;
                }
                return s;
            }
        }


        
        public static T UcitajEnumSubota<T>(string poruka) where T : struct, Enum
        {
            Console.WriteLine(poruka);

            // Ako je zadana vrijednost i korisnik pritisne Enter bez unosa, koristi zadanu vrijednost
            string unos = Console.ReadLine()?.Trim();


            // Pokušaj parsiranja unosa u enum vrijednost
            if (Enum.TryParse<T>(unos, true, out T rezultat) && Enum.IsDefined(typeof(T), rezultat))
            {
                return rezultat;
            }
            else
            {
                return (T)Enum.GetValues(typeof(T)).GetValue(0);
            }
        }

        internal static DateTime UcitajDatumVrijeme(string v, DateTime datumVrijeme)
        {
            DateTime d;
            while (true)
            {
                try
                {
                    Console.WriteLine("Format unosa je yyyy-MM-dd HH:mm, za današnji datum {0}",
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

                    Console.Write(v + ": ");
                    string unos = Console.ReadLine();
                    if (string.IsNullOrEmpty(unos))
                    {
                        return datumVrijeme; // Vrati staru vrijednost ako je unos prazan
                    }
                    d = DateTime.Parse(unos);
                    return d;
                }
                catch
                {
                    Console.WriteLine("Unos datuma i vremena nije dobar");
                }
            }
        }

        internal static int UcitajBroj(string v)
        {
            int b;
            while (true)
            {
                try
                {
                    Console.Write(v + ": ");
                    b = int.Parse(Console.ReadLine());
                    return b;
                }
                catch
                {
                    Console.WriteLine("Unos broja nije dobar");
                }
            }
        }

        internal static bool UcitajBool(string v)
        {
            while (true)
            {
                try
                {
                    Console.Write(v + ": ");
                    string unos = Console.ReadLine().Trim().ToLower();
                    if (unos == "true" || unos == "1")
                    {
                        return true;
                    }
                    else if (unos == "false" || unos == "0")
                    {
                        return false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Unos mora biti 'true' ili 'false'");
                }
            }
        }

        internal static int UcitajRasponBroja(string v1, int v2, int maxValue)
        {
            int b;
            while (true)
            {
                try
                {
                    Console.Write(v1 + ": ");
                    b = int.Parse(Console.ReadLine());
                    if (b < v2 || b > maxValue)
                    {
                        throw new Exception();
                    }
                    return b;
                }
                catch
                {
                    Console.WriteLine("Unos mora biti u rasponu {0} i {1}", v2, maxValue);
                }
            }
        }

        internal static decimal UcitajDecimal(string v, decimal cijena)
        {
            decimal b;
            while (true)
            {
                try
                {
                    Console.Write(v + ": ");
                    b = decimal.Parse(Console.ReadLine());
                    return b;
                }
                catch
                {
                    Console.WriteLine("Unos decimalnog broja nije dobar.");
                }
            }
        }
    }
}
