public class Solution {
    public int MinDistance(string word1, string word2) 
    {
        return Solve(word1, word2, word1.Length, word2.Length);
    }

    private int Solve(string word1, string word2, int i, int j) {
        // Base case: one string is empty
        if (i == 0) return j;
        if (j == 0) return i;

        // Characters match, no edit needed
        if (word1[i - 1] == word2[j - 1]) {
            return Solve(word1, word2, i - 1, j - 1);
        }

        // Try all three operations and take the minimum
        int deleteCost = Solve(word1, word2, i - 1, j);
        int insertCost = Solve(word1, word2, i, j - 1);
        int replaceCost = Solve(word1, word2, i - 1, j - 1);

        return 1 + Math.Min(deleteCost, Math.Min(insertCost, replaceCost));
    }
}