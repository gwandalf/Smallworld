﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wrapper;

namespace test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ExampleWrapper ex = new ExampleWrapper(2);
            Assert.AreEqual(ex);
        }
    }
}
