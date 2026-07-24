public class Solution {
    public bool CanPartition(int[] nums) 
    {
        int sum = 0;
        int n = nums.Length;
        foreach(int num in nums)
        {
            sum += num;
        }

        if(sum%2 != 0)
        {
            return false;
        }

        int target = sum/2;

        int[][] dp = new int[n+1][];

        for(int i=0;i<dp.Length;i++)
        {
            dp[i] = new int[target+1];
            for(int j=0; j<target+1; j++)
            {
                dp[i][j] = -1;
            }
        }

        return Helper(nums,target,dp,0);
    }

    private bool Helper(int[] nums, int target, int[][] dp,int index)
    {
        if(target == 0)
        {
            return true;
        }

        if(target < 0)
        {
            return false;
        }

        if(index >= nums.Length)
        {
            return false;
        }

        if(dp[index][target] != -1)
        {
            return dp[index][target] == 1 ? true :false;
        }

       bool result = Helper(nums, target - nums[index], dp, index + 1) 
       || Helper(nums, target, dp, index + 1);
       
        dp[index][target] = result ? 1 : 0;
        return result;

    }
}