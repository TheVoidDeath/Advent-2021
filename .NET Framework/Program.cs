using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_2021_Framework_Edition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            Console.WriteLine($"Day {i++}");
            Console.WriteLine($"The Part1 Solution is {Day1.Part1()}");
            Console.WriteLine($"The Part2 Solution is {Day1.Part2()}");

            Console.WriteLine($"\nDay {i++}");
            Console.WriteLine($"The Part1 Solution is {Day2.Part1()}");
            Console.WriteLine($"The Part2 Solution is {Day2.Part2()}");

            Console.WriteLine($"\nDay {i++}");
            Console.WriteLine($"The Part1 Solution is {Day3.Part1()}");
            Console.WriteLine($"The Part2 Solution is {Day3.Part2()}");






            Console.ReadLine();
        }
    }



    public static class Template
    {
        public static void Part1()
        {
            string PathToInput = System.Reflection.Assembly.GetExecutingAssembly().Location;
            PathToInput = PathToInput.Remove(PathToInput.LastIndexOf(@"\")) + "\\INPUT.txt";
            Debug.WriteLine(PathToInput);

            var input = File.ReadLines(PathToInput).Select(x => "Parsing").ToArray();

        }
        public static void Part2()
        {
            string PathToInput = System.Reflection.Assembly.GetExecutingAssembly().Location;
            PathToInput = PathToInput.Remove(PathToInput.LastIndexOf(@"\")) + "\\INPUT.txt";
            Debug.WriteLine(PathToInput);

            var input = File.ReadLines(PathToInput).Select(x => "Parsing").ToArray();

        }
    }

    public static class Day1
    {

        public static uint Part1()
        {
            string PathToInput = System.Reflection.Assembly.GetExecutingAssembly().Location;
            PathToInput = PathToInput.Remove(PathToInput.LastIndexOf(@"\")) + "\\Day1_input.txt";
            Debug.WriteLine(PathToInput);

            var input = File.ReadLines(PathToInput).Select(x => int.Parse(x)).ToArray();

            var previus = input[0];
            uint result = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] > previus)
                {
                    result++;
                }
                previus = input[i];
            }
            return result;
        }

        public static uint Part2()
        {
            uint result = 0;

            string PathToInput = System.Reflection.Assembly.GetExecutingAssembly().Location;
            PathToInput = PathToInput.Remove(PathToInput.LastIndexOf(@"\")) + "\\Day1_input.txt";

            Debug.WriteLine(PathToInput);

            var input = File.ReadLines(PathToInput).Select(x => int.Parse(x)).ToArray();

            var previus = input[0] + input[1] + input[2];
            for (int i = 1; i < input.Length - 2; i++)
            {
                var current = input[i] + input[i + 1] + input[i + 2];
                if (current > previus)
                    result++;
                previus = current;
            }
            return result;
        }

    }

    public static class Day2
    {

        public static int Part1()
        {

            string PathToInput = System.Reflection.Assembly.GetExecutingAssembly().Location;
            PathToInput = PathToInput.Remove(PathToInput.LastIndexOf(@"\")) + "\\Day2_input.txt";

            Debug.WriteLine(PathToInput);

            var input = File.ReadLines(PathToInput).Select(x => ((x.Split(' ')[0]), int.Parse(x.Split(' ')[1]))).ToArray();

            int horizontal = 0, vertical = 0;

            foreach (var current in input)
            {
                switch (current.Item1)
                {
                    case "up":
                        vertical -= current.Item2;
                        break;
                    case "down":
                        vertical += current.Item2;
                        break;
                    case "forward":
                        horizontal += current.Item2;
                        break;
                }
            }

            return horizontal * vertical;

        }

        public static int Part2()
        {
            string PathToInput = System.Reflection.Assembly.GetExecutingAssembly().Location;
            PathToInput = PathToInput.Remove(PathToInput.LastIndexOf(@"\")) + "\\Day2_input.txt";

            Debug.WriteLine(PathToInput);

            var input = File.ReadLines(PathToInput).Select(x => ((x.Split(' ')[0]), int.Parse(x.Split(' ')[1]))).ToArray();

            int horizontal = 0, vertical = 0, aim = 0;

            foreach (var current in input)
            {
                switch (current.Item1)
                {
                    case "up":
                        aim -= current.Item2;
                        break;
                    case "down":
                        aim += current.Item2;
                        break;
                    case "forward":
                        vertical += aim * current.Item2;
                        horizontal += current.Item2;
                        break;
                }
            }

            return horizontal * vertical;

        }
    }

    public static class Day3
    {
        public static float Part1()
        {
            string PathToInput = System.Reflection.Assembly.GetExecutingAssembly().Location;
            PathToInput = PathToInput.Remove(PathToInput.LastIndexOf(@"\")) + "\\Day3_input.txt";
            Debug.WriteLine(PathToInput);

            var input = File.ReadLines(PathToInput).Select(x => x).ToArray();
            string gamma = "", epsilon = "";

            for (int i = 0; i < input[0].Length; i++)
            {
                uint counter = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j].ElementAt(i) == '1')
                    {
                        counter++;
                    }
                }
                if (counter > input.Length / 2)
                {
                    gamma += '1';
                    epsilon += '0';
                }
                else
                {
                    gamma += '0';
                    epsilon += '1';
                }
            }

            return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);

        }
        public static int Part2()
        {
            string PathToInput = System.Reflection.Assembly.GetExecutingAssembly().Location;
            PathToInput = PathToInput.Remove(PathToInput.LastIndexOf(@"\")) + "\\Day3_input.txt";
            Debug.WriteLine(PathToInput);

            var input = File.ReadLines(PathToInput).Select(x => x).ToArray();
            /*
            input = new string[]
    {
    "00100",
    "11110",
    "10110",
    "10111",
    "10101",
    "01111",
    "00111",
    "11100",
    "10000",
    "11001",
    "00010",
    "01010"
    };*/
            var resultsList = input.ToList();

            for (int i = 0; i < resultsList[0].Length; i++)
            {
                var counter_one = 0;
                var counter_zero = 0;
                for (int j = 0; j < resultsList.Count; j++)
                {
                    if (resultsList[j].ElementAt(i) == '1')
                    {
                        counter_one++;
                    }
                    else counter_zero++;
                }
                if (counter_one >= counter_zero)
                {
                    resultsList.RemoveAll(x => x.ElementAt(i) == '0');
                }
                else
                {
                    resultsList.RemoveAll(x => x.ElementAt(i) == '1');
                }
                if (resultsList.Count == 1)
                {
                    break;
                }
            }
            var oxygen_generator_rating = Convert.ToInt32(resultsList.FirstOrDefault(), 2);

            resultsList = input.ToList();

            for (int i = 0; i < resultsList[0].Length - 1; i++)
            {
                var counter_one = 0;
                var counter_zero = 0;
                for (int j = 0; j < resultsList.Count; j++)
                {
                    if (resultsList[j].ElementAt(i) == '1')
                    {
                        counter_one++;
                    }
                    else counter_zero++;
                }
                if (counter_zero >= counter_one)
                {
                    resultsList.RemoveAll(x => x.ElementAt(i) == '0');
                }
                else
                {
                    resultsList.RemoveAll(x => x.ElementAt(i) == '1');
                }
                if (resultsList.Count == 1)
                {
                    break;
                }
            }

            var co2rating = Convert.ToInt32(resultsList.FirstOrDefault(), 2);
            Debug.WriteLine(co2rating);
            return co2rating * oxygen_generator_rating;
        }
    }
}
