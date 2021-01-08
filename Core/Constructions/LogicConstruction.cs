namespace FactoryStarter.Core.Constructions
{
    public class Logic: Construction
    {
        public LogicType LogicType => (LogicType) Type;
    }

    public class LogicType : ConstructionType
    {
        
    }
}