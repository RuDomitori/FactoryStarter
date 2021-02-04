using FactoryStarter.Core.Items;

namespace FactoryStarter.Core.Constructions
{
    public interface IConstructionEventHandler
    {
        public void OnItemInserted(int slot, ItemDto item);
    }
}