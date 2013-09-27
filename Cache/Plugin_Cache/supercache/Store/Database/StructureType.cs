using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STSdb4.Database
{
    public static class StructureType
    {
        //do not change
        public const int RESERVED = 0;

        public const int XINDEX = 1;
        public const int XFILE = 2;

        public static bool IsValid(int type)
        {
            if (type == XINDEX || type == XFILE)
                return true;

            return false;
        }
    }
}
