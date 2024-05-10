Console.WriteLine("Введите строку:");
string str = Console.ReadLine();
string str1 = "", str2 = "", result = "";
int strLen = str.Length;
if (strLen % 2 == 0)
{
    str1 = str.Substring(0, strLen / 2);
    str2 = str.Substring(strLen / 2);
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
    for (int i = str.Length - 1; i >= 0; i--)
    {
        result += str[i];
    }
    result += str;
}
Console.WriteLine("Результат:");
Console.WriteLine(result);