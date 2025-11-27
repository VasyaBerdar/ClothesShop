using System;

namespace LabRobOPAME3
{
    internal class Program
    {
        class Product
        {
            public string Name = "";      
            public double Price;          
            public int Quantity;          
            public string Category = "";
        }


        static void Main(string[] args)
        {
            if (!LoginSystem()) return;

            MainMenu();
        }

        private static bool LoginSystem()
        {
            string correctLogin = "admin";
            string correctPassword = "1234";

            int countTry = 3;
            string login, password;

            do
            {
                Console.Write(" Введіть свій логін: ");
                login = Console.ReadLine();

                Console.Write("Введіть свій пароль пароль: ");
                password = Console.ReadLine();

                if (login == correctLogin && password == correctPassword)
                {
                    Console.WriteLine("Успішний вхід!");
                    return true;
                }

                countTry--;
                Console.WriteLine($"Невірно! Залишилось спроб: {countTry}\n");

            } while (countTry > 0);

            Console.WriteLine("Упс! У вас закінчилися спроби. Програма завершується.");
            return false;
        }

        private static void MainMenu()
        {
            Product[] products = new Product[10];

            products[0] = new Product() { Name = "Футболка", Price = 450, Quantity = 25, Category = "Одяг" };
            products[1] = new Product() { Name = "Джинси", Price = 1200, Quantity = 18, Category = "Одяг" };
            products[2] = new Product() { Name = "Кросівки", Price = 2500, Quantity = 12, Category = "Взуття" };
            products[3] = new Product() { Name = "Куртка", Price = 3200, Quantity = 10, Category = "Одяг" };
            products[4] = new Product() { Name = "Шорти", Price = 600, Quantity = 30, Category = "Одяг" };
            products[5] = new Product() { Name = "Кофта", Price = 850, Quantity = 22, Category = "Одяг" };
            products[6] = new Product() { Name = "Бомбер", Price = 2800, Quantity = 8, Category = "Одяг" };
            products[7] = new Product() { Name = "Шкарпетки", Price = 80, Quantity = 100, Category = "Аксесуари" };
            products[8] = new Product() { Name = "Сорочка", Price = 900, Quantity = 20, Category = "Одяг" };
            products[9] = new Product() { Name = "Черевики", Price = 3400, Quantity = 14, Category = "Взуття" };


            while (true)
            {
                Console.WriteLine("ГОЛОВНЕ МЕНЮ");
                Console.WriteLine("1. Показати всі товари");
                Console.WriteLine("2. Купити товар");
                Console.WriteLine("3. Статистика");
                Console.WriteLine("4. Звіт");
                Console.WriteLine("5. Вихід");

                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Меню товарів:");
                    ShowAll(products);
                }
                else if (choice == "2")
                {
                    Buy(products);
                }
                else if (choice == "3")
                {
                    Statistics(products);
                }
                else if (choice == "4")
                {
                    Report(products);
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Вихід...");
                    return;
                }
                else
                {
                    Console.WriteLine("Невірний пункт.");
                }
            }
        }

        private static void ShowAll(Product[] products)
        {
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - {products[i].Price} грн/шт");
            }
        }

        private static void Buy(Product[] products)
        {
            ShowAll(products);

            int chooseProduct;
            while (true)
            {
                Console.Write("\nВведіть номер товару: ");
                if (int.TryParse(Console.ReadLine(), out chooseProduct) && chooseProduct >= 1 && chooseProduct <= products.Length)
                {
                    chooseProduct--;
                    break;
                }
                Console.WriteLine("Помилка. Введіть коректний номер.");
            }

            int amount;
            while (true)
            {
                Console.Write($"Введіть кількість \"{products[chooseProduct].Name}\": ");
                if (int.TryParse(Console.ReadLine(), out amount) && amount > 0)
                {
                    if (amount <= products[chooseProduct].Quantity)
                        break;
                    Console.WriteLine($"На складі доступно: {products[chooseProduct].Quantity}");
                }
                else
                    Console.WriteLine("Помилка. Введіть число більше 0.");
            }

            double total = products[chooseProduct].Price * amount;

            Random random = new Random();
            double discount = Math.Round(random.NextDouble() * 15, 2);
            double discountAmount = total * discount / 100;
            double finalSum = Math.Round(total - discountAmount, 2);

            products[chooseProduct].Quantity -= amount;

            Console.WriteLine($"\nСума без знижки: {Math.Round(total, 2)} грн");
            Console.WriteLine($"Знижка: {discount}%");
            Console.WriteLine($"До сплати: {finalSum} грн\n");

            Console.WriteLine("\nДякуємо за покупку у 'StyleRoom'!");
        }

        private static void Statistics(Product[] arr)
        {
            double sum = 0;
            double min = arr[0].Price;
            double max = arr[0].Price;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i].Price;

                if (arr[i].Price < min) min = arr[i].Price;
                if (arr[i].Price > max) max = arr[i].Price;
            }

            double avg = sum / arr.Length;

            Console.WriteLine("\nСТАТИСТИКА");
            Console.WriteLine($"Загальна сума цін: {sum} грн");
            Console.WriteLine($"Середня ціна: {avg} грн");
            Console.WriteLine($"Мінімальна цiна: {min} грн");
            Console.WriteLine($"Максимальна цiна: {max} грн");
        }

        private static void Report(Product[] products)
        {
            Console.WriteLine("ЗВІТ");
            Console.WriteLine("Список всіх товарів");
            ShowAll(products);
            Console.WriteLine("Підсумкові дані:");
            Statistics(products);
            Console.WriteLine("КІНЕЦЬ ЗВІТУ");
        }
    }
}
