using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolcenData.Items;
using WolcenData.Items.Magic;
using WolcenData.Items.Subclass_Items;

namespace WolcenData
{
    public class InventoryBelt
    {
        public int BeltSlot { get; set; }
        public Item Item { get; set; }

        public static List<InventoryBelt> ReadJson(JArray jArray)
        {
            List<InventoryBelt> inventoryBelt = new List<InventoryBelt>();
            foreach (var item in jArray)
            {
                InventoryBelt inventoryBeltItem = new InventoryBelt()
                {
                    BeltSlot = item["BeltSlot"].ToObject<int>()
                };
                JObject jObject = (JObject)item;
                inventoryBeltItem.Item = Item.CreateItem(jObject);
                inventoryBelt.Add(inventoryBeltItem);
            }
            return inventoryBelt;
        }

        public JObject WriteJson()
        {
            JObject jObject = new JObject
            {
                { "BeltSlot", BeltSlot }
            };
            jObject.Merge(Item.WriteJson());
            return jObject;
        }
    }
}
