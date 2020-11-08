using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey
{
    class DBConnect
    {
        public static SqlConnection myCon = null;

        public void CreateConnection()
        {
            myCon = new SqlConnection("data source=(local);initial catalog=survey;persist security info=True;user id=sa;password=P@SSW0RD;pooling=False;MultipleActiveResultSets=True");
            myCon.Open();
        }

    }
}
