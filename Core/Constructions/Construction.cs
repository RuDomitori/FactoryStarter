using System;
using System.Collections.Generic;
using FactoryStarter.Core.Items;

namespace FactoryStarter.Core.Constructions
{
    internal abstract class Construction
    {
        internal ConstructionType Type;

        internal uint Id;

        internal Position Center;
    }

    internal abstract class ConstructionType
    {
        internal uint Id;

        internal List<Position> Offsets;

        internal Dictionary<ItemType, uint> RequiredItems;

        internal ConstructionType(ConstructionTypeInfo info, Dictionary<uint, ItemType> itemTypes)
        {
            Id = info.Id;
            Offsets = info.Offsets;
            
            RequiredItems = new Dictionary<ItemType, uint>();
            
            foreach (var item in info.RequiredItems)
            {
                if (!itemTypes.ContainsKey(item.Key)) 
                    throw new Exception($"Item type {item.Key} has not downloaded to game");
                
                RequiredItems.Add(itemTypes[item.Key], item.Value);
            }
        }
    }

    [Serializable]
    public abstract class ConstructionTypeInfo
    {
        public uint Id { get; set; }
        public List<Position> Offsets { get; set; }
        public Dictionary<uint, uint> RequiredItems { get; set; }

        public ConstructionTypeInfo() {}

        internal ConstructionTypeInfo(ConstructionType type)
        {
            Id = type.Id;
            Offsets = type.Offsets;
            RequiredItems = new Dictionary<uint, uint>();
            foreach (var pare in type.RequiredItems)
            {
                RequiredItems.Add(pare.Key.Id, pare.Value);
            }
        }
    }
}