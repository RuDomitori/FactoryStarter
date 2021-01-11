using System;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;

namespace FactoryStarter.Core
{
    public class Game
    {
        private Level _level = new Level();

        private Dictionary<uint, FactoryType> _factoryTypes = new Dictionary<uint, FactoryType>();
        private Dictionary<uint, LogicType> _logicTypes = new Dictionary<uint, LogicType>();
        private Dictionary<uint, TransportType> _transportTypes = new Dictionary<uint, TransportType>();

        private Dictionary<uint, ItemType> _itemTypes = new Dictionary<uint, ItemType>();
        private Dictionary<uint, PackType> _packTypes = new Dictionary<uint, PackType>();

        public event Level.ChangingSize OnChangingSize
        {
            add => _level.OnChangingSize += value;
            remove => _level.OnChangingSize -= value;
        }

        public LevelEditor LevelEditor => new LevelEditor(_level);

        #region Adding types to the game

        public void AddFactoryType(FactoryTypeInfo info)
        {
            if (_factoryTypes.ContainsKey(info.Id)) 
                throw new Exception("Factory type with same id already is added");

            var factoryType = new FactoryType(info, _itemTypes);
            
            _factoryTypes.Add(info.Id, factoryType);
        }
        
        public void AddLogicType(LogicTypeInfo info)
        {
            if (_logicTypes.ContainsKey(info.Id)) 
                throw new Exception("Logic type with same id already is added");

            var logicType = new LogicType(info, _itemTypes);
            
            _logicTypes.Add(info.Id, logicType);
        }
        
        public void AddTransportType(TransportTypeInfo info)
        {
            if (_transportTypes.ContainsKey(info.Id)) 
                throw new Exception("Transport type with same id already is added");

            var transportType = new TransportType(info, _itemTypes);
            
            _transportTypes.Add(info.Id, transportType);
        }

        public void AddItemType(ItemTypeInfo info)
        {
            if (_itemTypes.ContainsKey(info.Id)) 
                throw new Exception("Item type with same id already is added");

            var itemType = new ItemType(info);
            
            _itemTypes.Add(info.Id, itemType);
        }
        
        public void AddPackType(PackTypeInfo info)
        {
            if (_packTypes.ContainsKey(info.Id)) 
                throw new Exception("Pack type with same id already is added");

            var packType = new PackType(info);
            
            _packTypes.Add(info.Id, packType);
        }

        #endregion
        
    }
}