using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using Utilities;

namespace ISRA_Class_Library
{
    class ISRA_ID_Generator
    {
        Connection objDB = new Connection();
        private string Generator()
        {
            StoredProcedure command = new StoredProcedure();
            string id;
            Random random = new Random();
            id = random.Next(int.MinValue, int.MaxValue).ToString("x");
            int idCount = (int)objDB.ExecuteScalarFunction(command.ISRA_ID_DuplicationPrevention(id));

            return idCount > 0 ? Generator() : id;
        }

    }
}
