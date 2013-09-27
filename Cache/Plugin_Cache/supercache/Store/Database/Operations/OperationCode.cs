using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STSdb4.WaterfallTree;
using STSdb4.Data;

namespace STSdb4.Database.Operations
{
    public static class OperationCode
    {
        // XIndex
        public const int UNDEFINED = 0;

        public const int REPLACE = 1;
        public const int DELETE = 2;
        public const int DELETE_RANGE = 3;
        public const int INSERT_OR_IGNORE = 4;
        public const int READ = 5;
        public const int READ_RANGE = 6;
        public const int CLEAR = 7;
        public const int REFRESH = 8;
        public const int REFRESH_POINT = 9;
        public const int REFRESH_RANGE = 10;

        public const int TRY_GET = 11;
        public const int FORWARD = 12;
        public const int BACKWARD = 13;
        public const int FIND_NEXT = 14;
        public const int FIND_AFTER = 15;
        public const int FIND_PREV = 16;
        public const int FIND_BEFORE = 17;
        public const int FIRST_ROW = 18;
        public const int LAST_ROW = 19;
        public const int COUNT = 20;
        public const int EXCEPTION = 21;
        public const int STORAGE_ENGINE_COMMIT = 22;

        //user defined operations
        public const int USER = 65536;
    }    
}
