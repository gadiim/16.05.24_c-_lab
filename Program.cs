using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Тема: Вступ до LINQ
//Модуль 13. Частина 2


namespace _16._05._24_c__lab
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Завдання 1:
            //Для масиву рядків реалізуйте користувальницьке сортування.
            //Сортування має працювати за кількістю символів(за зростанням
            //та спаданням). Наприклад, якщо сортування проводиться за
            //спаданням, потрібно повернути рядки з максимальною
            //довжиною в порядку зменшення довжини.

            Console.WriteLine($"Task 1\n");

            string[] string_array_1 = { "lorem", "ipsum", "para", "bellum" };
            Console.Write("string array 1:\t\t\t");
            Display(string_array_1);

            Console.Write("ascending:\t\t\t");
            var ascending = string_array_1.OrderBy(s => s.Length); 
            Display(ascending);

            Console.Write("descending:\t\t\t");
            var descending = string_array_1.OrderByDescending(s => s.Length);
            Display(descending);

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.Clear();

            //Завдання 2:
            //Для двох масивів цілих реалізуйте такі запити:
            // Отримати різницю двох масивів(елементи першого масиву,
            //яких немає у другому).
            // Отримати перетин масивів(спільні елементи для обох
            //масивів).
            // Отримати об'єднання масивів (елементи обох масивів без
            //дублікатів).
            // Отримати вміст першого масиву без повторень.

            Console.WriteLine($"Task 2\n");

            int[] int_array_1 = { 1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 8, 9, 3, 15 };
            int[] int_array_2 = {11, 12, 13, 14, 7, 1, 2, 3, 15, 16, 17, 18 };

            Console.Write("int array 1:\t\t\t");
            Display(int_array_1);
            Console.Write("int array 2:\t\t\t");
            Display(int_array_2);

            Console.Write("exceptions:\t\t\t");
            var int_exceptions = int_array_1.Except(int_array_2);
            Display(int_exceptions);

            Console.Write("intersections:\t\t\t");
            int[] int_intersections = int_array_1.Intersect(int_array_2).ToArray();
            Display(int_intersections);

            Console.Write("union:\t\t\t\t");
            var int_union = int_array_1.Union(int_array_2);
            Display(int_union);

            Console.Write("union all:\t\t\t");
            int[] int_union_all = int_array_1.Concat(int_array_2).ToArray();
            Display(int_union_all);

            Console.Write("distinct:\t\t\t");
            var int_distinct = int_array_1.Distinct();
            Display(int_distinct);

            Console.WriteLine("\nPress any key to continue . . .");
            Console.ReadKey();
            Console.Clear();

            //Завдання 3:
            //Створіть користувацький тип «Автомобіль», який зберігатиме
            //таку інформацію:
            // назва;
            // виробник;
            // рік випуску.
            //Для двох масивів автомобілів реалізуйте операції:
            // різниця масивів;
            // перетин масивів;
            // об'єднання масивів.
            //Критерій для виконання операцій – виробник.

            Console.WriteLine($"Task 3\n");

            Car[] good_cars = new Car[]
            {
            new Car("965", "ZAZ", 1960),
            new Car("968М", "ZAZ", 1979),
            new Car("M461", "Aro", 1988),
            new Car("Polonez", "FSO", 1980),
            new Car("Caro", "FSO", 1987),
            new Car("Favorit", "Skoda", 1983),
            new Car("1.3", "Wartburg", 1986)
            };
            Car[] excellent_cars = new Car[]
            {
            new Car("965", "ZAZ", 1960),
            new Car("Polonez", "FSO", 1980),
            new Car("613", "Tatra", 1989),
            new Car("601", "Trabant", 1982),
            new Car("969", "LuAZ", 1984)
            };

            Console.WriteLine("good cars:\t");
            DisplayAuto(good_cars);
            Console.WriteLine("excellent cars:\t");
            DisplayAuto(excellent_cars);

            Console.WriteLine("\nNext . . .");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine($"Task 3\n");

            Console.Write("manufacturer exceptions:\t");
            var manufacturer_exceptions = good_cars.Select(c => c.Manufacturer).Except(excellent_cars.Select(c => c.Manufacturer));
            Display(manufacturer_exceptions);

            Console.Write("manufacturer intersection:\t");
            var manufacturer_intersection = good_cars.Select(c => c.Manufacturer).Intersect(excellent_cars.Select(c => c.Manufacturer));
            Display(manufacturer_intersection);

            Console.Write("union intersection:\t\t");
            var union_intersection = good_cars.Select(c => c.Manufacturer).Union(excellent_cars.Select(c => c.Manufacturer));
            Display(union_intersection);

            Console.WriteLine();


        }
        static void Display<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
        static void DisplayAuto(Car[] collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine($"{item} ");
            }
            Console.WriteLine();
        }
    }
    class Car
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }

        public Car(string name, string manufacturer, int year)
        {
            Name = name;
            Manufacturer = manufacturer;
            Year = year;
        }

        public override string ToString()
        {
            return $"name: {Name};\tmanufacturer: {Manufacturer};\tyear: {Year}.";
        }
    }
}
