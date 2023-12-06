string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day2.txt");
// partOne();
partTwo();
void partOne()
{
    int total = 0;
    foreach (string line in file)
    {
        string[] parts = line.Split(new string[] { ";", ":" }, StringSplitOptions.None);
        parts[0] = parts[0].Remove(0, 5);
        bool possible = true;
        for (int i = 1; i < parts.Length; i++)
        {
            string[] collors = parts[i].Split(new string[] { ", " }, StringSplitOptions.None);
            foreach (string collor in collors)
            {
                string temp = collor;
                if (temp.Contains("red"))
                {
                    temp = temp.Replace(" red", "");
                    int amount = Int32.Parse(temp);
                    if (amount > 12)
                    {
                        possible = false;
                    }

                }
                else if (temp.Contains("blue"))
                {
                    temp = temp.Replace(" blue", "");
                    int amount = Int32.Parse(temp);
                    if (amount > 14)
                    {
                        possible = false;
                    }
                }
                else if (temp.Contains("green"))
                {
                    temp = temp.Replace(" green", "");
                    int amount = Int32.Parse(temp);
                    if (amount > 13)
                    {
                        possible = false;
                    }
                }
            }
        }
        if (possible)
        {
            total += Int32.Parse(parts[0]);
        }
    }
    Console.WriteLine(total);
}

void partTwo()
{
    int total = 0;
    foreach (string line in file)
    {
        string[] parts = line.Split(new string[] { ";", ":" }, StringSplitOptions.None);
        int redMax = 0;
        int greenMax = 0;
        int blueMax = 0;
        for (int i = 1; i < parts.Length; i++)
        {
            string[] collors = parts[i].Split(new string[] { ", " }, StringSplitOptions.None);
            foreach (string collor in collors)
            {
                string temp = collor;
                if (temp.Contains("red"))
                {
                    temp = temp.Replace(" red", "");
                    int amount = Int32.Parse(temp);
                    if (amount > redMax)
                    {
                        redMax = amount;
                    }

                }
                else if (temp.Contains("blue"))
                {
                    temp = temp.Replace(" blue", "");
                    int amount = Int32.Parse(temp);
                    if (amount > blueMax)
                    {
                        blueMax = amount;
                    }
                }
                else if (temp.Contains("green"))
                {
                    temp = temp.Replace(" green", "");
                    int amount = Int32.Parse(temp);
                    if (amount > greenMax)
                    {
                        greenMax = amount;
                    }
                }
            }
        }
        int sum =redMax * greenMax * blueMax;
        total += sum;
    }
    Console.WriteLine(total);
}
