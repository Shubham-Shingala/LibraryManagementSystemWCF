using Library_Management.dtos;
using Library_Management.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Library_Management.services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStudentService" in both code and config file together.
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        string Login(Credentials creds);
        [OperationContract]
        string Register(Student student);
        [OperationContract]
        StudentDto getUser(int rollNo);
        [OperationContract]
        StudentDto GetUserByToken(string token);
        [OperationContract]
        bool isValidToken(string token);
    }
}
