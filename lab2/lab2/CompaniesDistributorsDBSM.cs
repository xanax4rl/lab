using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2;

public class CompaniesDistributorsDBSM
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

    public override string ToString() 
    { 
        return ($"Фірма = {company}\nКількість продуктів = {products}\nРічний об'єм продажу = {asv}\nЧастина ринку = {marketPart}%");// Метод, який виводить інформацію про компанію на консоль.
    }
}
