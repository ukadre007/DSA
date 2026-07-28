public class Solution {
    public int FindTargetSumWays(int[] nums, int target) 
    {
        return Helper(nums,target,0);
    }

    private int Helper(int[] nums,int target, int index)
    {
       if(index == nums.Length)
       {
         return target == 0 ? 1:0;
       }

        int ans = Helper(nums,target-nums[index],index+1) + Helper(nums,target+nums[index],index+1);

        return ans;
    }
}