public class Solution
{
    public int MinDistance(string word1, string word2)
    {
        int[][] dp = new int[word1.Length + 1][];

        for (int i = 0; i <= word1.Length; i++)
        {
            dp[i] = new int[word2.Length + 1];
            Array.Fill(dp[i], -1);
        }

        return Solve(word1, word2, word1.Length, word2.Length, dp);
    }

    private int Solve(string word1, string word2,
                      int i, int j, int[][] dp)
    {
        // Base cases
        if (i == 0) return j;
        if (j == 0) return i;

        // Already computed
        if (dp[i][j] != -1)
        {
            return dp[i][j];
        }

        // Characters match
        if (word1[i - 1] == word2[j - 1])
        {
            return dp[i][j] =
                Solve(word1, word2, i - 1, j - 1, dp);
        }

        int deleteCost =
            Solve(word1, word2, i - 1, j, dp);

        int insertCost =
            Solve(word1, word2, i, j - 1, dp);

        int replaceCost =
            Solve(word1, word2, i - 1, j - 1, dp);

        return dp[i][j] =
            1 + Math.Min(deleteCost,
                         Math.Min(insertCost, replaceCost));
    }
}