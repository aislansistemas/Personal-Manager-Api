using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using PersonalManagement.Api.Context;
using PersonalManagement.Api.Models;
using PersonalManagement.Api.Repositories;
using PersonalManagement.Api.Repositories.Contracts;
using PersonalManagement.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PersonalManagement.Test
{
    public class ControlPointTest
    {
        
        [Fact]
        public async Task FindControlPointsTest()
        {
            var controlPointRepository = new Mock<IControlPointRepository>();
            var controlPoint = new ControlPoint() {
                ApplicationUserId = "das12312",
                Date = DateTime.Now,
                HourValue = 30
            };
           
            controlPointRepository.Setup(c => c.Create(It.IsAny<ControlPoint>())).Verifiable();

            controlPointRepository.Verify(c => c.Create(It.IsAny<ControlPoint>()), Times.Once);
            Assert.Equal(1,1);
        }

        [Fact]
        public void GetPointsTest()
        {
            var controlPointRepository = new Mock<IControlPointRepository>();
            var controlPointList = new List<ControlPoint>();
            var controlPointResults = controlPointRepository.Setup(c => c.GetAll(It.IsAny<ControlPointViewModel>())).Returns(Task.FromResult((IList<ControlPoint>)controlPointList));
            
        }
    }
}
