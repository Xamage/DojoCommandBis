using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DojoCommandBis.Commands;

namespace DojoCommandBis.UnitTests
{
    [TestClass]
    public class CommandProcessorTests
    {
        [TestMethod]
        public void GivenACommandWhenHandledThenItIsExecuted()
        {
            // Given
            SpaceToPipeCommand command = new SpaceToPipeCommand();
            command.Input = "chien chat";

            // When
            CommandProcessor.Instance.Do(command);

            // Then
            Assert.AreEqual("chien|chat", command.Result);
        }

        [TestMethod]
        public void GivenAHandledCommandWhenUndoThenItReturnsTheSameThing()
        {
            const string expected = "chien chat";

            // Given
            SpaceToPipeCommand command = new SpaceToPipeCommand();
            command.Input = expected;
            CommandProcessor.Instance.Do(command);

            // When
            CommandProcessor.Instance.Undo();

            // Then
            Assert.AreEqual(expected, command.Result);
        }

        [TestMethod]
        public void GivenTwoHandledCommandsWhenUndoTwiceThenTheCommandsAreUndone()
        {
            const string expected1 = "chien chat";
            const string expected2 = "http://www.domaine.fr/une action?fichier=mon_fichier.txt";

            // Given
            SpaceToPipeCommand command1 = new SpaceToPipeCommand();
            command1.Input = expected1;
            EncodeUriCommand command2 = new EncodeUriCommand();
            command2.Input = expected2;

            CommandProcessor.Instance.Do(command1);
            CommandProcessor.Instance.Do(command2);

            // When
            CommandProcessor.Instance.Undo();
            CommandProcessor.Instance.Undo();

            // Then
            Assert.AreEqual(expected1, command1.Result);
            Assert.AreEqual(expected2, command2.Result);
        }

        [TestMethod]
        public void GivenTwoHandledCommandsWhenUndoTwiceAndRedoTwiceThenCommandsAreReExecuted()
        {
            const string expected1 = "chien chat";
            const string expected2 = "http://www.domaine.fr/une action?fichier=mon_fichier.txt";

            // Given
            SpaceToPipeCommand command1 = new SpaceToPipeCommand();
            command1.Input = expected1;
            EncodeUriCommand command2 = new EncodeUriCommand();
            command2.Input = expected2;

            CommandProcessor.Instance.Do(command1);
            CommandProcessor.Instance.Do(command2);

            // When
            CommandProcessor.Instance.Undo();
            CommandProcessor.Instance.Undo();
            CommandProcessor.Instance.Redo();
            CommandProcessor.Instance.Redo();

            // Then
            Assert.AreEqual("chien|chat", command1.Result);
            Assert.AreEqual("http%3a%2f%2fwww.domaine.fr%2fune+action%3ffichier%3dmon_fichier.txt", command2.Result);
        }
    }
}
