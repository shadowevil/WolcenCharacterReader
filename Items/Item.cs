using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolcenData.Items.Subclass_Items;
using WolcenData.Items.Magic;
using Newtonsoft.Json.Linq;

namespace WolcenData.Items
{
    public enum ItemTypeEnum
    {
        Armor,
        Weapon,
        Potion,
        Enneract,
        Unknown
    }

    public class Item
    {
        public int Rarity { get; set; }
        public int Quality { get; set; }
        public int Type { get; set; }
        public string ItemType { get; set; }
        public string Value { get; set; }
        public int Level { get; set; }
        public Armor Armor { get; set; }
        public Weapon Weapon { get; set; }
        public Potion Potion { get; set; }
        public Enneract Enneract { get; set; }
        public MagicEffect MagicEffects { get; set; }

        public static Item CreateItem(JObject jObject)
        {
            return jObject.ToObject<Item>();
        }

        [JsonIgnore]
        public ItemTypeEnum ItemTypeCategory
        {
            get
            {
                if (Armor != null) return ItemTypeEnum.Armor;
                if (Weapon != null) return ItemTypeEnum.Weapon;
                if (Potion != null) return ItemTypeEnum.Potion;
                if (Enneract != null) return ItemTypeEnum.Enneract;
                return ItemTypeEnum.Unknown;
            }
        }

        public JObject WriteJson()
        {
            JObject json = JObject.FromObject(this);
            return json;
        }
    }
}
