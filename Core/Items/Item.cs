namespace FactoryStarter.Core.Items
{
    internal class Item
    {
        internal readonly ItemType Type;
        internal uint Count;

        internal Item(){}
        internal Item(ItemDto dto, TypeRepository types)
        {
            Type = types.GetItemType(dto.TypeId);
            Count = dto.Count;
        }
    }
}