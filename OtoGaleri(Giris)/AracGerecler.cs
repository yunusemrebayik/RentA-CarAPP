using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleri_Giris_
{
    class AracGerecler
    {

        static public bool PlakaMi(string veri)
        {

            int sayi;

            //Girilen plaka min 7 maks 9 haneli olmalı. 
            //ilk iki hanesi sayı olmalı. 
            //son iki hanesi de sayı olmalı. 
            //3. hanesi kesinlikle harf olmalı. 

            if (veri.Length > 6 && veri.Length < 10
                && int.TryParse(veri.Substring(0, 2), out sayi)
                && HarfMi(veri.Substring(2, 1))
                )
            {

               
                if (veri.Length == 7 && int.TryParse(veri.Substring(3), out sayi))
                {

                    return true;

                }
                
                else if (veri.Length < 9 && HarfMi(veri.Substring(3, 1)) && int.TryParse(veri.Substring(4), out sayi))
                {

                    return true;

                }
                
                else if (HarfMi(veri.Substring(3, 2)) && int.TryParse(veri.Substring(5), out sayi))
                {

                    return true;

                }

            }

            return false;

        }

        static public string PlakaAl(string mesaj)
        {

            string plaka;
            do
            {

                try
                {

                    Console.Write(mesaj);
                    plaka = Console.ReadLine().ToUpper();

                    if (plaka == "X")
                    {

                        return "X";
                    
                    }

                    if (!PlakaMi(plaka))
                    {

                        throw new Exception("Bu şekilde plaka girişi yapamazsınız. Tekrar Deneyin.");

                    }

                    return plaka;

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                
                }

            } while (true);
        
        }




        static public int SayiAl(string mesaj) 
        {
            int sayi;
            do
            {
                try
                {

                    Console.Write(mesaj);
                    string giris = Console.ReadLine();

                    if (giris == "X")
                    {

                        return 0;
                    
                    }

                    if (int.TryParse(giris, out sayi))
                    {

                        return sayi;

                    }
                    else
                    {

                        throw new Exception("Giriş tanımlanamadı. Tekrar deneyin. ");

                    }

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);

                }

            } while (true);    
        
        
        }

        static public string YaziAl(string mesaj)
        {
            int sayi;
            do
            {

                try
                {

                    Console.Write(mesaj);
                    string giris = Console.ReadLine().ToUpper();

                    if (giris == "X")
                    {

                        return "X";
                    
                    }

                    if (int.TryParse(giris, out sayi))
                    {

                        throw new Exception("Giriş tanımlanamadı. Tekrar deneyin...");

                    }
                    else
                    {

                        return giris;

                    }

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                
                }

            } while (true);
        
        }

        static public bool HarfMi(string veri)
        {
            veri = veri.ToUpper(); 

            for (int i = 0; i < veri.Length; i++)
            {
                int kod = (int)veri[i];

                if ((kod >= 65 && kod <= 90) != true)
                {

                    return false;
                
                }
                
            }

            return true;
        
        }

        static public string AracTipiAl()
        { 
        
            while(true)
            {

                try
                {
                    Console.WriteLine("Araba Tipi: ");
                    Console.WriteLine("SUV için 1");
                    Console.WriteLine("Sedan için 3");
                    Console.WriteLine("Hatcback için 2");

                    Console.Write("Seçiminiz: ");
                    string secim = Console.ReadLine();

                    switch (secim)
                    {

                        case "1":
                            return "SUV";

                        case "2":
                            return "Hatchback";

                        case "3":
                            return "Sedan";

                        default:
                            throw new Exception("Giriş Tanımlanamadı. Tekrar Deneyin...");

                    }

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                
                }

            }

        }



    }
}
