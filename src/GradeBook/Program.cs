using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      IBook book = new DiskBook("Forest's Grade Book");
      book.GradeAdded += OnGradeAdded;

      EnterGrades(book);

      var stats = book.GetStatistics();

      System.Console.WriteLine($"For the Book named {book.Name}");
      System.Console.WriteLine($"The average grade is {stats.Average:N2}");
      System.Console.WriteLine($"The highest grade is {stats.High:N2}");
      System.Console.WriteLine($"The lowest grade is {stats.Low:N2}");
      System.Console.WriteLine($"The letter is {stats.Letter}");
    }

    private static void EnterGrades(IBook book)
    {
      var done = false;
      while (!done)
      {
        Console.WriteLine("Please enter a grade or press q to exit");
        var userGradeInput = Console.ReadLine();

        if (userGradeInput == "q")
        {
          done = true;
          continue;
        }
        try
        {
          var grade = double.Parse(userGradeInput);
          book.AddGrade(grade);
        }
        catch (ArgumentException ex)
        {
          Console.Write(ex.Message);
        }
        finally
        {
          Console.WriteLine("**");
        }
      };
    }

    static void OnGradeAdded(object sender, EventArgs e)
    {
      Console.WriteLine("A grade was added");
    }
  }
}
