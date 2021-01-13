using FactoryStarter.Core.Positions;

namespace FactoryStarter.Core.Levels
{
    public class LevelEditor
    {
        private Level _level;
        private readonly Game _game;
        
        internal LevelEditor(Game game, Level level)
        {
            _level = level;
            _game = game;
        }

        public void ChangeLevelSize(uint width, uint height) => _level.ChangeSize(width, height);

        public void BuildConstruction(uint typeId, Position2 center) =>
            _level.Build(_game.GetConstructionTypeById(typeId), center);
    }
}