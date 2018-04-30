using System.Collections.Generic;
using System.Linq;
using GamerCave.Identity.Infra.CrossCutting.NoficationResult.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GamerCave.Identity.Tests
{
    [TestClass]
    public class NotificationResultTests
    {
        private const string SuccessMessage = "Criado com sucesso.";
        private const string ErrorMessage = "Ocorreu um erro.";
        private readonly List<string> _object = new List<string> { "Um", "Dois" };


        [TestMethod]
        public void NotificationResult_Constructor()
        {
            // Arrange
            var notificationResult = new NotificationResult();

            // Act
            notificationResult.SetSuccessMessage(SuccessMessage);

            // Assert
            Assert.AreEqual(SuccessMessage, notificationResult.SuccessMessage);
            Assert.IsTrue(notificationResult.IsValid);
            Assert.IsTrue(notificationResult.Errors.Count == 0);
        }

        [TestMethod]
        public void NotificationResult_SetError()
        {
            // Arrange
            var notificationResult = new NotificationResult();

            // Act
            notificationResult.SetError(ErrorMessage);

            // Assert
            Assert.IsTrue(notificationResult.Errors.Any(x => x == ErrorMessage));
            Assert.IsTrue(!notificationResult.IsValid);
            Assert.IsTrue(notificationResult.Errors.Count > 0);
            Assert.IsTrue(notificationResult.SuccessMessage == "");
        }

        [TestMethod]
        public void NotificationResult_SetSuccessMessageWithError()
        {
            // Arrange
            var notificationResult = new NotificationResult();

            // Act
            notificationResult.SetError(ErrorMessage);
            notificationResult.SetSuccessMessage(SuccessMessage);

            // Assert
            Assert.IsTrue(notificationResult.Errors.Any(x => x == ErrorMessage));
            Assert.IsTrue(!notificationResult.IsValid);
            Assert.IsTrue(notificationResult.Errors.Count > 0);
            Assert.IsTrue(notificationResult.SuccessMessage == "");
            Assert.IsTrue(notificationResult.SuccessMessage != SuccessMessage);
        }

        [TestMethod]
        public void NotificationResult_SetData()
        {
            // Arrange
            var notificationResult = new NotificationResult();

            // Act
            notificationResult.SetData(_object, SuccessMessage);
            var data = (List<string>)notificationResult.Data;

            // Assert
            Assert.IsTrue(notificationResult.Errors.Count == 0);
            Assert.IsTrue(notificationResult.IsValid);
            Assert.IsTrue(notificationResult.SuccessMessage == SuccessMessage);
            Assert.IsTrue(data.Any(x => x == "Um"));
            Assert.IsTrue(data.Any(x => x == "Dois"));
        }

        [TestMethod]
        public void NotificationResult_SetDataWithError()
        {
            // Arrange
            var notificationResult = new NotificationResult();

            // Act
            notificationResult.SetError(ErrorMessage);
            notificationResult.SetData(_object, SuccessMessage);
            var data = (List<string>)notificationResult.Data;

            // Assert
            Assert.IsTrue(notificationResult.Errors.Any(x => x == ErrorMessage));
            Assert.IsTrue(!notificationResult.IsValid);
            Assert.IsTrue(notificationResult.Errors.Count > 0);
            Assert.IsTrue(notificationResult.SuccessMessage == "");
            Assert.IsNull(notificationResult.Data);
            Assert.IsNull(data);
        }

        [TestMethod]
        public void NotificationResult_SetErrorWithData()
        {
            // Arrange
            var notificationResult = new NotificationResult();

            // Act
            notificationResult.SetData(_object, SuccessMessage);
            notificationResult.SetError(ErrorMessage);
            var data = (List<string>)notificationResult.Data;

            // Assert
            Assert.IsTrue(notificationResult.Errors.Any(x => x == ErrorMessage));
            Assert.IsTrue(!notificationResult.IsValid);
            Assert.IsTrue(notificationResult.Errors.Count > 0);
            Assert.IsTrue(notificationResult.SuccessMessage == "");
            Assert.IsNull(notificationResult.Data);
            Assert.IsNull(data);
        }
    }
}
