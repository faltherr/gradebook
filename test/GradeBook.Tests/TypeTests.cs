using System;
using Xunit;

namespace GradeBook.Tests
{
  public delegate string WriteLogDelegate(string logMessage);

  public class TypeTests
  {
    int count = 0;

    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
      WriteLogDelegate log = ReturnMessage;
      log += ReturnMessage;
      log += IncrementCount;
      var result = log("Hello");
      Assert.Equal(3, count);
    }
    
    private string IncrementCount(string message)
    {
      count++;
      return message;
    }
    private string ReturnMessage(string message)
    {
      count++;
      return message;
    }

    [Fact]
    public void StringsBahaveLikeValueTypes()
    {
      string name = "Forest";
      name = MakeUppercase(name);
      Assert.Equal("FOREST", name);
    }

    private string MakeUppercase(string parameter)
    {
      return parameter.ToUpper();
    }

    [Fact]
    public void IntsAreValueTypes()
    {
      var x = GetInt();
      SetInt(ref x);
      Assert.Equal(42, x);
    }

    private void SetInt(ref int x)
    {
      x = 42;
    }

    private int GetInt()
    {
      return 3;
    }

    [Fact]
    public void cSharpCanPassByRef()
    {
      var book1 = GetBook("Book 1");
      GetBookSetName(ref book1, "New Name");
      Assert.Equal("New Name", book1.Name);
    }

    private void GetBookSetName(ref InMemoryBook book, string name)
    {
      book = new InMemoryBook(name);
    }
  
    [Fact]
    public void cSharpIsPassByValue()
    {
      var book1 = GetBook("Book 1");
      GetBookSetName(book1, "New Name");
      Assert.Equal("Book 1", book1.Name);
    }

    private void GetBookSetName(InMemoryBook book, string name)
    {
      book = new InMemoryBook(name);
    }

    [Fact]
    public void CanSetNameFromReference()
    {
      var book1 = GetBook("Book 1");
      SetName(book1, "New Name");
      Assert.Equal("New Name", book1.Name);
    }

    private void SetName(InMemoryBook book, string name)
    {
      book.Name = name;
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
      var book1 = GetBook("Book 1");
      var book2 = GetBook("Book 2");

      Assert.Equal("Book 1", book1.Name);
      Assert.Equal("Book 2", book2.Name);
    }

    [Fact]
    public void TwoVariablesCanReferenceSameObject()
    {
      var book1 = GetBook("Book 1");
      var book2 = book1;

      //Is the reference object the same
      Assert.Same(book2, book1);
      Assert.True(Object.ReferenceEquals(book2, book1));
    }

    InMemoryBook GetBook(string name)
    {
      return new InMemoryBook(name);
    }
  }
}
