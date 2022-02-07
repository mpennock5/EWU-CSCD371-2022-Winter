namespace GenericsHomework;
public class Node
{
    public Node(object node)
    {
        _Node = node;
    }

    public object _Node { get; set; }

    public void Append(object value)
    {

    }

    public void Clear(Node current)
    {

    }

    public Boolean Exists(object value)
    {
        return false;
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}