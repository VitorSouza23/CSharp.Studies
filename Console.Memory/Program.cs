using System.Buffers;

static void WriteInt32ToBuffer(int value, Memory<char> buffer)
{
    var strValue = value.ToString();
    var span = buffer.Slice(0, strValue.Length).Span;
    strValue.AsSpan().CopyTo(span);
}

static void DisplayBuffer(Memory<char> buffer)
{
Console.WriteLine($"Buffer content: {buffer}");
}

using (IMemoryOwner<char> buffer = MemoryPool<char>.Shared.Rent())
{
    WriteInt32ToBuffer(42, buffer.Memory);
    DisplayBuffer(buffer.Memory);
}