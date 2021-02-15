using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;

namespace FactoryStarter.Console {
    public class ConstructionEventHandler : IConstructionEventHandler {
        private readonly int _constructionId;

        public ConstructionEventHandler(int constructionId) => _constructionId = constructionId;

        public void OnItemBunchAdded(ItemBunchDto itemBunch) {
            System.Console.WriteLine(
                $"[ItemBunchAdded] " +
                $"constructionId: {_constructionId}, " +
                $"Item: {{Id: {itemBunch.TypeId}, Count: {itemBunch.Count}}}");
        }

        public void OnItemBunchRemoved(ItemBunchDto itemBunch) {
            System.Console.WriteLine(
                $"[ItemBunchRemoved] " +
                $"constructionId: {_constructionId}, " +
                $"Item: {{Id: {itemBunch.TypeId}, Count: {itemBunch.Count}}}");
        }
    }
}