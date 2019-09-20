using Microservice.Data;
using Microservice.Services;
using Microservice.Validation;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using DataAnnotations = System.ComponentModel.DataAnnotations;

namespace Microservice.Tests.Services
{
    public class CrudServiceTests : IDisposable
    {
        private MockRepository mockRepository;
        private Mock<IDataContext> dataContext;
        private Mock<DataModel> dataModel;
        private Mock<IValidator> validator;
        

        public CrudServiceTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            dataContext = mockRepository.Create<IDataContext>();
            dataModel = mockRepository.Create<DataModel>();
            validator = mockRepository.Create<IValidator>();           
        }

        [Fact]
        public async Task Add_ValidModel_ReturnsTrue()
        {
            // Arrange
            var service = MakeService();
            validator.Setup(x => x.TryValidateCreate(dataModel.Object, It.IsAny<List<DataAnnotations.ValidationResult>>())).Returns(true);
            dataContext.Setup(x => x.Add(dataModel.Object)).Returns(Task.FromResult(dataModel.Object));

            // Act
            var result = await service.Add(
                dataContext.Object,
                dataModel.Object,
                validator.Object);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Add_ValidModel_ReturnsNoErrors()
        {
            // Arrange
            var service = MakeService();
            validator.Setup(x => x.TryValidateCreate(dataModel.Object, It.IsAny<List<DataAnnotations.ValidationResult>>())).Returns(true);
            dataContext.Setup(x => x.Add(dataModel.Object)).Returns(Task.FromResult(dataModel.Object));

            // Act
            var result = await service.Add(
                dataContext.Object,
                dataModel.Object,
                validator.Object);

            // Assert
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task Add_ValidModel_ReturnsModel()
        {
            // Arrange
            var service = MakeService();
            validator.Setup(x => x.TryValidateCreate(dataModel.Object, It.IsAny<List<DataAnnotations.ValidationResult>>())).Returns(true);
            dataContext.Setup(x => x.Add(dataModel.Object)).Returns(Task.FromResult(dataModel.Object));

            // Act
            var result = await service.Add(
                dataContext.Object,
                dataModel.Object,
                validator.Object);

            // Assert
            Assert.Equal(dataModel.Object,result.Result);
        }

        [Fact]
        public async Task Add_InvalidModel_ReturnsFalse()
        {
            // Arrange
            var service = MakeService();
            validator.Setup(x => x.TryValidateCreate(dataModel.Object, It.IsAny<List<DataAnnotations.ValidationResult>>()))
                .Callback<DataModel, List<DataAnnotations.ValidationResult>>((x, y) => { y.Add(new DataAnnotations.ValidationResult("")); })
                .Returns(false);

            // Act
            var result = await service.Add(
                dataContext.Object,
                dataModel.Object,
                validator.Object);

            // Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Add_InvalidModel_ReturnsErrors()
        {
            // Arrange
            var service = MakeService();
            validator.Setup(x => x.TryValidateCreate(dataModel.Object, It.IsAny<List<DataAnnotations.ValidationResult>>()))
                .Callback<DataModel, List<DataAnnotations.ValidationResult>>((x, y) => { y.Add(new DataAnnotations.ValidationResult("")); })
                .Returns(false);

            // Act
            var result = await service.Add(
                dataContext.Object,
                dataModel.Object,
                validator.Object);

            // Assert
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public async Task Add_InvalidModel_ReturnsNoModel()
        {
            // Arrange
            var service = MakeService();
            validator.Setup(x => x.TryValidateCreate(dataModel.Object, It.IsAny<List<DataAnnotations.ValidationResult>>()))
                .Callback<DataModel, List<DataAnnotations.ValidationResult>>((x, y) => { y.Add(new DataAnnotations.ValidationResult("")); })
                .Returns(false);

            // Act
            var result = await service.Add(
                dataContext.Object,
                dataModel.Object,
                validator.Object);

            // Assert
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task Update_ValidModel_ReturnsTrue()
        {
            // Arrange
            var service = MakeService();
            validator.Setup(x => x.TryValidateUpdate(dataModel.Object, It.IsAny<List<DataAnnotations.ValidationResult>>())).Returns(true);
            dataContext.Setup(x => x.Update(dataModel.Object)).Returns(Task.FromResult(dataModel.Object));

            // Act
            var result = await service.Update(
                dataContext.Object,
                dataModel.Object,
                validator.Object);

            // Assert
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Update_ValidModel_ReturnsNoErrors()
        {
            // Arrange
            var service = MakeService();
            validator.Setup(x => x.TryValidateUpdate(dataModel.Object, It.IsAny<List<DataAnnotations.ValidationResult>>())).Returns(true);
            dataContext.Setup(x => x.Update(dataModel.Object)).Returns(Task.FromResult(dataModel.Object));

            // Act
            var result = await service.Update(
                dataContext.Object,
                dataModel.Object,
                validator.Object);

            // Assert
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task Update_ValidModel_ReturnsModel()
        {
            // Arrange
            var service = MakeService();
            validator.Setup(x => x.TryValidateUpdate(dataModel.Object, It.IsAny<List<DataAnnotations.ValidationResult>>())).Returns(true);
            dataContext.Setup(x => x.Update(dataModel.Object)).Returns(Task.FromResult(dataModel.Object));

            // Act
            var result = await service.Update(
                dataContext.Object,
                dataModel.Object,
                validator.Object);

            // Assert
            Assert.Equal(dataModel.Object, result.Result);
        }

        [Fact]
        public async Task Update_InvalidModel_ReturnsFalse()
        {
            // Arrange
            var service = MakeService();
            validator.Setup(x => x.TryValidateUpdate(dataModel.Object, It.IsAny<List<DataAnnotations.ValidationResult>>()))
                .Callback<DataModel, List<DataAnnotations.ValidationResult>>((x, y) => { y.Add(new DataAnnotations.ValidationResult("")); })
                .Returns(false);

            // Act
            var result = await service.Update(
                dataContext.Object,
                dataModel.Object,
                validator.Object);

            // Assert
            Assert.False(result.Success);
        }

        [Fact]
        public async Task Update_InvalidModel_ReturnsErrors()
        {
            // Arrange
            var service = MakeService();
            validator.Setup(x => x.TryValidateUpdate(dataModel.Object, It.IsAny<List<DataAnnotations.ValidationResult>>()))
                .Callback<DataModel, List<DataAnnotations.ValidationResult>>((x, y) => { y.Add(new DataAnnotations.ValidationResult("")); })
                .Returns(false);

            // Act
            var result = await service.Update(
                dataContext.Object,
                dataModel.Object,
                validator.Object);

            // Assert
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public async Task Update_InvalidModel_ReturnsNoModel()
        {
            // Arrange
            var service = MakeService();
            validator.Setup(x => x.TryValidateUpdate(dataModel.Object, It.IsAny<List<DataAnnotations.ValidationResult>>()))
                .Callback<DataModel, List<DataAnnotations.ValidationResult>>((x, y) => { y.Add(new DataAnnotations.ValidationResult("")); })
                .Returns(false);

            // Act
            var result = await service.Update(
                dataContext.Object,
                dataModel.Object,
                validator.Object);

            // Assert
            Assert.Null(result.Result);
        }



        public void Dispose()
        {
            mockRepository.VerifyAll();
        }

       
        private CrudService MakeService()
        {
            return new CrudService();
        }

        private static List<DataAnnotations.ValidationResult> GetEmptyValidationResults()
        {
            return new List<DataAnnotations.ValidationResult>();
        }
        private static List<DataAnnotations.ValidationResult> GetFullValidationResults()
        {
            return new List<DataAnnotations.ValidationResult>(new[] { new DataAnnotations.ValidationResult("") });
        }
    }
}
