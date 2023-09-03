using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolcenData.Items.Magic
{
    public class MagicEffect
    {
        public List<Effect> Default { get; set; }
        public List<Affixes> RolledAffixes { get; set; }
    }

    public class Effect
    {
        public string EffectId { get; set; }
        public string EffectName { get; set; }
        public int MaxStack { get; set; }
        public int bDefault { get; set; }
        public List<EffectParameter> Parameters { get; set; }
    }

    public class Affixes
    {
        public string EffectId { get; set; }
        public string EffectName { get; set; }
        public int MaxStack { get; set; }
        public List<EffectParameter> Parameters { get; set; }
    }
}
