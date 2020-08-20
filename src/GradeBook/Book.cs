using System;
using System.Collections.Generic;

namespace GradeBook
{
  public delegate void GradeAddedDelegate(object sender, EventArgs args);

  public abstract class Book : NamedObject, IBook
  {
    protected Book(string name) : base(name)
    {
    }

    public abstract event GradeAddedDelegate GradeAdded;
    public abstract void AddGrade(double grade);
    public abstract Statistics GetStatistics();
  }
  public interface IBook
  {
    void AddGrade(double grade);
    Statistics GetStatistics();
    string Name {get;}
    event GradeAddedDelegate GradeAdded;
  }

  public class InMemoryBook : Book
  {
    public InMemoryBook(string name) : base(name)
    {
      // grades = new List<double>();
      Name = name;
    }
    
    public void AddGrade(char letter)
    {
      switch(letter)
      {
        case 'A':
          AddGrade(90);
          break;
        case 'B':
          AddGrade(80);
          break;
        case 'C':
          AddGrade(70);
          break;
        default:
          AddGrade(0);
          break;
      }
    }

    public override void AddGrade(double grade)
    {
      if (grade <= 100 && grade >= 0)
      {
        grades.Add(grade);
        if(GradeAdded != null)
        {
          GradeAdded(this, new EventArgs());
        }
      }
      else
      {
        throw new ArgumentException($"Invalid {nameof(grade)}");
      }
    }
    public override event GradeAddedDelegate GradeAdded;

    public override Statistics GetStatistics()
    {
      var result = new Statistics();

      // For each loop
      // foreach (var grade in grades)
      // {
      //   result.High = Math.Max(grade, result.High);
      //   result.Low = Math.Min(grade, result.Low);
      //   result.Average += grade;
      // }

      // While loop
      // var index = 0;
      // while (index < grades.Count)
      // {
      //   result.High = Math.Max(grades[index], result.High);
      //   result.Low = Math.Min(grades[index], result.Low);
      //   result.Average += grades[index];
      //   index += 1;
      // };

      // For loop
      for(var index=0; index < grades.Count; index += 1)
      {
        result.Add(grades[index]);
      }

      return result;
    }
    private List<double> grades;
    public const string CATEGORY = "Science";
  }
}