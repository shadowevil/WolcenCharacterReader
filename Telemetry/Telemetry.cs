using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolcenData.Telemetry
{
    public class Telemetry
    {
        public string Version { get; set; }
        public Playtime Playtime { get; set; }
        public Playtime PlaytimeOutTown { get; set; }
        public List<KillCount> KillCountPerBossrank { get; set; }
        public List<KillCount> KillCountPerMobRankType { get; set; }
        public List<KillCount> DeathCountPerBossrank { get; set; }
        public List<ItemInfo> ItemsDropped { get; set; }
        public List<ItemInfo> ItemsPicked { get; set; }
        public List<ItemInfo> ItemsBought { get; set; }
        public List<ItemInfo> ItemsSold { get; set; }
        public List<ZoneInfo> TimeSpentPerZone { get; set; }
        public List<ZoneInfo> SoloReviveTokenUsedPerZone { get; set; }
        public List<ZoneInfo> SoloDeathPerZone { get; set; }
        public List<ZoneInfo> MultiRevivePerZone { get; set; }
        public List<SkillUsage> SkillUsage { get; set; }
        public CountInfo MinLevelKilled { get; set; }
        public CountInfo MaxLevelKilled { get; set; }
        public CountInfo DeathCount { get; set; }
        public CountInfo XpFromQuest { get; set; }
        public CountInfo XpFromKill { get; set; }
        public CountInfo GoldDropped { get; set; }
        public CountInfo GoldGainedQuests { get; set; }
        public CountInfo GoldGainedMerchant { get; set; }
        public CountInfo GoldPicked { get; set; }
        public CountInfo GoldSpent { get; set; }
        public CountInfo GoldSpentMerchant { get; set; }
        public CountInfo GoldSpentJewelerUnsocketItem { get; set; }
        public CountInfo PrimordialAffinitySpent { get; set; }
        public CountInfo PrimordialAffinitySpentSkillLevelUp { get; set; }
        public CountInfo PrimordialAffinityGained { get; set; }
        public CountInfo QuestAttempt_NPC2 { get; set; }
        public CountInfo QuestSuccess_NPC2 { get; set; }
        public CountInfo QuestFailed_NPC2 { get; set; }
        public CountInfo QuestMaxFloorReached_NPC2 { get; set; }
        public CountInfo UnlockChestCount { get; set; }
        public CountInfo ResetPSTCount { get; set; }
        public CountInfo ResetCharacterAttributesCount { get; set; }
    }
}
