using FactoryStarter.Core.Items;
using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Levels
{
    public class LevelEditor
    {
        private readonly Level _level;
        private readonly TypeRepository _typeRepository;
        
        internal LevelEditor(TypeRepository typeRepository, Level level) {
            _level = level;
            _typeRepository = typeRepository;
        }

        public void ChangeLevelSize(int width, int height) {
            _level.ChangeSize(width, height);
        }

        public void BuildConstruction(int typeId, Position2 center) {
            _level.Build(_typeRepository.GetConstructionType(typeId), center);
        }

        public void AddItemBunch(int constructionId, ItemBunchDto bunchDto) {
            _level.GetConstruction(constructionId)
                .AddItemBunch(new ItemBunch(bunchDto, _typeRepository));
        }

        public void RemoveItemBunch(int constructionId, ItemBunchDto bunchDto) {
            var construction = _level.GetConstruction(constructionId);
            construction.RemoveItemBunch(new ItemBunch(bunchDto, _typeRepository));
        }
    }
}