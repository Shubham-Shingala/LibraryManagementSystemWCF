using Library_Management.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Library_Management.services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBookService" in both code and config file together.
    [ServiceContract(Name = "IBookService")]
    interface IBookService
    {
        [OperationContract]
        IEnumerable<Book> GetBooks();
        [OperationContract]
        Book GetBook(int id);
        [OperationContract]
        void AddBook(Book book);
        [OperationContract]
        void UpdateBook(Book book);
        [OperationContract]
        void DeleteBook(int id);
    }
}
