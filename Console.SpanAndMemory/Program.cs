byte[] arr = new byte[5];
Span<byte> span = arr;

arr[0] = 10;
arr[1] = 11;
arr[2] = 12;
arr[3] = 13;
arr[4] = 14;

Console.WriteLine(string.Join(',', arr));

span[1] = 21;

Console.WriteLine(string.Join(',', arr));

Span<byte> spanSliced = span.Slice(1, 2);

Console.WriteLine(string.Join(',', spanSliced.ToArray()));

spanSliced[0] = 31;

Console.WriteLine(string.Join(',', arr));

int length = 10;
Random random = new();
string result = string.Create(length, random, (Span<char> chars, Random r) =>
{
    for(int i = 0; i < chars.Length; i++)
    {
        chars[i] = (char)(r.Next(0, 10) + '0');
    }
});

Console.WriteLine(result);

string value = "This is a Test";
string inverseValue = string.Create(value.Length, value, (Span<char> chars, string v) =>
{
    v.AsSpan().CopyTo(chars);
    chars.Reverse();
});
Console.WriteLine(value);
Console.WriteLine(inverseValue);
