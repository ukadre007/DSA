public class Solution 
{
    public int Rob(int[] nums) 
    {
        int n = nums.Length;

        //Edge cases
        if(n == 0)
        {
            return 0;
        }
        if(n == 1)
        {
            return nums[0];
        }

        //Since the array is circular, the first and last house are adjacent.
        //So we run the linear House Robber twice:
        //1) On houses [0 .. n-2] (excluding the last house)
        //2) On houses [1 .. n-1] (excluding the first house)
        //and take the maximum of both.
        int excludingLast = RobLinear(nums, 0, n - 2);
        int excludingFirst = RobLinear(nums, 1, n - 1);

        return Math.Max(excludingLast, excludingFirst);
    }

    //Standard bottom-up House Robber over the inclusive range [start, end]
    private int RobLinear(int[] nums, int start, int end)
    {
        //prev2 -> best up to i-2, prev1 -> best up to i-1
        int prev2 = 0;
        int prev1 = 0;

        for(int i = start; i <= end; i++)
        {
            //Either skip current house (prev1) or rob it (nums[i] + prev2)
            int current = Math.Max(prev1, nums[i] + prev2);
            prev2 = prev1;
            prev1 = current;
        }

        return prev1;
    }
}
