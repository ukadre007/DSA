public class Solution {
    public bool CanPartition(int[] nums) 
    {
        int sum =0;
        for(int i=0; i<nums.Length; i++)
        {
            sum += nums[i];
        }

        if(sum%2 != 0)
        {
            return false;
        }

        return Helper(nums,sum/2,0);
    }

    private bool Helper(int[] nums, int target, int index)
    {
        if(target == 0)
        {
            return true;
        }

        if(target < 0)
        {
            return false;
        }

        
        if(index >= nums.Length)
         {
        return false;
        }


        return Helper(nums,target-nums[index],index+1) || Helper(nums,target,index+1);
        
    }
}