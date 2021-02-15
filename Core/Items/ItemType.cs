namespace FactoryStarter.Core.Items
{
    internal class ItemType
    {
        internal readonly string Name;
        internal readonly int Id;
        internal readonly int CountPerSlot;
        
        internal ItemType(ItemTypeDto dto)
        {
            Name = dto.Name;
            Id = dto.Id;
            CountPerSlot = dto.CountPerSlot;
        }
    }
}