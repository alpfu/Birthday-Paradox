using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje2
{
    class Program   // dogum gunu problemini simule eden program. 05170000751 Alp Furkan Urkmez
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            // a sikki baslangici
            
            int[] kisiSayisi = { 50, 100, 500, 1000 };
            int[][] aylar;

            double[,] istatistik = new double[11, 4];   // cakisma sayilari tutar. son satir ortalama.
            int takvimSayisi = 1, kesisim = 0;
            for (int i = 0; i< kisiSayisi.Length; i++)    
            {
                for(int j = 0; j<10; j++)
                {
                    aylar = takvim();
                    aylar = randomDoldur(aylar, kisiSayisi[i]); 
                    kesisim = 0;
                    Console.WriteLine("takvim " +(takvimSayisi++));
                    for (int k = 0; k < aylar.Length; k++)  // takvimi dolasir
                    {
                        for (int l = 0; l < aylar[k].Length; l++)
                        {
                            Console.Write(aylar[k][l] + " ");       
                            if (aylar[k][l] != 0 && aylar[k][l] != 1)
                                kesisim += aylar[k][l]-1;
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("-------------------------------------------------------------");
                    istatistik[j, i] = kesisim;
                }
            }

            istatistik = average(istatistik);

            for(int i = 0; i<kisiSayisi.Length; i++)
            {
                Console.Write(kisiSayisi[i] + "   ");
            }
            Console.WriteLine("\n");

            for (int i = 0; i < istatistik.GetLength(0); i++)
            {
                for (int j = 0; j < istatistik.GetLength(1); j++)
                {
                    Console.Write(istatistik[i, j] + "    ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            Console.WriteLine("kisi sayilarina gore cakisma yuzdeleri :\n");
            Console.WriteLine("50 kisi: "+ oran(istatistik[10, 0], 50) +"  100 kisi: "+ oran(istatistik[10, 1], 100) + "  500 kisi: "+ oran(istatistik[10, 2], 500) + "  1000 kisi: " + oran(istatistik[10, 3], 1000) +"\n\n");
            
            // a sikki bitisi

            // b sikki baslangici

            int[] kisi = { 50, 100, 250 };
            int[] donguSayisi = new int[3];
            
            for(int i = 0; i<kisi.Length; i++)
            {
                aylar = takvim();
                donguSayisi[i] = randomB(aylar, kisi[i]);
            }
            Console.WriteLine("b sikki bilgileri: \n50   100   250 kisi icin uretilen random sayi sayilari asagidadir");
            foreach (int i in donguSayisi)
                Console.Write(i + "   ");
            // b sikki bitisi

            Console.ReadKey();
        }

        public static int[][] takvim()  // 365 gun olusturur, degerler default '0'
        {
            int[][] aylar = new int[12][];
            for(int i = 0; i<12; i++)
            {
                if (i == 0 || i == 2 || i == 4 || i == 6 || i == 7 || i == 9 || i == 11)   // 0(ocak)-2-4-6-7-9-11 
                    aylar[i] = new int[31];
                else if (i == 3 || i == 5 || i == 8 || i == 10) // 3(nisan)-5-8-10
                    aylar[i] = new int[30];
                else                        // 1 subat
                    aylar[i] = new int[28];
            }
            return aylar;
        }

        public static int[][] randomDoldur(int[][] dizi, int kisiSayisi)
        {
            Random r = new Random();
            for(int i = 0; i<kisiSayisi; )
            {
                int ay = r.Next(0, 12);
                int gun = r.Next(0, 31);
                if ((ay == 0 || ay == 2 || ay == 4 || ay == 6 || ay == 7 || ay == 9 || ay == 11) && gun < 31)
                {
                    dizi[ay][gun]++;
                    i++;
                }
                else if ((ay == 3 || ay == 5 || ay == 8 || ay == 10) && gun < 30)
                {
                    dizi[ay][gun]++;
                    i++;
                }
                else if(ay == 1 && gun < 28)
                {
                    dizi[ay][gun]++;
                    i++;
                }
            }
            return dizi;
        }

        public static double[,] average(double[,] dizi)
        {
            double sum = 0;
            for (int i = 0; i < dizi.GetLength(1); i++)
            {
                sum = 0;
                for (int j = 0; j < dizi.GetLength(0); j++)
                {
                    sum += dizi[j, i];
                }
                dizi[10, i] = sum / 10;
            }
            return dizi;
        }

        public static double oran(double sayi, int kisiSayisi)
        {
            return (sayi * 100) / kisiSayisi;
        }

        public static int randomB(int[][] dizi, int kisiSayisi)
        {
            Random r = new Random();
            int counter = 0;
            for (int i = 0; i < kisiSayisi;)
            {
                int ay = r.Next(0, 12);
                int gun = r.Next(0, 31);
                if ((ay == 0 || ay == 2 || ay == 4 || ay == 6 || ay == 7 || ay == 9 || ay == 11) && gun < 31)
                {
                    if (dizi[ay][gun] == 0)
                    {
                        dizi[ay][gun]++;
                        i++;
                    }
                    else
                        continue;
                }
                else if ((ay == 3 || ay == 5 || ay == 8 || ay == 10) && gun < 30)
                {
                    if (dizi[ay][gun] == 0)
                    {
                        dizi[ay][gun]++;
                        i++;
                    }
                    else
                        continue;
                }
                else if (ay == 1 && gun < 28)
                {
                    if (dizi[ay][gun] == 0)
                    {
                        dizi[ay][gun]++;
                        i++;
                    }
                    else
                        continue;
                }
                counter++;
            }
            return counter;
        }
    }
}