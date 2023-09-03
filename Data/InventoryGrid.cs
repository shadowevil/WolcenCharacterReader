using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolcenData.Items;

namespace WolcenData
{
    public class InventoryGrid
    {
        public int InventoryX { get; set; }
        public int InventoryY { get; set; }
        public Item Item { get; set; }

        public static List<InventoryGrid> ReadJson(JArray jArray)
        {
            var json = new List<InventoryGrid>();
            if (jArray == null) return json;
            foreach(var jItem in jArray)
            {
                InventoryGrid invGrid = new InventoryGrid
                {
                    InventoryX = jItem["InventoryX"].ToObject<int>(),
                    InventoryY = jItem["InventoryY"].ToObject<int>()
                };
                JObject jObject = (JObject)jItem;
                jObject.Remove("InventoryX");
                jObject.Remove("InventoryY");
                invGrid.Item = Item.CreateItem(jObject);
                json.Add(invGrid);
            }
            return json;
        }

        public JObject WriteJson()
        {
            JObject jObject = new JObject
            {
                { "InventoryX", InventoryX },
                { "InventoryY", InventoryY }
            };
            jObject.Merge(Item.WriteJson());
            return jObject;
        }
    }
}
