public class Solution {
    public bool CanPartition(int[] nums) 
    {
        int sum =0;
        for(int i=0; i<nums.Length; i++)
        {
            sum += nums[i];
        }

        if(sum%2 != 0)
        {
            return false;
        }

        // return Helper(nums,sum/22);
    }

    private bool Helper(int[] nums, int target)
    {
       int n = nums.Length;

       bool[][] dp = new bool[n+1][];

       for(int i=0; i< dp.Length; i++)
       {
         dp[i] = new bool[target+1];
       }

      // Sum 0 is always possible
		for(int i = 0; i <= n; i++)
		{
			dp[i][0] = true;
		}

		// With 0 numbers, positive sums are impossible
		for(int j = 1; j <= target; j++)
		{
		dp[0][j] = false;
		}

       for(int i=1; i<n+1; i++)
       {
        for(int j=1; j<target+1; j++)
        {
            if(j < nums[i-1])
            {
                dp[i][j] = dp[i-1][j];

            }
            else
            {
                dp[i][j] = dp[i-1][j] || dp[i-1][j-nums[i-1]];
            }
        }
       }

        return dp[n][target];


        
    }
}
}