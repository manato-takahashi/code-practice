using System;

public class Hello
{
    public static void chmax<T> (ref T a, T b) where T : IComparable<T>
    {
        if(a.CompareTo(b) < 0)
        {
            a = b;
        }
    }

    public static void Main()
    {
        // 標準入力の受け取り
        int N = int.Parse(Console.ReadLine());
        int[,] happiness = new int[N, 3];
        for(int i=0; i<N; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            for(int j=0; j<3; j++)
            {
                happiness[i, j] = int.Parse(input[j]);
                // Console.Write(happiness[i, j] + " "); // 標準入力の確認用
            }
        }

        // DPテーブル定義
        int[,] dp = new int[N+1, 3];

        for(int i=0; i<N; i++)
        {
            // i日目にAを選んだ場合
            chmax(ref dp[i+1, 0], dp[i, 1] + happiness[i, 0]);
            chmax(ref dp[i+1, 0], dp[i, 2] + happiness[i, 0]);

            // i日目にBを選んだ場合
            chmax(ref dp[i+1, 1], dp[i, 0] + happiness[i, 1]);
            chmax(ref dp[i+1, 1], dp[i, 2] + happiness[i, 1]);
            
            // i日目にCを選んだ場合
            chmax(ref dp[i+1, 2], dp[i, 0] + happiness[i, 2]);
            chmax(ref dp[i+1, 2], dp[i, 1] + happiness[i, 2]);
        }


        // 答えの出力
        int ans = 0;
        for(int i=0; i<3; i++)
        {
            chmax(ref ans, dp[N, i]);
        }
        Console.WriteLine(ans);
    }
}