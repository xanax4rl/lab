using System;

namespace lab1
{
   
    class Program
    {
        

        static void Main(string[] args) //У даному методі створюються об'єкти класу CompaniesDistributorsDBSM, які представляють різні компанії-дистриб'ютори, ініціалізуються відповідними значеннями
        {
            CompaniesDistributorsDBSM Oracle = new CompaniesDistributorsDBSM("Oracle", 1, 2500000000, 31.01);
            CompaniesDistributorsDBSM IBM = new CompaniesDistributorsDBSM("IBM", 3, 2400000000, 29.25);
            CompaniesDistributorsDBSM Microsoft = new CompaniesDistributorsDBSM("Microsoft", 2, 1000000000, 13.01);
            CompaniesDistributorsDBSM companiesDistributorsDBSM1 = new CompaniesDistributorsDBSM();


        }


    }
}
