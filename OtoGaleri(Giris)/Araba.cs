using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri_Giris_
{
    class Araba
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public float KiralamaBedeli { get; set; }
        public string AracTipi { get; set; }
        public string Durum { get; set; } //"Galeride" ya da "Kirada"

        public List<int> KiralanmaSureleri = new List<int>();

        public int ToplamKiralanmaSuresi 
        {
            get 
            {

                //return KiralanmaSureleri.Sum(); //kisa yolu 
                
                int toplam = 0;

                foreach (int item in this.KiralanmaSureleri) 
                {

                    toplam += item;
                
                }

                return toplam;
            
            } 
        }
        public int KiralanmaSayısı
        {
            get
            {

                return this.KiralanmaSureleri.Count;

            }
        }

        public Araba(string plaka, string marka, float kiralanmaBedeli, string aracTipi)
        {

            this.Plaka = plaka;
            this.Marka = marka;
            this.AracTipi = aracTipi;
            this.KiralamaBedeli = kiralanmaBedeli;
            this.Durum = "Galeride";

        }

    }
}
