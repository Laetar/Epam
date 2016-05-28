using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace NoteSave
{
    static public class ConnectionString
    {
        public static string GetConnectionString()
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["FileDateBase"].ConnectionString;
            return connectionStringItem;
        }
    }
}
