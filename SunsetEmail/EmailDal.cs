using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SunsetEmail
{
    public class EmailDal
    {
        public static void Save(string email)
        {
            SqlHelper.Opertions("INSERT INTO EmailAddress VALUES('" + email + "')");
        }

        public static bool IsEmailExist(string email)
        {
            return SqlHelper.CheckHasRows("SELECT * FROM EmailAddress WHERE Email = '" + email + "'");
        }
    }

    
}