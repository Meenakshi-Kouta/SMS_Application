using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Exceptions
{
    public class StudentException : ApplicationException
    {
        /// <summary>
        /// Custom Exceptio class created for student management system
        /// </summary>
        /// <param name="errorMsg"></param>
        public StudentException() : base()
        {

        }
        public StudentException(string errorMsg) : base(errorMsg)
        { 

        }
    }
}

