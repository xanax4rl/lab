using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
   
    class Program
    {
        public class CompaniesDistributorsDBSM //Цей клас представляє собою модель даних для зберігання інформації про компанії-дистриб'ютори
        {
            public string company { get; set; } = ""; //Рядок, який зберігає ім'я компанії
            public int products { get; set; } = 0; //Ціле число, яке представляє кількість продуктів компанії
            public long asv { get; set; } = 0; //Довге ціле число, яке представляє річний обсяг продажів компанії
            public double marketPart { get; set; } = 0; //Десяткове число, яке представляє частку ринку, зайняту компанією у відсотках


            public CompaniesDistributorsDBSM() { } //Конструктор за замовчуванням

            public CompaniesDistributorsDBSM(string company, int products, long asv, double marketPart) // Конструктор, який дозволяє встановити значення всіх полів при створенні об'єкта класу на основі переданих аргументів
            {
                this.company = company;
                this.products = products;
                this.asv = asv;
                this.marketPart = marketPart;
            }



            public void Print() => Console.WriteLine($"Фірма = {company}\nКількість продуктів = {products}\nРічний об'єм продажу = {asv}\nЧастина ринку = {marketPart}%");
            // Метод, який виводить інформацію про компанію на консоль.
        }

        static void Main(string[] args) //У даному методі створюються об'єкти класу CompaniesDistributorsDBSM, які представляють різні компанії-дистриб'ютори, ініціалізуються відповідними значеннями
        {
            CompaniesDistributorsDBSM Oracle = new CompaniesDistributorsDBSM("Oracle", 1, 2500000000, 31.01);
            CompaniesDistributorsDBSM IBM = new CompaniesDistributorsDBSM("IBM", 3, 2400000000, 29.25);
            CompaniesDistributorsDBSM Microsoft = new CompaniesDistributorsDBSM("Microsoft", 2, 1000000000, 13.01);
            CompaniesDistributorsDBSM companiesDistributorsDBSM1 = new CompaniesDistributorsDBSM();

            Oracle.Print();
            Console.WriteLine();
            IBM.Print();
            Console.WriteLine();
            Microsoft.Print();
            Console.WriteLine();

        }


    }
}
