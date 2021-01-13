using System;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Levels;

namespace FactoryStarter.Core
{
    public class Game
    {
        private Level _level = new Level();

        private Dictionary<uint, ConstructionType> _constructionTypes = new Dictionary<uint, ConstructionType>();

        internal ConstructionType GetConstructionTypeById(uint id)
        {
            if (!_constructionTypes.ContainsKey(id))
                throw new Exception($"Construction type with id {id} is not loaded");

            return _constructionTypes[id];
        }

        private Dictionary<uint, ItemType> _itemTypes = new Dictionary<uint, ItemType>();

        public EventBinder EventBinder => new EventBinder(_level);
        public LevelEditor LevelEditor => new LevelEditor(this, _level);
        
        public LevelInfo LevelInfo
        {
            get => new LevelInfo(_level);
        }

        #region Adding types

        public void Add(ConstructionTypeInfo info)
        {
            if (_constructionTypes.ContainsKey(info.Id))
                throw new Exception("Factory type with same id already is added");

            var factoryType = new ConstructionType(info, _itemTypes);

            _constructionTypes.Add(info.Id, factoryType);
        }

        public void Add(IEnumerable<ConstructionTypeInfo> infos) 
        {
            foreach (var info in infos) Add(info);
        }

        public void Add(ItemTypeInfo info)
        {
            if (_itemTypes.ContainsKey(info.Id))
                throw new Exception("Item type with same id already is added");

            var itemType = new ItemType(info);

            _itemTypes.Add(info.Id, itemType);
        }

        public void Add(IEnumerable<ItemTypeInfo> infos)
        {
            foreach (var info in infos) Add(info);
        }

        #endregion
    }
}