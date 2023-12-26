/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        int moveUp = 0; // 繰り上がり
        ListNode ans = new ListNode();
        ListNode current = ans;

        while (l1 != null || l2 != null)
        {
            int temp = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + moveUp;
            if (l1 != null) l1 = l1.next;
            if (l2 != null) l2 = l2.next;
            moveUp = 0;
            if (temp >= 10)
            {
                moveUp = 1;
                temp %= 10;
            }
            current.next = new ListNode(temp);
            current = current.next;
        }
        if (moveUp > 0)
        {
            current.next = new ListNode(moveUp);
        }
        return ans.next;
    }
}

