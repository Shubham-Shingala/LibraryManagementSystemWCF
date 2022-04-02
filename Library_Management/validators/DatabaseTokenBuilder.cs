using Library_Management.dtos;
using Library_Management.interfaces;
using Library_Management.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Web;

namespace Library_Management.validators
{
    public class DatabaseTokenBuilder : ITokenBuilder
    {
        public static int TokenSize = 100;
        private readonly AppDbContext _context;
        public DatabaseTokenBuilder(AppDbContext context)
        {
            _context = context;
        }
        string getToken(Student  student)
        {
            string secureToken = BuildSecureToken(TokenSize);
            _context.Tokens.Add(new Token
            {
                SecureToken = secureToken,
                Student = student,
                CreateDate = DateTime.Now
            });
            _context.SaveChanges();
            return secureToken;
        }

        public string Build(Credentials cred)
        {
            if (!new DatabaseCredentialsValidator(_context).IsValid(cred))
            {
                throw new AuthenticationException();
            }
            Student student = _context.Students.SingleOrDefault(x => x.CollegeId.Equals(cred.CollegeId, StringComparison.CurrentCultureIgnoreCase));

            Token token = _context.Tokens.Where<Token>(t => t.StudentId == student.Id).FirstOrDefault();
            if (token == null)
            {
                return getToken(student);
            }
            else if (DatabaseTokenValidator.IsExpired(token))
            {
                _context.Tokens.Remove(token);
                _context.SaveChanges();
                return getToken(student);
            }
            else
            {
                return token.SecureToken;
            }
        }

        private string BuildSecureToken(int length)
        {
            var buffer = new byte[length];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetNonZeroBytes(buffer);
            }
            return Convert.ToBase64String(buffer);
        }
    }
}