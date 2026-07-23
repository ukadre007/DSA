public class Solution 
{
    public int Rob(int[] nums) 
    {
        //Edge case when array is empty
        if(nums.Length == 0)
        {
            return 0;
        }

        //dp[i] -> Max robbed till ith index
        int[] dp = new int[nums.Length];
        for(int i=0; i< dp.Length; i++)
        {
            dp[i] = -1;
        }

        //Helper method with required parameters
        return Helper(nums,0,dp);
    }

    private int Helper(int[] nums, int index,int[] dp)
    {
        //When index is out of bound return the calculated results
        if(index >= nums.Length)
        {
            return 0;
        }

        if(dp[index] != -1)
        {
            return dp[index];
        }

        //Recursivly calling 
        //1) When index is choosen adding that to sum, moving to index+2
        //2) When index is not choosen skiping and moving to ndex
        int rob = nums[index] + Helper(nums,index+2,dp);
        int skip = Helper(nums,index+1,dp);

        //Note: Always use seperate varaible for calculating different states also if two variables are changing in recursion use 2d dp
        return dp[index] = Math.Max(rob,skip);

    }
}