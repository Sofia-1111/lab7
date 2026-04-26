using DataStructuresLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            MyFloatList list = new MyFloatList();

            list.Add(5.5f);
            list.Add(12.3f);
            list.Add(-2.0f);
            list.Add(8.0f);
            list.Add(-5.0f);
            list.Add(20.1f);

            Console.WriteLine("Поточний список:");
            foreach (var x in list) Console.Write(x + " ");
            Console.WriteLine("\n");

            float threshold1 = 10.5f;
            float? found = list.FindFirstGreaterThan(threshold1);
            Console.WriteLine($"1. Перший елемент > {threshold1}: {(found.HasValue ? found.Value.ToString() : "не знайдено")}");

            float sum = list.GetSumConditionedByFirstNegative();
            Console.WriteLine($"2. Сума елементів, менших за перший від'ємний: {sum}");

            MyFloatList filteredList = list.GetNewListGreaterThan(threshold1);
            Console.WriteLine($"3. Новий список (елементи > {threshold1}):");
            foreach (var x in filteredList) Console.Write(x + " ");
            Console.WriteLine("\n");

            Console.WriteLine($"Елемент за індексом 1: {list[1]}");
            list.RemoveAt(1);
            Console.WriteLine("Список після видалення елемента за індексом 1:");
            foreach (var x in list) Console.Write(x + " ");

            Console.ReadKey();
        }
    }
}
