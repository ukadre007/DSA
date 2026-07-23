public class Solution
{
    public int ClimbStairs(int n)
    {
      //Dp[i] is ways till ith step
       int[] dp = new int[n+1];
       for(int i=0; i<dp.Length; i++)
       {
        //Intialized dp with -1
        dp[i] = -1;
       }


       return Helper(n,dp);
    }

    private int Helper(int n, int[] dp)
    {
        //Base condition
        if(n == 0)
        {
            return 1;
        }

        //Invalid input
        if(n < 0)
        {
            return 0;
        }

        //If result is already present inside the dp
        if(dp[n] != -1)
        {
            return dp[n];
        }

        //Storing the result in dp i.e. number of ways till nth step
        dp[n] = Helper(n-1,dp) + Helper(n-2,dp);
        return dp[n];
    }
}