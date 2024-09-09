// See https://aka.ms/new-console-template for more information
using System.Text;

public static class Program 
{
    public static void Main(string[] args)
    {
        // Input
        Console.WriteLine("Input a character from the alphabet");
        var input = Console.ReadLine()?.ToUpper();

        // Input Error handling
        if (string.IsNullOrEmpty(input) || input.Length > 1 || !char.IsLetter(input[0]))
        {
            Console.WriteLine("Invalid input. Please enter a single letter.");
            return;
        }

        var charInput = input[0];

        GenerateOutput(charInput);
    }


    public static List<string> GenerateOutput(char charInput)
    {
        // Set Alphabet
        List<char> alphabet = Enumerable.Range('A', 26).Select(c => (char)c).ToList();

        // Find input alphabet index
        var inputAlphabetIndex = alphabet.IndexOf(charInput) + 1;

        // Filter for only required letter
        var alphabetSubList = alphabet.Take(inputAlphabetIndex).ToList();

        // Max length of each diamond string
        var diamondLength = inputAlphabetIndex * 2 - 1;

        // Diamond strings to be stored in list
        var output = new List<string>();

#region Old Code        
        // var midpoint = (diamondLength + 1) / 2;
        // var currentPosition = 0;
        // while (currentPosition < inputAlphabetIndex)
        // {
        //     var currentLetter = alphabetSubList[currentPosition];

        //     if (currentLetter == alphabetSubList.First())
        //     {
        //         output.Add(CreateDiamondString(diamondLength, midpoint));
        //     }
        //     else
        //     {
        //         var leftMidpoint = midpoint - currentPosition;
        //         var rightMidpoint = midpoint + currentPosition;
        //         output.Add(CreateDiamondStringWithChar(length, leftMidpoint, rightMidpoint, currentLetter));
        //     }

        //     currentPosition++;
        // }
#endregion Old Code        

        // For loop iterates
        for (int currentPosition = 0; currentPosition < inputAlphabetIndex; currentPosition++)
        {
            var currentLetter = alphabetSubList[currentPosition];
            var leftMidpoint = inputAlphabetIndex - currentPosition - 1;
            var rightMidpoint = inputAlphabetIndex + currentPosition - 1;

            output.Add(CreateDiamondLine(diamondLength, leftMidpoint, rightMidpoint, currentLetter));
        }

        // Writing output of diamond lines
        foreach (var line in output)
            Console.WriteLine(line);

        // Reverse writing output of diamond lines
        if(output.Count > 1)
        {
            for (int i = output.Count - 2; i >= 0; i--)
                Console.WriteLine(output[i]);
        }

        return output;
    }

#region Old Code
    public static string CreateDiamondString(int length, int midpoint) {
        
        var sb = new StringBuilder();

        for(int i = 0; i < length; i++)
        {
            if(i == midpoint - 1)
            {
                sb.Append('A');
            }
            else
            {
                sb.Append(' ');
            }      
        }

        return sb.ToString();
    }

    public static string CreateDiamondStringWithChar(int length, int leftMidpoint, int rightMidpoint, char charInput) {
        
        var sb = new StringBuilder();

        for(int i = 0; i < length; i++)
        {
            if(i == leftMidpoint - 1 || i == rightMidpoint - 1)
            {
                sb.Append(charInput);
            }
            else
            {
                sb.Append(' ');
            }
        }

        return sb.ToString();
    }
#endregion

    // Method created to replace empty string with relevant letter using key value
    public static string CreateDiamondLine(int length, int leftMidpoint, int rightMidpoint, char charInput)
    {
        var sb = new StringBuilder(new string(' ', length));

        sb[leftMidpoint] = charInput;
        sb[rightMidpoint] = charInput;

        return sb.ToString();
    }
}
