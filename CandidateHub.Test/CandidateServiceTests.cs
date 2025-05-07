using CandidateHub.Application.Services;
using CandidateHub.Domain.Entities;
using CandidateHub.Domain.Interfaces;
using Moq;

namespace CandidateHub.Test
{
    public class CandidateServiceTests
    {
        private readonly Mock<ICandidateRepository> _mockRepo;
        public CandidateServiceTests()
        {
            _mockRepo = new Mock<ICandidateRepository>();
        }

        [Fact]
        public async Task GetCandidateByEmailAsync_ExistingEmail_ShouldReturnCandidate()
        {
            // Arrange
            var email = "mahmoud.sami720@gmail.com";
            Candidate candidate = Candidate.Create(
                "Mahmoud", 
                "Sami",
                email,
                "01159880086",
                "https://www.linkedin.com/in/mahmoud-sami71/",
                "https://github.com/Mahmoud-Sami");

            _mockRepo.Setup(repo => repo.GetByEmailAsync(email))
                    .ReturnsAsync(candidate);

            var service = new CandidateService(_mockRepo.Object);

            // Act
            var result = await service.GetByEmailAsyn(email);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(email, result.Value.Email);
            Assert.Equal("Mahmoud", result.Value.FirstName);
        }
    }
}