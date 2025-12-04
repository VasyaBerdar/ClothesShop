using System;

namespace LabRobOPAME3
{
    internal class Program
    {
        private static List<Product> products = new List<Product>();
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
            products = new List<Product>();

            products.Add(new Product() { Name = "Футболка", Price = 450, Quantity = 25, Category = "Одяг" });
            products.Add( new Product() { Name = "Джинси", Price = 1200, Quantity = 18, Category = "Одяг" });
            products.Add( new Product() { Name = "Кросівки", Price = 2500, Quantity = 12, Category = "Взуття" });
            products.Add(new Product() { Name = "Куртка", Price = 3200, Quantity = 10, Category = "Одяг" });
            products.Add(new Product() { Name = "Шапка", Price = 200, Quantity = 10, Category = "Одяг" });


            while (true)
            {
                Console.WriteLine("ГОЛОВНЕ МЕНЮ");
                Console.WriteLine("1. Показати всі товари");
                Console.WriteLine("2. Купити товар");
                Console.WriteLine("3. Статистика");
                Console.WriteLine("4. Додати товар");
                Console.WriteLine("5. Пошук");
                Console.WriteLine("6. Видалення");
                Console.WriteLine("7. Сортування за назвою");
                Console.WriteLine("8. Сортування бульбашкою");
                Console.WriteLine("0. Вихід");

                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Меню товарів:");
                    ShowTable();
                }
                else if (choice == "2")
                {
                    Buy();
                }
                else if (choice == "3")
                {
                    FullStatistics();
                }
                else if (choice == "4")
                {
                    AddProduct();
                }
                else if (choice == "5")
                {
                   SearchProduct();
                }
                else if (choice == "6")
                {
                    DeleteProduct();
                }
                else if (choice == "7")
                {
                    SortByName();
                }
                else if (choice == "8")
                {
                    BubbleSortByPrice();
                }
                else if (choice == "0")
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

        public static void AddProduct()
        {
            Console.WriteLine("Введіть назву товару");
            string name = Console.ReadLine();

            Console.WriteLine("Задайте ціну продукту");
            string price = Console.ReadLine();

            Console.WriteLine("Введіть кількість");
            string quantity = Console.ReadLine();

            Console.WriteLine("Введіть категорію товару");
            string category = Console.ReadLine();


            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(quantity) || string.IsNullOrEmpty(category))
            {
                Console.WriteLine("Упс! Якесь з полів пусте або всі пусті");
                Console.WriteLine("Спробуйте знову");
                return;
            }

            if (double.TryParse(price,out double newPrice) && int.TryParse(quantity, out int newQuantity))
            {
                Console.WriteLine("Успішне додавання");
                products.Add(new Product {Name = name,Price = newPrice,Quantity = newQuantity,Category = category });
            }
            else
            {
                Console.WriteLine("Упс! Схоже, що ви ввели для ціни або кількості не числові значення");
                Console.WriteLine("Спробуйте знову");
                return;
            }

        }

        private static void SearchProduct()
        {
            Console.Write("\nВведіть назву для пошуку: ");
            string key = Console.ReadLine().ToLower();

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Name.ToLower().Contains(key))
                {
                    Console.WriteLine($"\nЗнайдено товар #{i + 1}: {products[i].Name}, {products[i].Price} грн, {products[i].Quantity} шт, категорія: {products[i].Category}");
                    return;
                }
            }

            Console.WriteLine("Товар не знайдено.");
        }

        private static void DeleteProduct()
        {
            ShowTable();

            Console.Write("\nВведіть номер товару для видалення: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > products.Count)
            {
                Console.WriteLine("Некоректний номер!");
                return;
            }

            products.RemoveAt(index - 1);
            Console.WriteLine("Товар видалено.");
        }

        private static void SortByName()
        {
            products.Sort((a, b) => a.Name.CompareTo(b.Name));
            Console.WriteLine("Сортування за назвою виконано.");
        }

        private static void BubbleSortByPrice()
        {
            
            for (int i = 0; i < products.Count - 1; i++)
            {
                for (int j = 0; j < products.Count - i - 1; j++)
                {
                    if (products[j].Price > products[j + 1].Price)
                    {
                        Product temp = products[j];
                        products[j] = products[j + 1];
                        products[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Бульбашкове сортування за ціною виконано.");
        }
        private static void Buy()
        {
            ShowTable();

            int chooseProduct;
            while (true)
            {
                Console.Write("\nВведіть номер товару: ");
                if (int.TryParse(Console.ReadLine(), out chooseProduct) && chooseProduct >= 1 && chooseProduct <= products.Count)
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

        private static void FullStatistics()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Немає товарів.");
                return;
            }

            double sum = 0;
            double min = products[0].Price;
            double max = products[0].Price;

            for (int i = 0; i < products.Count; i++)
            {
                sum += products[i].Price;
                if (products[i].Price < min) min = products[i].Price;
                if (products[i].Price > max) max = products[i].Price;
            }

            double avg = sum / products.Count;

            Console.WriteLine("\nСТАТИСТИКА");
            Console.WriteLine($"Кількість товарів: {products.Count}");
            Console.WriteLine($"Сума цін: {sum}");
            Console.WriteLine($"Середня ціна: {avg:F2}");
            Console.WriteLine($"Мінімальна ціна: {min}");
            Console.WriteLine($"Максимальна ціна: {max}");
        }

        private static void ShowTable()
        {
            Console.WriteLine("\n№ | Назва            | Ціна   | Кількість | Категорія");
            Console.WriteLine("---------------------------------------------------------");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1,-2}| {products[i].Name,-15} | {products[i].Price,7} | {products[i].Quantity,9} | {products[i].Category}");
            }
        }

    }
}
