using FactoryStarter.Core.Items;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Levels
{
    public class LevelEditor
    {
        private readonly Level _level;
        private readonly TypeRepository _typeRepository;
        
        internal LevelEditor(TypeRepository typeRepository, Level level)
        {
            _level = level;
            _typeRepository = typeRepository;
        }

        public void ChangeLevelSize(uint width, uint height) => _level.ChangeSize(width, height);

        public void BuildConstruction(uint typeId, Position2 center) =>
            _level.Build(_typeRepository.GetConstructionType(typeId), center);

        public void InsertItem(uint constructionId, int slot, ItemDto dto = null) =>
            _level.GetConstruction(constructionId)
                .InsertItem(slot, dto == null ? null : new Item(dto, _typeRepository));
    }
}