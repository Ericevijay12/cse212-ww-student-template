using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    /// <summary>
    /// Insert a new node in the BST.
    /// </summary>
    public void Insert(int value)
    {
        Node newNode = new(value);
        if (_root is null)
        {
            _root = newNode;
        }
        else
        {
            _root.Insert(value);
        }
    }

    /// <summary>
    /// Check to see if the tree contains a certain value.
    /// </summary>
    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the BST (Smallest to Largest).
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    /// <summary>
    /// Iterate backward through the BST (Largest to Smallest).
    /// </summary>
    public IEnumerable Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    /// <summary>
    /// Problem 3: Traverse the tree backwards (Right -> Root -> Left).
    /// </summary>
    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseBackward(node.Right, values);
            values.Add(node.Data);
            TraverseBackward(node.Left, values);
        }
    }

    /// <summary>
    /// Problem 4: Get the height of the entire tree starting from root.
    /// </summary>
    public int GetHeight()
    {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }

    /// <summary>
    /// Problem 5: Create a balanced BST from a sorted array.
    /// </summary>
    public static void CreateTreeFromSortedList(BinarySearchTree bst, int[] sortedList)
    {
        InsertMiddle(bst, sortedList, 0, sortedList.Length - 1);
    }

    /// <summary>
    /// Problem 5 Helper: Recursively inserts the middle element of current range.
    /// </summary>
    private static void InsertMiddle(BinarySearchTree bst, int[] values, int first, int last)
    {
        if (first > last)
            return;

        int mid = (first + last) / 2;
        bst.Insert(values[mid]);

        // Recursively handle the left and right halves
        InsertMiddle(bst, values, first, mid - 1);
        InsertMiddle(bst, values, mid + 1, last);
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
