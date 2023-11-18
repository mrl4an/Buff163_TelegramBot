using Microsoft.Graph;
using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Net;

namespace Buff163_TelegramBot
{
    internal class Program
    {
        public static List<string> WeaponLink_List = new List<string>()
        {
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921424",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921550",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921492",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921530",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921552",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921481",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921533",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921553",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921523",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921562",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781536",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781555",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781626",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781616",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781560",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781629",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781610",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781660",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900511",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900466",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900603",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900470",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900607",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900492",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900565",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=36444",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35739",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=33821",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=34481",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=36589",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35801",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35006",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=36442",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35898",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=763278",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=763335",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=763256",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921523",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921553",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921562",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=921576",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900529",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=900565",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=887070",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=871431",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=871746",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=871636",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=871340",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=857690",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=835670",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=835906",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=835780",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781610",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781629",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781560",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781649",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=781660",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=775807",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=773706",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=773667",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=773668",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=763335",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=763278",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=763256",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=763311",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=759249",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=759275",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=759363",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=759243",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=45261",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=34088",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=34359",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=42191",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35942",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=36359",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=33910",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=34431",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=34083",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35827",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=33945",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35326",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=42181",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35207",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=34832",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=36528",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=36458",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=34095",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=33859",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35190",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=36114",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=34399",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=34733",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=927380",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=927389",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=927390",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=927375",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=927385",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=871596",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=871548",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=871122",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=871680",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=871291",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=871288",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=871289",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=835860",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=835877",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=835856",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=36008",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=34439",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=34891",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=42037",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35470",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=36168",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35374",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=35906",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=36497",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=42157",
@"https://buff.163.com/api/market/goods/sell_order?game=csgo&goods_id=34706"
        };//ссылки предварительно обработаны для использования встроеннного API

        public static List<WebProxy> ProxyList = new List<WebProxy>()
        {
            new WebProxy{
            Address = new Uri($"http://5.101.80.210:8000"),
    BypassProxyOnLocal = false,
    UseDefaultCredentials = false,
    
    // Proxy credentials
    Credentials = new NetworkCredential(
        userName: "g33PuE",
        password: "x1JAqg")
            },
            new WebProxy{
            Address = new Uri($"http://5.101.81.97:8000"),
    BypassProxyOnLocal = false,
    UseDefaultCredentials = false,
    
    // Proxy credentials
    Credentials = new NetworkCredential(
        userName: "g33PuE",
        password: "x1JAqg")
            },
            new WebProxy{
            Address = new Uri($"http://5.101.84.3:8000"),
    BypassProxyOnLocal = false,
    UseDefaultCredentials = false,
    
    // Proxy credentials
    Credentials = new NetworkCredential(
        userName: "g33PuE",
        password: "x1JAqg")
            },
            new WebProxy{
            Address = new Uri($"http://5.101.84.235:8000"),
    BypassProxyOnLocal = false,
    UseDefaultCredentials = false,
    
    // Proxy credentials
    Credentials = new NetworkCredential(
        userName: "g33PuE",
        password: "x1JAqg")
            },
            new WebProxy{
            Address = new Uri($"http://5.101.84.171:8000"),
    BypassProxyOnLocal = false,
    UseDefaultCredentials = false,
    
    // Proxy credentials
    Credentials = new NetworkCredential(
        userName: "g33PuE",
        password: "x1JAqg")
            }

        };

        public static void sql_sender(BuffItem item)
        {
            try
            {

                MySqlConnection conn = new MySqlConnection(config.Sql_con);
                conn.Open();
                string sql = $"SELECT EXISTS(SELECT id FROM `Buff163_base` WHERE `paintwear` = '{item.paintwear.ToString().Replace(',', '.')}')";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(0) == "0")
                    {
                        MySqlConnection conn2 = new MySqlConnection(config.Sql_con);
                        conn2.Open();
                        string sql2 = $"INSERT INTO `Buff163_base` (`paintwear`, `average_price`, `link_for_item`, `item_name`, `item_price`, `sended`) VALUES ('{item.paintwear.ToString().Replace(',', '.')}', '{item.item_steamprice.ToString().Replace(',', '.')}', '{item.link_for_item}', '{item.item_name}', '{item.actual_price.ToString().Replace(',', '.')}', '0')";
                        MySqlCommand command2 = new MySqlCommand(sql2, conn2);
                        command2.ExecuteNonQuery();
                        conn2.Close();
                    }
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static async Task webstream(string link, WebProxy proxyAddress)
        {
            try
            {
                #region
                
                // Create a client handler that uses the proxy
                var httpClientHandler = new HttpClientHandler
                {
                    Proxy = proxyAddress,
                };

                // Disable SSL verification
                httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                #endregion //proxy

                string web_page = link;
                HttpClient client = new HttpClient(handler: httpClientHandler, disposeHandler: true);
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
                    if (line.Contains("_bargain_price\": \""))
                    {
                        steam_price = line.Substring(line.IndexOf("ice\": \"") +7);
                        steam_price = steam_price.Substring(0, steam_price.IndexOf("\""));
                        steam_price = steam_price.Replace(".", ",");
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
                            string item_link = config.Buff_link + id_page + @"?from=market#tab=selling&min_paintwear=" + result[0] + @"&max_paintwear=" + result[0];
                            if (Convert.ToDouble(result[1]) > 0)
                                ItemList.Add(new BuffItem(id_page, Convert.ToDouble(result[0]), Convert.ToDouble(result[1]), item_link, Convert.ToDouble(steam_price), weapon_name));
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка при добавлении предмета");
                            ErrorCounter.ErrorAddItem++;
                        }
                    }

                }
                str.Close();
                sr.Close();
                foreach (BuffItem item in ItemList)
                {
                    try
                    {
                        if (Convert.ToDouble(steam_price) / 100 * (100 + config.Percent_ForBuy) > item.actual_price && config.float_for_buy> item.paintwear)
                        {
                            sql_sender(item);
                            Console.WriteLine(item.actual_price+" "+item.item_name);
                        }
                    }
                    catch(Exception ex) 
                    {
                        Console.WriteLine($"Неверная сумма: {steam_price}");
                        ErrorCounter.ErrorSUM++;
                    }
                   
                }
                ItemList = null;
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Ошибка при попытке подключения");
                ErrorCounter.ErrorConnection++;
                Console.WriteLine(ex.Message);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        static async Task Main(string[] args)
        {
            while (true)
            {
                Task task = null;
                int counter = 0;
                foreach (string link in WeaponLink_List)
                {
                    task = new Task(() => webstream(link, ProxyList[counter]));
                    task.Start();

                    counter++;
                    if (counter > ProxyList.Count-1)
                        counter = 0;

                    await Task.Delay(150);
                    
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Thread.Sleep(1000);

                Console.WriteLine($"Всего записей: {ErrorCounter.AllINT} ошибок {ErrorCounter.SumErrorINT(0)}");
                Console.WriteLine($"Проблем с подключением: {ErrorCounter.ErrorConnection}");
                Console.WriteLine($"Проблем с ценами: {ErrorCounter.ErrorSUM}");
                Console.WriteLine($"Проблем с добавлением предметов: {ErrorCounter.ErrorAddItem}");
            }
        }
    }
}
