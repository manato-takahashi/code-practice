public class Solution {
    public int LengthOfLongestSubstring(string s) {
        Dictionary<char, int> list = new Dictionary<char, int>();
        List<int> result = new List<int>();
        int current = 0;
        int start = 0;

        if(s.Length == 0) return 0;
        while(current < s.Length)
        {
            if(!list.ContainsKey(s[current]))
            {
                if(list.Count == 0) start = current;
                list.Add(s[current], current);
                current++;
            }
            else
            {
                result.Add(list.Count);
                current = start + 1;
                list.Clear();
            }
        }
        result.Add(list.Count);
        return result.Max();
    }
}