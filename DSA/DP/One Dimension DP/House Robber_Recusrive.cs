public class Solution {
    public int Rob(int[] nums) 
    {
        //Edge case when array is empty
        if(nums.Length == 0)
        {
            return 0;
        }

        //Helper method with required parameters
        return Helper(nums,0);
    }

    private int Helper(int[] nums, int index)
    {
        //When index is out of bound return the calculated results
        if(index >= nums.Length)
        {
            return 0;
        }

        //Recursivly calling 
        //1) When index is choosen adding that to sum, moving to index+2
        //2) When index is not choosen skiping and moving to ndex
        return Math.Max(nums[index] + Helper(nums,index+2),Helper(nums,index+1));

    }
}