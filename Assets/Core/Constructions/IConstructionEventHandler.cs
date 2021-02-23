using FactoryStarter.Core.Items;

namespace FactoryStarter.Core.Constructions
{
    public interface IConstructionEventHandler
    {
        void OnItemBunchAdded(ItemBunchDto itemBunch);
        void OnItemBunchRemoved(ItemBunchDto itemBunch);
    }
}