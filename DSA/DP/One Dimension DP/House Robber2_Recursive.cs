public class Solution 
{
    public int Rob(int[] nums) 
    {
        int n=nums.Length;
        //Edge case when array is empty
        if(n == 0)
        {
            return 0;
        }

        //Since array is circular we need two calls when first index is included and when first index is excluded. 
        int excludingLast = Helper(nums,0,n-2);
        int excludingFirst = Helper(nums,1,n-1);

        //Taking max of both approaches
        return Math.Max(excludingLast,excludingFirst);
    }

    private int Helper(int[] nums, int index,int end)
    {
        //Provided end index from outside for two cases to work 
        if(index >end)
        {
            return 0;
        }

        //Robbing the current house
        int take = nums[index] + Helper(nums,index+2,end);

        //skiping the current house
        int skip = Helper(nums,index+1,end);

        //Taking maximum from both
        return Math.Max(take,skip);
    }
}