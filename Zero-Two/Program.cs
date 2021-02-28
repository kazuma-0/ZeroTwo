namespace Zero_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new bot();
            bot.runAsync().GetAwaiter().GetResult();
        }
    }
}