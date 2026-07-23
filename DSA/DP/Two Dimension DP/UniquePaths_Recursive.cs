public class Solution {
    public int UniquePaths(int m, int n) 
    {
        int[][] grid = new int[m][];

        //Intialized dp with -1
        for(int i=0; i< m; i++)
        {
            grid[i] = new int[n];
        }
		//Introducing helper method with required parameters
        return Helper(0,0,grid);
    }

    private int Helper(int row, int col,int[][] grid)
    {
		//Base case when we have reached end of grid
        if(row  == grid.Length-1 && col == grid[0].Length-1)
        {
            return 1;
        }
		
		
		//Index out of bound i.e. invalid inputs 
        if(row >grid.Length-1 || col>grid[0].Length-1)
        {
            return 0;
        }
			
		//Recursive calls for moving right and down i.e. adding 1 to row when moving down and adding one to col when moving right
       int max =  Helper(row+1,col,grid) + Helper(row,col+1,grid);
        return max;
    }
}