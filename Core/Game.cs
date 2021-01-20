using System;
using System.Collections.Generic;
using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;
using FactoryStarter.Core.Levels;

namespace FactoryStarter.Core
{
    public class Game
    {
        private readonly Level _level = new Level();
        private readonly TypesContainer _typesContainer = new TypesContainer();

        public EventBinder EventBinder => new EventBinder(_level);
        public LevelEditor LevelEditor => new LevelEditor(_typesContainer, _level);
        public TypesContainer TypesContainer => _typesContainer;
        
        public LevelInfo LevelInfo => new LevelInfo(_level);
        public void RestoreLevel(LevelInfo info) => _level.Restore(info, _typesContainer);
    }
}