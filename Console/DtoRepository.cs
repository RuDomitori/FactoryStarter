using System.Collections.Generic;
using FactoryStarter.Core;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Levels;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Console
{
    public class DtoRepository: IDtoRepository
    {
        private List<ItemTypeDto> _itemTypes = new List<ItemTypeDto> {
            new ItemTypeDto {
                Id = 1,
                Name = "ItemType1",
                MaxCount = 4
            },
            new ItemTypeDto {
                Id = 2,
                Name = "ItemType2",
                MaxCount = 16
            },
            new ItemTypeDto {
                Id = 3,
                Name = "ItemType3",
                MaxCount = 32
            }
        };

        private List<ConstructionTypeDto> _constructionTypes = new List<ConstructionTypeDto> {
            new ConstructionTypeDto {
                Id = 1,
                Name = "Plus factory",
                Offsets = new List<Position3> {
                    new Position3(){ X= 0,   Y = 1,   Layer = 2 },
                    new Position3(){ X= -1,  Y = 0,   Layer = 2 },
                    new Position3(){ X= 0,   Y = 0,   Layer = 2 },
                    new Position3(){ X= 1,   Y = 0,   Layer = 2 },
                    new Position3(){ X= 0,   Y = -1,  Layer = 2 }
                },
                RequiredItems = new Dictionary<uint, uint> {
                    {1, 10}, {2, 5}, {3, 1}
                },
                StorageCapacity = 4
            },
            new ConstructionTypeDto {
                Id = 2,
                Name = "Square factory",
                Offsets = new List<Position3> {
                    new Position3 { X = -1,  Y = 1,   Layer = 2 },
                    new Position3 { X = 0,   Y = 1,   Layer = 2 },
                    new Position3 { X = 1,   Y = 1,   Layer = 2 },
                    new Position3 { X = -1,  Y = 0,   Layer = 2 },
                    new Position3 { X = 0,   Y = 0,   Layer = 2 },
                    new Position3 { X = 1,   Y = 0,   Layer = 2 },
                    new Position3 { X = -1,  Y = -1,  Layer = 2 },
                    new Position3 { X = 0,   Y = -1,  Layer = 2 },
                    new Position3 { X = 1,   Y = -1,  Layer = 2 }
                },
                RequiredItems = new Dictionary<uint, uint> {
                    {1, 10}
                },
                StorageCapacity = 8
            }
        };

        private List<LevelDto> _levels = new List<LevelDto> { };
        
        public void Save(LevelDto dto)
        {
            var i = _levels.FindIndex(x => x.Id == dto.Id);
            if (i != -1)
                _levels.Insert(i, dto);
            else
                _levels.Add(dto);
        }

        public ConstructionTypeDto GetConstructionType(uint id) => 
            _constructionTypes.Find(x => x.Id == id);

        public ItemTypeDto GetItemType(uint id) => 
            _itemTypes.Find(x => x.Id == id);

        public LevelDto GetLevel(uint id) => 
            _levels.Find(x => x.Id == id);
    }
}