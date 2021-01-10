namespace FactoryStarter.Core.Items
{
    internal class Pack: Item
    {
        internal PackType PackType => (PackType) Type;

        internal readonly ItemType ContentType;

        internal uint Count;
    }

    internal class PackType: ItemType
    {
        internal readonly uint MaxCount;

        internal PackType(PackTypeInfo info) : base(info)
        {
            MaxCount = info.MaxCount;
        }
    }

    public class PackTypeInfo : ItemTypeInfo
    {
        public uint MaxCount;
    }
}