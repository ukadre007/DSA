public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        
        return Helper(text1,text2,0,0,0);
    }

    private int Helper(string text1, string text2, int i, int j,int ans)
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
		
		//When char is matching
        if(text1[i] == text2[j])
        {
            ans = 1+ Helper(text1,text2,i+1,j+1,ans);
        }
        else
        {	//Taking max from all 3 scenarios
			//skiping from 1st
			//skiping from 2nd
			//skiping from both
            ans = Math.Max(Helper(text1,text2,i+1,j+1,ans) ,Math.Max(Helper(text1,text2,i,j+1,ans) , Helper(text1,text2,i+1,j,ans)));
        }

        return ans;

    }
}