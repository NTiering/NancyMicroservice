using Microservice.Data;
using Microservice.Validation;
using Moq;
using System;
using System.Collections.Generic;
using DataAnnotations = System.ComponentModel.DataAnnotations;
using Xunit;

namespace Microservice.Tests.Validation
{
    public class ValidatorTests : IDisposable
    {
        private DataModel dataModel;
        private Mock<ICreateValidator> mockCreateValidator;
        private Mock<IDeleteValidator> mockDeleteValidator;
        private MockRepository mockRepository;

        private Mock<IUpdateValidator> mockUpdateValidator;
        public ValidatorTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            mockUpdateValidator = mockRepository.Create<IUpdateValidator>();
            mockCreateValidator = mockRepository.Create<ICreateValidator>();
            mockDeleteValidator = mockRepository.Create<IDeleteValidator>();
            dataModel = new DataModel();
        }

        public void Dispose()
        {
            mockRepository.VerifyAll();
        }


        [Fact]
        public void TryValidateUpdate_TryValidateUpdate_InvalidObjectReturnFalse()
        {
            // Arrange
            var validator = CreateValidator();
            mockUpdateValidator.Setup(x => x.ValidateModel(dataModel)).Returns(GetFullValidationResults());
            var validationResults = new List<DataAnnotations.ValidationResult>();

            // Act
            var result = validator.TryValidateUpdate(
                dataModel,
                validationResults);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TryValidateUpdate_TryValidateUpdate_InvalidObjectReturnsErrors()
        {
            // Arrange
            var validator = CreateValidator();
            mockUpdateValidator.Setup(x => x.ValidateModel(dataModel)).Returns(GetFullValidationResults());
            var validationResults = new List<DataAnnotations.ValidationResult>();

            // Act
            var result = validator.TryValidateUpdate(
                dataModel,
                validationResults);

            // Assert
            Assert.Single(validationResults);
        }

        [Fact]
        public void TryValidateUpdate_TryValidateUpdate_ValidObjectReturnNoErrors()
        {
            // Arrange
            var validator = CreateValidator();
            mockUpdateValidator.Setup(x => x.ValidateModel(dataModel)).Returns(new List<DataAnnotations.ValidationResult>());
            var validationResults = new List<DataAnnotations.ValidationResult>();

            // Act
            var result = validator.TryValidateUpdate(
                dataModel,
                validationResults);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void TryValidateUpdate_TryValidateUpdate_ValidObjectReturnTrue()
        {
            // Arrange
            var validator = CreateValidator();
            mockUpdateValidator.Setup(x => x.ValidateModel(dataModel)).Returns(GetEmptyValidationResults());
            var validationResults = new List<DataAnnotations.ValidationResult>();

            // Act
            var result = validator.TryValidateUpdate(
                dataModel,
                validationResults);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryValidateDelete_TryValidateDelete_InvalidObjectReturnFalse()
        {
            // Arrange
            var validator = CreateValidator();
            mockDeleteValidator.Setup(x => x.ValidateModel(dataModel)).Returns(GetFullValidationResults());
            var validationResults = new List<DataAnnotations.ValidationResult>();

            // Act
            var result = validator.TryValidateDelete(
                dataModel,
                validationResults);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TryValidateDelete_TryValidateDelete_InvalidObjectReturnsErrors()
        {
            // Arrange
            var validator = CreateValidator();
            mockDeleteValidator.Setup(x => x.ValidateModel(dataModel)).Returns(GetFullValidationResults());
            var validationResults = new List<DataAnnotations.ValidationResult>();

            // Act
            var result = validator.TryValidateDelete(
                dataModel,
                validationResults);

            // Assert
            Assert.Single(validationResults);
        }

        [Fact]
        public void TryValidateDelete_TryValidateDelete_ValidObjectReturnNoErrors()
        {
            // Arrange
            var validator = CreateValidator();
            mockDeleteValidator.Setup(x => x.ValidateModel(dataModel)).Returns(new List<DataAnnotations.ValidationResult>());
            var validationResults = new List<DataAnnotations.ValidationResult>();

            // Act
            var result = validator.TryValidateDelete(
                dataModel,
                validationResults);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void TryValidateDelete_TryValidateDelete_ValidObjectReturnTrue()
        {
            // Arrange
            var validator = CreateValidator();
            mockDeleteValidator.Setup(x => x.ValidateModel(dataModel)).Returns(GetEmptyValidationResults());
            var validationResults = new List<DataAnnotations.ValidationResult>();

            // Act
            var result = validator.TryValidateDelete(
                dataModel,
                validationResults);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void TryValidateCreate_TryValidateCreate_InvalidObjectReturnFalse()
        {
            // Arrange
            var validator = CreateValidator();
            mockCreateValidator.Setup(x => x.ValidateMode3l(dataModel)).Returns(GetFullValidationResults());
            var validationResults = new List<DataAnnotations.ValidationResult>();

            // Act
            var result = validator.TryValidateCreate(
                dataModel,
                validationResults);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void TryValidateCreate_TryValidateCreate_InvalidObjectReturnsErrors()
        {
            // Arrange
            var validator = CreateValidator();
            mockCreateValidator.Setup(x => x.ValidateMode3l(dataModel)).Returns(GetFullValidationResults());
            var validationResults = new List<DataAnnotations.ValidationResult>();

            // Act
            var result = validator.TryValidateCreate(
                dataModel,
                validationResults);

            // Assert
            Assert.Single(validationResults);
        }

        [Fact]
        public void TryValidateCreate_TryValidateCreate_ValidObjectReturnNoErrors()
        {
            // Arrange
            var validator = CreateValidator();
            mockCreateValidator.Setup(x => x.ValidateMode3l(dataModel)).Returns(new List<DataAnnotations.ValidationResult>());
            var validationResults = new List<DataAnnotations.ValidationResult>();

            // Act
            var result = validator.TryValidateCreate(
                dataModel,
                validationResults);

            // Assert
            Assert.Empty(validationResults);
        }

        [Fact]
        public void TryValidateCreate_TryValidateCreate_ValidObjectReturnTrue()
        {
            // Arrange
            var validator = CreateValidator();
            mockCreateValidator.Setup(x => x.ValidateMode3l(dataModel)).Returns(GetEmptyValidationResults());
            var validationResults = new List<DataAnnotations.ValidationResult>();

            // Act
            var result = validator.TryValidateCreate(
                dataModel,
                validationResults);

            // Assert
            Assert.True(result);
        }
        private static List<DataAnnotations.ValidationResult> GetEmptyValidationResults()
        {
            return new List<DataAnnotations.ValidationResult>();
        }
        private static List<DataAnnotations.ValidationResult> GetFullValidationResults()
        {
            return new List<DataAnnotations.ValidationResult>(new[] { new DataAnnotations.ValidationResult("") });
        }
        private IValidator CreateValidator()
        {
            return new Validator(
                mockUpdateValidator.Object,
                mockCreateValidator.Object,
                mockDeleteValidator.Object);
        }
    }
}
