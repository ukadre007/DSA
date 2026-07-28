public class Solution
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        int sum = 0;
        foreach (int num in nums)
            sum += num;

        if (Math.Abs(target) > sum)
            return 0;

        if ((target + sum) % 2 != 0)
            return 0;

        int s = (target + sum) / 2;

        int[][] dp = new int[nums.Length][];
        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = new int[s + 1];
            Array.Fill(dp[i], -1);
        }

        return Helper(nums, s, 0, dp);
    }

    private int Helper(int[] nums, int target, int index, int[][] dp)
    {
        if (index == nums.Length)
            return target == 0 ? 1 : 0;

        if (target < 0)
            return 0;

        if (dp[index][target] != -1)
            return dp[index][target];

        int take = Helper(nums, target - nums[index], index + 1, dp);
        int skip = Helper(nums, target, index + 1, dp);

        return dp[index][target] = take + skip;
    }
}