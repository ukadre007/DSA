public class Solution 
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid) 
    {	
		//Calling helper function with suitable parameters
        return Helper(obstacleGrid,0,0);
    }

    private int Helper(int[][] grid, int row ,int col)
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
		
		//since right and down are allowed we are doing row+1 and col +1 respectivly 
        return Helper(grid, row+1, col) + Helper(grid,row, col+1);
    }
}