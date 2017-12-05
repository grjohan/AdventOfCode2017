using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    using System.Globalization;
    using System.IO;

    class Day5 : DailySolution {
        public int Part1() {
            var file = new FileInfo(@"C:\Development\projects\AdventOfCode\Day5Input.txt");
            var shit = File.ReadAllLines(file.FullName);
            var asNumbers = shit.Select(o => Convert.ToInt32(o)).ToArray();
            var nextNumber = 0;
            int numberOfSteps = 0;
            var currentPos = 0;
            while (nextNumber <= asNumbers.Length  - 1) {
                numberOfSteps++;
                var currentNumber = asNumbers[currentPos];
                nextNumber += currentNumber;
                asNumbers[currentPos]++;
                currentPos = nextNumber;
            }
            return numberOfSteps;
        }

        public int Part2() {
            var file = new FileInfo(@"C:\Development\projects\AdventOfCode\Day5Input.txt");
            var shit = File.ReadAllLines(file.FullName);
            var asNumbers = shit.Select(o => Convert.ToInt32(o)).ToArray();
            var nextNumber = 0;
            int numberOfSteps = 0;
            var currentPos = 0;
            while (nextNumber <= asNumbers.Length - 1)
            {
                numberOfSteps++;
                var currentNumber = asNumbers[currentPos];
                nextNumber += currentNumber;
                if (currentNumber >= 3) {
                    asNumbers[currentPos]--;
                }
                else {
                    asNumbers[currentPos]++;
                }

                currentPos = nextNumber;
            }
            return numberOfSteps;
        }
    }
}
