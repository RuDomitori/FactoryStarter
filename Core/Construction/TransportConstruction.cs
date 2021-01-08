namespace Core.Construction
{
    public class Transport: Construction
    {
        public TransportType TransportType => (TransportType) Type;
    }

    public class TransportType : ConstructionType
    {
        
    }
}