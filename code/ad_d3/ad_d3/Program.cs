using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day3.txt");


//string[] file = { "467..114..", "...*......","..35..633.", "......#...", "617*......", ".....+.58.", "..592.....", "......755.", "...$.*....", ".664.598.." };
//string[] file = { ".......", "001*002", ".......", "003.004", "...*...", ".......", "...*...", "005.006", "*......", "007....", "....008", ".....*.", "....009", "...*...", "010....", "...*...", "....011"};
partTwo();

void partOne()
{
    int total = 0;
    string number = "";
    bool numberActive = false;
    bool symbolOnNumber = false;
    for (int row = 0; row < file.Length; row++)
    {
        for (int col = 0; col < file[row].Length; col++)
        {
            if (Char.IsNumber(file[row][col]))
            {
                numberActive = true;
                bool symbol = checkSurrounding(row, col, file);
                if (symbol)
                {
                    symbolOnNumber = true;
                }
                number += file[row][col];
                Console.WriteLine(file[row][col].ToString(), symbol);
            }
            else
            {
                numberActive = false;
                if (symbolOnNumber)
                {
                    Console.WriteLine(number);
                    total += Int32.Parse(number);
                    symbolOnNumber = false;
                }
                number = "";
            }
        }
    }
    Console.WriteLine(total);
}

void partTwo()
{
    int total = 0;
    for (int row  = 0; row < file.Length;row++)
    {
        for(int col = 0;col < file[row].Length; col++)
        {
            if (file[row][col] == '*')
            {
                total += checkStarSurroundings(row, col, file);
            }
        }
    }
    Console.WriteLine(total);
}

bool checkSurrounding(int row , int col, string[] file)
{
    bool Symbol = false;
    if (row > 0 && row < file.Length - 1)
    {
        if (col > 0 && col < file[0].Length - 1)
        {
            if (regex(file[row - 1][col - 1]) || regex(file[row - 1][col]) || regex(file[row - 1][col + 1]))
            {
                Symbol = true;
            }
            if (regex(file[row][col - 1]) || regex(file[row][col + 1]))
            {
                Symbol = true;
            }
            if (regex(file[row + 1][col - 1]) || regex(file[row + 1][col]) || regex(file[row + 1][col + 1]))
            {
                Symbol = true;
            }
        }
        else if( col > 0)
        {
            if (regex(file[row - 1][col - 1]) || regex(file[row - 1][col]))
            {
                Symbol = true;
            }
            if (regex(file[row][col - 1]))
            {
                Symbol = true;
            }
            if (regex(file[row + 1][col - 1]) || regex(file[row + 1][col]))
            {
                Symbol = true;
            }
        }
        else
        {
            if (regex(file[row - 1][col]) || regex(file[row - 1][col + 1]))
            {
                Symbol = true;
            }
            if ( regex(file[row][col + 1]))
            {
                Symbol = true;
            }
            if ( regex(file[row + 1][col]) || regex(file[row + 1][col + 1]))
            {
                Symbol = true;
            }
        }
    }
    else if (row == file.Length - 1)
    {
        if (col > 0 && col < file[0].Length - 1)
        {
            if (regex(file[row - 1][col - 1]) || regex(file[row - 1][col]) || regex(file[row - 1][col + 1]))
            {
                Symbol = true;
            }
            if (regex(file[row][col - 1]) || regex(file[row][col + 1]))
            {
                Symbol = true;
            }
        }
        else if (col > 0)
        {
            if (regex(file[row - 1][col - 1]) || regex(file[row - 1][col]))
            {
                Symbol = true;
            }
            if (regex(file[row][col - 1]))
            {
                Symbol = true;
            }
        }
        else
        {
            if (regex(file[row - 1][col]) || regex(file[row - 1][col + 1]))
            {
                Symbol = true;
            }
            if ( regex(file[row][col + 1]))
            {
                Symbol = true;
            }
        }
    }
    else if (row == 0)
    {
        if (col >0 && col < file[0].Length - 1)
        {
            if (regex(file[row][col - 1]) || regex(file[row][col + 1]))
            {
                Symbol = true;
            }
            if (regex(file[row + 1][col - 1]) || regex(file[row + 1][col]) || regex(file[row + 1][col + 1]))
            {
                Symbol = true;
            }
        }
        else if( col > 0)
        {
            if (regex(file[row][col - 1]))
            {
                Symbol = true;
            }
            if (regex(file[row + 1][col - 1]) || regex(file[row + 1][col]))
            {
                Symbol = true;
            }
        }
        else
        {
            if (regex(file[row][col + 1]))
            {
                Symbol = true;
            }
            if (regex(file[row + 1][col]) || regex(file[row + 1][col + 1]))
            {
                Symbol = true;
            }
        }
    }
    return Symbol;
}

bool regex(char c)
{
    Regex rx = new Regex(@"[!@#$%^&*=+\-\/]");
    if (rx.IsMatch(c.ToString()))
    {
        return true;
    }
    else
    {
        return false;
    }
}

int checkStarSurroundings(int row, int col , string[] file)
{
    List<string> subList = new List<string>();

    if(row > 0 && row < file.Length - 1)
    {
        if(col > 0 && col < file[0].Length - 1)
        {
            string sub = file[row -1].Substring(col -1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
            sub = file[row].Substring(col - 1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
            sub = file[row +1].Substring(col - 1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
        }
        else if (col > 0)
        {
            string sub = file[row - 1].Substring(col - 1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
            sub = file[row].Substring(col - 1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
            sub = file[row + 1].Substring(col - 1, 2);
            subList.Add(sub);
            Console.WriteLine(sub);
        }
        else
        {
            string sub = file[row - 1].Substring(col, 2);
            subList.Add(sub);
            Console.WriteLine(sub);
            sub = file[row].Substring(col, 2);
            subList.Add(sub);
            Console.WriteLine(sub);
            sub = file[row + 1].Substring(col, 2);
            subList.Add(sub);
            Console.WriteLine(sub);
        }
    }
    if(row == file.Length -1)
    {
        if (col > 0 && col < file[0].Length - 1)
        {
            string sub = file[row - 1].Substring(col - 1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
            sub = file[row].Substring(col - 1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
        }
        else if (col > 0)
        {
            string sub = file[row - 1].Substring(col - 1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
            sub = file[row].Substring(col - 1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
        }
        else
        {
            string sub = file[row - 1].Substring(col, 2);
            subList.Add(sub);
            Console.WriteLine(sub);
            sub = file[row].Substring(col - 1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
        }
    }
    if(row == 0)
    {
        if (col > 0 && col < file[0].Length - 1)
        {
            string sub = file[row].Substring(col - 1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
            sub = file[row + 1].Substring(col - 1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
        }
        else if (col > 0)
        {
            string sub = file[row].Substring(col - 1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
            sub = file[row + 1].Substring(col - 1, 2);
            subList.Add(sub);
            Console.WriteLine(sub);
        }
        else
        {
            string sub = file[row].Substring(col - 1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
            sub = file[row + 1].Substring(col - 1, 3);
            subList.Add(sub);
            Console.WriteLine(sub);
        }
    }
    int count = 0;
    int NrCount = 0;
    int times = 1;
    foreach (string sub in subList)
    {
        
        if (sub.Any(Char.IsNumber))
        {
            NrCount++;
            int[] numbers = getNumber(sub, row, col, count);
            if (numbers[1] != 0)
            {
                times = times * numbers[0] * numbers[1];
                NrCount++;
            }
            else
            {
                times = times * numbers[0];
            }
            
        }
        count++;
    }
    if(NrCount == 2)
    {
        return times;
    }
    else
    {
        return 0;
    }
}

int[] getNumber(string s, int row, int col, int listIndex)
{
    int index = s.IndexOfAny("0123456789".ToCharArray());
    int number = 0;
    int second = 0;
    if(listIndex == 0)
    {
        if(index == 0)
        {
            if (Char.IsNumber(file[row - 1][col - 1]))
            {
                int y = -1;
                List<int> ints = new List<int>();
                while (Char.IsNumber(file[row - 1][col + y]))
                {

                    ints.Insert(0, file[row - 1][col + y] - '0');
                    y--;
                    if (col + y < 0)
                    {
                        break;
                    }
                }
                foreach (int i in ints)
                {
                    number = int.Parse(number.ToString() + i.ToString());
                }

                if (char.IsNumber(file[row - 1][col + 1]))
                {
                    int x = 1;
                    List<int> ints2 = new List<int>();
                    while (Char.IsNumber(file[row - 1][col + x]))
                    {

                        ints2.Add(file[row - 1][col + x] - '0');
                        if(col + x + 1 < file[0].Length)
                        {
                            x++;
                        }
                        else
                        {
                            break;
                        }
                            
                    }
                    foreach (int i in ints2)
                    {
                        second = int.Parse(second.ToString() + i.ToString());
                    }
                }
            }
            else
            {
                int y = 1;
                List<int> ints = new List<int>();
                while (Char.IsNumber(file[row - 1][col + y]))
                {
                    ints.Add(file[row - 1][col + y] - '0');
                    y++;
                }
                foreach (int i in ints)
                {
                    number = int.Parse(number.ToString() + i.ToString());
                }
            }
        }
        else if (index == 1)
        {
            int y = 0;
            List<int> ints = new List<int>();
            while (Char.IsNumber(file[row - 1][col + y]))
            {
                
                ints.Add(file[row - 1][col + y] - '0');
                y++;
            }
            foreach (int i in ints)
            {
                number = int.Parse(number.ToString() + i.ToString());
            }
        }
        else
        {
            int y = 1;
            List<int> ints = new List<int>();
            while (Char.IsNumber(file[row - 1][col + y]))
            {

                ints.Add(file[row - 1][col + y] - '0');
                y++;
            }
            foreach (int i in ints)
            {
                number = int.Parse(number.ToString() + i.ToString());
            }
        }
    }
    else if (listIndex == 1)
    {
        if (index == 0)
        {
            if (Char.IsNumber(file[row][col - 1]))
            {
                int y = -1;
                List<int> ints = new List<int>();
                while (Char.IsNumber(file[row][col + y]))
                {
                    ints.Insert(0, file[row][col + y] - '0');
                    y--;
                    if (col + y < 0)
                    {
                        break;
                    }
                }

                foreach (int i in ints)
                {
                    number = int.Parse(number.ToString() + i.ToString());
                }
            }
        }
        else
        {
            int y = 1;
            List<int> ints = new List<int>();
            while (Char.IsNumber(file[row][col + y]))
            {
                ints.Add(file[row][col + y] - '0');
                y++;
            }
            foreach (int i in ints)
            {
                number = int.Parse(number.ToString() + i.ToString());
            }
        }
    }
    else
    {
        if (index == 0)
        {
            if (Char.IsNumber(file[row + 1][col - 2]))
            {
                int y = -1;
                List<int> ints = new List<int>();
                while (Char.IsNumber(file[row + 1][col + y]))
                {
                    ints.Insert(0, file[row + 1][col + y] - '0');
                    y--;
                    if (col + y < 0)
                    {
                        break;
                    }
                }
                foreach (int i in ints)
                {
                    number = int.Parse(number.ToString() + i.ToString());
                }

                if (char.IsNumber(file[row - 1][col + 1]))
                {
                    int x = 1;
                    List<int> ints2 = new List<int>();
                    while (Char.IsNumber(file[row - 1][col + x]))
                    {

                        ints2.Add( file[row - 1][col + x] - '0');
                        x++;
                    }
                    foreach (int i in ints2)
                    {
                        second = int.Parse(second.ToString() + i.ToString());
                    }
                }
            }
            else
            {
                int y = -1;
                List<int> ints = new List<int>();
                while (Char.IsNumber(file[row + 1][col + y]))
                {
                    ints.Add(file[row + 1][col + y] - '0');
                    y++;
                }
                foreach (int i in ints)
                {
                    number = int.Parse(number.ToString() + i.ToString());
                }
            }
        }
        else
        {
            int y = 0;
            List<int> ints = new List<int>();
            while (Char.IsNumber(file[row + 1][col + y]))
            {
                ints.Add(file[row + 1][col + y] - '0');
                y++;
            }
            foreach (int i in ints)
            {
                number = int.Parse(number.ToString() + i.ToString());
            }
        }
    }
    Console.WriteLine(number);
    if(second != 0)
    {
        Console.WriteLine(second);
    }
    int[] output = { number, second };
    return output;
}