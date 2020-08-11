using System;
using System.Collections.Generic;

namespace GradeBook
{
  class Book
  {
    public Book(string name)
    {
      grades = new List<double>();
      this.name = name;
    }
    public void AddGrade(double grade)
    {
      grades.Add(grade);
    }
    public void ShowStatistics()
    {
      double sum = 0;
      var highGrade = double.MinValue;
      var lowGrade = double.MaxValue;
      foreach (var number in grades)
      {
        highGrade = Math.Max(number, highGrade);
        lowGrade = Math.Min(number, lowGrade);
        sum += number;
      }
      int listLength = grades.Count;
      double avgGrade = sum / listLength;
      System.Console.WriteLine($"The average grade is {avgGrade:N2}");
      System.Console.WriteLine($"The highest grade is {highGrade:N2}");
      System.Console.WriteLine($"The lowest grade is {lowGrade:N2}");
    }
    private List<double> grades;
    private string name;
  }
}