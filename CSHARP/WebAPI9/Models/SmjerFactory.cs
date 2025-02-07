namespace WebAPI9.Models
{
    public class SmjerFactory
    {

        public static List<Smjer> smjerovi;

     

        public static List<Smjer> GetSmjerovi()
        {
            if(SmjerFactory.smjerovi == null)
            {
                smjerovi = new List<Smjer>();
                for (int i = 0; i < 10; i++)
                {
                    Smjer smjer = new Smjer();
                    smjer.Sifra = i + 1;
                    smjer.Naziv = Faker.Name.First();
                    smjer.IzvodiSeOd = Faker.Identification.DateOfBirth();
                    smjer.Vaucer = Faker.Boolean.Random();
                    smjer.Cijena = (float)Faker.Finance.Coupon();
                    smjerovi.Add(smjer);
                }
                SmjerFactory.smjerovi = smjerovi;
            }

            return smjerovi;
        }

    }
}
