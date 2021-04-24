using Moq;
using NSubstitute;
using PersonalManagement.Api.Context;
using PersonalManagement.Api.Models;
using PersonalManagement.Api.Repositories;
using PersonalManagement.Api.Repositories.Contracts;
using PersonalManagement.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PersonalManagement.Test
{
    public class ControlPointTest
    {
        private IControlPointRepository _controlPointRepository;
        public ControlPointTest()
        {
            _controlPointRepository = Substitute.For<IControlPointRepository>();
        }

        [Fact]
        public void CalculateTotalHour()
        {
            var controlPoint = new ControlPoint()
            {
                ApplicationUserId = "530d0847-a28e-438e-8459-69fe207b4f1a",
                HourInputOne = TimeSpan.Parse("08:00"),
                HourInputTwo = TimeSpan.Parse("12:00"),
                HourExitOne = TimeSpan.Parse("14:00"),
                HourExitTwo = TimeSpan.Parse("18:00")
            };

            int totalHour = (controlPoint.HourInputTwo.Hours - controlPoint.HourInputOne.Hours)
                + (controlPoint.HourExitTwo.Hours - controlPoint.HourExitOne.Hours);
    
            Assert.NotNull(totalHour);
        }

        [Fact]
        public async Task GetControlPoints_Test()
        {
            var controlPoints = await _controlPointRepository.GetAll(new ControlPointViewModel());
            Assert.NotNull(controlPoints);
        }

        [Theory]
        [InlineData(1)]
        public async Task GetControlPointId_Test(int id)
        {
            var controlPoint = await _controlPointRepository.GetById(id);
            Assert.NotNull(controlPoint);
            
        }
    }
}
