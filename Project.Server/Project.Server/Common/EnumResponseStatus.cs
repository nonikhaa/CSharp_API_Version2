using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Server.Common
{
    public enum EnumResponseStatus
    {
        Success = 200,
        Failed = 99,
        DataAlreadyExists = 91
    }
}