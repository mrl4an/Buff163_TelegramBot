using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff163_TelegramBot
{
   
    public class BuffItem
    {
        public int id_item { get; set; }
        public double paintwear { get; set; }
        public double actual_price {  get; set; }
        public string link_for_item { get; set; }

        public string item_name { get; set; }
        public double item_steamprice { get; set; }
        public BuffItem(int id_item, double paintwear, double actual_price, string link_for_item, double item_steamprice, string item_name)
        {
            this.id_item = id_item;
            this.paintwear = paintwear;
            this.actual_price = actual_price;
            this.link_for_item = link_for_item;
            this.item_steamprice = item_steamprice;
            this.item_name = item_name;
        }
    }
    /*public class Weapon
    {
        public int id_weapon { get; set; }
        public double min_wear { get; set; }
        public double max_wear { get;set; }
        public double BuyPercent { get; set; }
        public Weapon(int id_weapon, double min_wear, double max_wear, double buyPercent)
        {
            this.id_weapon = id_weapon;
            this.min_wear = min_wear;
            this.max_wear = max_wear;
            BuyPercent = buyPercent;
        }
       
    }*/
    
}
