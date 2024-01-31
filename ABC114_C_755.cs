using System;

public class Hello
{
    public static void func(long N, long cur, int use, ref long counter)
    {
        if (cur > N) return; // ベースケース
        if (use == 0b111) counter++; // 答えを増やす

        // 7 を付け加える
        func(N, cur * 10 + 7, use | 0b001, ref counter);

        // 5 を付け加える
        func(N, cur * 10 + 5, use | 0b010, ref counter);

        // 3 を付け加える
        func(N, cur * 10 + 3, use | 0b100, ref counter);
    }

    public static void Main()
    {
        long N = long.Parse(Console.ReadLine());
        long counter = 0;
        func(N, 0, 0, ref counter);
        Console.WriteLine(counter);
    }
}
