public class Solution 
{
	//It can be further space optimized instead of dp use two variables
	public int Rob(int[] nums) 
    {
        int n = nums.Length;

        //Edge cases
        if (n == 0) return 0;
        if (n == 1) return nums[0];

        //dp[i] -> Maximum robbed till ith index
        int[] dp = new int[n];
        
        //Intialized dp with first elements
        //Max till 0th index
        dp[0] = nums[0];
        //Max till first index
        dp[1] = Math.Max(nums[0], nums[1]);

        //Iterating over taking maximum at each dp[i]
        for (int i = 2; i < n; i++)
        {
            dp[i] = Math.Max(dp[i - 1], nums[i] + dp[i - 2]);
        }

        return dp[n - 1];

        
    }
}