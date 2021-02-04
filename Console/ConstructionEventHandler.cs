using FactoryStarter.Core.Constructions;
using FactoryStarter.Core.Items;

namespace FactoryStarter.Console
{
    public class ConstructionEventHandler: IConstructionEventHandler
    {
        private readonly uint _constructionId;

        public ConstructionEventHandler(uint constructionId) => this._constructionId = constructionId;

        public void OnItemInserted(int slot, ItemDto item)
        {
            System.Console.WriteLine(
                $"[ItemInserted] " +
                $"constructionId: {_constructionId}, " +
                $"slot: {slot}, " +
                $"Item: {{Id: {item.TypeId}, Count: {item.Count}}}");
        }
    }
}