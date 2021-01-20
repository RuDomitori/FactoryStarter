using System;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;

namespace FactoryStarter.Core
{
    public class TypesContainer
    {
        private readonly Dictionary<uint, ConstructionType> _constructions = new Dictionary<uint, ConstructionType>();
        private readonly Dictionary<uint, ItemType> _items = new Dictionary<uint, ItemType>();
        
        public void Add(ConstructionTypeInfo info)
        {
            if (_constructions.ContainsKey(info.Id))
                throw new Exception("Factory type with same id already is added");

            var factoryType = new ConstructionType(info, _items);

            _constructions.Add(info.Id, factoryType);
        }

        public void Add(IEnumerable<ConstructionTypeInfo> infos) 
        {
            foreach (var info in infos) Add(info);
        }

        public void Add(ItemTypeInfo info)
        {
            if (_items.ContainsKey(info.Id))
                throw new Exception("Item type with same id already is added");

            var itemType = new ItemType(info);

            _items.Add(info.Id, itemType);
        }

        public void Add(IEnumerable<ItemTypeInfo> infos)
        {
            foreach (var info in infos) Add(info);
        }

        internal ConstructionType GetConstructionType(uint id)
        {
            if (!_constructions.ContainsKey(id))
                throw new Exception($"Construction type with id {id} is not loaded");

            return _constructions[id];
        }
        
        internal ItemType GetItemType(uint id)
        {
            if (!_items.ContainsKey(id))
                throw new Exception($"Item type with id {id} is not loaded");

            return _items[id];
        }
    }
}