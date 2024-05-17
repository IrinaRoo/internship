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
            OtherCharacters(input);
        }
    }
    static bool IsLowerCaseEnglish(string input) //Проверка, что строка состоит из символов английского алфавита
    {
        return Regex.IsMatch(input, "^[a-z]*$");
    }
    static void OtherCharacters(string input) //Вывод символов не английского алфавита
    {
        Console.WriteLine("Строка содержит другие символы помимо строчных букв английского алфавита:");
        foreach (char c in input)
        {
            if (!char.IsLower(c) || c < 'a' || c > 'z')
            {
                Console.Write(c + " ");
            }
        }
    }
    static void StringProcessing(string input) //Обработка строки
    {
        string str1, str2, result = "";
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
        Dictionary<char, int> characterCount = CountCharacters(result);
        foreach (var kvp in characterCount)
        {
            Console.WriteLine($"Символ '{kvp.Key}' встречается {kvp.Value} раз");
        }
        Console.WriteLine(FindLongestVowelSubstring(result));
    }
    static Dictionary<char, int> CountCharacters(string inputString) //подсчет символов, входящих в строку
    {
        Dictionary<char, int> characterCount = new Dictionary<char, int>();
        foreach (char c in inputString)
        {
            if (characterCount.ContainsKey(c))
            {
                characterCount[c]++;
            }
            else
            {
                characterCount.Add(c, 1);
            }
        }
        return characterCount;
    }
    static string FindLongestVowelSubstring(string input) //поиск подстроки, начинающейся и заканчивающейся гласной
    {
        string vowels = "aeiouy";
        int maxLength = 0;
        string maxSubstring = "";
        for (int i = 0; i < input.Length; i++)
        {
            if (!vowels.Contains(input[i]))
                continue;

            for (int j = input.Length - 1; j > i; j--)
            {
                if (!vowels.Contains(input[j]))
                    continue;

                string substring = input.Substring(i, j - i + 1);

                if (substring.Length > maxLength)
                {
                    maxLength = substring.Length;
                    maxSubstring = substring;
                }
            }
        }
        return maxSubstring;
    }
}

