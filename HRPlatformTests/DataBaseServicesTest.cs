using HRPlatform.Helper;
using HRPlatform.Models;
using HRPlatform.Repository;
using HRPlatform.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRPlatformTests
{
    public class DataBaseServicesTest
    {
        private readonly DataBaseServices _dataBaseServices;
        private readonly Mock<IHrPlatformRepository> hrPlatformRepositoryMock = new Mock<IHrPlatformRepository>();
        private readonly Mock<IEmailValidator> emailValidatorMock = new Mock<IEmailValidator>();
        private readonly Mock<IPhoneValidator> phoneValidatorMock = new Mock<IPhoneValidator>();

        public DataBaseServicesTest()
        {
            _dataBaseServices = new DataBaseServices(hrPlatformRepositoryMock.Object, emailValidatorMock.Object, phoneValidatorMock.Object);
        }

        [Fact]
        public void AddCandidate_WithValidEmailAndPhone_ReturnsTrue()
        {
            Candidate candidate = new Candidate();
            // Arrange
            hrPlatformRepositoryMock.Setup(repo => repo.AddCandidate(candidate));
            emailValidatorMock.Setup(repo => repo.IsValid(It.IsAny<String>()))
                .Returns(true);
            phoneValidatorMock.Setup(repo => repo.IsValid(It.IsAny<String>()))
                .Returns(true);
            hrPlatformRepositoryMock.Setup(repo => repo.ExistingEmail(It.IsAny<String>()))
                .Returns(false);
            hrPlatformRepositoryMock.Setup(repo => repo.ExistingPhoneNumber(It.IsAny<String>()))
                .Returns(false);     
            // Act
            var result = _dataBaseServices.AddCandidate(candidate);

            // Assert
            hrPlatformRepositoryMock.Verify(repo => repo.AddCandidate(candidate),Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void AddCandidate_WithInvalidEmailAndPhone_ReturnsFalse()
        {
            Candidate candidate = new Candidate();
            // Arrange
            hrPlatformRepositoryMock.Setup(repo => repo.AddCandidate(candidate));
            emailValidatorMock.Setup(repo => repo.IsValid(It.IsAny<String>()))
                .Returns(true);
            phoneValidatorMock.Setup(repo => repo.IsValid(It.IsAny<String>()))
                .Returns(true);
            hrPlatformRepositoryMock.Setup(repo => repo.ExistingEmail(It.IsAny<String>()))
                .Returns(true);
            hrPlatformRepositoryMock.Setup(repo => repo.ExistingPhoneNumber(It.IsAny<String>()))
                .Returns(false);
            // Act
            var result = _dataBaseServices.AddCandidate(candidate);

            // Assert
            hrPlatformRepositoryMock.Verify(repo => repo.AddCandidate(candidate), Times.Never);
            Assert.False(result);
        }

        [Fact]
        public void AddSkill_WithUnexistingSkill_ReturnsTrue()
        {
            Skill skill = new Skill();
            // Arrange
            hrPlatformRepositoryMock.Setup(repo => repo.ExistingSkill(It.IsAny<int>()))
                .Returns(false);
            // Act
            var result = _dataBaseServices.AddSkill(skill);

            // Assert
            hrPlatformRepositoryMock.Verify(repo => repo.AddSkill(skill), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void AddSkill_WithExistingSkill_ReturnsFalse()
        {
            Skill skill = new Skill();
            // Arrange
            hrPlatformRepositoryMock.Setup(repo => repo.ExistingSkill(It.IsAny<int>()))
                .Returns(true);
            // Act
            var result = _dataBaseServices.AddSkill(skill);

            // Assert
            hrPlatformRepositoryMock.Verify(repo => repo.AddSkill(skill), Times.Never);
            Assert.False(result);
        }

        [Fact]
        public void UpdateCandidate_WithExistingCandidate_ReturnsTrue()
        {
            // Arrange
            hrPlatformRepositoryMock.Setup(repo => repo.ExistingCandidate(It.IsAny<int>()))
                .Returns(true);
            // Act
            var result = _dataBaseServices.UpdateCandidate(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            hrPlatformRepositoryMock.Verify(repo => repo.UpdateSkill(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void UpdateCandidate_WithUnexistingCandidate_ReturnsFalse()
        {
            // Arrange
            hrPlatformRepositoryMock.Setup(repo => repo.ExistingCandidate(It.IsAny<int>()))
                .Returns(false);
            // Act
            var result = _dataBaseServices.UpdateCandidate(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            hrPlatformRepositoryMock.Verify(repo => repo.UpdateSkill(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
            Assert.False(result);
        }

        [Fact]
        public void RemoveSkillFromCandidate_WithExistingCandidateAndSkill_ReturnsTrue()
        {
            // Arrange
            hrPlatformRepositoryMock.Setup(repo => repo.RemoveSkill(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true);
            // Act
            var result = _dataBaseServices.RemoveSkillFromCandidate(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            hrPlatformRepositoryMock.Verify(repo => repo.RemoveSkill(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void RemoveSkillFromCandidate_WithUnexistingCandidateAndSkill_ReturnsFalse()
        {
            // Arrange
            hrPlatformRepositoryMock.Setup(repo => repo.RemoveSkill(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(false);
            // Act
            var result = _dataBaseServices.RemoveSkillFromCandidate(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            hrPlatformRepositoryMock.Verify(repo => repo.RemoveSkill(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
            Assert.False(result);
        }

        [Fact]
        public void RemoveCandidate_WithExistingCandidate_ReturnsTrue()
        {
            // Arrange
            hrPlatformRepositoryMock.Setup(repo => repo.ExistingCandidate(It.IsAny<int>()))
                .Returns(true);
            // Act
            var result = _dataBaseServices.RemoveCandidate(It.IsAny<int>());

            // Assert
            hrPlatformRepositoryMock.Verify(repo => repo.RemoveCandidate(It.IsAny<int>()), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public void RemoveCandidate_WithUnexistingCandidate_ReturnsFalse()
        {
            // Arrange
            hrPlatformRepositoryMock.Setup(repo => repo.ExistingCandidate(It.IsAny<int>()))
                .Returns(false);
            // Act
            var result = _dataBaseServices.RemoveCandidate(It.IsAny<int>());

            // Assert
            hrPlatformRepositoryMock.Verify(repo => repo.RemoveCandidate(It.IsAny<int>()), Times.Never);
            Assert.False(result);
        }
    }
}
