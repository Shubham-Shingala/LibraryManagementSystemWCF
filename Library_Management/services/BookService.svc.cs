using Library_Management.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Library_Management.services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookService.svc or BookService.svc.cs at the Solution Explorer and start debugging.
    public class BookService : IBookService
    {
        public void AddBook(Book book)
        {
            AppDbContext dbContext = new AppDbContext();
            try
            {
                dbContext.Books.Add(book);
                dbContext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public void DeleteBook(int id)
        {
            AppDbContext dbContext = new AppDbContext();
            Book book = dbContext.Books.Where<Book>(i => i.Id == id).FirstOrDefault();
            if (book != null)
            {
                dbContext.Books.Remove(book);
                dbContext.SaveChanges();
            }
            else
            {
                Exception exception = new Exception("entered id of book is not found");
                throw exception;
            }
        }

        public Book GetBook(int id)
        {
            AppDbContext dbContext = new AppDbContext();
            Book book = dbContext.Books.Where<Book>(i => i.Id == id).FirstOrDefault();
            if (book != null)
            {
                return book;
            }
            else
            {
                Exception exception = new Exception("entered id of book is not found");
                throw exception;
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            AppDbContext dbContext = new AppDbContext();
            books = dbContext.Books.ToList<Book>();
            return books;
        }

        public void UpdateBook(Book book)
        {
            AppDbContext dbContext = new AppDbContext();
            Book book1 = dbContext.Books.Where<Book>(i => i.Id == book.Id).FirstOrDefault();
            if (book1 != null)
            {
                book1.Name = book.Name;
                book1.Author = book.Author;
                book1.Category = book.Category;
                book1.Edition = book.Edition;
                book1.No_of_Available_Copy = book.No_of_Available_Copy;
                book1.No_of_Total_Copy = book.No_of_Total_Copy;
                dbContext.SaveChanges();
            }
            else
            {
                Exception exception = new Exception("entered book details is not found");
                throw exception;
            }
        }
    }
}
