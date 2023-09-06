using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri_Giris_
{
    class Uygulama
    {
        static Galeri OtoGaleri = new Galeri();

        static int sayac = 0;

        static public void Calistir()
        {
            OtoGaleri.SahteVeriGir();
            Menu();
            while (true)
            {
                string secim = SecimAl();
                Console.WriteLine();

                switch (secim)
                {

                    case "K":
                    case "1":
                        ArabaKirala();
                        break;
                    case "T":
                    case "2":
                        ArabaTeslimi();
                        break;
                    case "R":
                    case "3":
                        ArabalariListele("Kirada");
                        break;
                    case "M":
                    case "4":
                        ArabalariListele("Galeride");
                        break;
                    case "A":
                    case "5":
                        ArabalariListele("Hepsi");
                        break;
                    case "I":
                    case "6":
                        KiralamaIptal();
                        break;
                    case "Y":
                    case "7":
                        ArabaEkle();
                        break;
                    case "S":
                    case "8":
                        ArabaSil();
                        break;
                    case "G":
                    case "9":
                        BilgileriGoster();
                        break;
                    case "X":
                        Menu();
                        continue;
                    case "ÇIKIŞ":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                        sayac++;
                        break;

                }

            }
            
        }

        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon                     ");
            Console.WriteLine("1 - Araba Kirala(K)                  ");
            Console.WriteLine("2 - Araba Teslim Al(T)               ");
            Console.WriteLine("3 - Kiradaki Arabaları Listele(R)    ");
            Console.WriteLine("4 - Galerideki Arabaları Listele(M)  ");
            Console.WriteLine("5 - Tüm Arabaları Listele(A)         ");
            Console.WriteLine("6 - Kiralama İptali(I)               ");
            Console.WriteLine("7 - Araba Ekle(Y)                    ");
            Console.WriteLine("8 - Araba Sil(S)                     ");
            Console.WriteLine("9 - Bilgileri Göster(G)              ");
        }

        static string SecimAl()
        {
            if (sayac != 10)
            {

                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                return Console.ReadLine().ToUpper();

            }
            else 
            {

                Console.WriteLine();
                Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program Sonlandırılıyor...");
                return "ÇIKIŞ";
            
            }
        
        }

        static void ArabalariListele(string durum)
        {

            if (durum == "Kirada")
            {

                Console.WriteLine("-Kiradaki Arabalar-");

            }
            else if (durum == "Galeride")
            {

                Console.WriteLine("-Galerideki Arabalar-");

            }
            else 
            {

                Console.WriteLine("-Tüm Arabalar-");
            
            }

            Console.WriteLine();
            ArabaListele(OtoGaleri.ArabaListesiGetir(durum));
        
        }

        static void ArabaListele(List<Araba> liste)
        {

            if (liste.Count == 0)
            {

                Console.WriteLine("Listelenecek araç yok...");
                return;
            
            }

            Console.WriteLine("Plaka".PadRight(15) + "Marka".PadRight(12) + "K. Bedeli".PadRight(10) + "Araba Tipi".PadRight(14) + "K. Sayısı".PadRight(12) + "Durum");
            Console.WriteLine("".PadRight(100, '-'));

            foreach (Araba item in liste)
            {

                Console.WriteLine(item.Plaka.PadRight(15) + item.Marka.PadRight(12) + item.KiralamaBedeli.ToString().PadRight(10) + item.AracTipi.PadRight(14) + item.KiralanmaSayısı.ToString().PadRight(12) + item.Durum);

            }
        
        }

        static void ArabaKirala()
        {

            Console.WriteLine("-Araba Kirala-");
            Console.WriteLine();

            try
            {

                if (OtoGaleri.Arabalar.Count == 0)
                {

                    throw new Exception("Galeride Hiç Araba Yok...");

                }
                else if (OtoGaleri.GaleridekiAracSayisi == 0)
                {

                    throw new Exception("Tüm araçlar kirada..");

                }
                string plaka;
                while (true)
                {

                    plaka = AracGerecler.PlakaAl("Kiralanacak arabanın plakası: ");

                    if (plaka == "X")
                    {

                        return;
                    
                    }
                    // bu araç kiradamı yoksa böyle bir araç var mı bilmem lazım.
                    string durum = OtoGaleri.DurumGetir(plaka);

                    if (durum == "Kirada")
                    {

                        Console.WriteLine("Araba şu anda kirada. Farklı bir araba seçin...");

                    }
                    else if (durum == "ArabaYok")
                    {

                        Console.WriteLine("Galeriye ait bu plakada bir araç yok...");

                    }
                    else
                    {

                        break;

                    }

                }

                int sure = AracGerecler.SayiAl("Kiralanma Suresi: ");
                if (sure == 0)
                {

                    return;
                
                }

                OtoGaleri.AracKirala(plaka, sure);
                Console.WriteLine();
                Console.WriteLine(plaka.ToUpper() + " plakalı araba " + sure + " saatliğine kiralandı...");

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            
            }

        }

        static void ArabaTeslimi()
        {

            Console.WriteLine("-Araba Teslim Al-");
            Console.WriteLine();
            try
            {

                if (OtoGaleri.Arabalar.Count == 0)
                {

                    throw new Exception("Galeride Hiç Araba Yok...");

                }
                else if (OtoGaleri.GaleridekiAracSayisi == 0)
                {

                    throw new Exception("Tüm araçlar kirada..");

                }

                string plaka;

                while (true)
                {

                    plaka = AracGerecler.PlakaAl("Teslim Edilecek arabanın plakası: ");
                    if (plaka == "X")
                    {

                        return;
                    
                    }
                    string durum = OtoGaleri.DurumGetir(plaka);

                    if (durum == "Galeride")
                    {

                        Console.WriteLine("Hatalı giriş yapıldı. Araç zaten Galeride...");

                    }
                    else if (durum == "ArabaYok")
                    {

                        Console.WriteLine("Galeriye ait bu plakada bir araba yok...");

                    }
                    else 
                    {

                        break;
                    
                    }

                }

                OtoGaleri.ArabaTeslimAl(plaka);
                Console.WriteLine();
                Console.WriteLine("Araç galeride beklemeye alındı...");

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            
            }
        
        }

        static void KiralamaIptal()
        {

            Console.WriteLine("-Kiralama İptali-");
            Console.WriteLine();

            try
            {

                if (OtoGaleri.KiradakiAracSayisi == 0)
                {

                    throw new Exception("Kirada araç yok.");

                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }

            string plaka;

            while (true)
            {
                plaka = AracGerecler.PlakaAl("Kiralanması iptal edilecek arabanın plakası: ");
                if (plaka == "X")
                {

                    return;
                
                }
                string durum = OtoGaleri.DurumGetir(plaka);

                if (durum == "Galeride")
                {

                    Console.WriteLine("Hatalı giriş yapıldı. araba zaten galeride");

                }
                else if (durum == "ArabaYok")
                {

                    Console.WriteLine("Galeride bu plakaya ait bir araba yok...");

                }
                else 
                {

                    break;
                
                }

            }

            OtoGaleri.KiralamaIptal(plaka);
            Console.WriteLine();
            Console.WriteLine("İptal gerçekleştirildi...");

        }

        static void ArabaEkle()
        {

            Console.WriteLine("-Araba Ekle-");
            Console.WriteLine();

            string plaka;

            while (true)
            {

                plaka = AracGerecler.PlakaAl("Plaka: ");
                if (plaka == "X")
                {

                    return;
                
                }

                if (OtoGaleri.DurumGetir(plaka) == "Kirada" || OtoGaleri.DurumGetir(plaka) == "Galeride")
                {

                    Console.WriteLine("Aynı plakada araba mevcut. Girdiğiniz plakayı kontrol edin...");

                }
                else 
                {

                    break;
                
                }


            }


            string marka = AracGerecler.YaziAl("Marka: ");

            if (marka == "X")
            {

                return;

            }
            float kiralanmaBedeli = AracGerecler.SayiAl("Kiralanma Bedeli: ");

            if (kiralanmaBedeli == 0)
            {

                return;
            
            }

            string aracTipi = AracGerecler.AracTipiAl();

            if (aracTipi == "X")
            {

                return;

            }

            OtoGaleri.ArabaEkle(plaka, marka, kiralanmaBedeli, aracTipi);
            Console.WriteLine();
            Console.WriteLine("Araba başarılı bir şekilde eklendi.");

        }

        static void ArabaSil()
        {

            Console.WriteLine("-Araba Sil-");
            Console.WriteLine();

            string plaka;
            try
            {

                if (OtoGaleri.Arabalar.Count == 0)
                {

                    throw new Exception("Galeride Hiç Araba Yok...");

                }
                else if (OtoGaleri.GaleridekiAracSayisi == 0)
                {

                    throw new Exception("Tüm araçlar kirada..");

                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            
            }

            while (true)
            {

                plaka = AracGerecler.PlakaAl("Silmek istediğiniz arabanın plakası: ");

                if (plaka == "X")
                {

                    return;
                
                }

                string durum = OtoGaleri.DurumGetir(plaka);

                if (durum == "Kirada")
                {

                    Console.WriteLine("Kirada olan bir aracı silemezsiniz...");

                }
                else if (durum == "ArabaYok")
                {

                    Console.WriteLine("Galeride bu plakaya ait bir araba yok...");

                }
                else
                {

                    break;

                }

            }

            OtoGaleri.ArabaSil(plaka);
            Console.WriteLine();
            Console.WriteLine("Araba başarıyla silindi...");
        
        }

        static void BilgileriGoster()
        {

            Console.WriteLine("-Galeri Bilgileri-");
            Console.WriteLine("Toplam araç sayısı: " + OtoGaleri.ToplamAracSayisi);
            Console.WriteLine("Kiradaki araç sayısı: " + OtoGaleri.KiradakiAracSayisi);
            Console.WriteLine("Bekleyen araç sayısı: " + OtoGaleri.GaleridekiAracSayisi);
            Console.WriteLine("Toplam Araba Kiralama Süresi: " + OtoGaleri.ToplamAracKiralanmaSuresi);
            Console.WriteLine("Toplam Araba kiralama adedi: " + OtoGaleri.ToplamAracKiralamaAdeti);
            Console.WriteLine("Ciro: " + OtoGaleri.Ciro);
        
        }





    }
}
