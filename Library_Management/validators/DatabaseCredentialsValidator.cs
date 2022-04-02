using Library_Management.dtos;
using Library_Management.EncryptDecrypt;
using Library_Management.interfaces;
using Library_Management.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management.validators
{
    public class DatabaseCredentialsValidator : ICredentialsValidator
    {
        private readonly AppDbContext _context;
        public DatabaseCredentialsValidator(AppDbContext context)
        {
            _context = context;
        }
        public bool IsValid(Credentials cred)
        {
            Student student=  _context.Students.SingleOrDefault(x => x.CollegeId.Equals(cred.CollegeId, StringComparison.CurrentCultureIgnoreCase));

            return student != null && Hash.Compare(cred.Password, student.Salt, student.Password,
                Hash.DefaultHashType, Hash.DefaultEncoding);
        }
    }
}