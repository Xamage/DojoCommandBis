using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DojoCommandBis.Commands;

namespace DojoCommandBis.UnitTests
{
    [TestClass]
    public class EncodeUriCommandTests
    {
        [TestMethod]
        public void GivenAnUriWithoutSpecialCharactersThenItReturnsTheSameUri()
        {
            EncodeUriCommand command = new EncodeUriCommand();

            // Given
            command.Input = "www.domaine.fr";

            // When
            command.Execute();

            // Then
            Assert.AreEqual("www.domaine.fr", command.Result);
        }

        [TestMethod]
        public void GivenAnUriWithSpecialCharactersThenItIsEncoded()
        {
            EncodeUriCommand command = new EncodeUriCommand();

            // Given
            command.Input = "http://www.domaine.fr/une action?fichier=mon_fichier.txt";

            // When
            command.Execute();

            // Then
            Assert.AreEqual("http%3a%2f%2fwww.domaine.fr%2fune+action%3ffichier%3dmon_fichier.txt", command.Result);
        }

        [TestMethod]
        public void GivenAnUriWithSpecialCharactersWhenEncodedAndUndoThenItReturnsTheSameUri()
        {
            const string expected = "http://www.domaine.fr/une action?fichier=mon_fichier.txt";

            EncodeUriCommand command = new EncodeUriCommand();

            // Given
            command.Input = expected;

            // When
            command.Execute();
            command.Undo();

            // Then
            Assert.AreEqual(expected, command.Result);
        }
    }
}
