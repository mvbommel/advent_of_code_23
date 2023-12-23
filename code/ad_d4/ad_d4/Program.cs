string[] file = File.ReadAllLines(@"..\..\..\..\..\..\txt\day4.txt");
//string[] file = { "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19","Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11" };
//partOne();
partTwo();
void partOne()
{
    int total = 0;
    foreach (string line in file)
    {
        string[] parts = line.Split(new string[] { ": ", " | " }, StringSplitOptions.None);

        string[] winningNumbers = parts[1].Split(new string[] { "  ", " " }, StringSplitOptions.None);
        string[] numbers = parts[2].Split(new string[] { "  ", " " }, StringSplitOptions.None);
        int count = 0;

        foreach(string number in numbers)
        {
            if (winningNumbers.Contains(number))
            {
                count++;
            }
        }
        int score = 0;
        while (count > 0)
        {
            if(score == 0)
            {
                score = 1;
            }
            else
            {
                score = score * 2;
            }
            count--;
        }
        Console.WriteLine(score);
        total += score;
    }
    Console.WriteLine(total);
}

void partTwo()
{
    int[] cardAmountCount = Enumerable.Repeat(1, file.Length).ToArray();
    int count = 0;
    foreach (string line in file)
    {
        string[] parts = line.Split(new string[] { ": ", " | " }, StringSplitOptions.None);

        string[] winningNumbers = parts[1].Split(new string[] { "  ", " " }, StringSplitOptions.None);
        string[] numbers = parts[2].Split(new string[] { "  ", " " }, StringSplitOptions.None);

        int winCount = 0;
        foreach (string number in numbers)
        {
            if (winningNumbers.Contains(number))
            {
                winCount++;
            }
        }
        int currentNr = count + 1;
        while (winCount > 0)
        {
            cardAmountCount[currentNr] += cardAmountCount[count];
            currentNr++;
            winCount--;
        }
        count++;
    }
    int total = 0;
    foreach(int  card in cardAmountCount)
    {
        total += card;
    }
    Console.WriteLine(total);

}