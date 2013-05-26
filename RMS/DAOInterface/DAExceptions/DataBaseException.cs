using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOInterface.DAExceptions
{
    public class DataBaseException : ApplicationException
    {
        public DataBaseException(string message)
            : base(message)
        {
        }

        public DataBaseException(string message, Exception ex)
            : base(message, ex)
        {
        }
    }
}
