using System;

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Онлайн-магазин 'StyleRoom'");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Меню товарів:");
        Console.WriteLine("1. Футболка - 450 грн/шт");
        Console.WriteLine("2. Джинси - 1200 грн/шт");
        Console.WriteLine("3. Кросівки - 2500 грн/пара");
        Console.ResetColor();

        Console.Write("Введіть кількість футболок: ");
        double tshirts = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть кількість джинсів: ");
        double jeans = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть кількість кросівок: ");
        double sneakers = Convert.ToDouble(Console.ReadLine());

        double tshirtSum = tshirts * 450;
        double jeansSum = jeans * 1200;
        double sneakersSum = sneakers * 2500;

        double total = tshirtSum + jeansSum + sneakersSum;

        Random random = new Random();
        double discount = Math.Round(random.NextDouble() * 15, 2);
        double discountAmount = total * discount / 100;
        double finalSum = Math.Round(total - discountAmount, 2);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\nЗагальна сума: {Math.Round(total, 2)} грн");
        Console.WriteLine($"Випадкова знижка: {discount}%");
        Console.WriteLine($"До сплати: {finalSum} грн");
        Console.ResetColor();

        Console.WriteLine($"\nКвадратний корінь із суми покупки: {Math.Round(Math.Sqrt(finalSum), 2)}");
        Console.WriteLine($"Сума у квадраті: {Math.Round(Math.Pow(finalSum, 2), 2)}");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nДякуємо за покупку у 'StyleRoom'! Гарного дня!");
        Console.ResetColor();
    }
}
