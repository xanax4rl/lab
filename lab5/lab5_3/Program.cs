using System.IO;

// Оголошуємо інтерфейс "Чоловічий Одяг" з методом "одягти Чоловіка".
interface IMensClothing
{
    void DressMan();
}

// Оголошуємо інтерфейс "Жіночий Одяг" з методом "одягти Жінку".
interface IWomensClothing
{
    void DressWoman();
}

// Абстрактний клас Одяг, що містить загальні характеристики одягу.
abstract class Clothing
{
    public string Size { get; set; }
    public decimal Price { get; set; }
    public string Color { get; set; }

    public Clothing(string size, decimal price, string color)
    {
        Size = size;
        Price = price;
        Color = color;
    }
}

// Клас Футболка, який реалізує інтерфейси "Чоловічий Одяг" та "Жіночий Одяг".
class TShirt : Clothing, IMensClothing, IWomensClothing
{
    public TShirt(string size, decimal price, string color) : base(size, price, color) { }

    public void DressMan()
    {
        Console.WriteLine($"Men's T-Shirt: Size {Size}, Color {Color}, Price ${Price}");
    }

    public void DressWoman()
    {
        Console.WriteLine($"Women's T-Shirt: Size {Size}, Color {Color}, Price ${Price}");
    }
}

// Клас Штани, який реалізує інтерфейси "Чоловічий Одяг" та "Жіночий Одяг".
class Pants : Clothing, IMensClothing, IWomensClothing
{
    public Pants(string size, decimal price, string color) : base(size, price, color) { }

    public void DressMan()
    {
        Console.WriteLine($"Men's Pants: Size {Size}, Color {Color}, Price ${Price}");
    }

    public void DressWoman()
    {
        Console.WriteLine($"Women's Pants: Size {Size}, Color {Color}, Price ${Price}");
    }
}

// Клас Спідниця, який реалізує інтерфейс "Жіночий Одяг".
class Skirt : Clothing, IWomensClothing
{
    public Skirt(string size, decimal price, string color) : base(size, price, color) { }

    public void DressWoman()
    {
        Console.WriteLine($"Women's Skirt: Size {Size}, Color {Color}, Price ${Price}");
    }
}

// Клас Краватка, який реалізує інтерфейс "Чоловічий Одяг".
class Tie : Clothing, IMensClothing
{
    public Tie(string size, decimal price, string color) : base(size, price, color) { }

    public void DressMan()
    {
        Console.WriteLine($"Men's Tie: Size {Size}, Color {Color}, Price ${Price}");
    }
}

// Клас Shop, який містить масив із розмірами одягу та має метод getDescription.
class Shop
{
    public List<string> ClothingSizes { get; } = new List<string> { "XXS", "XS", "S", "M", "L" };

    public int EuroSize { get; set; }

    public Shop(int euroSize)
    {
        EuroSize = euroSize;
    }

    public virtual string GetDescription()
    {
        return "Дорослий розмір";
    }

    public string GetSizeByEuroSize()
    {
        if (EuroSize >= 32 && EuroSize <= 40)
        {
            return ClothingSizes[EuroSize - 32];
        }
        return "Невідомий розмір";
    }
}

// Клас-спадкоємець від Shop, що перевизначає метод getDescription для XXS.
class ShopWithChildSize : Shop
{
    public ShopWithChildSize(int euroSize) : base(euroSize) { }

    public override string GetDescription()
    {
        if (GetSizeByEuroSize() == "XXS")
        {
            return "Дитячий розмір";
        }
        return "Дорослий розмір";
    }
}

// Клас Ательє, що містить методи одягнути Жінку та одягнути Чоловіка.
class Atelier
{
    public static void DressWoman(List<IWomensClothing> clothes)
    {
        Console.WriteLine("Одягаємо Жінку:");
        foreach (IWomensClothing item in clothes)
        {
            item.DressWoman();
        }
    }

    public static void DressMan(List<IMensClothing> clothes)
    {
        Console.WriteLine("Одягаємо Чоловіка:");
        foreach (IMensClothing item in clothes)
        {
            item.DressMan();
        }
    }
}


class Program
{


public static void Main()
{
    
    // Створюємо список об'єктів одягу різних типів.
    List<Clothing> clothes = new List<Clothing>
    {
            new TShirt("M", 25.99M, "Red"),
            new TShirt("S", 19.99M, "Blue"),
            new Pants("L", 49.99M, "Black"),
            new Skirt("XS", 39.99M, "Green"),
            new Tie("L", 29.99M, "Navy")
    };

    // Виводимо інформацію про всі види одягу.
    Console.WriteLine("Інформація про одяг:");
    foreach (Clothing item in clothes)
    {
        Console.WriteLine($"Одяг: {item.GetType().Name}, Розмір: {item.Size}, Ціна: ${item.Price}, Колір: {item.Color}");
    }
    
    // Створюємо магазин з розміром XXS.
    ShopWithChildSize shop = new ShopWithChildSize(32);
    
    // Виводимо опис розміру з магазину.
    Console.WriteLine($"Опис розміру з магазину: {shop.GetDescription()}");
    
    // Використовуємо ательє для одягу Жінку та Чоловіка.
    Console.WriteLine("\nВиведення одягу Жінки:");
    Atelier.DressWoman(clothes.OfType<IWomensClothing>().ToList());
    
    Console.WriteLine("\nВиведення одягу Чоловіка:");
    Atelier.DressMan(clothes.OfType<IMensClothing>().ToList());
 
    }    
    
}