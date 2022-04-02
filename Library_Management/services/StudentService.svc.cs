using Library_Management.dtos;
using Library_Management.EncryptDecrypt;
using Library_Management.interfaces;
using Library_Management.models;
using Library_Management.validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Authentication;
using System.ServiceModel;
using System.Text;

namespace Library_Management.services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StudentService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select StudentService.svc or StudentService.svc.cs at the Solution Explorer and start debugging.
    public class StudentService : IStudentService
    {
        public StudentDto getUser(int rollno)
        {
            try
            {
                AppDbContext context = new AppDbContext();
                Student student = context.Students.Where(u => u.RollNo==rollno).FirstOrDefault();
                StudentDto studentDto = new StudentDto
                {
                    Id = student.Id,
                    CollegeId = student.CollegeId,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                };
                
                return studentDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        public StudentDto GetUserByToken(string token)
        {
            try
            {
                AppDbContext context = new AppDbContext();
                DatabaseTokenValidator tokenValidator = new DatabaseTokenValidator(context);
                if (tokenValidator.IsValid(token))
                {
                    Student student = context.Tokens.Where(t => t.SecureToken == token).FirstOrDefault().Student;
                    StudentDto studentDto = new StudentDto
                    {
                        Id = student.Id,
                        CollegeId = student.CollegeId,
                        FirstName = student.FirstName,
                        LastName = student.LastName
                    };
                    return studentDto;
                }
                throw new InvalidCredentialException("Invalid token");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool isValidToken(string token)
        {
            AppDbContext dbContext = new AppDbContext();
            DatabaseTokenValidator tokenValidator = new DatabaseTokenValidator(dbContext);
            return tokenValidator.IsValid(token);

        }

        public string Login(Credentials creds)
        {
            try
            {
                AppDbContext context = new AppDbContext();
                ICredentialsValidator validator = new DatabaseCredentialsValidator(context);
                if (validator.IsValid(creds))
                {
                    return new DatabaseTokenBuilder(context).Build(creds);
                }
                throw new InvalidCredentialException("Invalid credentials");
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string Register(Student student)
        {
            try
            {
                AppDbContext context = new AppDbContext();
                student.Salt = "dgsje";
                student.CollegeId = DateTime.Now.Year+student.Branch+RandomString(3)+student.RollNo;
                student.Password = Hash.Get(student.Password + student.Salt, Hash.DefaultHashType, Hash.DefaultEncoding);
                context.Students.Add(student);
                context.SaveChanges();
                return student.CollegeId;
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
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }
    }
}
