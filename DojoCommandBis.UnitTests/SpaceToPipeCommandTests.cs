using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DojoCommandBis.Commands;

namespace DojoCommandBis.UnitTests
{
    [TestClass]
    public class SpaceToPipeCommandTests
    {
        [TestMethod]
        public void GivenAStringWithoutSpacesThenItReturnsTheSameString()
        {
            SpaceToPipeCommand command = new SpaceToPipeCommand();

            // Given
            command.Input = "azerty";

            // When
            command.Execute();

            // Then
            Assert.AreEqual("azerty", command.Result);
        }

        [TestMethod]
        public void GivenAStringWithSpacesThenItReplacesSpacesWithPipes()
        {
            SpaceToPipeCommand command = new SpaceToPipeCommand();

            // Given
            command.Input = "a z e r t y";

            // When
            command.Execute();

            // Then
            Assert.AreEqual("a|z|e|r|t|y", command.Result);
        }
    }
}
