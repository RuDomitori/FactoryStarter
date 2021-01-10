namespace FactoryStarter.Core.Items
{
    internal class Item
    {
        internal readonly ItemType Type;
    }

    internal class ItemType
    {
        internal readonly uint Id;

        internal ItemType(ItemTypeInfo info)
        {
            Id = info.Id;
        }
    }

    public class ItemTypeInfo
    {
        public uint Id;
    }
    
}