using System;
using System.Collections.Generic;

public class Hello
{
    public static int Main()
    {
        string str = Console.ReadLine();
        int N = str.Length;
        List<char> list = new List<char>();
        int sum = 0;

        foreach (char c in str)
        {
            list.Add(c);
        }

        for (int bit = 0; bit < (1 << N - 1); bit++)
        {
            int tempSum = 0;
            string tempStr = list[0].ToString();

            for (int i = 0; i < N - 1; i++)
            {
                if ((bit & (1 << i)) != 0)
                {
                    // ビットが立っている場合、今までの数字を合計に足し、一時文字列をリセット
                    tempSum += int.Parse(tempStr);
                    tempStr = "";
                }
                tempStr += list[i + 1];
            }

            // 残りの数字を合計に足す
            tempSum += int.Parse(tempStr);
            // Console.WriteLine(tempSum); // 合計値の確認用
            sum += tempSum;
        }

        sum += int.Parse(str); // 元の数字も合計に含める
        Console.WriteLine(sum); // 合計を出力
        return sum;
    }
}

