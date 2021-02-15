using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Levels;

namespace FactoryStarter.Core {
    public interface IDtoRepository {
        public void Save(LevelDto dto);

        public ConstructionTypeDto GetConstructionType(int id);
        public ItemTypeDto GetItemType(int id);
        public LevelDto GetLevel(int id);
    }
}