using Microservice.Data;
using Microservice.Validation;
using Moq;
using System;
using Xunit;

namespace Microservice.Tests.Validation
{
    public class DeleteValidatorTests : IDisposable
    {
        private readonly MockRepository mockRepository;

        public DeleteValidatorTests()
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
            var DeleteValidator = MakeDeleteValidator();
            DataModel model = GetValidDataModel();

            // Act
            var result = DeleteValidator.ValidateModel(model);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Validate_WithInValidModel_ProducesErrors()
        {
            // Arrange
            var DeleteValidator = MakeDeleteValidator();
            DataModel model = GetInValidDataModel();

            // Act
            var result = DeleteValidator.ValidateModel(model);

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
        private IDeleteValidator MakeDeleteValidator()
        {
            return new DeleteValidator();
        }
    }
}
