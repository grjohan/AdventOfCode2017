using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    using System.IO;

    class Day6 : DailySolution
    {
        public int Part1() {
            var file = new FileInfo(@"C:\Development\projects\AdventOfCode\Day6Input.txt");
            var shit = File.ReadAllText(file.FullName);
            var numbers = shit.Split().Select(o => Convert.ToInt32(o)).ToList();
            //var numbers = new List<int>(){0,2,7,0};
            var seenConfigs = new List<string>();
            var seenString = string.Join("",numbers.Select(o => o.ToString()));
            var loops = 0;
            do {
                seenConfigs.Add(seenString);
                var highestIndex = numbers.Max();
                var index = numbers.FindIndex(o => o == highestIndex);
                var blocksLeft = numbers[index];
                numbers[index] = 0;
                while (blocksLeft > 0) {
                    index = (index + 1) % numbers.Count;
                    numbers[index]++;
                    blocksLeft--;
                }
                seenString = string.Join("", numbers.Select(o => o.ToString()));
                loops++;
            }
            while (seenConfigs.All(o => o != seenString));
            return loops;
        }

        public int Part2() {
            var file = new FileInfo(@"C:\Development\projects\AdventOfCode\Day6Input.txt");
            var shit = File.ReadAllText(file.FullName);
            var numbers = shit.Split().Select(o => Convert.ToInt32(o)).ToList();
            //var numbers = new List<int>(){0,2,7,0};
            var seenConfigs = new List<string>();
            var seenString = string.Join("", numbers.Select(o => o.ToString()));
            var loops = 0;
            do
            {
                seenConfigs.Add(seenString);
                var highestIndex = numbers.Max();
                var index = numbers.FindIndex(o => o == highestIndex);
                var blocksLeft = numbers[index];
                numbers[index] = 0;
                while (blocksLeft > 0)
                {
                    index = (index + 1) % numbers.Count;
                    numbers[index]++;
                    blocksLeft--;
                }
                seenString = string.Join("", numbers.Select(o => o.ToString()));
                loops++;
            }
            while (seenConfigs.All(o => o != seenString));
            return loops - seenConfigs.IndexOf(seenString);
        }
    }
}
