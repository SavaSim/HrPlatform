using HRPlatform.Controllers;
using HRPlatform.Models;
using HRPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRPlatformTests
{
    public class SkillControllerTest
    {
        private readonly SkillController _skillController;
        private readonly Mock<IDataBaseServices> dataBaseServicesMock = new Mock<IDataBaseServices>();

        public SkillControllerTest()
        {
            _skillController = new SkillController(dataBaseServicesMock.Object);
        }

        [Fact]
        public void PostSkill_WithValidSkill_ReturnsCreated()
        {
            // Arrange
            dataBaseServicesMock.Setup(serv => serv.AddSkill(It.IsAny<Skill>()))
                .Returns(true);

            // Act
            var result = _skillController.PostSkill(new Skill());

            // Assert
            dataBaseServicesMock.Verify(serv => serv.AddSkill(It.IsAny<Skill>()));
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void PostSkill_WithInvalidSkill_ReturnsBadReques()
        {
            // Arrange
            dataBaseServicesMock.Setup(serv => serv.AddSkill(It.IsAny<Skill>()))
                .Returns(false);

            // Act
            var result = _skillController.PostSkill(new Skill());

            // Assert
            dataBaseServicesMock.Verify(serv => serv.AddSkill(It.IsAny<Skill>()));
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void GetCandidateSkill_WithValidName_ReturnsOk()
        {
            List<Candidate> candidates = new List<Candidate>();
            // Arrange
            dataBaseServicesMock.Setup(serv => serv.SearchBySkill(It.IsAny<string>()))
                .Returns(candidates);

            // Act
            var result = _skillController.GetCandidateSkill(It.IsAny<string>());

            // Assert
            dataBaseServicesMock.Verify(serv => serv.SearchBySkill(It.IsAny<string>()));
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetCandidateSkill_WithInvalidName_ReturnsNotFound()
        {
            // Arrange
            dataBaseServicesMock.Setup(serv => serv.SearchBySkill(It.IsAny<string>()))
                .Returns((List<Candidate>)null);

            // Act
            var result = _skillController.GetCandidateSkill(It.IsAny<string>());

            // Assert
            dataBaseServicesMock.Verify(serv => serv.SearchBySkill(It.IsAny<string>()));
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void RemoveCandidateSkill_WithValidSkillAndCandidateId_ReturnsOk()
        {
            // Arrange
            dataBaseServicesMock.Setup(serv => serv.RemoveSkillFromCandidate(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);

            // Act
            var result = _skillController.RemoveCandidateSkill(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            dataBaseServicesMock.Verify(serv => serv.RemoveSkillFromCandidate(It.IsAny<int>(), It.IsAny<int>()));
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void RemoveCandidateSkill_WithInvalidSkillAndCandidateId_ReturnsNotFound()
        {
            // Arrange
            dataBaseServicesMock.Setup(serv => serv.RemoveSkillFromCandidate(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(false);

            // Act
            var result = _skillController.RemoveCandidateSkill(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            dataBaseServicesMock.Verify(serv => serv.RemoveSkillFromCandidate(It.IsAny<int>(), It.IsAny<int>()));
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
