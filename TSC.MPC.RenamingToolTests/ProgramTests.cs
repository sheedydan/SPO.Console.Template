using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSC.MPC.RenamingTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSC.MPC.RenamingTool.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            var args = new string[] {"not enough args"};
            var actual = Program.Main(args);
            var expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RunTest()
        {
            var args = new string[] { "-s", "", "-u", "", "-p", "" };
            var actual = Program.Main(args);
            var expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}
