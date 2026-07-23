public class Solution 
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid) 
    {
		//dp[i][j] -> unique number of ways to come to i,j
        int[][] dp = new int[obstacleGrid.Length][];
		
		//Intialized dp with -1
        for(int i=0; i<dp.Length; i++)
        {
            dp[i] = new int[obstacleGrid[0].Length];
            for(int j=0; j<dp[i].Length; j++)
            {
                dp[i][j] = -1;
            }
        }
		
		//Calling helper function with suitable parameters
        return Helper(obstacleGrid,0,0,dp);
    }

    private int Helper(int[][] grid, int row ,int col,int[][] dp)
    {
		//Index out of bound condition row or col exceeds grid parameters
        if(row > grid.Length-1 || col > grid[0].Length-1)
        {
            return 0;
        }
		
		//When it is obstacle on grid[row][col] we are returing zero since we cant move either right or down  
        if(grid[row][col] == 1)
        {
            return 0;
        }
		
		//Base condition i.e. reaching last index
        if(row == grid.Length-1 && col == grid[0].Length-1)
        {
            return 1;
        }
		
		//Using memoized value if it is evaluated before
        if(dp[row][col] != -1)
        {
            return dp[row][col];
        }
		
		//Storing number of ways, since right and down are allowed we are doing row+1 and col +1 respectivly 
        dp[row][col] = Helper(grid, row+1, col,dp) + Helper(grid,row, col+1,dp);
        return dp[row][col];
    }
}