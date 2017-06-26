using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SysAgropec.Class
{
    public class Banco
    {


        public Banco()
        {
        }



        public static string getConexao()
        {

            if (System.Diagnostics.Debugger.IsAttached)
            {
                return ConfigurationManager.ConnectionStrings["dbConnectionLocal"].ConnectionString;
            }
            else
            {
                return ConfigurationManager.ConnectionStrings["dbConnectionAzure"].ConnectionString;
            }
        }
    }
}