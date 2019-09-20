using Microservice.Data;
using Microservice.Validation;
using Moq;
using System;
using Xunit;

namespace Microservice.Tests.Validation
{
    public class UpdateValidatorTests : IDisposable
    {
        private readonly MockRepository mockRepository;

        public UpdateValidatorTests()
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
            var UpdateValidator = MakeUpdateValidator();
            DataModel model = GetValidDataModel();

            // Act
            var result = UpdateValidator.ValidateModel(model);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Validate_WithInValidModel_ProducesErrors()
        {
            // Arrange
            var UpdateValidator = MakeUpdateValidator();
            DataModel model = GetInValidDataModel();

            // Act
            var result = UpdateValidator.ValidateModel(model);

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
        private IUpdateValidator MakeUpdateValidator()
        {
            return new UpdateValidator();
        }
    }
}
