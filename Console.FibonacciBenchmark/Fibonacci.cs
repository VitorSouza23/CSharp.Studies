namespace Console.FibonacciBenchmark;

public class Fibonacci
{
    public static ulong Recursive(ulong n)
    {
        if (n is 1 or 2) return 1;
        return Recursive(n - 1) + Recursive(n - 2);
    }

    public static ulong Memo(ulong n)
    {
        var memo = new ulong[n + 1];
        return MemoInternal(n, memo);
    }
    
    private static ulong MemoInternal(ulong n, ulong[] memo)
    {
        if (memo[n] is not 0) return memo[n];
        if (n is 1 or 2) memo[n] = 1;
        else memo[n] = MemoInternal(n - 1, memo) + MemoInternal(n - 2, memo);

        return memo[n];
    }

    public static ulong BottomUp(ulong n)
    {
        if (n is 1 or 2) return 1;
        var bottomUp = new ulong[n + 1];
        bottomUp[1] = 1;
        bottomUp[2] = 1;
        for (ulong i = 3; i < n + 1; i++)
        {
            bottomUp[i] = bottomUp[i - 1] + bottomUp[i - 2];
        }

        return bottomUp[n];
    }
}