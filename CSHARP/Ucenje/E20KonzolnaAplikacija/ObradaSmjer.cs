using Ucenje.E20KonzolnaAplikacija.Model;

namespace Ucenje.E20KonzolnaAplikacija
{
    internal class ObradaSmjer
    {

        public List<Smjer>  Smjerovi { get; set; }

        public ObradaSmjer() 
        { 
            Smjerovi = new List<Smjer>();
            if (PomocnoRR.DEV)
            {
                UcitajTestnePodatke();
            }
        }

        private void UcitajTestnePodatke()
        {
            Smjerovi.Add(new() { Naziv="Web programiranje"});
            Smjerovi.Add(new() { Naziv = "Web Dizajn" });
            Smjerovi.Add(new() { Naziv = "Serviser" });
        }

        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s smjerovima");
            Console.WriteLine("1. Pregled svih smjerova");
            Console.WriteLine("2. Pregled detalja pojedinog smjera");
            Console.WriteLine("3. Unos novog smjera");
            Console.WriteLine("4. Promjena podataka postojećeg smjera");
            Console.WriteLine("5. Brisanje smjera");
            Console.WriteLine("6. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
           switch(PomocnoRR.UcitajRasponBroja("Odaberite stavku izbornika", 1, 6))
            {
                case 1:
                    PrikaziSmjerove();
                    PrikaziIzbornik();
                    break;
                case 2:
                    PregledDetaljaPojedinogSmjera();
                    PrikaziIzbornik();
                    break;
                case 3:
                    UnosNovogSmjera();
                    PrikaziIzbornik();
                    break;
                case 4:
                    PromjeniPostojeciSmjer();
                    PrikaziIzbornik();
                    break;
                case 5:
                    ObrisiPostojeciSmjer();
                    PrikaziIzbornik();
                    break;
                case 6:                    
                    Console.Clear();
                    break;
            }
        }

        private void PregledDetaljaPojedinogSmjera()
        {
            PrikaziSmjerove();
            var s = Smjerovi[
                PomocnoRR.UcitajRasponBroja("Odaberi redni broj smjera za detalje",1,Smjerovi.Count)-1
                ];
            Console.WriteLine("--------------------");
            Console.WriteLine("Detalji smjera:");
            Console.WriteLine("Šifra: " + s.Sifra);
            Console.WriteLine("Naziv: " + s.Naziv);
            Console.WriteLine("Cijena: " + s.Cijena);
            Console.WriteLine("Izvodi se od: " + s.IzvodiSeOd.Value.ToString("dd. MM. yyyy."));
            Console.WriteLine("Vaučer: " + ((bool)s.Vaucer ? "DA" : "NE"));
            Console.WriteLine("Datum zadnje izmjene: " + s.DatumPromjene.Value.ToString("dd. MM. yyyy. HH:mm:ss"));
            Console.WriteLine("--------------------");
        }

        private void ObrisiPostojeciSmjer()
        {
            PrikaziSmjerove();
            var odabrani = Smjerovi[PomocnoRR.UcitajRasponBroja("Odaberi redni broj smjera za Brisanje",
                1, Smjerovi.Count) - 1];

            if(PomocnoRR.UcitajBool("Sigurno obrisati " +  odabrani.Naziv + "? (DA/NE)", "da"))
            {
                Smjerovi.Remove(odabrani);
            }

        }

        private void PromjeniPostojeciSmjer()
        {
            PrikaziSmjerove();
            var odabrani = Smjerovi[PomocnoRR.UcitajRasponBroja("Odaberi redni broj smjera za promjenu",
                1, Smjerovi.Count) - 1];

            if(PomocnoRR.UcitajRasponBroja("1. Mjenjaš sve\n2. Pojedinačna promjena", 1, 2) == 1)
            {
                // poziv API-u da se javi tko ovo koristi
                odabrani.Sifra = PomocnoRR.UcitajRasponBroja("Unesi šifru smjera", 1, int.MaxValue);
                odabrani.Naziv = PomocnoRR.UcitajString("Unesi naziv smjera", 50, true);
                odabrani.Cijena = PomocnoRR.UcitajDecimalniBroj("Unesi cijenu smjera", 0, 10000);
                odabrani.IzvodiSeOd = PomocnoRR.UcitajDatum("Unesi datum od kada se izvodi smjer", true);
                odabrani.Vaucer = PomocnoRR.UcitajBool("Da li je smjer vaučer (DA/NE)", "da");
                
            }
            else{
                // poziv API-u da se javi tko ovo koristi
                switch (PomocnoRR.UcitajRasponBroja("1. Šifra\n2. Naziv\n3. Trajanje\n4. Izvodi se od\n" +
                    "5. Vaučer",1,5))
                {
                    case 1:
                    odabrani.Sifra = PomocnoRR.UcitajRasponBroja("Unesi šifru smjera", 1, int.MaxValue);
                    break;
                    case 2:
                        odabrani.Naziv = PomocnoRR.UcitajString("Unesi naziv smjera", 50, true, odabrani.Naziv);
                        break;
                    // ... ostali
                    case 5:
                        odabrani.Vaucer = PomocnoRR.UcitajBool("Da li je smjer vaučer (DA/NE)", "da");
                        break;

                }
            }
            odabrani.DatumPromjene = DateTime.Now;




            // gornjih 6 linija igra istu ulogu kao na 93 - 98. Izvući u metodu

        }

        public void PrikaziSmjerove()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Smjerovi u aplikaciji");
            int rb = 0;
            foreach(var s in Smjerovi)
            {
                Console.WriteLine(++rb + ". " + s.Naziv); 
            }
            Console.WriteLine("****************************");
        }

        private void UnosNovogSmjera()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Unesite tražene podatke o smjeru");
            Smjerovi.Add(new()
            {
                Sifra = PomocnoRR.UcitajRasponBroja("Unesi šifru smjera", 1, int.MaxValue),
                Naziv = PomocnoRR.UcitajString("Unesi naziv smjera", 50, true),
                Cijena = PomocnoRR.UcitajDecimalniBroj("Unesi cijenu smjera", 0, 10000),
                IzvodiSeOd = PomocnoRR.UcitajDatum("Unesi datum od kada se izvodi smjer", true),
                Vaucer = PomocnoRR.UcitajBool("Da li je smjer vaučer (DA/NE)","da"),
                DatumPromjene = DateTime.Now
            });
        }
    }
}
