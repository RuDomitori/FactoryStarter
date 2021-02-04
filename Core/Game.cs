using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Levels;

namespace FactoryStarter.Core
{
    public class Game
    {
        private readonly Level _level;

        private readonly IDtoRepository _dtoRepository;
        internal readonly TypeRepository Types;
        public readonly LevelEditor Editor;

        public Game(IDtoRepository dtoRepository)
        {
            _dtoRepository = dtoRepository;
            Types = new TypeRepository(_dtoRepository);
            _level = new Level(Types);
            Editor = new LevelEditor(Types, _level);
        }

        public void SaveLevel() => _dtoRepository.Save(new LevelDto(_level));
        public void RestoreLevel(uint id) => _level.Restore(_dtoRepository.GetLevel(id));

        public void SetLevelEventHandler(ILevelEventHandler handler) => _level.EventHandler = handler;

        public void SetConstructionEventHandler(uint id, IConstructionEventHandler handler) =>
            _level.GetConstruction(id).EventHandler = handler;
    }
}