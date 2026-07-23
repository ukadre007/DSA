public class Solution 
{
    public int Rob(int[] nums) 
    {
        int n=nums.Length;
        //Edge case when array is empty
        if(n == 0)
        {
            return 0;
        }

        if(n ==1)
        {
            return nums[0];
        }

        //Since two cases are there we need 2 dp's we cant pass single dp in every call b/c dp[index] might get filled with some value suboptimal value, we can find more optimized value in next recursive call
        int[] dp1 = new int[n];
        Array.Fill(dp1,-1);
        int[] dp2 = new int[n];
        Array.Fill(dp2,-1);

        //Since array is circular we need two calls when first index is included and when first index is excluded. 
        int excludingLast = Helper(nums,0,n-2,dp1);
        int excludingFirst = Helper(nums,1,n-1,dp2);

        //Taking max of both approaches
        return Math.Max(excludingLast,excludingFirst);
    }

    private int Helper(int[] nums, int index,int end,int[] dp)
    {
        //Provided end index from outside for two cases to work 
        if(index >end)
        {
            return 0;
        }

        if(dp[index] != -1)
        {
            return dp[index];
        }

        //Robbing the current house
        int take = nums[index] + Helper(nums,index+2,end,dp);

        //skiping the current house
        int skip = Helper(nums,index+1,end,dp);

        //Taking maximum from both
        return dp[index] = Math.Max(take,skip);
    }
}