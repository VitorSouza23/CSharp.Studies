using System.Text;

Dictionary<int, string> numberNames = new()
{
    [0] = "zero",
    [1] = "one",
    [2] = "two",
    [3] = "trhee",
    [4] = "four",
    [5] = "five",
    [6] = "six",
    [7] = "seven",
    [8] = "eight",
    [9] = "nine",
    [10] = "ten",
    [11] = "eleven",
    [12] = "twelve",
    [13] = "thirteen",
    [14] = "fourteen",
    [15] = "fifteen",
    [16] = "sixteen",
    [17] = "seventeen",
    [18] = "eighteen",
    [19] = "nineteen",
    [20] = "tweenty",
    [30] = "thirty",
    [40] = "forty",
    [50] = "fifty",
    [60] = "sixty",
    [70] = "seventy",
    [80] = "eighty",
    [90] = "ninety"
};

string[] units = { "thousand", "million", "billion" };

int number = 1123456789;

IEnumerable<string> separateNumbers = SeparateNumbers(number);
IEnumerable<string> translatedNumbers = TranslateNumber(separateNumbers);
string finalResult = CombineNames(translatedNumbers.ToArray());

Console.WriteLine(finalResult);


static IEnumerable<string> SeparateNumbers(int number) 
{
    string numberString = number.ToString();
    for (int index = numberString.Length; index >= 1; index -= 3)
    {
        int start = index >= 3 ? index - 3 : 0;
        int length = index >= 3 ? 3 : index;
        yield return numberString.Substring(start, length);
    }
}

IEnumerable<string> TranslateNumber(IEnumerable<string> numbers)
{
    foreach (string number in numbers)
    {
        yield return number switch
        {
            "0" => numberNames[0],
            string num when num.StartsWith('0') || num.Length < 3 => numberNames[int.Parse(num)],
            string num when num.EndsWith('0') => $"{numberNames[int.Parse(num[..1])]} hundred {numberNames[int.Parse(num[1..3])]}",
            string num => $"{numberNames[int.Parse(num[..1])]} hundred {numberNames[int.Parse(num[1..2] + "0")]} {numberNames[int.Parse(num[2..])]}",
            _ => ""
        };
    }
}

string CombineNames(string[] translatedNumbers)
{
    StringBuilder sb = new();
    for(int index = translatedNumbers.Length - 1; index >= 0; index--)
    {
        string unit = index > 0 ? units[index - 1] : "";
        sb.Append($"{translatedNumbers[index]} {unit} ");
    }
    return sb.ToString();
}