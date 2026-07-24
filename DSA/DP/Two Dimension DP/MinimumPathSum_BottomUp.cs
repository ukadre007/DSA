public class Solution {
    public int MinPathSum(int[][] grid) 
    {
        int m = grid.Length;
        int n = grid[0].Length;
        
		//dp[i][j] -> Minimum path sum till i,j
        int[][] dp = new int[m][];

        for(int i=0; i<dp.Length; i++)
        {
            dp[i] = new int[n];
        }
		
		//Intialized dp[0][0] 
        dp[0][0] = grid[0][0];
		
		//Intialized first row
        for(int i=1; i<m; i++)
        {
            dp[i][0] = dp[i-1][0] + grid[i][0];
        }
		
		//Intialized second row
        for(int j=1; j<n; j++)
        {
            dp[0][j] = dp[0][j-1] + grid[0][j];
        }
		
		//Adding current value and taking minimum from down and right
        for(int i=1; i<m; i++)
        {
            for(int j=1; j<n; j++)
            {
                dp[i][j] = grid[i][j] + Math.Min(dp[i-1][j],dp[i][j-1]);
            }
        }

        return dp[m-1][n-1];

    }
}