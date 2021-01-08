namespace FactoryStarter.Core.Items
{
    public class Pack: Item
    {
        public PackType PackType => (PackType) Type;

        public readonly ItemType ContentType;

        public uint Count;
    }

    public class PackType: ItemType
    {
        public readonly uint Id;
        public readonly uint MaxCount;
    }
}