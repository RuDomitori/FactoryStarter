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
        
        public void Add(ConstructionTypeDto dto)
        {
            if (_constructions.ContainsKey(dto.Id))
                throw new Exception("Factory type with same id already is added");

            var factoryType = new ConstructionType(dto, this);

            _constructions.Add(dto.Id, factoryType);
        }

        public void Add(IEnumerable<ConstructionTypeDto> infos) 
        {
            foreach (var info in infos) Add(info);
        }

        public void Add(ItemTypeDto dto)
        {
            if (_items.ContainsKey(dto.Id))
                throw new Exception("Item type with same id already is added");

            var itemType = new ItemType(dto);

            _items.Add(dto.Id, itemType);
        }

        public void Add(IEnumerable<ItemTypeDto> infos)
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