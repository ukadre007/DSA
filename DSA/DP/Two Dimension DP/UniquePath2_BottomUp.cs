public class Solution
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid) 
    {
        // Number of rows
        int m = obstacleGrid.Length;

        // Number of columns
        int n = obstacleGrid[0].Length;

        // If starting cell itself has an obstacle,
        // there is no valid path.
        if (obstacleGrid[0][0] == 1)
        {
            return 0;
        }

        /*
         * dp[i][j] represents:
         * Number of unique ways to reach cell (i, j)
         */
        int[][] dp = new int[m][];

        // Initialize each row of the jagged array
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[n];
        }

        /*
         * Fill first column.
         *
         * Once an obstacle is encountered in the first column,
         * all cells below it become unreachable because we can
         * only move Down or Right.
         */
        bool flag = true;

        for (int i = 0; i < m; i++)
        {
            if (obstacleGrid[i][0] != 1 && flag)
            {
                dp[i][0] = 1;
            }
            else
            {
                dp[i][0] = 0;
                flag = false;
            }
        }

        /*
         * Fill first row.
         *
         * Once an obstacle is encountered in the first row,
         * all cells after it become unreachable because we can
         * only move Right or Down.
         */
        flag = true;

        for (int i = 0; i < n; i++)
        {
            if (obstacleGrid[0][i] != 1 && flag)
            {
                dp[0][i] = 1;
            }
            else
            {
                dp[0][i] = 0;
                flag = false;
            }
        }

        /*
         * Fill the remaining DP table.
         */
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                // If current cell contains an obstacle,
                // it cannot be reached.
                if (obstacleGrid[i][j] == 1)
                {
                    dp[i][j] = 0;
                }
                else
                {
                    /*
                     * We can reach the current cell from:
                     * 1. The cell above    -> dp[i-1][j]
                     * 2. The cell on left  -> dp[i][j-1]
                     *
                     * Total ways =
                     * ways from top + ways from left
                     */
                    dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                }
            }
        }

        // Bottom-right cell contains the answer.
        return dp[m - 1][n - 1];
    }
}