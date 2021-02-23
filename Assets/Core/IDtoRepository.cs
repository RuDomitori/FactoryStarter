using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Levels;

namespace FactoryStarter.Core {
    public interface IDtoRepository {
        void Save(LevelDto dto);

        ConstructionTypeDto GetConstructionType(int id);
        ItemTypeDto GetItemType(int id);
        LevelDto GetLevel(int id);
    }
}