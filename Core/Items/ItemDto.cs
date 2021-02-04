using System;

namespace FactoryStarter.Core.Items
{
    [Serializable]
    public class ItemDto
    {
        

        public uint TypeId { get; set; }
        public uint Count { get; set; }
        
        public ItemDto(){}
        
        public ItemDto(uint typeId, uint count)
        {
            TypeId = typeId;
            Count = count;
        }

        internal ItemDto(Item item)
        {
            TypeId = item.Type.Id;
            Count = item.Count;
        }
    }
}