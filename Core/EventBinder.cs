using FactoryStarter.Core.Levels;

namespace FactoryStarter.Core
{
    public class EventBinder
    {
        private Level _level;

        internal EventBinder(Level level) => _level = level;
        
        public event Level.ChangingSize OnChangingSize
        {
            add => _level.OnChangingSize += value;
            remove => _level.OnChangingSize -= value;
        }
        
        public event Level.Building OnBuilding
        {
            add => _level.OnBuilding += value;
            remove => _level.OnBuilding -= value;
        }
    }
}