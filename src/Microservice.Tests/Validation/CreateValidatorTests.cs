using Microservice.Data;
using Microservice.Validation;
using Moq;
using System;
using Xunit;

namespace Microservice.Tests.Validation
{
    public class CreateValidatorTests : IDisposable
    {
        private readonly MockRepository mockRepository;
               
        public CreateValidatorTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }

        public void Dispose()
        {
            mockRepository.VerifyAll();
        }       

        [Fact]
        public void Validate_WithValidModel_ProducesNoErrors()
        {
            // Arrange
            var createValidator = MakeCreateValidator();
            DataModel model = GetValidDataModel();

            // Act
            var result = createValidator.ValidateMode3l(model);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Validate_WithInValidModel_ProducesErrors()
        {
            // Arrange
            var createValidator = MakeCreateValidator();
            DataModel model = GetInValidDataModel();

            // Act
            var result = createValidator.ValidateMode3l(model);

            // Assert
            Assert.NotEmpty(result);
        }

        private DataModel GetValidDataModel()
        {
            return new DataModel();
        }

        private DataModel GetInValidDataModel()
        {
            return null;
        }
        private ICreateValidator MakeCreateValidator()
        {
            return new CreateValidator();
        }
    }
}
