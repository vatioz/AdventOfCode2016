using System;

namespace AdventRunner
{
    public static class Program
    {
        static void Main(string[] args)
        {   
            var runner = new AdventRunner();
            runner.ComposeAllSolutions();
            runner.ExecuteComposedSolutions();
            
            Console.WriteLine(Environment.NewLine + "The End");
            Console.ReadKey();
        }
    }
}
