using BusinessLayer.Interface;
using BusinessLayer.MediatR;
using DataModel;
using DataModel.DataModel;
using Moq;

namespace BusinessLayer.Tests
{
    public class CandidateHandlerTests
    {
        [Fact]

   
        public async Task Handle_ShouldReturnSuccessResponse_WhenUpdateIsSuccessful()
        {
            // Arrange
            var candidate = new Candidate()
            {
                FirstName = "Ram",
                Email = "a"
            };
            var mockCandidateInfo = new Mock<ICandidateInformation>();

            // Set up the mock to return a Failure ApiResponse
            mockCandidateInfo.Setup(repo => repo.UpdateCreateCandidate(It.IsAny<Candidate>()))
                          .ReturnsAsync(new ApiResponse { Success = false, Message = "Update failed" , StatusCode=500});

            var handler = new UpdateCreateCandidateHandler(mockCandidateInfo.Object);
            var command = new UpdateCreateCandidateCommand(candidate);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("Update failed", result.Message);
        }
    }
}