using Microsoft.Graph;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Buff163_TelegramBot
{
    internal class Program
    {
        public static List<string> WeaponLink_List = new List<string>()
        {
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921424&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921550&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921492&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921530&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921552&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921481&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921533&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921553&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921523&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921562&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781536&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781555&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781626&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781616&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781560&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781629&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781610&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781660&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900511&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900466&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900603&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900470&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900607&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900492&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900565&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=36444&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35739&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=33821&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=34481&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=36589&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35801&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35006&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=36442&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35898&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=763278&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=763335&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=763256&min_paintwear=0.00&max_paintwear=0.01",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921434&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921451&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921430&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921423&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921416&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921469&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921519&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921527&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781589&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781605&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781572&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781594&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781643&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781559&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781591&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900503&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900489&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900527&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900502&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900576&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900485&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900615&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=763311&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=871443&min_paintwear=0.07&max_paintwear=0.08",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921421&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921420&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921439&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921427&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921426&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921511&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921493&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921462&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921517&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921536&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921569&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781614&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781592&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781577&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781567&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781568&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900478&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900497&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900518&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=33960&min_paintwear=0.15&max_paintwear=0.18",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35002&min_paintwear=0.76&max_paintwear=0.80",
            @"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=34065&min_paintwear=0.90&max_paintwear=1.00"
        };//ссылки предварительно обработаны для использования встроеннного API
        public static async Task webstream(string link, double percentBuy)
        {
            try
            {
                string web_page = link;
                HttpClient client = new HttpClient();
                Stream str = await client.GetStreamAsync(web_page);
                StreamReader sr = new StreamReader(str);
                string line;

                List<BuffItem> ItemList = new List<BuffItem>();

                string[] result = new string[2];
                string weapon_name = "";//название оружия
                string steam_price = "";//цена в стиме
                int id_page = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("goods_id\": ")) 
                    {
                        string s = line.Substring(line.IndexOf("goods_id\": ")+10);
                        s = s.Substring(0, s.IndexOf(","));
                        id_page = int.Parse(s);
                    }
                    if (line.Contains("market_hash_name"))
                    {
                        weapon_name = line.Substring(line.IndexOf("h_name\": \"") + 10);
                        weapon_name = weapon_name.Substring(0, weapon_name.IndexOf("\""));
                        Console.WriteLine(weapon_name);
                    }
                    if (line.Contains("steam_price_cny"))
                    {
                        steam_price = line.Substring(line.IndexOf("e_cny\": \"") +9);
                        steam_price = steam_price.Substring(0, steam_price.IndexOf("\""));
                        steam_price = steam_price.Replace(".", ",");
                        Console.WriteLine(steam_price); 
                    }
                    if (line.Contains("asset_info"))
                    {
                        result[0] = "";
                        result[1] = "";
                    }
                    if (line.Contains("paintwear"))
                    {
                        string subString = line.Substring(line.IndexOf("wear\": \"") + 8);
                        subString = subString.Substring(0, subString.IndexOf("\""));
                        subString = subString.Replace(".",",");
                        result[0] = subString;
                    }
                    if (line.Contains("\"price\":"))
                    {
                        ErrorCounter.AllINT++;
                        string subString = line.Substring(line.IndexOf("ce\": \"") + 6);
                        subString = subString.Substring(0, subString.IndexOf("\""));
                        subString = subString.Replace(".", ",");
                        result[1] = subString;
                        try
                        {
                            string item_link = config.Buff_link + id_page + @"&min_paintwear=" + result[0] + @"&max_paintwear=" + result[0];
                            ItemList.Add(new BuffItem(id_page, Convert.ToDouble(result[0]), Convert.ToDouble(result[1]), item_link));
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка при добавлении предмета");
                            ErrorCounter.ErrorAddItem++;
                        }
                    }

                }
                str.Close();
                foreach (BuffItem item in ItemList)
                {
                    try
                    {
                        if (Convert.ToDouble(steam_price) / 100 * (100 + percentBuy) > item.actual_price)
                        {
                            Console.WriteLine(item.actual_price+" "+item.link_for_item);
                        }
                    }
                    catch(Exception ex) 
                    {
                        Console.WriteLine($"Неверная сумма: {steam_price}");
                        ErrorCounter.ErrorSUM++;
                    }
                   
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Ошибка при попытке подключения");
                ErrorCounter.ErrorConnection++;
                Console.WriteLine(ex.Message);
            }   
        }
        static async Task Main(string[] args)
        {
            while (true)
            {
                foreach (string link in WeaponLink_List)
                {
                    await webstream(link, config.Percent_ForBuy);
                }
                Console.WriteLine($"Всего записей: {ErrorCounter.AllINT} ошибок {ErrorCounter.SumErrorINT(0)}");
                Console.WriteLine($"Проблем с подключением: {ErrorCounter.ErrorConnection}");
                Console.WriteLine($"Проблем с ценами: {ErrorCounter.ErrorSUM}");
                Console.WriteLine($"Проблем с добавлением предметов: {ErrorCounter.ErrorAddItem}");
                Thread.Sleep( 1000 );
            }
            Console.ReadLine();
        }
    }
}
