using System.Collections.Generic;
using FactoryStarter.Core;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Constructions.Rpn;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Levels;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Console {
    public class DtoRepository : IDtoRepository {
        private List<ItemTypeDto> _itemTypes = new List<ItemTypeDto> {
            new ItemTypeDto {
                Id = 1,
                Name = "ItemType1",
                CountPerSlot = 4
            },
            new ItemTypeDto {
                Id = 2,
                Name = "ItemType2",
                CountPerSlot = 16
            },
            new ItemTypeDto {
                Id = 3,
                Name = "ItemType3",
                CountPerSlot = 32
            }
        };

        private List<ConstructionTypeDto> _constructionTypes = new List<ConstructionTypeDto> {
            new ConstructionTypeDto {
                Id = 1,
                Name = "Plus factory",
                Offsets = new List<Position3> {
                    new Position3 {X = 0, Y = 1, Layer = 2},
                    new Position3 {X = -1, Y = 0, Layer = 2},
                    new Position3 {X = 0, Y = 0, Layer = 2},
                    new Position3 {X = 1, Y = 0, Layer = 2},
                    new Position3 {X = 0, Y = -1, Layer = 2}
                },
                RequiredItems = new List<ItemBunchDto> {
                    new ItemBunchDto(1, 10),
                    new ItemBunchDto(2, 5),
                    new ItemBunchDto(3, 1)
                },
                StorageCapacity = 4,
                Logic = new List<List<Elem>> {
                    new List<Elem> {
                        new Elem(Elem.ElemType.Arg, 1),//Id
                        new Elem(Elem.ElemType.Arg, 2),//Count
                        new Elem(Elem.ElemType.Arg, 1),//Type count
                        new Elem(Elem.ElemType.Arg, 2),//Target type id
                        new Elem(Elem.ElemType.Arg, 1),//Target count
                        new Elem(Elem.ElemType.TryCraft)
                    }
                }
            },
            new ConstructionTypeDto {
                Id = 2,
                Name = "Square factory",
                Offsets = new List<Position3> {
                    new Position3 {X = -1, Y = 1, Layer = 2},
                    new Position3 {X = 0, Y = 1, Layer = 2},
                    new Position3 {X = 1, Y = 1, Layer = 2},
                    new Position3 {X = -1, Y = 0, Layer = 2},
                    new Position3 {X = 0, Y = 0, Layer = 2},
                    new Position3 {X = 1, Y = 0, Layer = 2},
                    new Position3 {X = -1, Y = -1, Layer = 2},
                    new Position3 {X = 0, Y = -1, Layer = 2},
                    new Position3 {X = 1, Y = -1, Layer = 2}
                },
                RequiredItems = new List<ItemBunchDto> {
                    new ItemBunchDto(1, 10)
                },
                StorageCapacity = 8,
                Logic = new List<List<Elem>> {
                    new List<Elem>{}
                }
            }
        };

        private List<LevelDto> _levels = new List<LevelDto> { };

        public void Save(LevelDto dto) {
            var i = _levels.FindIndex(x => x.Id == dto.Id);
            if (i != -1) _levels[i] = dto;
            else _levels.Add(dto);
        }

        public ConstructionTypeDto GetConstructionType(int id) {
            return _constructionTypes.Find(x => x.Id == id);
        }

        public ItemTypeDto GetItemType(int id) {
            return _itemTypes.Find(x => x.Id == id);
        }

        public LevelDto GetLevel(int id) {
            return _levels.Find(x => x.Id == id);
        }
    }
}