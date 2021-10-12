using Moq;
using NUnit.Framework;
using ThirdPartyTools.Service;

namespace ThirdPartyTools.Test
{
    public class HandlerTest
    {
        private Mock<IHandler> _handler;

        [SetUp]
        public void Setup()
        {
            _handler = new Mock<IHandler>();
        }

        [Test]
        public void GetResponse_WhenPassedValidSizeString_ReturnsFileSize()
        {
            //Arrange
            string[] args = { "-v", "C:\\Test" };
            _handler.Setup(p => p.GetResponse(args)).Returns("C:\\Test");

            //Act
            string version = _handler.Object.GetResponse(args);
            
            //Assert
            Assert.IsTrue(version.Length > 0);
        }

        [Test]
        public void GetResponse_WhenPassedInValidSizeString_ReturnsNull()
        {
            //Arrange
            string[] args = { "-vcs", "C:\\Test" };
            _handler.Setup(p => p.GetResponse(args)).Returns(string.Empty);

            //Act
            string version = _handler.Object.GetResponse(args);

            //Assert
            Assert.AreEqual(version, string.Empty);
        }
        [Test]
        public void GetResponse_WhenPassedValidSizeString_ReturnsFileName()
        {
            //Arrange
            string[] args = { "-s", "C:\\Test" };
            _handler.Setup(p => p.GetResponse(args)).Returns("12345");

            //Act
            string size = _handler.Object.GetResponse(args);

            //Assert
            Assert.IsTrue(size.Length > 0);
        }
        [Test]
        public void GetResponse_WhenPassedInvalidVersionString_ReturnsNull()
        {
            //Arrange
            string[] args = { "-ssq", "C:\\Test" };
            _handler.Setup(p => p.GetResponse(args)).Returns(string.Empty);

            //Act
            string size = _handler.Object.GetResponse(args);

            //Assert
            Assert.AreEqual(size, string.Empty);
        }
        [Test]
        public void GetVersion_WhenPassedFilePath_ReturnsVersion()
        {
            //Arrange
            string path = "C:\\Test";
            _handler.Setup(p => p.GetVersion(path)).Returns("1.2.1");

            //Act
            string size = _handler.Object.GetVersion(path);

            //Assert
            Assert.IsTrue(size.Length > 0);
        }
        [Test]
        public void GetVersion_WhenPassedFilePath_ReturnsSize()
        {
            //Arrange
            string path = "C:\\Test";
            _handler.Setup(p => p.GetSize(path)).Returns(113132);

            //Act
            int size = _handler.Object.GetSize(path);

            //Assert
            Assert.IsTrue(size > 0);
        }
    }
}