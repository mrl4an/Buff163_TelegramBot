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
        public static string Buff_link = @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=";
        public static double Percent_ForBuy = 10;//в качестве разграничителя используется запятая(например 10,1)
        //public static string listPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.Length - 10), @"List_of_Weapon.txt");
    }
}
