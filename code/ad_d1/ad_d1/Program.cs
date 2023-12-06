string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day1.txt");
//string[] file = { "two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen" };

//partOne(file);
partTwo();

void partOne(string[] input) {
    int total = 0;
    foreach(string line in input)
    {
        int first = -1;
        int second = -1;
        char[] chars = line.ToCharArray();
       foreach(char c in chars)
        {
            if(char.IsNumber(c) && first == -1)
            {
                first = c - '0';
            }
            else if(char.IsNumber(c))
            {
                second = c - '0';
            }
        }
        if(second == -1)
        {
            second = first;
        }

        int lineNumber = int.Parse(first.ToString() + second.ToString());
        Console.WriteLine(lineNumber);
        total += lineNumber;
    }
    Console.WriteLine(total);
}

void partTwo()
{
    string[] convertedFile = new string[file.Length];
    int count = 0;
    foreach(string line in file)
    {
        string temp = line;
        if (line.Contains("one"))
        {
            temp = temp.Replace("one", "o1e");

        }
        if (line.Contains("two"))
        {
            temp = temp.Replace("two", "t2o");

        }
        if (line.Contains("three"))
        {
            temp = temp.Replace("three", "t3e");

        }
        if (line.Contains("four"))
        {
            temp = temp.Replace("four", "f4r");

        }
        if (line.Contains("five"))
        {
            temp = temp.Replace("five", "f5e");

        }
        if (line.Contains("six"))
        {
            temp = temp.Replace("six", "s6x");

        }
        if (line.Contains("seven"))
        {
            temp = temp.Replace("seven", "s7n");

        }
        if (line.Contains("eight"))
        {
            temp = temp.Replace("eight", "e8t");

        }
        if (line.Contains("nine"))
        {
            temp = temp.Replace("nine", "n9e");

        }
        //Console.WriteLine(temp);
        convertedFile[count] = temp;
        count++;
    }
    partOne(convertedFile);
}
