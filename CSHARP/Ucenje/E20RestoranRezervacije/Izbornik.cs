using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ucenje.E20KonzolnaAplikacija;
using Ucenje.E20RestoranRezervacije.Models;

namespace Ucenje.E20RestoranRezervacije
{
    internal class Izbornik
    {
        public ObradaGost ObradaGost { get; set; }
        public ObradaStol ObradaStol { get; set; }
        public ObradaRezervacija ObradaRezervacija { get; set; }
        public ObradaNarudzba ObradaNarudzba { get; set; }
        public ObradaJelovnik ObradaJelovnik { get; set; }

        public Izbornik()
        {
            PomocnoRR.DEV = true;
            ObradaGost = new ObradaGost();
            ObradaStol = new ObradaStol();
            ObradaRezervacija = new ObradaRezervacija();
            ObradaNarudzba = new ObradaNarudzba ();
            ObradaJelovnik = new ObradaJelovnik ();
            UcitajPodatke();
            PozdravnaPoruka();
            PrikaziIzbornik();
        }

        

       private void UcitajPodatke()
        {
            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            if (File.Exists(Path.Combine(docPath, "gosti.json")))
            {
                StreamReader file = File.OpenText(Path.Combine(docPath, "gosti.json"));
                ObradaGost.Gosti = JsonConvert.DeserializeObject < List < Gost >> (file.ReadToEnd());
                file.Close();
            }
        }

        private void PrikaziIzbornik()
        {
            Console.WriteLine("Glavni izbornik");
            Console.WriteLine("1. Gosti");
            Console.WriteLine("2. Stolovi");
            Console.WriteLine("3. Rezervacije");
            Console.WriteLine("4. Jelovnik");
            Console.WriteLine("5. Narudzbe");
            Console.WriteLine("6. Izlaz iz programa");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            switch (PomocnoRR.UcitajRasponBroja("Odaberite stavku izbornika", 1, 6))
            {
                case 1:
                    Console.Clear();
                    ObradaGost.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 2:
                    Console.Clear();
                    ObradaStol.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 3:
                    Console.Clear();
                    ObradaRezervacija.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 4:
                    Console.Clear();
                    ObradaJelovnik.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.Clear();
                    ObradaNarudzba.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 6:
                    Console.WriteLine("Hvala na korištenju aplikacije, doviđenja!");
                    SpremiPodatke();
                    break;


            }
        }

        private void SpremiPodatke()
        {
            if (PomocnoRR.DEV)
            {
                return;
            }

            //Console.WriteLine(JsonConvert.SerializeObject(ObradaStol.Stolovi));

            string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "gosti.json"));
            outputFile.WriteLine(JsonConvert.SerializeObject(ObradaGost.Gosti));
            outputFile.Close();
        }

        private void PozdravnaPoruka()
        {
            Console.WriteLine("***********************************************");
            Console.WriteLine("*** Restorant Manager Reservation App v 1.0 ***");
            Console.WriteLine("***********************************************");
        }

        
    }
}
