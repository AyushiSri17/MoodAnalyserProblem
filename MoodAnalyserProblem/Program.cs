using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserProblem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyser Program");
            string message ="";
            MoodAnalyser analyser = new MoodAnalyser(message);
            //Console.WriteLine(analyser.AnalyseMood());
            Console.WriteLine(analyser.CustomAnalyseMood());
            Console.ReadLine();
        }
    }
}
