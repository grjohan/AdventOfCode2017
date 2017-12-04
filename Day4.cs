using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    using System.IO;

    public class Day4 : DailySolution
    {
        public int Part1() {
            var file = new FileInfo(@"C:\Development\projects\AdventOfCode\Day4Input.txt");
            var phrases = File.ReadAllLines(file.FullName);
            var counter = 0;
            foreach (var phrase in phrases) {
                var words = phrase.Split();
                var distinct = words.Distinct();
                if (words.Length == distinct.Count()) {
                    counter++;
                }
            }
            return counter;
        }

        public int Part2() {
            var file = new FileInfo(@"C:\Development\projects\AdventOfCode\Day4Input.txt");
            var phrases = File.ReadAllLines(file.FullName);
            var counter = 0;
            foreach (var phrase in phrases)
            {
                var words = phrase.Split();
                words = words.Select(o => String.Concat(o.OrderBy(c => c))).ToArray();
                var distinct = words.Distinct();
                if (words.Length == distinct.Count())
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
