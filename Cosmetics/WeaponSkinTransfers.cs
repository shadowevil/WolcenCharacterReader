using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolcenData.Cosmetics
{
    public class WeaponSkinTransfers
    {
        public IdsClass WeaponLeft { get; set; }
        public IdsClass WeaponRight { get; set; }
    }

    public class IdsClass
    {
        public Dictionary<string, object> Ids { get; set; }
    }
}
