// 以下のコードは自分で考えたもののうまくいかなかったコード
public class Solution {
 public int LengthOfLongestSubstring(string s) {
   List<char> list = new List<char>();
   List<int> tempLength = new List<int>();
   int i = 0;
   int start = 0;
   int end = 0;

   if(s.Length == 0) return 0;
   while(true)
   {
       if(list.Contains(s[i]))
       {
           tempLength.Add(list.Count);
           i = start + 1;
           if(i < 0) i = 0;
           list.Clear();
           if(i >= 0)
           {
                list.Add(s[i]);
                start = i;
           }
       }
       else
       {
           list.Add(s[i]);
           end = i;
       }
       if(start == s.Length-1) break;
       i ++;
   }
   tempLength.Add(list.Count); // Add the length of the last substring
   foreach(var n in tempLength)
   {
       Console.WriteLine(n);
   }
   if(tempLength.Count == 0) return 0;
   return tempLength.Max();
 }
}

// 以下 GPT-4 Turbo が生成したコード

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int n = s.Length;
        int ans = 0;
        
        // キャラクターのインデクスを保存するMapを使用する
        Dictionary<char, int> charIndexMap = new Dictionary<char, int>();

        // スライディングウィンドウとして二つのポインタを利用する
        for(int j = 0, i = 0; j < n; j++) {
            if(charIndexMap.ContainsKey(s[j])) {
                // ドキュメントで見つかった最後のインデックスからスライディングウィンドウの開始位置を更新
                i = Math.Max(charIndexMap[s[j]] + 1, i);
            }

            // 現在のウィンドウの長さで最大長を更新
            ans = Math.Max(ans, j - i + 1);
            charIndexMap[s[j]] = j;  // キャラクターの最新のインデックスを保存
        }

        return ans;
    }
}



// GPT-4 Turbo が生成したコード こっちの方がわかりやすいかも

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s == null || s.Length == 0) {
            return 0;
        }

        var charIndices = new Dictionary<char, int>();
        int maxLength = 0;
        int start = 0;  // スライディングウィンドウの開始位置をトラッキングする

        for (int end = 0; end < s.Length; end++) {
            char currentChar = s[end];

            if (charIndices.ContainsKey(currentChar)) {
                // すでに現れている文字の場合、スタート位置を更新
                // ただし、スタート位置は戻らないようにする
                start = Math.Max(charIndices[currentChar] + 1, start);
            }

            charIndices[currentChar] = end; // 文字の最新位置を更新する
            maxLength = Math.Max(maxLength, end - start + 1); // 最大長を更新
        }

        return maxLength;
    }
}
