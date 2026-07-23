public class Solution {
    public int MinPathSum(int[][] grid) 
    {
        return Helper(grid,0,0);
    }

    private int Helper(int[][] grid, int row, int col)
    {
		//Index out of bounds 
         if(row > grid.Length-1 || col > grid[0].Length-1)
        {
            return int.MaxValue;
        }
		
		//Base condition when we reach last index
        if(row == grid.Length-1 && col == grid[0].Length-1)
        {
            return grid[row][col];
        }

		//Recursivly calling function for down and right with row+1 and col+1 respectivly
        return grid[row][col] + Math.Min(Helper(grid,row+1,col),Helper(grid,row,col+1));
    }
}