using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Levels;

namespace FactoryStarter.Core
{
    public interface IDtoRepository
    {
        public void Save(LevelDto dto);

        public ConstructionTypeDto GetConstructionType(uint id);
        public ItemTypeDto GetItemType(uint id);
        public LevelDto GetLevel(uint id);
    }
}