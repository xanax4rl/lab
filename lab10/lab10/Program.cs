using System;
using System.Collections.Generic;
using System.Linq;

class CharSet
{
    private HashSet<char> charSet;

    public CharSet(IEnumerable<char> chars)
    {
        charSet = new HashSet<char>(chars);
    }

    // Перенавантаження оператора видалення (-)
    public static CharSet operator -(CharSet set, char element)
    {
        set.charSet.Remove(element);
        return set;
    }

    // Перенавантаження оператора перетину (*)
    public static CharSet operator *(CharSet set1, CharSet set2)
    {
        IEnumerable<char> intersection = set1.charSet.Intersect(set2.charSet);
        return new CharSet(intersection);
    }

    // Перенавантаження оператора порівняння (<)
    public static bool operator <(CharSet set1, CharSet set2)
    {
        return set1.charSet.IsProperSubsetOf(set2.charSet);
    }

    // Перенавантаження оператора порівняння (>)
    public static bool operator >(CharSet set1, CharSet set2)
    {
        return set1.charSet.IsProperSupersetOf(set2.charSet);
    }

    public override string ToString()
    {
        return "{" + string.Join(", ", charSet) + "}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        CharSet set1 = new CharSet(new char[] { 'a', 'b', 'c', 'd' });
        CharSet set2 = new CharSet(new char[] { 'c', 'd', 'e', 'f' });

        // Використання перевантажених операторів
        CharSet resultDifference = set1 - 'b';
        CharSet resultIntersection = set1 * set2;
        bool resultSubset = set1 < set2;
        bool resultSuperset = set1 > set2;

        Console.WriteLine("Set 1: " + set1);
        Console.WriteLine("Set 2: " + set2);
        Console.WriteLine("Difference of Set 1 after removing 'b': " + resultDifference);
        Console.WriteLine("Intersection of Set 1 and Set 2: " + resultIntersection);
        Console.WriteLine("Is Set 1 a proper subset of Set 2? " + resultSubset);
        Console.WriteLine("Is Set 1 a proper superset of Set 2? " + resultSuperset);
    }
}
