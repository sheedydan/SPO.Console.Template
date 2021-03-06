// <copyright file="ProgramTest.cs">Copyright ©  2018</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSC.MPC.RenamingTool;

namespace TSC.MPC.RenamingTool.Tests
{
    /// <summary>This class contains parameterized unit tests for Program</summary>
    [PexClass(typeof(Program))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ProgramTest
    {
        /// <summary>Test stub for Main(String[])</summary>
        [PexMethod]
        internal int MainTest(string[] args)
        {
            int result = Program.Main(args);
            return result;
            // TODO: add assertions to method ProgramTest.MainTest(String[])
        }
    }
}
