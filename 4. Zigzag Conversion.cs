public class Solution {
    public string Convert(string s, int numRows) {
        char[,] array2D = new char[numRows, s.Length/2+1];
        int currentIndex = 0;
        int unitNum = numRows + numRows - 2;

        if(numRows == 1) return s;
        if(s.Length == 1) return s;
        for(int i=0; i<s.Length/2+1; i++)
        {
            for(int j=0; j<numRows; j++)
            {
                if(currentIndex >= s.Length) break;

                if(currentIndex % unitNum < numRows)
                {
                    if(currentIndex % unitNum == 0) j = 0;
                    array2D[j, i] = s[currentIndex];
                    currentIndex++;
                }
                else
                {
                    int move = currentIndex % unitNum + 1 - numRows;
                    array2D[numRows-1-move, i] = s[currentIndex];
                    currentIndex++;
                    i += 1;
                }
            }
        }

        List<char> answer = new List<char>();
        for(int i=0; i<numRows; i++)
        {
            for(int j=0; j<s.Length/2+1; j++)
            {
                // 出力を確認するためのコード
                // if(true)
                // {
                //     if(j<s.Length/2)
                //     {
                //         Console.Write(array2D[i, j]);
                //     }
                //     else
                //     {
                //         Console.WriteLine(array2D[i, j]);
                //     }
                // }
                if(array2D[i,j] != '\0')
                {
                    if(j<s.Length/2)
                    {
                        answer.Add(array2D[i, j]);
                    }
                    else
                    {
                        answer.Add(array2D[i, j]);
                    }
                }
            }
        }
    return string.Join("", answer);
    }
}




// GPT-4による自動生成コード（こっちの方が圧倒的に早い）
public class Solution {
    public string Convert(string s, int numRows) {
        if (numRows == 1) return s;

        StringBuilder sb = new StringBuilder();
        int n = s.Length;
        int cycleLen = 2 * numRows - 2;

        for (int i = 0; i < numRows; i++) {
            for (int j = 0; j + i < n; j += cycleLen) {
                sb.Append(s[j + i]);
                if (i != 0 && i != numRows - 1 && j + cycleLen - i < n)
                    sb.Append(s[j + cycleLen - i]);
            }
        }
        return sb.ToString();
    }
}