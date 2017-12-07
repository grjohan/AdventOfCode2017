using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    using System.IO;
    using System.Security.Cryptography.X509Certificates;

    class Day7 : DailySolution
    {
        public int Part1() {
            var correctTower = "";
            var file = new FileInfo(@"C:\Development\projects\AdventOfCode\Day7Input.txt");
            var lines = File.ReadAllLines(file.FullName);
            var towers = new List<tower>();
            foreach (var line in lines) {
                var name = line.Substring(0, line.IndexOf(' '));
                var weight = line.Substring(line.IndexOf('(') + 1, line.IndexOf(')') - line.IndexOf('(') - 1);
                var shitSplit = new List<string>();
                if (line.Contains('>')) {
                    var shit = line.Substring(line.IndexOf('>') + 2);
                     shitSplit = shit.Split(',').ToList();
                }

                var tower = new tower {
                                          AdjecentPrograms = shitSplit.Select(o => o.Trim()).ToList(),
                                          name = name,
                                          wieght = Convert.ToInt32(weight)
                                      };
                towers.Add(tower);
            }
            correctTower = towers.First(o => o.AdjecentPrograms.Any() && towers.All(p => !p.AdjecentPrograms.Contains(o.name))).name;
            return 2;

        }

        public int Part2()
        {
            var file = new FileInfo(@"C:\Development\projects\AdventOfCode\Day7Input.txt");
            var lines = File.ReadAllLines(file.FullName);
            var towers = new List<tower>();
            foreach (var line in lines)
            {
                var name = line.Substring(0, line.IndexOf(' '));
                var weight = line.Substring(line.IndexOf('(') + 1, line.IndexOf(')') - line.IndexOf('(') - 1);
                var shitSplit = new List<string>();
                if (line.Contains('>'))
                {
                    var shit = line.Substring(line.IndexOf('>') + 2);
                    shitSplit = shit.Split(',').ToList();
                }

                var tower = new tower
                            {
                                AdjecentPrograms = shitSplit.Select(o => o.Trim()).ToList(),
                                name = name,
                                wieght = Convert.ToInt32(weight)
                            };
                towers.Add(tower);
            }
            var correctTower = towers.First(o => o.AdjecentPrograms.Any() && towers.All(p => !p.AdjecentPrograms.Contains(o.name)));
            CalculateSubTowerWeights(correctTower, towers);
            return CorrectWeightThatIsWrong(correctTower, towers, 0);
        }


        private int CorrectWeightThatIsWrong(tower correctTower, List<tower> otherTowers, int neighboorWeight) {
            var kids = otherTowers.Where(o => correctTower.AdjecentPrograms.Contains(o.name));
            var lol = kids.GroupBy(o => o.subDiskWeight);
            var single = lol.SingleOrDefault(o => o.Count() == 1);
            if (single == null) {
                return neighboorWeight - kids.Select(o => o.subDiskWeight).Sum();
            }
            else {

                var other = kids.First(o => o.name != single.First().name);
                return this.CorrectWeightThatIsWrong(single.First(), otherTowers, other.subDiskWeight);
            }
        }

        private int CalculateSubTowerWeights(tower correctTowera, List<tower> towers) {
            if (!correctTowera.AdjecentPrograms.Any()) {
                correctTowera.subDiskWeight = correctTowera.wieght;
                return correctTowera.wieght;
            }
            var weights = towers.Where(o => correctTowera.AdjecentPrograms.Contains(o.name))
                .Select(o => this.CalculateSubTowerWeights(o, towers));
            correctTowera.subDiskWeight = weights.Sum() + correctTowera.wieght;
            return weights.Sum() + correctTowera.wieght;
        }

        class tower {
            public string name { get; set; }
            public int wieght { get; set; }
            public List<string> AdjecentPrograms { get; set; }
            public int subDiskWeight { get; set; }
        }
    }
}
