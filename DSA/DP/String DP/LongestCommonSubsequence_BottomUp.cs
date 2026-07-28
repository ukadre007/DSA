public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        
        //Length of text
        int n=text1.Length;
        int m = text2.Length;

        //dp[i][j] -> Longest common subsequence of text1 till ith index and text2 till jth index
        int[][] dp = new int[n+1][];

        for(int i = 0; i< dp.Length; i++)
        {
            dp[i] = new int[m+1];
        }

        //Intializing base row
        for(int i=0; i<dp.Length; i++)
        {
            dp[i][0] = 0;
        }

        //Intializing base col
        for(int j=0; j<dp[0].Length; j++)
        {
            dp[0][j] = 0;
        }

        //Transition 
        for(int i=1; i<dp.Length; i++)
        {
            for(int j=1; j<dp[0].Length; j++)
            {   
                //When char matches from both strings
                if(text1[i-1] == text2[j-1])
                {
                    dp[i][j] = 1+dp[i-1][j-1];
                }
                else
                {   //When char dont match 3 scenarios
                    //1. Skip from first string
                    int skipFromText1 = dp[i-1][j];
                    //2. Skip from second string
                    int skipFromText2 = dp[i][j-1];
                    //3. Skip from both string
                    int skipFromBoth = dp[i-1][j-1];
                    //choosing max ans from all
                    dp[i][j] = Math.Max(skipFromText1,Math.Max(skipFromText2,skipFromBoth));
                }
            }

        }

        return dp[n][m];


    }
}