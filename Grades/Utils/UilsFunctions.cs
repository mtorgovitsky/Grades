using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Utils
{
    public static class UilsFunctions
    {
        public static byte[] WriteAsBytes(int value)
        {
            return BitConverter.GetBytes(value);
        }
    }
}
