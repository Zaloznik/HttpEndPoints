using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class DiffControllerTests
    {
        [TestMethod]
        public void Left_WithValidData_ShouldReturnCreated()
        {
            // Arrange
            var mockClientDataService = new Mock<IClientDataService>();
            var controller = new DiffController(mockClientDataService.Object);

            var id = Guid.NewGuid();
            var data = "SGVsbG8gV29ybGQ="; // "Hello World" in base64

            // Act
            var result = controller.Left(id, data) as StatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(201, result.StatusCode);

            // Additional assertions based on your specific logic...
        }

        [TestMethod]
        public void Right_WithValidData_ShouldReturnCreated()
        {
            // Arrange
            var mockClientDataService = new Mock<IClientDataService>();
            var controller = new DiffController(mockClientDataService.Object);

            var id = Guid.NewGuid();
            var data = "SGVsbG8gV29ybGQ="; // "Hello World" in base64

            // Act
            var result = controller.Right(id, data) as StatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(201, result.StatusCode);

            // Additional assertions based on your specific logic...
        }

        [TestMethod]
        public void Diff_WithExistingId_ShouldReturnDiffResult()
        {
            // Arrange
            var mockClientDataService = new Mock<IClientDataService>();
            var controller = new DiffController(mockClientDataService.Object);

            var id = Guid.NewGuid();

            // Assuming we have mocked data in the client data service
            mockClientDataService.Setup(x => x.GetClientData(id)).Returns(new ClientData { Id = id, LeftData = new byte[] { 1, 2, 3 }, RightData = new byte[] { 1, 2, 4 } });

            // Act
            var result = controller.Diff(id) as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            // Additional assertions based on your specific logic...
        }

        [TestMethod]
        public void Diff_WithNonExistingId_ShouldReturnNotFound()
        {
            // Arrange
            var mockClientDataService = new Mock<IClientDataService>();
            var controller = new DiffController(mockClientDataService.Object);

            var id = Guid.NewGuid();

            // Assuming client data service returns null for non-existing id
            mockClientDataService.Setup(x => x.GetClientData(id)).Returns((ClientData)null);

            // Act
            var result = controller.Diff(id) as StatusCodeResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);

            // Additional assertions based on your specific logic...
        }
    }
}
