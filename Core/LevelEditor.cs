namespace FactoryStarter.Core
{
    public class LevelEditor
    {
        private Level _level;
        internal LevelEditor(Level level) => _level = level;
        
        public void ChangeLevelSize(uint width, uint height)
        {
            _level.ChangeSize(width, height);
        }
    }
}