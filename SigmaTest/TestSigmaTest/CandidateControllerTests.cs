using BusinessLayer.MediatR;
using DataModel;
using DataModel.DataModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SigmaTest.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Tests
{
    public class CandidateControllerTests
    {
        //private readonly CandidateController _controller;
        //public CandidateControllerTests(CandidateController controller)
        //{
        //    _controller = controller;  
        //}
        [Fact]
        public async Task UpdateCandidate_ShouldReturnBadRequest_WhenDataIsInvalid()
        {
            // Arrange
            var candidate = new Candidate()
            {
              FirstName="Ram",
              Email="a"
            };
            var mockMediator=new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<UpdateCreateCandidateCommand>(), default))
                      .ReturnsAsync(new ApiResponse { Success = false, Message = "Update Not successful" });

            var controller = new CandidateController(mockMediator.Object);
            // Act
            var result = await controller.UpdateCreateCandidate(candidate);

            // Assert
            var BadResult = Assert.IsType<BadRequestObjectResult>(result);
            var response = Assert.IsType<ApiResponse>(BadResult.Value);
            Assert.False(response.Success);
            Assert.Equal("Update Not successful", response.Message);
        }
        [Fact]
        public async Task UpdateCandidate_ShouldReturnOk_WhenUpdateIsNotSuccessful()
        {
            // Arrange
            var candidate = new Candidate()
            {
                FirstName = "Ram",
                Email = "a@gmail.com",
                LastName="Sita",
                Remarks="TEST",
                
            };
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(It.IsAny<UpdateCreateCandidateCommand>(), default))
                      .ReturnsAsync(new ApiResponse { Success = true, Message = "Update successful", StatusCode=200 });

            var controller = new CandidateController(mockMediator.Object);
            // Act
            var result = await controller.UpdateCreateCandidate(candidate);

            // Assert
            var OkResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponse>(OkResult.Value);
            Assert.True(response.Success);
            Assert.Equal("Update successful", response.Message);
        }
    }
}
