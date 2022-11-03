using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSONFormatter.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONFormatter.Core.Tests;

[TestClass()]
public class FormatterTests
{
    readonly Formatter defaultFormatter = new();

    [TestMethod()]
    public void FormatTest__EmptyString()
    {
        Assert.AreEqual(
            "",
            defaultFormatter.Format(""));
    }

    [TestMethod()]
    public void FormatTest__EmptyObject()
    {
        Assert.AreEqual(
            "{}",
            defaultFormatter.Format("{}"));
        Assert.AreEqual(
            "{}",
            defaultFormatter.Format("  {   \n}"));
        Assert.AreEqual(
            "{}",
            defaultFormatter.Format("  {   }"));
    }

    [TestMethod()]
    public void FormatTest__ObjectWithNumericalMember()
    {
        Assert.AreEqual(
            "{\n" +
            "  num: 5\n" +
            "}",
            defaultFormatter.Format("{num:5}"));
    }

    [TestMethod()]
    public void FormatTest__ObjectWithTwoNumericalMembers()
    {
        Assert.AreEqual(
            "{\n" +
            "  num1: 5,\n" +
            "  num2: 7\n" +
            "}",
            defaultFormatter.Format("{num1:5, num2:7}"));
    }
 
    }
}