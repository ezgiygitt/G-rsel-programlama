using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int sayi1,sayi2 , sonuc;
            sonuc = 0;
            Console.WriteLine("birinci sayıyı giriniz.");
            sayi1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("ikinci sayıyı giriniz.");
            sayi2 = Convert.ToInt32(Console.ReadLine());
            while (sayi2>0)
            {
                sonuc = sonuc + sayi1;
                sayi2 -= 1;
            }
            Console.WriteLine("sonuc" + sonuc);
            Console.ReadLine();
               
        }
    }
}
