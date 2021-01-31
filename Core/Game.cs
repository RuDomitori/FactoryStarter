using FactoryStarter.Core.Levels;

namespace FactoryStarter.Core
{
    public class Game
    {
        private readonly Level _level;
        
        public readonly TypesContainer Types = new TypesContainer();
        public readonly LevelEditor Editor;

        public Game()
        {
            _level = new Level(Types);
            Editor = new LevelEditor(Types, _level);
        }
        
        public LevelDto LevelDto => new LevelDto(_level);
        public void RestoreLevel(LevelDto dto) => _level.Restore(dto);

        public void SetLevelEventHandler(ILevelEventHandler handler) => _level.EventHandler = handler;
    }
}