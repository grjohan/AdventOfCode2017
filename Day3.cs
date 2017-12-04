using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public class Day3 : DailySolution
    {
        public int Part1() {
            var numberOfTime = 0;
            var currentNumber = 289326;
            while (currentNumber > 1) {
                numberOfTime++;
                currentNumber = MoveOneTowardsCenter(currentNumber);
 }
            return numberOfTime;
        }

        public int Part2() {
            var values = new List<int>();
            var input = 289326;
            var currentNumber = 2;
            var latestNumber = 1;
            values.Add(1);
            while (latestNumber < input) {
                latestNumber = GetNextNumber(values, currentNumber);
                values.Add(latestNumber);
                currentNumber++;
            }
            return latestNumber;
        }

        private int GetNextNumber(List<int> allnumbersSoFar, int currentNumber) {
            var numberList = Enumerable.Range(1, 100000);
            var onlyOdds = numberList.Where(o => o % 2 != 0);
            var squareSize = onlyOdds.First(i => i * i >= currentNumber);
            var squareNumber = onlyOdds.ToList().FindIndex(o => o == squareSize) + 1;
            if (squareNumber == 1) {
                return 1;
            }
            var innerSquareSize = squareSize - 2;
            var lowestNumberInSquare = Math.Pow(innerSquareSize, 2) + 1;
            var amountOfNumbersInInnerSquare = GetNumberOfNumbersInOuterRing(innerSquareSize);
            var amountOfNumbersInSquare = GetNumberOfNumbersInOuterRing(squareSize);
            var firstCorner = lowestNumberInSquare + innerSquareSize;
            var seconddCorner = firstCorner + squareSize - 1;
            var thirdCorner = seconddCorner + squareSize - 1;
            var fourthCorner = thirdCorner + squareSize - 1;
            var corners = new List<int> { (int)firstCorner, (int)seconddCorner, (int)thirdCorner, (int)fourthCorner };
            // The previous one is always going to be our neighbour
            var acc = allnumbersSoFar.Last();
            if (currentNumber == lowestNumberInSquare + amountOfNumbersInSquare - 2)
            {
                acc += allnumbersSoFar[(int)lowestNumberInSquare - 1];
            }
            else if (currentNumber == lowestNumberInSquare + amountOfNumbersInSquare - 1)
            {
                acc += allnumbersSoFar[(int)lowestNumberInSquare - 1];
            }
            if (currentNumber != lowestNumberInSquare) {
                if (corners.All(o => (int) o != currentNumber)) {
                    if (squareNumber == 2) {
                        acc += 1;
                    }
                    else if (currentNumber < firstCorner)
                    {
                        acc += allnumbersSoFar[(currentNumber - 1) - amountOfNumbersInInnerSquare -1];
                    }
                    else if (currentNumber < seconddCorner)
                    {
                        acc += allnumbersSoFar[(currentNumber - 1) - amountOfNumbersInInnerSquare -3];
                    }
                    else if (currentNumber < thirdCorner)
                    {
                        acc += allnumbersSoFar[(currentNumber - 1) - amountOfNumbersInInnerSquare -5];
                    }
                    else if (currentNumber < fourthCorner)
                    {
                        acc += allnumbersSoFar[(currentNumber - 1) -amountOfNumbersInInnerSquare -7];
                    }
                }
                else {
                    if (squareNumber == 2) {
                        acc += 1;
                    }
                    else if (currentNumber == firstCorner)
                    {
                        acc += allnumbersSoFar[(currentNumber - 1) - amountOfNumbersInInnerSquare - 2];
                    }
                    else if (currentNumber == seconddCorner)
                    {
                        acc += allnumbersSoFar[(currentNumber - 1) - amountOfNumbersInInnerSquare - 4];
                    }
                    else if (currentNumber == thirdCorner)
                    {
                        acc += allnumbersSoFar[(currentNumber - 1) - amountOfNumbersInInnerSquare - 6];
                    }
                    else if (currentNumber == fourthCorner)
                    {
                        acc += allnumbersSoFar[(currentNumber - 1) - amountOfNumbersInInnerSquare - 8];
                    }
                    return acc;
                }
                }
            // if we are -1 from any of the corners we do not have this corner. so check for that!
            if (corners.All(o => o != currentNumber+1) && squareNumber != 2) {
                if (currentNumber < firstCorner)
                {
                    acc += allnumbersSoFar[(currentNumber - 1) - amountOfNumbersInInnerSquare];
                }
                else if (currentNumber < seconddCorner)
                {
                    acc += allnumbersSoFar[(currentNumber - 1) - (amountOfNumbersInInnerSquare + 2)];
                }
                else if (currentNumber < thirdCorner)
                {
                    acc += allnumbersSoFar[(currentNumber - 1) - (amountOfNumbersInInnerSquare + 4)];
                }
                else if (currentNumber < fourthCorner)
                {
                    acc += allnumbersSoFar[(currentNumber - 1) - (amountOfNumbersInInnerSquare + 6)];
                }
            }

            // if we are -1 from any of the corners we do not have this corner. so check for that!
            if ((corners.Any(o => o == currentNumber - 1) && currentNumber != lowestNumberInSquare) || (lowestNumberInSquare + 1 == currentNumber && squareNumber > 2))
            {
                acc += allnumbersSoFar[(currentNumber - 1) - 2];
            }
            else if (squareNumber > 2 && currentNumber != lowestNumberInSquare) {
                if (currentNumber < firstCorner)
                {
                    acc += allnumbersSoFar[(currentNumber - 1) - amountOfNumbersInInnerSquare - 2];
                }
                else if (currentNumber < seconddCorner)
                {
                    acc += allnumbersSoFar[(currentNumber - 1) - amountOfNumbersInInnerSquare -4];
                }
                else if (currentNumber < thirdCorner)
                {
                    acc += allnumbersSoFar[(currentNumber - 1) - amountOfNumbersInInnerSquare -6];
                }
                else if (currentNumber < fourthCorner)
                {
                    acc += allnumbersSoFar[(currentNumber - 1) - amountOfNumbersInInnerSquare -8];
                }
            }


            return acc;
        }

        private int MoveOneTowardsCenter(int currentNumber) {
            var numberList = Enumerable.Range(1, 100000);
            var onlyOdds = numberList.Where(o => o % 2 != 0);
            var squareSize = onlyOdds.First(i => i * i >= currentNumber);
            var squareNumber = onlyOdds.ToList().FindIndex(o => o == squareSize) + 1;
            if (squareNumber == 1) {
                return 1;
            }
            var innerSquareSize = squareSize - 2;
            var lowestNumberInSquare = Math.Pow(innerSquareSize, 2) + 1;
            var amountOfNumbersInInnerSquare = GetNumberOfNumbersInOuterRing(innerSquareSize);
            var firstCorner = lowestNumberInSquare + innerSquareSize;
            var seconddCorner = firstCorner + squareSize - 1;
            var thirdCorner = seconddCorner + squareSize - 1;
            var fourthCorner = thirdCorner + squareSize - 1;
            // Calculate where the fuck you are on your thingy
            if (currentNumber < firstCorner) {
                // move one to the left
                return currentNumber - (currentNumber == lowestNumberInSquare ? 1 :  amountOfNumbersInInnerSquare + 1);
            }
            if (currentNumber < seconddCorner) {
                // Move one down
                return currentNumber - (currentNumber == firstCorner ? 1 : amountOfNumbersInInnerSquare + 3);
            }
            if (currentNumber < thirdCorner) {
                // move one left
                return currentNumber - (currentNumber == seconddCorner ? 1 : amountOfNumbersInInnerSquare + 5);
            }
            if (currentNumber < fourthCorner) {
                return currentNumber - (currentNumber == thirdCorner ? 1 : amountOfNumbersInInnerSquare + 7);
            }
            // The only thing left is that we are at the highest number, so lets just move to the lowest which is one up...
            return (int)lowestNumberInSquare;
        }

        private int GetNumberOfNumbersInOuterRing(int ringSize) {
            var acc = 0;
            var shit = Enumerable.Range(1, ringSize * 2).Where(o => o % 2 != 0);
            foreach (var i in shit.TakeWhile(o => o < ringSize)) {
                acc += (int) Math.Pow(i, 2) - acc;
            }
            return (int) Math.Pow(ringSize, 2) - acc;
        }
    }
}
