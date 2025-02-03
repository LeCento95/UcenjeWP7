using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Text;
using Ucenje.E20KonzolnaAplikacija.Model;

namespace Ucenje.E20KonzolnaAplikacija
{
    internal class Izbornik
    {

        public ObradaSmjer ObradaSmjer { get; set; }  
        public ObradaPolaznik ObradaPolaznik { get; set; } 
        public ObradaGrupa ObradaGrupa { get; set; } 

        public Izbornik() 
        {
            Pomocno.DEV = false;
            ObradaSmjer = new ObradaSmjer();
            ObradaPolaznik = new ObradaPolaznik();
            ObradaGrupa = new ObradaGrupa(this);
            UcitajPodatke();
            PozdravnaPoruka();
            PrikaziIzbornik();
        }

        private void UcitajPodatke()
        {
            string docPath =
         Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if(File.Exists(Path.Combine(docPath, "smjerovi.json")))
            {
                StreamReader file = File.OpenText(Path.Combine(docPath, "smjerovi.json"));
                ObradaSmjer.Smjerovi = JsonConvert.DeserializeObject<List<Smjer>>(file.ReadToEnd());
                file.Close();

            }

        }

        private void PrikaziIzbornik()
        {
            Console.WriteLine("Glavni izbornik");
            Console.WriteLine("1. Smjerovi");
            Console.WriteLine("2. Polaznici");
            Console.WriteLine("3. Grupe");
            Console.WriteLine("4. Izlaz iz programa");
            Console.WriteLine("5. Hello PDF");
            OdabirOpcijeIzbornika();
        }

        private void OdabirOpcijeIzbornika()
        {
            
            switch(Pomocno.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    Console.Clear();
                    ObradaSmjer.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 2:
                    Console.Clear();
                    ObradaPolaznik.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 3:
                    Console.Clear();
                    ObradaGrupa.PrikaziIzbornik();
                    PrikaziIzbornik();
                    break;
                case 4:
                    Console.WriteLine("Hvala na korištenju aplikacije, doviđenja!");
                    SpremiPodatke();
                    break;
                case 5:
                    HelloPDF();
                    PrikaziIzbornik();
                    break;
            }
        }

        private void HelloPDF()
        {
            // Create a new PDF document

            PdfDocument document = new PdfDocument();

            document.Info.Title = "Created with PDFsharp";



            // Create an empty page

            PdfPage page = document.AddPage();



            // Get an XGraphics object for drawing

            XGraphics gfx = XGraphics.FromPdfPage(page);



            // Create a font

            XFont font = new XFont("Verdana", 30);

            // Draw the text

           

            var sb = new StringBuilder();
            sb.AppendLine("Smjerovi;");
            sb.AppendLine();
            var rb = 0;
            foreach (var s in ObradaSmjer.Smjerovi)
            {
                sb.Append(++rb).Append(". ");
                sb.AppendLine(s.Naziv);
            }

            gfx.DrawString(sb.ToString(), font, XBrushes.Red, new XRect(10, 10, page.Width-10, page.Height-10),XStringFormats.Center);

            // Save the document...

            string docPath =
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);



            document.Save(Path.Combine(docPath, "HelloWorld.pdf"));

            // ...and start a viewer.

            //Process.Start(filename);
        }

        private void SpremiPodatke()
        {
            if (Pomocno.DEV)
            {
                return;
            }

            //Console.WriteLine(JsonConvert.SerializeObject(ObradaSmjer.Smjerovi));

            string docPath =
          Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "smjerovi.json"));
            outputFile.WriteLine(JsonConvert.SerializeObject(ObradaSmjer.Smjerovi));
            outputFile.Close();
        }

        private void PozdravnaPoruka()
        {
            Console.WriteLine("*********************************");
            Console.WriteLine("*** Edunova Console App v 1.0 ***");
            Console.WriteLine("*********************************");
        }
    }
}
