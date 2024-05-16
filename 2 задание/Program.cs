using System.Text.RegularExpressions;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();
        if (IsLowerCaseEnglish(input))
        {
            StringProcessing(input);
        }
        else
        {
            Console.WriteLine("Строка содержит другие символы помимо строчных букв английского алфавита.");
            foreach (char c in input)
            {
                if (!char.IsLower(c) || c < 'a' || c > 'z')
                {
                    Console.Write(c + " ");
                }
            }
        }
    }
    static bool IsLowerCaseEnglish(string input)
    {
        return Regex.IsMatch(input, "^[a-z]*$");
    }
    static void StringProcessing(string input)
    {
        string str1 = "", str2 = "", result = "";
        int strLen = input.Length;
        if (strLen % 2 == 0)
        {
            str1 = input.Substring(0, strLen / 2);
            str2 = input.Substring(strLen / 2);
            for (int i = str1.Length - 1; i >= 0; i--)
            {
                result += str1[i];
            }
            for (int i = str2.Length - 1; i >= 0; i--)
            {
                result += str2[i];
            }
        }
        else
        {
            for (int i = input.Length - 1; i >= 0; i--)
            {
                result += input[i];
            }
            result += input;
        }
        Console.WriteLine("Результат:" + result);
    }
}