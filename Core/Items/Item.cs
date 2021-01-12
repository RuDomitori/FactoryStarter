namespace FactoryStarter.Core.Items
{
    internal class Item
    {
        internal readonly ItemType Type;
        
        internal uint Count;
    }

    internal class ItemType
    {
        internal readonly string Name;
        
        internal readonly uint Id;
        
        internal readonly uint MaxCount;

        internal ItemType(ItemTypeInfo info)
        {
            Name = info.Name;
            Id = info.Id;
            MaxCount = info.MaxCount;
        }
    }

    public class ItemTypeInfo
    {
        public string Name { get; set; }
        
        public uint Id { get; set; }

        public uint MaxCount { get; set; } = 1;
    }
}