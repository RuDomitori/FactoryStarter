namespace FactoryStarter.Core.Items
{
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
}