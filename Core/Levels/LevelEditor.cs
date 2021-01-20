using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Levels
{
    public class LevelEditor
    {
        private readonly Level _level;
        private readonly TypesContainer _typesContainer;
        
        internal LevelEditor(TypesContainer typesContainer, Level level)
        {
            _level = level;
            _typesContainer = typesContainer;
        }

        public void ChangeLevelSize(uint width, uint height) => _level.ChangeSize(width, height);

        public void BuildConstruction(uint typeId, Position2 center) =>
            _level.Build(_typesContainer.GetConstructionType(typeId), center);
    }
}