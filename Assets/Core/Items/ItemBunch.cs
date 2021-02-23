using System;

namespace FactoryStarter.Core.Items
{
    internal class ItemBunch
    {
        internal readonly ItemType Type;
        internal int Count;

        internal ItemBunch(){}
        internal ItemBunch(ItemBunchDto bunchDto, TypeRepository types)
        {
            Type = types.GetItemType(bunchDto.TypeId);
            Count = bunchDto.Count;
        }

        internal ItemBunch(ItemType type, int count) {
            Type = type;
            Count = count;
        }

        internal int RequiredCapacity => Count == 0 ? 0 : (Count - 1) / Type.CountPerSlot + 1;

        public static ItemBunch operator +(ItemBunch left, ItemBunch right) {
            if (left.Type != right.Type) throw new Exception("Different types");
            return new ItemBunch(left.Type, left.Count + right.Count);
        }
        public static ItemBunch operator -(ItemBunch left, ItemBunch right) {
            if (left.Type != right.Type) throw new Exception("Different types");
            return new ItemBunch(left.Type, left.Count - right.Count);
        }
    }
}