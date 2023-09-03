using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using WolcenData.Cosmetics;

namespace WolcenData
{
    public class CharacterData
    {
        [JsonIgnore]
        public string FilePath { get; set; }

        public string Name { get; set; }
        public string PlayerId { get; set; }
        public string CharacterId { get; set; }
        public int DifficultyMode { get; set; }
        public int League { get; set; }
        public string UpdatedAt { get; set; }
        public CharacterCustomization CharacterCustomization { get; set; }
        public Stats Stats { get; set; }
        public List<UnlockedSkill> UnlockedSkills { get; set; }
        public List<SkillBar> SkillBar { get; set; }
        public List<object> PassiveSkills { get; set; }
        public List<BeltConfig> BeltConfig { get; set; }
        public Progression Progression { get; set; }
        public Telemetry.Telemetry Telemetry { get; set; }
        public Versions Versions { get; set; }
        public CharacterCosmeticInventory CharacterCosmeticInventory { get; set; }
        public List<InventoryGrid> InventoryGrid { get; set; }
        public List<InventoryEquipped> InventoryEquipped { get; set; }
        public List<InventoryBelt> InventoryBelt { get; set; }
        public List<PSTConfig> PSTConfig { get; set; }
        public ApocalypticData ApocalypticData { get; set; }
        public PetsData PetsData { get; set; }
        public List<Tutorials> Tutorials { get; set; }
        public LastGameParameters LastGameParameters { get; set; }
        public CityBuilding CityBuilding { get; set; }
        public Pro Pro { get; set; }
        public RewardsClass Rewards { get; set; }

        public CharacterData(string filePath)
        {
            FilePath = filePath;
            string json = File.ReadAllText(FilePath);
            JObject jObject = JObject.Parse(json);

            Name = jObject["Name"].ToObject<string>();
            PlayerId = jObject["PlayerId"].ToObject<string>();
            CharacterId = jObject["CharacterId"].ToObject<string>();
            DifficultyMode = jObject["DifficultyMode"].ToObject<int>();
            League = jObject["League"].ToObject<int>();
            UpdatedAt = jObject["UpdatedAt"].ToObject<string>();
            CharacterCustomization = jObject["CharacterCustomization"].ToObject<CharacterCustomization>();
            Stats = jObject["Stats"].ToObject<Stats>();
            UnlockedSkills = jObject["UnlockedSkills"].ToObject<List<UnlockedSkill>>();
            SkillBar = jObject["SkillBar"].ToObject<List<SkillBar>>();
            PassiveSkills = jObject["PassiveSkills"].ToObject<List<object>>();
            BeltConfig = jObject["BeltConfig"].ToObject<List<BeltConfig>>();
            Progression = jObject["Progression"].ToObject<Progression>();
            Telemetry = jObject["Telemetry"].ToObject<Telemetry.Telemetry>();
            Versions = jObject["Versions"].ToObject<Versions>();
            CharacterCosmeticInventory = jObject["CharacterCosmeticInventory"].ToObject<CharacterCosmeticInventory>();
            InventoryGrid = WolcenData.InventoryGrid.ReadJson((JArray)jObject["InventoryGrid"]);
            InventoryEquipped = WolcenData.InventoryEquipped.ReadJson((JArray)jObject["InventoryEquipped"]);
            InventoryBelt = WolcenData.InventoryBelt.ReadJson((JArray)jObject["InventoryBelt"]);
            PSTConfig = jObject["PSTConfig"].ToObject<List<PSTConfig>>();
            ApocalypticData = jObject["ApocalypticData"].ToObject<ApocalypticData>();
            PetsData = jObject["PetsData"].ToObject<PetsData>();
            Tutorials = jObject["Tutorials"].ToObject<List<Tutorials>>();
            LastGameParameters = jObject["LastGameParameters"].ToObject<LastGameParameters>();
            CityBuilding = jObject["CityBuilding"].ToObject<CityBuilding>();
            Pro = jObject["pro"]?.ToObject<Pro>() ?? new Pro();
            Rewards = jObject["Rewards"].ToObject<RewardsClass>();

            jObject = null;
        }

        public void Save()
        {
            // Create a backup of the original file
            string backupFilePath = GenerateBackupFilePath(FilePath, ".bak");

            File.Copy(FilePath, backupFilePath, true);

            DateTime dateTime = new DateTime(DateTime.Now.Ticks, DateTimeKind.Utc);
            UpdatedAt = dateTime.ToString("yy-MM-ddTHH:mm:ssZ");

            JArray invEquipped = new JArray();
            foreach (WolcenData.InventoryEquipped inventoryEquipped in InventoryEquipped)
            {
                invEquipped.Add(inventoryEquipped.WriteJson());
            }

            JArray invBelt = new JArray();
            foreach (WolcenData.InventoryBelt inventoryBelt in InventoryBelt)
            {
                invBelt.Add(inventoryBelt.WriteJson());
            }

            JArray invGrid = new JArray();
            foreach (WolcenData.InventoryGrid inventoryGrid in InventoryGrid)
            {
                invGrid.Add(inventoryGrid.WriteJson());
            }

            JObject jsonObject = new JObject
            {
                { "Name", Name },
                { "PlayerId", PlayerId },
                { "CharacterId", CharacterId },
                { "DifficultyMode", DifficultyMode },
                { "League", League },
                { "UpdatedAt", UpdatedAt },
                { "CharacterCustomization", JToken.FromObject(CharacterCustomization) },
                { "Stats", JToken.FromObject(Stats) },
                { "UnlockedSkills", JToken.FromObject(UnlockedSkills) },
                { "SkillBar", JToken.FromObject(SkillBar) },
                { "PassiveSkills", JToken.FromObject(PassiveSkills) },
                { "BeltConfig", JToken.FromObject(BeltConfig) },
                { "Progression", JToken.FromObject(Progression) },
                { "Telemetry", JToken.FromObject(Telemetry) },
                { "Versions", JToken.FromObject(Versions) },
                { "CharacterCosmeticInventory", JToken.FromObject(CharacterCosmeticInventory) },
                { "InventoryEquipped", invEquipped },
                { "InventoryGrid", invGrid },
                { "InventoryBelt", invBelt },
                { "PSTConfig", JToken.FromObject(PSTConfig) },
                { "ApocalypticData", JToken.FromObject(ApocalypticData) },
                { "PetsData", JToken.FromObject(PetsData) },
                { "Tutorials", JToken.FromObject(Tutorials) },
                { "LastGameParameters", JToken.FromObject(LastGameParameters) },
                { "CityBuilding", JToken.FromObject(CityBuilding) },
                { "pro", JToken.FromObject(Pro) },
                { "Rewards", JToken.FromObject(Rewards) }
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            RemoveNullProperties(jsonObject);

            string json = JsonConvert.SerializeObject(jsonObject, settings);

            File.WriteAllText(FilePath, json);
        }

        private string GenerateBackupFilePath(string originalPath, string extension)
        {
            string backupFilePath = $"{originalPath}{extension}";
            string backupDirectory = Path.GetDirectoryName(backupFilePath) + "\\Backups\\";
            string fileName = Path.GetFileName(backupFilePath);
            backupFilePath = backupDirectory + fileName;
            int counter = 1;

            while (File.Exists(backupFilePath))
            {
                backupFilePath = $"{backupFilePath}_{counter:D2}{extension}";
                counter++;
            }

            return backupFilePath;
        }


        public static void RemoveNullProperties(JToken token)
        {
            if (token.Type == JTokenType.Object)
            {
                var properties = token.Children<JProperty>().ToList();
                foreach (var property in properties)
                {
                    if (property.Value.Type == JTokenType.Null)
                    {
                        property.Remove();
                    }
                    else
                    {
                        RemoveNullProperties(property.Value);
                    }
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (var item in token.Children())
                {
                    RemoveNullProperties(item);
                }
            }
        }
    }

    public class IgnoreNullContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
            {
                property.ShouldSerialize = obj =>
                {
                    var value = member is PropertyInfo propInfo
                        ? propInfo.GetValue(obj)
                        : null;

                    return value != null;
                };
            }

            return property;
        }
    }
}