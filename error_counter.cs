using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff163_TelegramBot
{
    internal class ErrorCounter
    {
        public static int AllINT { get; set; }
        public static int ErrorSUM { get; set; }
        public static int ErrorConnection { get; set; }
        public static int ErrorAddItem { get; set; }
        public static int SumErrorINT(int ErrorINT)
        {
            ErrorINT = ErrorSUM + ErrorConnection + ErrorAddItem;
            return ErrorINT;
        }
    }
}
