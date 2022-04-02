using Library_Management.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management.interfaces
{
    public interface ICredentialsValidator
    {
        bool IsValid(Credentials cred);
    }
}