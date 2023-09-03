using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolcenData.Items;
using WolcenData.Items.Subclass_Items;
using WolcenData.Items.Magic;

namespace WolcenData
{
    public class InventoryEquipped
    {
        public int BodyPart { get; set; }
        public Item Item { get; set; }

        public static List<InventoryEquipped> ReadJson(JArray jArray)
        {
            List<InventoryEquipped> inventoryEquipped = new List<InventoryEquipped>();
            foreach (var item in jArray)
            {
                InventoryEquipped inventoryEquippedItem = new InventoryEquipped()
                {
                    BodyPart = item["BodyPart"].ToObject<int>()
                };
                JObject jObject = (JObject)item;
                jObject.Remove("BodyPart");
                inventoryEquippedItem.Item = Item.CreateItem((JObject)jObject);
                inventoryEquipped.Add(inventoryEquippedItem);
            }
            return inventoryEquipped;
        }

        public JObject WriteJson()
        {
            JObject jObject = new JObject
            {
                { "BodyPart", BodyPart }
            };
            jObject.Merge(Item.WriteJson());
            return jObject;
        }
    }
}
