using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace mysqlefcore
{
  class Program
  {
    static void Main(string[] args)
    {
      //InsertData();
      //PrintData();
      InsertDataOtro();
      PrintDataOtro();
    }

    private static void InsertDataOtro()
    {
      using(var context = new LibraryContext())
      {

        // Creates the database if not exists
        context.Database.EnsureCreated();

        

                
        Random rnd = new Random();
        int next = rnd.Next(1, 1000);
        String temp="F";
        if((next%2)==0) temp = "M";
         
        context.Student.Add(new Student
        {
          FirstName = "Jose"+next,
          LastName = "Juarez"+next,
          Gender = temp,
          BirthDay = new DateTime(),
          Gratification = new decimal(100.4)
        });

        // Saves changes
        context.SaveChanges();

      }
    }

    private static void PrintDataOtro()
    {
      // Gets and prints all books in database
      using (var context = new LibraryContext())
      {
        var students = context.Student;
        foreach(var student in students)
        {
          var data = new StringBuilder();
          data.AppendLine($"ID: {student.ID}");
          data.AppendLine($"First Name: {student.FirstName}");
          data.AppendLine($"Last Name: {student.LastName}");
          data.AppendLine($"Gender: {student.Gender}");
          data.AppendLine($"Birth Day: {student.BirthDay}");
          data.AppendLine($"Gratification: {student.Gratification}");
          Console.WriteLine(data.ToString());
        }
      }
    }
    

    private static void InsertData()
    {
      using(var context = new LibraryContext())
      {
        // Creates the database if not exists
        context.Database.EnsureCreated();

        // Adds a publisher
        var publisher = new Publisher
        {
          Name = "Mariner Books"
        };
        context.Publisher.Add(publisher);

        Random rnd = new Random();
        int next = rnd.Next(1, 1000);

        // Adds some books
        context.Book.Add(new Book
        {
          ISBN = "978-0544003415"+next,
          Title = "The Lord of the Rings",
          Author = "J.R.R. Tolkien",
          Language = "English",
          Pages = 1216,
          Publisher = publisher
        });
        context.Book.Add(new Book
        {
          ISBN = "978-0547247762"+next,
          Title = "The Sealed Letter",
          Author = "Emma Donoghue",
          Language = "English",
          Pages = 416,
          Publisher = publisher
        });

        // Saves changes
        context.SaveChanges();
      }
    }

    private static void PrintData()
    {
      // Gets and prints all books in database
      using (var context = new LibraryContext())
      {
        var books = context.Book
          .Include(p => p.Publisher);
        foreach(var book in books)
        {
          var data = new StringBuilder();
          data.AppendLine($"ISBN: {book.ISBN}");
          data.AppendLine($"Title: {book.Title}");
          data.AppendLine($"Publisher: {book.Publisher.Name}");
          Console.WriteLine(data.ToString());
        }
      }
    }
  }
}

