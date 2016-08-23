using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
   public class conexionsql
    {
        public static string sqlcon = Properties.Settings.Default.cnn;
    }
}
