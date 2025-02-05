using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ucenje
{
    internal class GeneratorLozinki
    {
        public static void Run()
        {
            int lenght;
            bool includeUppercase;
            bool includeLowercase;
            bool includeNumbers;
            bool includeSpecialCharacters;
            bool startWithNumber;
            bool startWithSpecialCharacter;
            bool endWithNumber;
            bool endWithSpecialCharacter;
            bool allowRepeats;
            int numberOfPasswords;
            string upperCase;
            string lowerCase;
            string numbers;
            string specialCharacters;
            string allowedCharacters;
            Random random;

            Console.WriteLine("Unesite dužinu lozinke: ");
            while (!int.TryParse(Console.ReadLine(), out lenght) || lenght < 1) // Unos dužine lozinke
            {
                Console.WriteLine("Pogrešan unos. Molimo unesite cijeli broj veći od 0:");
            }

            while (true)
            {
                Console.WriteLine("Uključiti velika slova? (DA/NE)"); // Unos uključivanja velikih slova
                string input = Console.ReadLine()?.ToLower();
                if (input == "da")
                {
                    includeUppercase = true;
                    break;
                }
                else if (input == "ne")
                {
                    includeUppercase = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Molimo unesite 'DA' ili 'NE'. ");
                }
            }

            while (true)
            {
                Console.WriteLine("Uključiti mala slova? (DA/NE)"); // Unos uključivanja malih slova
                string input = Console.ReadLine()?.ToLower();
                if (input == "da")
                {
                    includeLowercase = true;
                    break;
                }
                else if (input == "ne")
                {
                    includeLowercase = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Molimo unesite 'DA' ili 'NE'. ");
                }
            }

            while (true)
            {
                Console.WriteLine("Uključiti brojeve? (DA/NE)"); // Unos uključivanja brojeva
                string input = Console.ReadLine()?.ToLower();
                if (input == "da")
                {
                    includeNumbers = true;
                    break;
                }
                else if (input == "ne")
                {
                    includeNumbers = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Molimo unesite 'DA' ili 'NE'. ");
                }
            }

            while (true)
            {
                Console.WriteLine("Uključiti interpunkcijske znakove? (DA/NE)"); // Unos uključivanja interpunkcijskih znakova
                string input = Console.ReadLine()?.ToLower();
                if (input == "da")
                {
                    includeSpecialCharacters = true;
                    break;
                }
                else if (input == "ne")
                {
                    includeSpecialCharacters = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Molimo unesite 'DA' ili 'NE'. ");
                }
            }

            if (!includeUppercase && !includeLowercase && !includeNumbers && !includeSpecialCharacters) // Provjera da li je odabran barem jedan skup znakova
            { 
                Console.WriteLine("Morate odabrati barem jedan skup znakova."); 
                return;
            }

            while (true)
            {
                Console.WriteLine("Lozinka počinje s brojem? (DA/NE)"); // Unos da li lozinka počinje s brojem
                string input = Console.ReadLine()?.ToLower();
                if (input == "da")
                {
                    startWithNumber = true;
                    break;
                }
                else if (input == "ne")
                {
                    startWithNumber = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Molimo unesite 'DA' ili 'NE'. ");
                }
            }

            while (true)
            {
                Console.WriteLine("Lozinka počinje s interpunkcijskim znakom? (DA/NE)"); // Unos da li lozinka počinje s interpunkcijskim znakom
                string input = Console.ReadLine()?.ToLower();
                if (input == "da")
                {
                    startWithSpecialCharacter = true;
                    break;
                }
                else if (input == "ne")
                {
                    startWithSpecialCharacter = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Molimo unesite 'DA' ili 'NE'. "); 
                }
            }

            if (startWithNumber && startWithSpecialCharacter)
            {
                Console.WriteLine("Lozinka ne može počieti sa brojem, i sa interpunkcijskim znakom istovremeno."); 
                return;
            }

            while (true)
            {
                Console.WriteLine("Lozinka završava s brojem? (DA/NE)"); // Unos da li lozinka završava s brojem
                string input = Console.ReadLine()?.ToLower();
                if (input == "da")
                {
                    endWithNumber = true;
                    break;
                }
                else if (input == "ne")
                {
                    endWithNumber = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Molimo unesite 'DA' ili 'NE'. ");
                }
            }

            while (true)
            {
                Console.WriteLine("Lozinka završava s interpunkcijskim znakom? (DA/NE)"); // Unos da li lozinka završava s interpunkcijskim znakom
                string input = Console.ReadLine()?.ToLower();
                if (input == "da")
                {
                    endWithSpecialCharacter = true;
                    break;
                }
                else if (input == "ne")
                {
                    endWithSpecialCharacter = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Molimo unesite 'DA' ili 'NE'. ");
                }
            }

            if (endWithNumber && endWithSpecialCharacter)
            {
                Console.WriteLine("Lozinka ne može završiti sa brojem, i sa interpunkcijskim znakom istovremeno.");
                return;
            }

            while (true)
            {
                Console.WriteLine("Dozvoliti ponavljanje znakova? (DA/NE)"); // Unos dozvole ponavljanja znakova
                string input = Console.ReadLine()?.ToLower();
                if (input == "da")
                {
                    allowRepeats = true;
                    break;
                }
                else if (input == "ne")
                {
                    allowRepeats = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Pogrešan unos. Molimo unesite 'DA' ili 'NE'. ");
                }
            }

            Console.WriteLine("Unesite broj lozinki koje želite generirati: ");
            while (!int.TryParse(Console.ReadLine(), out numberOfPasswords) || numberOfPasswords < 1)
            {
                Console.WriteLine("Pogrešan unos. Molimo unesite cijeli broj veći od 0:");
            }

            upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            lowerCase = "abcdefghijklmnopqrstuvwxyz";
            numbers = "0123456789";
            specialCharacters = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";

            allowedCharacters = "";
            if (includeUppercase)
            {
                allowedCharacters += upperCase;
            }
            if (includeLowercase)
            {
                allowedCharacters += lowerCase;
            }
            if (includeNumbers)
            {
                allowedCharacters += numbers;
            }
            if (includeSpecialCharacters)
            {
                allowedCharacters += specialCharacters;
            }

            random = new Random();

            for (int i = 0; i < numberOfPasswords; i++)
            {
                List<char> password = new List<char>(); // Lista znakova za lozinku

                if (startWithNumber)
                {
                    password.Add(numbers[random.Next(numbers.Length)]); 
                }
                else if (startWithSpecialCharacter)
                {
                    password.Add(specialCharacters[random.Next(specialCharacters.Length)]);
                }
                else
                {
                    password.Add(allowedCharacters[random.Next(allowedCharacters.Length)]);
                }
                if (endWithNumber)
                {
                    password.Add(numbers[random.Next(numbers.Length)]);
                }
                else if (endWithSpecialCharacter)
                {
                    password.Add(specialCharacters[random.Next(specialCharacters.Length)]); 
                }

                int remaining = lenght - password.Count;    // Preostali broj znakova za lozinku
                if (remaining < 0)
                {
                    Console.WriteLine("Nije moguće generirati lozinku s navedenim ograničenjima. ");
                    continue;
                }

                for (int j = 0; j < remaining; j++) // Generiranje preostalih znakova
                {
                    char nextCharacter;
                    do
                    {
                        nextCharacter = allowedCharacters[random.Next(allowedCharacters.Length)]; // Generiranje nasumičnog znaka iz dozvoljenih znakova
                    } while (!allowRepeats && password.Contains(nextCharacter)); // Ponovno generiranje znaka ako ponavljanje nije dozvoljeno

                    password.Insert(random.Next(password.Count), nextCharacter); // Dodavanje znaka na nasumično mjesto u listi
                }

                string generatedPassword = new string(password.ToArray()); // Kreiranje stringa od liste znakova
                Console.WriteLine($"Generirana lozinka {i + 1} : {generatedPassword}");

            }
        }
    }
}
