using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace mysqlefcore
{
  public class Book
  {
    [MaxLength(36)]
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Language { get; set; }   
    public int Pages { get; set; }
    public virtual Publisher Publisher { get; set; }
  }

  public class Publisher
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
  }

}