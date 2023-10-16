namespace Parallel_Homework
{
    internal class Program
    {
        static int NamePath = 0;
        static void Main(string[] args)
        {
            // Task 1+ Task 2 
            //Console.WriteLine("Enter the number:");
            //int number = Convert.ToInt32(Console.ReadLine());
            //Parallel.Invoke(
            //    () => Facrotial(number),
            //    () => SumNumbers(number),
            //    () => CountNumbers(number)
            //    );

            // Task 3 
            Console.WriteLine("Enter the range of numbers:");

            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            if (a > b)

                Console.WriteLine("Try again. First nuber can't be smaller then second");
            else
                Parallel.For(a, b + 1, MultiplicationTable);

            // Task 4

            // ---------------  Записати в метод
            // ---------------  Зробити ліст з чисел

            //string text = File.ReadAllText($"C:\\Users\\dev\\source\repos\\System_Programming\\System_Program\\test.txt");

            //for (int i = 0; i < text.Length; i++)
            //{
            //    if (char.IsDigit(text[i]))
            //    {
            //        string line = text[i].ToString();

            //    }
            //}




        }




        static long Facrotial(int x)
        {
            long result = 1;
            for (int i = 1; i < x; i++)
            {
                result *= i;
            }
            Console.WriteLine($"Result: {result}");
            return result;
        }

        static void CountNumbers(int number)
        {
            var count = 0;
            count = Math.Abs(number).ToString().Length;
            Console.WriteLine($"Count numbers: {count}");

        }

        static void SumNumbers(int number)
        {
            var sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            Console.WriteLine($"Summa all numbers: {sum}");

        }

        static void MultiplicationTable(int a)
        {
            string lines = "";
            string path = $"test({NamePath++}).txt";
            for (int i = 1; i <= 10; i++)
            {
                lines += $"{a} * {i} = {a * i}\n";
                Console.WriteLine(lines);
            }
            File.WriteAllText(path, lines);



        }

    }
}