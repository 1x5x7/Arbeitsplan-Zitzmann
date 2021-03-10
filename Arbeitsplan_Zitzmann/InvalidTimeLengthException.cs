using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbeitsplan_Zitzmann
{
    class InvalidTimeLengthException : Exception
    {
        public InvalidTimeLengthException() { }

        public InvalidTimeLengthException(string name)
            : base(String.Format("Invalid Time Length: {0}", name))
        {}

    }
}
