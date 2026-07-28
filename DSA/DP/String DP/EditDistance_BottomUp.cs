public class Solution {
    public int MinDistance(string word1, string word2) 
    {
        int n = word1.Length;
        int m = word2.Length;

        //dp[i][j] -> Minimum operations required to convert ith length of word1 to jth length of word2
        int[][] dp = new int[n+1][];

       
        for(int i=0; i<dp.Length; i++)
        {
            dp[i] = new int[m+1];
        }

       // Initialize the base case: converting from empty string to the other string
        for(int i=0; i<dp.Length; i++)
        {
            dp[i][0] = i; // Deleting all characters from word1 to match empty word2
        }
        // Inserting all characters of word2 to match empty word1
        for(int i=0; i<dp[0].Length; i++)
        {
            dp[0][i] = i;
        }

        for(int i=1; i<dp.Length; i++)
        {
            for(int j=1; j<dp[0].Length; j++)
            {   
                // No change needed if characters match
                if(word1[i-1] == word2[j-1])
                {
                    dp[i][j] = dp[i-1][j-1];
                }
                else
                {
                    int deleteChar = dp[i-1][j];
                    int insertChar = dp[i][j-1];
                    int replaceChar = dp[i-1][j-1];

                    dp[i][j] = 1+ Math.Min(deleteChar, Math.Min(insertChar,replaceChar));
                }
            }
        }

        return dp[n][m];
    }
}