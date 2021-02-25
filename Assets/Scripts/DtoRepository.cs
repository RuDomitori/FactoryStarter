using System;
using System.Collections.Generic;
using FactoryStarter.Core;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Constructions.Rpn;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Levels;
using FactoryStarter.Core.Positions;
using UnityEngine;

namespace FactoryStarter.Unity {
    [Serializable]
    public class DtoRepository: IDtoRepository {
        public List<ConstructionTypeDto> ConstructionTypes;
        public List<ItemTypeDto> ItemTypes;
        public List<LevelDto> Levels;
        
        public void Save(LevelDto dto) {
            throw new System.NotImplementedException();
        }

        public ConstructionTypeDto GetConstructionType(int id) {
            Debug.Log(id);
            Debug.Log(ConstructionTypes.Find(x => x.Id == id));
            return ConstructionTypes.Find(x => x.Id == id);
        }

        public ItemTypeDto GetItemType(int id) {
            return ItemTypes.Find(x => x.Id == id);
        }

        public LevelDto GetLevel(int id) {
            throw new System.NotImplementedException();
        }
    }
}