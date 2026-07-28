public class Solution
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        int sum = 0;
        foreach (int num in nums)
            sum += num;

        if (Math.Abs(target) > sum)
            return 0;

        if ((sum + target) % 2 != 0)
            return 0;

        int subsetSum = (sum + target) / 2;
        int n = nums.Length;

        int[][] dp = new int[n + 1][];

        for (int i = 0; i <= n; i++)
        {
            dp[i] = new int[subsetSum + 1];
        }

        // Initialize first row
        dp[0][0] = 1;
        for (int j = 1; j <= subsetSum; j++)
        {
            dp[0][j] = 0;
        }

        // Initialize first column
        for (int i = 1; i <= n; i++)
        {
            if (nums[i - 1] == 0)
                dp[i][0] = 2 * dp[i - 1][0];
            else
                dp[i][0] = dp[i - 1][0];
        }

        // Fill remaining table
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= subsetSum; j++)
            {
                dp[i][j] = dp[i - 1][j];

                if (j >= nums[i - 1])
                {
                    dp[i][j] += dp[i - 1][j - nums[i - 1]];
                }
            }
        }

        return dp[n][subsetSum];
    }
}