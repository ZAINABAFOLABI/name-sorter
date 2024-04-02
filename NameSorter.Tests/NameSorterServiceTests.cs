using FluentAssertions;
using Moq;
using NameSorter.Core.Models;
using NameSorter.Core.Services;
using NameSorter.Core.Services.Interfaces;
using Xunit;


namespace NameSorter.Tests
{
    public class NameSorterServiceTests
    {
        [Fact]
        public async Task LoadNames_WhenTextFileIsEmpty_ShouldReturnEmptyCollection()
        {
            //Arrange
            var textReaderMock = GetTextReaderMock(validItemsCount: 0, invalidItemsCount: 0);
            var service = GetNameSorterService(textReaderMock);

            //Act
            var loadedNames = await service.LoadNamesAsync();

            //Assert
            loadedNames.Should().BeEmpty();

            textReaderMock.Verify(r => r.ReadTextAsync(), Times.Once);

     

        }

        [Theory]
        [InlineData(2, 5, 2)]
        [InlineData(3, 2, 3)]
        [InlineData(0, 3, 0)]
        public async Task LoadNames_WhenTextFileContainsInvalidNames_ShouldReturnOnlyValidNames(int validItemsCount, int invalidItemsCount, int expectedListCount)
        {
            //Arrange
            var textReaderMock = GetTextReaderMock(validItemsCount, invalidItemsCount);
            var service = GetNameSorterService(textReaderMock);

            //Act
            var loadedNames = await service.LoadNamesAsync();

            //Assert
            loadedNames.Should().HaveCount(expectedListCount);
            textReaderMock.Verify(r => r.ReadTextAsync(), Times.Once);   
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task LoadNames_WhenAllNamesAreValid_ShouldReturnAllNames(int validItemsCount)
        {
            //Arrange
            var textReaderMock = GetTextReaderMock(validItemsCount);
            var service = GetNameSorterService(textReaderMock);

            //Act
            var loadedNames = await service.LoadNamesAsync();

            //Assert
            loadedNames.Should().HaveCount(validItemsCount);
            textReaderMock.Verify(r => r.ReadTextAsync(), Times.Once);
        }

        [Fact]
        public async Task SortAndOutputNames_ShouldBeOrderedCorrectly_AndOutputWriterIsCalled()
        {
            //Arrange
            var textWriterMock = GetTextWriterMock();
            var service = GetNameSorterService(textWriterMock: textWriterMock);
            var personNames = GetPersonNameMockData().ToList();
            var newLine = Environment.NewLine;
            var expectedOrder = $"A B1{newLine}A B2{newLine}A B3{newLine}A B4";

            //Act
            await service.SortAndOutputNamesAsync(personNames);

            //Assert
            textWriterMock.Verify(r => r.WriteTextAsync(expectedOrder), Times.Once);
        }
        public INameSorterService GetNameSorterService(Mock<ITextReader>? textReaderMock = null, Mock<ITextWriter>? textWriterMock = null)
        {
            textReaderMock ??= GetTextReaderMock();
            textWriterMock ??= GetTextWriterMock();
            return new NameSorterService(textReaderMock.Object, textWriterMock.Object);
        }

        private Mock<ITextReader> GetTextReaderMock(int validItemsCount = 3, int invalidItemsCount = 0)
        {
            var reader = new Mock<ITextReader>();
            var validNames = Enumerable.Range(1, validItemsCount)
                .Select(i => $"firstName middleName lastName{i}");
            var invalidNames = Enumerable.Range(1, invalidItemsCount)
                .Select(i => $"lastName{i}");

            reader.Setup( r => r.ReadTextAsync())
                .ReturnsAsync(validNames.Concat(invalidNames).ToList())
                .Verifiable();
                           
            return reader;
        }

        private Mock<ITextWriter> GetTextWriterMock()
        {
            var writer = new Mock<ITextWriter>();
            writer.Setup(w => w.WriteTextAsync(It.IsAny<string>()))
                .Verifiable();

            return writer;
        }

        private IEnumerable<PersonName> GetPersonNameMockData()
        {
            yield return new PersonName(new[] { "A", "B2" });
            yield return new PersonName(new[] { "A", "B1" });
            yield return new PersonName(new[] { "A", "B4" });
            yield return new PersonName(new[] { "A", "B3" });
        }

    }       
}
