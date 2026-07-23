public class Solution {
    public int UniquePaths(int m, int n) 
    {
		//dp[i][j] -> Unique number of ways to reach at i,j 
        int[][] dp = new int[m][];
		
		//Intialized dp with -1
        for(int i=0; i< m; i++)
        {
            dp[i] = new int[n];
            for(int j=0; j<dp[i].Length; j++)
            {
                dp[i][j] = -1;
            }
        }
		
		//Introducing helper method with required parameters
        return Helper(0,0,dp);
    }

    private int Helper(int row, int col,int[][] dp)
    {
		//Base case when we have reached end of grid
        if(row  == dp.Length-1 && col == dp[0].Length-1)
        {
            return 1;
        }
		
		
		//Index out of bound i.e. invalid inputs 
        if(row >dp.Length-1 || col>dp[0].Length-1)
        {
            return 0;
        }
		
		//Already solved optimized way to reach at dp[row][col]
        if(dp[row][col] != -1)
        {
            return dp[row][col];
        }
		
		//Recursive calls for moving right and down i.e. adding 1 to row when moving down and adding one to col when moving right
        dp[row][col] = Helper(row+1,col,dp) + Helper(row,col+1,dp);
        return dp[row][col];
    }
}