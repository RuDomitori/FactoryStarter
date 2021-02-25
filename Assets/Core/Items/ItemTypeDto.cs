using System;

namespace FactoryStarter.Core.Items
{
    [Serializable]
    public class ItemTypeDto {
        public string Name;
        public int Id;
        public int CountPerSlot = 1;
    }
}