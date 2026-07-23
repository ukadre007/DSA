public class Solution 
{
    //It can be further memory optimized with help of two variables instead of having dp array
    public int ClimbStairs(int n) 
    {
        //Edge cases 
        if(n == 0)
        {
            return 0;
        }
        if(n == 1)
        {
            return 1;
        }
        // dp[i] -> No. of ways to reach ith index
        int[] dp = new int[n+1];

        //Intialized dp with base cases
        dp[0] = 0;
        dp[1] = 1;
        dp[2] = 2;

        //Iterating till the end
        for(int i=3; i<= n; i++)
        {
            //No. of ways to reach ith index is no. of ways to reach i-1 + number of ways to reach i-2
            dp[i] = dp[i-1] +dp[i-2];
        }

        return dp[n];
        
    }
}