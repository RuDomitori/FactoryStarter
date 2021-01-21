namespace FactoryStarter.Core.Items
{
    public class ItemTypeDto
    {
        public string Name { get; set; }
        public uint Id { get; set; }
        public uint MaxCount { get; set; } = 1;
    }
}