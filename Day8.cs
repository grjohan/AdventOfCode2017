using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6 {
    using System.IO;

    class Day8 : DailySolution {
        public int Part1() {
            var file = new FileInfo(@"C:\Development\projects\AdventOfCode\Day8Input.txt");
            var phrases = File.ReadAllLines(file.FullName);
            var instructions = new List<shit>();
            foreach (var line in phrases) {
                var shit = line.Split();
               var lol = new shit {
                             RegisterToMod = shit[0],
                             op = shit[1],
                             by = Convert.ToInt32(shit[2]),
                             exp1 = shit[4],
                             exp2 = shit[5],
                             exp3 = shit[6]
                         };
                instructions.Add(lol);
            }
            var registers = instructions.Select(o => o.RegisterToMod).Distinct().ToList();
            var dictionary = new Dictionary<string, int>();
            foreach (var register in registers) {
                dictionary.Add(register, 0);
            }
            foreach (var instruction in instructions) {
                var regValueToCheckAGainst = dictionary[instruction.exp1];
                var valueToCheckWith =  Convert.ToInt32(instruction.exp3);
                bool answer = false;
                if (instruction.exp2 == ">") {
                    answer = regValueToCheckAGainst > valueToCheckWith;
                } else if (instruction.exp2 == "<") {
                    answer = regValueToCheckAGainst < valueToCheckWith;
                }
                else if (instruction.exp2 == ">=")
                {
                    answer = regValueToCheckAGainst >= valueToCheckWith;
                }
                else if (instruction.exp2 == "<=")
                {
                    answer = regValueToCheckAGainst <= valueToCheckWith;
                }
                else if (instruction.exp2 == "!=")
                {                    answer = regValueToCheckAGainst != valueToCheckWith;

                }
                else if (instruction.exp2 == "==")
                {
                    answer = regValueToCheckAGainst == valueToCheckWith;
                }
                else {
                    var two = "wtf";
                }
                if (answer) {
                    if (instruction.op == "inc") {
                        dictionary[instruction.RegisterToMod] += instruction.by;
                    }
                    else {
                        dictionary[instruction.RegisterToMod] -= instruction.by;
                    }
                }
            }
            return dictionary.Values.Max();
        }

        public int Part2() {
            var file = new FileInfo(@"C:\Development\projects\AdventOfCode\Day8Input.txt");
            var phrases = File.ReadAllLines(file.FullName);
            var instructions = new List<shit>();
            foreach (var line in phrases)
            {
                var shit = line.Split();
                var lol = new shit
                          {
                              RegisterToMod = shit[0],
                              op = shit[1],
                              by = Convert.ToInt32(shit[2]),
                              exp1 = shit[4],
                              exp2 = shit[5],
                              exp3 = shit[6]
                          };
                instructions.Add(lol);
            }
            int max = 0;
            var registers = instructions.Select(o => o.RegisterToMod).Distinct().ToList();
            var dictionary = new Dictionary<string, int>();
            foreach (var register in registers)
            {
                dictionary.Add(register, 0);
            }
            foreach (var instruction in instructions)
            {
                var lol = dictionary.Values.Max();
                max = max < lol ? lol : max;
                var regValueToCheckAGainst = dictionary[instruction.exp1];
                var valueToCheckWith = Convert.ToInt32(instruction.exp3);
                bool answer = false;
                if (instruction.exp2 == ">")
                {
                    answer = regValueToCheckAGainst > valueToCheckWith;
                }
                else if (instruction.exp2 == "<")
                {
                    answer = regValueToCheckAGainst < valueToCheckWith;
                }
                else if (instruction.exp2 == ">=")
                {
                    answer = regValueToCheckAGainst >= valueToCheckWith;
                }
                else if (instruction.exp2 == "<=")
                {
                    answer = regValueToCheckAGainst <= valueToCheckWith;
                }
                else if (instruction.exp2 == "!=")
                {
                    answer = regValueToCheckAGainst != valueToCheckWith;

                }
                else if (instruction.exp2 == "==")
                {
                    answer = regValueToCheckAGainst == valueToCheckWith;
                }
                else
                {
                    var two = "wtf";
                }
                if (answer)
                {
                    if (instruction.op == "inc")
                    {
                        dictionary[instruction.RegisterToMod] += instruction.by;
                    }
                    else
                    {
                        dictionary[instruction.RegisterToMod] -= instruction.by;
                    }
                }
            }
            return max;
        }

        class shit {
            public string RegisterToMod { get; set; }
            public string op { get; set; }
            public int by { get; set; }
            public string exp1 { get; set; }
            public string exp2 { get; set; }
            public string exp3 { get; set; }
        }
    }
}
