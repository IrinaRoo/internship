using System.Net;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string input = Console.ReadLine();
        if (IsLowerCaseEnglish(input))
        {
            string result = StringProcessing(input);
            Console.WriteLine("Выберите сортировку:" + "\n" + "1 - Быстрая сортировка, 2 - Сортировка деревом");
            int sort = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Отсортированная строка:");
            switch (sort)
            {
                case 1:
                    QuickSort(input);
                    break;
                case 2:
                    FunTreeSort(input);
                    break;
                default:
                    Console.WriteLine("Сортировка не выбрана");
                    break;
            }
            Console.WriteLine("Урезанная строка:" + "\n" + TrimLine(result));
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
    static string StringProcessing(string input) //Обработка строки
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
        Console.WriteLine("Обработанная строка:" + result);
        Dictionary<char, int> characterCount = CountCharacters(result);
        foreach (var kvp in characterCount)
        {
            Console.WriteLine($"Символ '{kvp.Key}' встречается {kvp.Value} раз");
        }
        Console.WriteLine("Строка, начинающаяся и заканчивающаяся гласной:");
        Console.WriteLine(FindLongestVowelSubstring(result));
        return result;
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
    public static void QuickSort(string input) //быстра сортировка
    {
        char[] charArray = input.ToCharArray();
        Array.Sort(charArray);
        Console.WriteLine(new string(charArray));
    }
    public static void FunTreeSort(string input) //сортировка деревом
    {
        TreeSort treeSort = new TreeSort();
        string sortedString = treeSort.TreeSortString(input);
        Console.WriteLine(sortedString);
    }
    public static string TrimLine(string input) //урезаем строку
    {
        try
        {
            string url = "";// "http://www.randomnumberapi.com/api/v1.0/randomnumber?min=0&max=&count=1";
            StringBuilder apiUrl = new StringBuilder(url);
            apiUrl.Insert(63, input.Length - 1);
            string responsetext = new WebClient().DownloadString(apiUrl.ToString());
            string str = responsetext.Substring(1, responsetext.Length - 3);
            string outputString = input.Remove(int.Parse(str), 1);
            return outputString;
        }
        catch
        {
            Random random = new Random();
            int randomNumber = random.Next(0, input.Length-1);
            string outputString = input.Remove(randomNumber, 1);
            return outputString;
        }
    }
}


class TreeSort
{
    private class Node
    {
        public char Key;
        public Node Left, Right;

        public Node(char key)
        {
            Key = key;
            Left = Right = null;
        }
    }

    private Node root;

    private Node InsertNode(Node root, char key)
    {
        if (root == null)
            return new Node(key);

        if (key < root.Key)
            root.Left = InsertNode(root.Left, key);
        else
            root.Right = InsertNode(root.Right, key);

        return root;
    }

    private void InorderTraversal(Node root, List<char> result)
    {
        if (root != null)
        {
            InorderTraversal(root.Left, result);
            result.Add(root.Key);
            InorderTraversal(root.Right, result);
        }
    }

    public string TreeSortString(string input)
    {
        root = null;
        foreach (char character in input)
        {
            root = InsertNode(root, character);
        }

        List<char> sortedChars = new List<char>();
        InorderTraversal(root, sortedChars);

        return new string(sortedChars.ToArray());
    }
}
