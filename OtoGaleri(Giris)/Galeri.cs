using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri_Giris_
{
    class Galeri
    {
        public List<Araba> Arabalar = new List<Araba>();

        public int ToplamAracSayisi
        {
            get
            {
                return this.Arabalar.Count;
            }

        }

        public int KiradakiAracSayisi
        {

            get
            {

                return this.Arabalar.Where(t => t.Durum == "Kirada").ToList().Count();

            }

        }

        public int GaleridekiAracSayisi
        {
            get
            {

                return this.Arabalar.Where(t => t.Durum == "Galeride").ToList().Count();

            }
        }

        public int ToplamAracKiralanmaSuresi
        {

            get
            {

                return this.Arabalar.Sum(a => a.KiralanmaSureleri.Sum());

            }

        }

        public int ToplamAracKiralamaAdeti
        {

            get
            {

                return this.Arabalar.Sum(a => a.KiralanmaSayısı);

            }


        }

        public float Ciro
        {

            get
            {

                return this.Arabalar.Sum(a => a.ToplamKiralanmaSuresi * a.KiralamaBedeli);

            }

        }

        public string DurumGetir(string plaka)
        {
            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();

            if (a != null)
            {

                return a.Durum;
            
            }

            return "ArabaYok";
        
        }

        public void AracKirala(string plaka, int sure)
        {

            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();

            a.Durum = "Kirada";
            a.KiralanmaSureleri.Add(sure);

        }

        public void ArabaTeslimAl(string plaka)
        {

            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();

            if (a != null)
            {

                a.Durum = "Galeride";

            }
            else 
            {

                throw new Exception("Bu plakada bir araç yok...");
            
            }

        }

        public void KiralamaIptal(string plaka)
        {

            Araba a = this.Arabalar.Where(a => a.Plaka == plaka.ToUpper()).FirstOrDefault();

            if (a != null)
            {

                a.Durum = "Galeride";
                a.KiralanmaSureleri.RemoveAt(a.KiralanmaSureleri.Count - 1);
            
            }

        }

        public void ArabaEkle(string plaka, string marka, float kiralamaBedeli, string aracTipi)
        {

            //parametreden gelen bu bilgilerle yeni bir araba objesi yaratıyoruz. 

            Araba a = new Araba(plaka, marka, kiralamaBedeli, aracTipi);

            //sonra bu arabayı galerideki arabalar listesine ekliyoruz. 

            this.Arabalar.Add(a);

        }

        public void ArabaSil(string plaka)
        {

            Araba a = this.Arabalar.Where(t => t.Plaka == plaka).FirstOrDefault();

            if (a != null && a.Durum == "Galeride")
            {

                this.Arabalar.Remove(a);
            
            }
        
        }

        public List<Araba> ArabaListesiGetir(string durum)
        {

            List<Araba> liste = this.Arabalar;
            if (durum == "Kirada" || durum == "Galeride")
            {

                liste = this.Arabalar.Where(a => a.Durum == durum).ToList();
            
            }
            return liste;
        
        }

        public void SahteVeriGir()
        {

            ArabaEkle("34ZS2986", "Renault", 100, "Hatchback");
            ArabaEkle("41ACC256", "Opel", 70, "SUV");
            ArabaEkle("54KK588", "Fiat", 150, "Sedan");
        
        }

    }
}
