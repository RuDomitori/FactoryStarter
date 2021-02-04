using System.Collections.Generic;
using System.Linq;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Constructions
{
    internal class Construction
    {
        internal ConstructionType Type;
        internal uint Id;
        internal Position2 Center;
        internal List<Item> Items;
        internal IConstructionEventHandler EventHandler;

        internal Construction(ConstructionType type, Position2 center, uint id)
        {
            Id = id;
            Type = type;
            Center = center;
            Items = Enumerable.Repeat<Item>(null, (int) Type.StorageCapacity)
                .ToList();
        }

        internal Construction(ConstructionDto dto, TypeRepository types) 
        {
            Id = dto.Id;
            Type = types.GetConstructionType(dto.TypeId);
            Center = dto.Center;
            Items = dto.Items
                .Select(dto => dto == null ? null : new Item(dto, types))
                .ToList();
            Items.AddRange(Enumerable.Repeat<Item>(null, (int)Type.StorageCapacity - Items.Count));
        }

        internal void InsertItem(int slot, Item item)
        {
            Items[slot] = item;
            EventHandler?.OnItemInserted(slot, new ItemDto(item));
        }
    }
}