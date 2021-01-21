namespace FactoryStarter.Core.Items
{
    internal class ItemType
    {
        internal readonly string Name;
        internal readonly uint Id;
        internal readonly uint MaxCount;
        
        internal ItemType(ItemTypeDto dto)
        {
            Name = dto.Name;
            Id = dto.Id;
            MaxCount = dto.MaxCount;
        }
    }
}