using AutoFixture;
using Event.Business.Interface;
using Event.Business.Models;
using Event.Client.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingTestProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.Controller
{
    public class EventControllerTest : ApiUnitTestBase<EventController>
    {
        private Mock<IEventRepository> mockEventRepository;
        public override void TestSetup()
        {
            mockEventRepository = this.CreateAndInjectMock<IEventRepository>();
            Target = new EventController(mockEventRepository.Object);
        }

        public override void TestTearDown()
        {
            mockEventRepository.VerifyAll();
        }

        [Fact]
        public void GetEventById_ValueFound()
        {
            // Arrange.
            var id = Fixture.Create<int>();
            List<Events> events = new List<Events>(id);
            this.mockEventRepository.Setup(c => c.GetEventById(id)).Returns(events);

            // Act.
            var result = Target.GetEventById(id) as ObjectResult;

            // Assert.
            Assert.NotNull(result);
            Assert.Equal(events, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockEventRepository.Verify(c => c.GetEventById(id), Times.Once);
        }

        [Fact]
        public void GetEventById_BadRequest()
        {
            // Arrange.

            // Act.
            var result = Target.GetEventById(0) as StatusCodeResult;

            // Assert.
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        //[Fact]
        //public void GetEventById_NotFound()
        //{
        //    //Arrange
        //    var id = Fixture.Create<int>();
        //    var events = Fixture.Create<Events>();
        //    events.Id = id;
        //    this.mockEventRepository.Setup(c => c.GetEventById(id));

        //    //Act
        //    var result = Target.GetEventById(id) as StatusCodeResult;

        //    //Assert
        //    Assert.NotNull(result);
        //    Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        //}

        [Fact]
        public void GetEventByCurrentMonth_Found()
        {
            // Arrange.
            var month = Fixture.Create<int>();
            List<Events> events = new List<Events>(month);
            this.mockEventRepository.Setup(c => c.GetEventByCurrentMonth(month)).Returns(events);

            // Act.
            var result = Target.GetEventByCurrentMonth(month) as ObjectResult;

            // Assert.
            Assert.NotNull(result);
            Assert.Equal(events, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockEventRepository.Verify(c => c.GetEventByCurrentMonth(month), Times.Once);
        }

        [Fact]
        public void GetEventByCurrentMonth_BadRequest()
        {
            // Arrange.

            // Act.
            var result = Target.GetEventByCurrentMonth(0) as StatusCodeResult;

            // Assert.
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact]
        public void GetAll_Found()
        {
            // Arrange.
            var id = Fixture.Create<int>();
            List<Events> events = new List<Events>();
            this.mockEventRepository.Setup(c => c.GetAll()).Returns(events);

            // Act.
            var result = Target.GetAll() as ObjectResult;

            // Assert.
            Assert.NotNull(result);
            Assert.Equal(events, result.Value);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            this.mockEventRepository.Verify(c => c.GetAll(), Times.Once);
        }

        [Fact]
        public void GetAll_NotFound()
        {
            // Arrange.
            IEnumerable<Events> events = null;
            this.mockEventRepository.Setup(c => c.GetAll()).Returns((List<Events>)events);

            // Act.
            var result = Target.GetAll() as StatusCodeResult;
            
            // Assert.
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public void Post_Ok()
        {
            var emp = Fixture.Create<Events>();
            this.mockEventRepository.Setup(c => c.Post(emp)).Returns(emp);

            //Act
            var result = Target.CreateEmployeeDetail(emp) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.True(result.Value != null && result.Value is Employees);
            mockEmpRepository.Verify(c => c.CreateEmployeeDetail(emp), Times.Once);
        }
    }
}
