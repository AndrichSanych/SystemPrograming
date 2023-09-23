namespace _03.Interlocked_Monitor
{
    public class Statistic
    {
        public int Letters { get; set; } = 0;
        public int Digits { get; set; } = 0;
        public int Punctuation { get; set; } = 0;
        //...
    }
    public class Analyse
    {
        public Statistic statistic = new Statistic();
        public string text { get; set; }
    }
    class Program
    {
        public static Statistic Statistic = new Statistic();
        static void Main(string[] args)
        {

            Task Time1 = new Task(() => Console.WriteLine($"{DateTime.Now}"));
            Time1.Start();

            string[] files = Directory.GetFiles("C:\\Users\\HP\\Desktop\\SystemPrograming", "test.txt");
            Analyse analyse = new Analyse();
            List<Thread> threads = new List<Thread>();
            foreach (var file in files)
            {
                string text = File.ReadAllText(file);
                Thread thread = new Thread(TextAnalyse);
                threads.Add(thread);
                thread.Start(text);
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
            // show total statistic
            Console.WriteLine($"Count Punctuation : {Statistic.Punctuation}");
            Console.WriteLine($"Count Digits : {Statistic.Digits}");
            Console.WriteLine($"Count Letters : {Statistic.Letters}");
        }

        static void TextAnalyse(object text)
        {
            // text analyse how many letters, digits etc.
            string AnalyseText = (string)text;
            for (int i = 0; i < AnalyseText.Length; i++)
            {
                if (char.IsDigit(AnalyseText[i]))
                {
                    Statistic.Digits++;
                }
                else if (char.IsLetter(AnalyseText[i]))
                {
                    Statistic.Letters++;
                }
                else if (char.IsPunctuation(AnalyseText[i]))
                {
                    Statistic.Punctuation++;
                }
            }
        }
    }
}