https://leetcode.com/problems/climbing-stairs/
public class Solution
{
    public int ClimbStairs(int n)
    {
        //Base condition
        if (n == 0)
            return 1;

        //When input goes negative
        if (n < 0)
            return 0;

        //Recursive calling for both cases since we need number of ways adding both
        return ClimbStairs(n - 1) + ClimbStairs(n - 2);
    }
}