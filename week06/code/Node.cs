public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Problem 1: Update Insert to only allow unique values.
    /// </summary>
    public void Insert(int value)
    {
        // If the value is a duplicate, just return and do nothing.
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Problem 2: Check if a value exists in the tree using recursion.
    /// </summary>
    public bool Contains(int value)
    {
        // Base case: we found it
        if (value == Data)
        {
            return true;
        }
        
        if (value < Data)
        {
            // Search left subtree if it exists
            return Left != null && Left.Contains(value);
        }
        else
        {
            // Search right subtree if it exists
            return Right != null && Right.Contains(value);
        }
    }

    /// <summary>
    /// Problem 4: Get the height of a node recursively.
    /// The height is 1 + the maximum height of its children.
    /// </summary>
    public int GetHeight()
    {
        // Use the null-coalescing operator (??) to treat null children as height 0
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
