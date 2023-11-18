using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff163_TelegramBot
{
    internal class config
    {
        public static string Buff_link = @"https://buff.163.com/goods/";
        public static double Percent_ForBuy = 10;//в качестве разграничителя используется запятая(например 10,1)
        public static string Sql_con = @"server=mailoi4r.beget.tech;user=mailoi4r_plus;database=mailoi4r_plus;password=ESGnWzIIe22;";
        public static double float_for_buy = 0.01;
    }
}
