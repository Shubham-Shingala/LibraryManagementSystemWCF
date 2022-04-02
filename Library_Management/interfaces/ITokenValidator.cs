using Library_Management.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library_Management.interfaces
{
    interface ITokenValidator
    {
        bool IsValid(string token);
        Token token { get; set; }
    }
}