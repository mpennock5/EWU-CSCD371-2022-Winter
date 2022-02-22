using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests;
[Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
public class NodeTests
{
    [TestMethod]
    public void ReturnsChildItemsGivenMax()
    {
        Node<int> node = testHelper();
        IEnumerable<Node<int>> max = node.ChildItems(6);
        IEnumerable<Node<int>> max2 = node.ChildItems(2);

        Assert.AreEqual<int>(6, max.Count());
        Assert.AreEqual<int>(2, max2.Count());
    }

    public Node<int> testHelper()
    {
        Node<int> node = new(42);
        node.Append(43);
        node.Append(44);
        node.Append(45);
        return node;
    }
}
