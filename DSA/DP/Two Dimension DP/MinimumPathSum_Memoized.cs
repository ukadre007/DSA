public class Solution 
{
    public int MinPathSum(int[][] grid) 
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
		
		//dp[i][j] -> mini path sum at i,j
        int[,] memo = new int[rows, cols];

		//Intialized dp with -1
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                memo[i, j] = -1;
            }
        }

        return Helper(grid, 0, 0, memo);
    }

    private int Helper(int[][] grid, int row, int col, int[,] memo)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
		
		//Out of bound condition
        if (row >= rows || col >= cols)
            return int.MaxValue;
		
		//Base condition when row and col reach last index
        if (row == rows - 1 && col == cols - 1)
            return grid[row][col];
		
		//Condition to check when memo is already filled
        if (memo[row, col] != -1)
            return memo[row, col];
		
		//Recusivly callig for down
        int down = Helper(grid, row + 1, col, memo);
		//Recusivly calling for right 
        int right = Helper(grid, row, col + 1, memo);
		
		//storing inside memo
        memo[row, col] = grid[row][col] + Math.Min(down, right);

        return memo[row, col];
    }
}