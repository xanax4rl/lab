using lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace lab2
{
    public static class Extensions //1 статичний клас, який містить розширення для масиву об'єктів класу
    {

        public static CompaniesDistributorsDBSM[] SortDescending(this CompaniesDistributorsDBSM[] array) // Дане розширення виконує сортування масиву об'єктів в порядку спадання і повертає відсортований масив
        {
            return array.OrderByDescending(x => x.products).ToArray();
        }
    }

    public static class Companies//2,1 Класс списку фірм СКБД 
    {
        public static List<CompaniesDistributorsDBSM> companies = new List<CompaniesDistributorsDBSM>(); //Створюємо list фірм СКБД 

        //2,4.1 Метод для визначення фірм у яких кількість продуктів меньше заданого числа  
        public static void CompanyProductsLowerThan(int x) 
        { 
           var ComlowerthenCollection = companies.Where(z => z.products < x);

            Console.WriteLine($"Company products lower than: {x}");
            foreach (var i in ComlowerthenCollection)
            {
                Console.WriteLine(i);
            }
            
        }
        //2,4.2 Найменше продуктів 
        public static void CompanyMinProducts()
        {
           var MinProduct = companies.MinBy(x => x.products);
            Console.WriteLine($"Company min product:\n{MinProduct}\n");
        }

        //2,5 Кількість компаній менших за значення 
        public static void CompanyCountLowerThan(int x)
        {
            if (companies.Count() > x) Console.WriteLine("Компаній більше заданого значення");
            else Console.WriteLine("Компаній менше або рівно заданому значенню");
        }

        

        public class Program
        {



            static void Main() //У даному методі створюються об'єкти класу CompaniesDistributorsDBSM, які представляють різні компанії-дистриб'ютори, ініціалізуються відповідними значеннями
            {
                CompaniesDistributorsDBSM Oracle = new CompaniesDistributorsDBSM("Oracle", 1, 2500000000, 31.01);
                CompaniesDistributorsDBSM IBM = new CompaniesDistributorsDBSM("IBM", 3, 2400000000, 29.25);
                CompaniesDistributorsDBSM Microsoft = new CompaniesDistributorsDBSM("Microsoft", 2, 1000000000, 13.01);
                CompaniesDistributorsDBSM KPNU = new CompaniesDistributorsDBSM("KPNU",1000, 950000000, 15.25);
                CompaniesDistributorsDBSM Apple = new CompaniesDistributorsDBSM("Apple", 4, 2200000000, 28.50);
                CompaniesDistributorsDBSM Google = new CompaniesDistributorsDBSM("Google", 5, 1800000000, 23.75);
                CompaniesDistributorsDBSM Amazon = new CompaniesDistributorsDBSM("Amazon", 6, 1500000000, 20.50);
                CompaniesDistributorsDBSM Facebook = new CompaniesDistributorsDBSM("Facebook", 7, 900000000, 12.25);
                CompaniesDistributorsDBSM Tesla = new CompaniesDistributorsDBSM("Tesla", 8, 800000000, 11.50);
                CompaniesDistributorsDBSM Netflix = new CompaniesDistributorsDBSM("Netflix", 9, 700000000, 10.75);


                companies.Add(Oracle);
                companies.Add(IBM);
                companies.Add(Microsoft);
                companies.Add(KPNU);
                companies.Add(Apple);
                companies.Add(Google);
                companies.Add(Amazon);
                companies.Add(Facebook);
                companies.Add(Tesla);
                companies.Add(Netflix);

                foreach (var item in companies)
                {
                    Console.WriteLine($"{item}\n");

                }

                CompaniesDistributorsDBSM[] companiesArray = { Oracle, IBM, Microsoft, KPNU, Apple, Amazon, Facebook, Tesla, Netflix };

                Console.WriteLine("Сортування по спаданню за кількістю продуктів:");
                var sortedArray = companiesArray.SortDescending(); // Об'єкти в companiesArray сортуються за допомогою методу розширення SortDescending та результат зберігається в sortedArray
                foreach (var company in sortedArray) //У циклі кожен об'єкт у sortedArray виводиться на консоль за допомогою методу Print
                {
                    Console.WriteLine(company);
                    Console.WriteLine();
                }

                
                


                CompanyCountLowerThan(5);
                CompanyMinProducts();
                CompanyProductsLowerThan(5);
            }
        }

    }    
    
}