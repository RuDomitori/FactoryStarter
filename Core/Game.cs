using System;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;

namespace FactoryStarter.Core
{
    public class Game
    {
        private Level _currentLevel = new Level();

        private Dictionary<uint, FactoryType> _factoryTypes = new Dictionary<uint, FactoryType>();
        private Dictionary<uint, LogicType> _logicTypes = new Dictionary<uint, LogicType>();
        private Dictionary<uint, TransportType> _transportTypes = new Dictionary<uint, TransportType>();

        private Dictionary<uint, ItemType> _itemTypes = new Dictionary<uint, ItemType>();
        private Dictionary<uint, PackType> _packTypes = new Dictionary<uint, PackType>();

        public void ChangeLevelSize(uint width, uint height)
        {
            _currentLevel.ChangeSize(width, height);
        }
        
        public event Level.ChangingSize OnChangingSize
        {
            add => _currentLevel.OnChangingSize += value;
            remove => _currentLevel.OnChangingSize -= value;
        }

        public void AddFactoryType(FactoryTypeInfo info)
        {
            if (_factoryTypes.ContainsKey(info.Id)) 
                throw new Exception("Factory type with same id already is added");

            var factoryType = new FactoryType(info, _itemTypes);
            
            _factoryTypes.Add(info.Id, factoryType);
        }
    }
}