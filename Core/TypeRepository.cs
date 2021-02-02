using System;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;

namespace FactoryStarter.Core
{
    internal class TypeRepository
    {
        private IDtoRepository _repository;
        private readonly Dictionary<uint, ConstructionType> _constructions = new Dictionary<uint, ConstructionType>();
        private readonly Dictionary<uint, ItemType> _items = new Dictionary<uint, ItemType>();

        internal TypeRepository(IDtoRepository repository) => _repository = repository;
        
        internal ConstructionType GetConstructionType(uint id)
        {
            if (!_constructions.ContainsKey(id))
            {
                var dto = _repository.GetConstructionType(id);
                if (dto == null) throw new Exception($"Construction type with id {id} is not exist");
                _constructions[id] = new ConstructionType(dto, this);
            }
            
            return _constructions[id];
        }
        
        internal ItemType GetItemType(uint id)
        {
            if (!_items.ContainsKey(id))
            {
                var dto = _repository.GetItemType(id);
                if (dto == null) throw new Exception($"Item type with id {id} is not exist");
                _items[id] = new ItemType(dto);
            }
            return _items[id];
        }
    }
}