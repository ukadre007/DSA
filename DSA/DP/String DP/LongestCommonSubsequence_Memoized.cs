public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        
        int n = text1.Length;
        int m = text2.Length;
        int[][] dp = new int[n+1][];
        for(int i=0; i<dp.Length; i++)
        {
            dp[i] = new int[m+1];
            for(int j=0; j<dp[i].Length; j++)
            {
                dp[i][j] = -1;
            }
        }
        return Helper(text1,text2,0,0,0,dp);
    }

    private int Helper(string text1, string text2, int i, int j,int ans,int[][] dp)
    {	
		//Base condition
        if(i == text1.Length || j == text2.Length)
        {
            return ans;
        }
		
		//Out of bound condition
        if(i > text1.Length || j > text2.Length)
        {
            return 0;
        }
		
		//If dp[i][j] is already present or precalculated
        if(dp[i][j] != -1)
        {
            return dp[i][j];
        }
		
		//if char matches
        if(text1[i] == text2[j])
        {
            ans = 1+ Helper(text1,text2,i+1,j+1,ans,dp);
            dp[i][j] = ans;
        }
        else
        {	//Taking max from all 3 scenarios
			//skiping from 1st
			//skiping from 2nd
			//skiping from both
            ans = Math.Max(Helper(text1,text2,i+1,j+1,ans,dp) ,Math.Max(Helper(text1,text2,i,j+1,ans,dp) , Helper(text1,text2,i+1,j,ans,dp)));
            dp[i][j] = ans;

        }

        return ans;

    }
}