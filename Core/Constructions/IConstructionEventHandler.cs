using FactoryStarter.Core.Items;

namespace FactoryStarter.Core.Constructions
{
    public interface IConstructionEventHandler
    {
        public void OnItemBunchAdded(ItemBunchDto itemBunch);
        public void OnItemBunchRemoved(ItemBunchDto itemBunch);
    }
}