using System;

namespace FactoryStarter.Core.Items
{
    [Serializable]
    public class ItemBunchDto {
        public int TypeId;
        public int Count;
        
        public ItemBunchDto(){}
        
        public ItemBunchDto(int typeId, int count)
        {
            TypeId = typeId;
            Count = count;
        }

        internal ItemBunchDto(ItemBunch itemBunch)
        {
            TypeId = itemBunch.Type.Id;
            Count = itemBunch.Count;
        }
    }
}