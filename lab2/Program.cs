using System;
using System.Linq;

namespace lab2
{


    public class CompaniesDistributorsDBSM
    {



        public string company { get; set; } = "";
        public int products { get; set; } = 0;
        public long asv { get; set; } = 0;
        public double marketPart { get; set; } = 0;

        public static int objectCount = 0; // Статичне поле для рахунку об'єктів

        public CompaniesDistributorsDBSM() {

            // Рахуємо об'єкти
            objectCount++;

        }

        public static int GetObjectCount()
        {
            return objectCount; // Повертаємо число об'єктів
        }

       
        public CompaniesDistributorsDBSM(string company, int products, long asv, double marketPart)
        {
            this.company = company;
            this.products = products;
            this.asv = asv;
            this.marketPart = marketPart;
        }



        

        public void Print() => Console.WriteLine($"Фірма = {company}\nКількість продуктів = {products}\nРічний об'єм продажу = {asv}\nЧастина ринку = {marketPart}%");
    }


    public static class Extensions // статичний клас, який містить розширення для масиву об'єктів класу
    {

    public static CompaniesDistributorsDBSM[] SortDescending(this CompaniesDistributorsDBSM[] array) // Дане розширення виконує сортування масиву об'єктів в порядку спадання і повертає відсортований масив
        {
            return array.OrderByDescending(x => x.products).ToArray();
        }
    }

    internal class Companies//2,2 Класс списку фірм СКБД 
    {
        public List<CompaniesDistributorsDBSM> companies;//Створюємо list фірм СКБД 
        public Companies()
        {
            companies = new List<CompaniesDistributorsDBSM>(); //Ініціалізовуємо його 
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            CompaniesDistributorsDBSM Oracle = new CompaniesDistributorsDBSM("Oracle", 1, 2500000000, 31.01);
            CompaniesDistributorsDBSM IBM = new CompaniesDistributorsDBSM("IBM", 3, 2400000000, 29.25);
            CompaniesDistributorsDBSM Microsoft = new CompaniesDistributorsDBSM("Microsoft", 2, 1000000000, 13.01);
            CompaniesDistributorsDBSM Apple = new CompaniesDistributorsDBSM("Apple",23, 2400057000, 29.73);
            CompaniesDistributorsDBSM Honda = new CompaniesDistributorsDBSM("Honda", 13, 1008000000, 16.05);
            CompaniesDistributorsDBSM BMW = new CompaniesDistributorsDBSM("BMW", 20, 1009000000, 16.20);
            CompaniesDistributorsDBSM Mercedes = new CompaniesDistributorsDBSM("Mercedes-Benz", 22, 1010000500, 18.02);
            CompaniesDistributorsDBSM Toyota = new CompaniesDistributorsDBSM("Toyota", 16, 1095000000, 21.55);
            CompaniesDistributorsDBSM Samsung = new CompaniesDistributorsDBSM("Samsung", 20, 1100000000, 23.64);
            CompaniesDistributorsDBSM Poco = new CompaniesDistributorsDBSM("Poco", 10, 1000000001, 13.02);
            CompaniesDistributorsDBSM companiesDistributorsDBSM1 = new CompaniesDistributorsDBSM();

            
            
            Console.WriteLine();

            Oracle.Print();
            Console.WriteLine();
            IBM.Print();
            Console.WriteLine();
            Microsoft.Print();
            Console.WriteLine();
            Apple.Print();
            Console.WriteLine();
            Honda.Print();
            Console.WriteLine();
            BMW.Print();
            Console.WriteLine();
            Mercedes.Print();
            Console.WriteLine();
            Toyota.Print();
            Console.WriteLine();
            Samsung.Print();
            Console.WriteLine();
            Poco.Print();
            Console.WriteLine();

            CompaniesDistributorsDBSM[] companiesArray = { Oracle, IBM, Microsoft, Apple, Honda, BMW, Mercedes, Toyota, Samsung, Poco };

            
           

            Console.WriteLine("Сортування по спаданню за кількістю продуктів:");
            var sortedArray = companiesArray.SortDescending(); // Об'єкти в companiesArray сортуються за допомогою методу розширення SortDescending та результат зберігається в sortedArray
            foreach (var company in sortedArray) //У циклі кожен об'єкт у sortedArray виводиться на консоль за допомогою методу Print
            {
                company.Print();
                Console.WriteLine();
            }


            int objectCount = CompaniesDistributorsDBSM.GetObjectCount();

            int number1 = 10;
            int number2 = 5;

            if (objectCount >= number1)
            {
                Console.WriteLine($"Кількість об'єктів більше 10 або дорівнює 10, а саме: {objectCount}\n");
            }
            else if (objectCount <= number2)
            {
                Console.WriteLine($"Кількість об'єктів менше 5 або дорівнює 5, а саме: {objectCount}\n");
            }
            else if (number2 < objectCount && objectCount < number1)
            {
                Console.WriteLine($"Кількість об'єктів більше 5 та менше 10, а саме: {objectCount}\n");
            }





        }
    }
}

