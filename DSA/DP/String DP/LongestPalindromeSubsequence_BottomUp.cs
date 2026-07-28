public class Solution {
    public int LongestPalindromeSubseq(string s) 
	{
		//Reversing s to get s2
		//We need to take LCS of s1 and s2
        string s2 = Reverse(s);
        return LongestCommonSubseq(s,s2);
    }

    private int LongestCommonSubseq(string s1, string s2)
    {
        int n = s1.Length;
        int m = s2.Length;
        int[][] dp = new int[n+1][];
        for(int i=0; i<dp.Length; i++)
        {
            dp[i] = new int[m+1];
        }
		
		//Base case row intialization
        for(int i=0; i<dp.Length; i++)
        {
            dp[i][0] = 0;
        }
		
		//Base case col intialization
        for(int j=0; j<dp.Length; j++)
        {
            dp[0][j] = 0;
        }
		
		//Transition
        for(int i=1; i<dp.Length; i++)
        {
            for(int j=1; j<dp[0].Length; j++)
            {
				//When letters match
                if(s1[i-1] == s2[j-1])
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

     private string Reverse(string s)
    {
        int i=0;
        int j = s.Length-1;
        StringBuilder sb = new StringBuilder(s);
        while(i < j)
        {
            char c = sb[i];
            sb[i] = sb[j];
            sb[j] = c;
            i++;
            j--;
        }

        return sb.ToString();
    }
}