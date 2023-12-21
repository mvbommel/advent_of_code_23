using System.Text.RegularExpressions;

string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day3.txt");
//string[] file = { "467.114...", "...*......","..35..633.", "......#...", "617*......", ".....+.58.", "..592.....", "......755.", "...$.*....", ".664.598.." };


string symbolPattern = @"[^0-9a-zA-Z.\r\n]";
string numberPattern = @"\d+";
string starPattern = @"[*]";

partOne();
partTwo();
void partOne()
{
    int outcome = 0;
    for (int row = 0; row < file.Length; row++)
    {
        for (int col = 0; col < file.Length; col++)
        {
            if (Regex.IsMatch(file[row][col].ToString(), symbolPattern))
            {
                outcome += calculate(file[row - 1], col);
                outcome += calculate(file[row], col);
                outcome += calculate(file[row + 1], col);
            }
        }
    }
    Console.WriteLine(outcome);
}

int calculate(string line, int col)
{
    int count = 0;
    MatchCollection matches = Regex.Matches(line, numberPattern);
    int[] indexes = { col - 1, col, col + 1 };

    foreach(Match match in matches)
    {
        string number = match.Value;

        if(indexInList(indexes, match.Index, match.Length))
        {
            count += Int32.Parse(number);
        }
    }

    return count;
}

bool indexInList(int[] indexes, int index, int length)
{
    for(int i = index; i < index + length; i++)
    {
        if (indexes.Contains(i))
        {
            return true;
        }
    }

    return false;
}


void partTwo()
{
    int outcome = 0;
    for (int row = 0; row < file.Length; row++)
    {
        for (int col = 0; col < file.Length; col++)
        {
            if (Regex.IsMatch(file[row][col].ToString(), starPattern))
            {
                int[] res1 = multiply(file[row - 1], col);
                int[] res2= multiply(file[row], col);
                int[] res3 = multiply(file[row + 1], col);

                int count = 0;
                int[] concat = res1.Concat(res2).ToArray();
                int[] concate = concat.Concat(res3).ToArray();
                foreach(int i in concate)
                {
                    if(i > 0)
                    {
                        count++;
                    }
                }

                if (count == 2)
                {
                    if (res1[0] != 0 && res1[1] != 0)
                    {
                        outcome += (res1[0] * res1[1]);
                    }
                    if (res2[0] != 0 && res2[1] != 0)
                    {
                        outcome += (res2[0] * res2[1]);
                    }
                    if (res3[0] != 0 && res3[1] != 0)
                    {
                        outcome += (res3[0] * res3[1]);
                    }
                    if (res1[0] != 0 && res1[1] == 0 && res2[0] != 0 && res2[1] == 0)
                    {
                        outcome += (res1[0] * res2[0]);
                    }
                    if (res1[0] != 0 && res1[1] == 0 && res3[0] != 0 && res3[1] == 0)
                    {
                        outcome += (res1[0] * res3[0]);
                    }
                    if (res2[0] != 0 && res2[1] == 0 && res3[0] != 0 && res3[1] == 0)
                    {
                        outcome += (res2[0] * res3[0]);
                    }
                }
            }
        }
    }
    Console.WriteLine(outcome);
}

int[] multiply(string line, int col)
{
    int[] outcome = new int[2];
    MatchCollection matches = Regex.Matches(line, numberPattern);
    int[] indexes = { col - 1, col, col + 1 };
    foreach (Match match in matches)
    {
        string number = match.Value;

        if (indexInList(indexes, match.Index, match.Length))
        {
            if (outcome[0] == 0)
            {
                outcome[0] = Int32.Parse(number);
            }
            else if (outcome[1] == 0)
            {
                outcome[1] = Int32.Parse(number);
            }
        }
    }
    return outcome;
}