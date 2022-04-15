using HRPlatform.Controllers;
using HRPlatform.Models;
using HRPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HRPlatformTests
{
    public class CandidateControllerTest
    {
        private readonly CandidateController _candidateController;
        private readonly Mock<IDataBaseServices> dataBaseServicesMock = new Mock<IDataBaseServices>();

        public CandidateControllerTest()
        {
            _candidateController = new CandidateController(dataBaseServicesMock.Object);
        }
        [Fact]
        public void PostCandidate_WithValidPhoneAndMail_ReturnsCreated()
        {
            // Arrange
            dataBaseServicesMock.Setup(serv => serv.AddCandidate(It.IsAny<Candidate>()))
                .Returns(true);

            // Act
            var result = _candidateController.PostCandidate(new Candidate());

            // Assert
            dataBaseServicesMock.Verify(serv => serv.AddCandidate(It.IsAny<Candidate>()));
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void PostCandidate_WithInvalidPhoneAndMail_ReturnsBadRequest()
        {
            // Arrange
            dataBaseServicesMock.Setup(serv => serv.AddCandidate(It.IsAny<Candidate>()))
                .Returns(false);

            // Act
            var result = _candidateController.PostCandidate(new Candidate());

            // Assert
            dataBaseServicesMock.Verify(serv => serv.AddCandidate(It.IsAny<Candidate>()));
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void AddSkillToCandidate_WithValidSkillAndCandidate_ReturnsOk()
        {
            // Arrange
            dataBaseServicesMock.Setup(serv => serv.UpdateCandidate(It.IsAny<int>(),It.IsAny<int>()))
                .Returns(true);

            // Act
            var result = _candidateController.AddSkillToCandidate(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            dataBaseServicesMock.Verify(serv => serv.UpdateCandidate(It.IsAny<int>(), It.IsAny<int>()));
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void AddSkillToCandidate_WithInvalidSkillAndCandidate_ReturnsNotFound()
        {
            // Arrange
            dataBaseServicesMock.Setup(serv => serv.UpdateCandidate(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(false);

            // Act
            var result = _candidateController.AddSkillToCandidate(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            dataBaseServicesMock.Verify(serv => serv.UpdateCandidate(It.IsAny<int>(), It.IsAny<int>()));
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetCandidateName_WithValidName_ReturnsOk()
        {
            List<Candidate> candidates = new List<Candidate>();
            // Arrange
            dataBaseServicesMock.Setup(serv => serv.SearchByName(It.IsAny<string>()))
                .Returns(candidates);

            // Act
            var result = _candidateController.GetCandidateName(It.IsAny<string>());

            // Assert
            dataBaseServicesMock.Verify(serv => serv.SearchByName(It.IsAny<string>()));
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetCandidateName_WithInvalidName_ReturnsNotFound()
        {
            // Arrange
            dataBaseServicesMock.Setup(serv => serv.SearchByName(It.IsAny<string>()))
                .Returns((List<Candidate>)null);

            // Act
            var result = _candidateController.GetCandidateName(It.IsAny<string>());

            // Assert
            dataBaseServicesMock.Verify(serv => serv.SearchByName(It.IsAny<string>()));
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void RemoveCandidate_WithValidId_ReturnsOk()
        {
            // Arrange
            dataBaseServicesMock.Setup(serv => serv.RemoveCandidate(It.IsAny<int>()))
                .Returns(true);

            // Act
            var result = _candidateController.RemoveCandidate(It.IsAny<int>());

            // Assert
            dataBaseServicesMock.Verify(serv => serv.RemoveCandidate(It.IsAny<int>()));
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void RemoveCandidate_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            dataBaseServicesMock.Setup(serv => serv.RemoveCandidate(It.IsAny<int>()))
                .Returns(false);

            // Act
            var result = _candidateController.RemoveCandidate(It.IsAny<int>());

            // Assert
            dataBaseServicesMock.Verify(serv => serv.RemoveCandidate(It.IsAny<int>()));
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
