public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        int[] ans = new int[2];
        int i,j;
        for(i=0; i<nums.Length-1; i++)
        {
            for(j=i+1; j<nums.Length; j++)
            {
                if(nums[i]+nums[j] == target)
                {
                    ans[0] = i;
                    ans[1] = j;
                }
            }
        }

        return ans;
    }
}