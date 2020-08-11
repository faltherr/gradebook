using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Program
  {
    static void Main(string[] args)
    {
      var book = new Book("Forest's Grade Book");
      book.AddGrade(88);
      book.AddGrade(90.5);
      book.AddGrade(77.3);
      book.ShowStatistics();
    }
  }
}
