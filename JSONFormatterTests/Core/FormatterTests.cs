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
}