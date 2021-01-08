namespace FactoryStarter.Core.Constructions
{
    public class Transport: Construction
    {
        public TransportType TransportType => (TransportType) Type;
    }

    public class TransportType : ConstructionType
    {
        
    }
}