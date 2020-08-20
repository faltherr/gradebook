using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesStatistics()
        {
          // Arrange 
          var book = new InMemoryBook("");
          book.AddGrade(90.0);
          book.AddGrade(80.0);
          book.AddGrade(70.0);

          // Act
          var result = book.GetStatistics();
          
          // Assert
          Assert.Equal(80.0, result.Average, 1);
          Assert.Equal(90.0, result.High, 1);
          Assert.Equal(70.0, result.Low, 1);
          Assert.Equal('B', result.Letter);
        }
        // [Fact]
        // public void BookCannotAddGradeGreaterThan100()
        // {
        //   var book = new Book("test");
        //   book.AddGrade(105.1);
        //   var result = book.GetStatistics();
        //   Assert.Equal(NaN, result.Average);
        // }
    }
}
