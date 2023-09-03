using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolcenData.Cosmetics
{
    public class CosmeticColors
    {
        public ColorSlotsClass ArmL { get; set; }
        public ColorSlotsClass ArmR { get; set; }
        public ColorSlotsClass Boots { get; set; }
        public ColorSlotsClass Chest { get; set; }
        public ColorSlotsClass Helmet { get; set; }
        public ColorSlotsClass Pant { get; set; }
        public ColorSlotsClass ShoulderL { get; set; }
        public ColorSlotsClass ShoulderR { get; set; }
    }

    public class ColorSlotsClass
    {
        public List<object> ColorSlots { get; set; }
    }
}
