using Library_Management.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management.interfaces
{
    interface ITokenBuilder
    {
        string Build(Credentials cred);
    }
}
