namespace FactoryStarter.Core
{
    public abstract class Message
    {
        public override string ToString()
        {
            var res = GetType().ToString() + "\n";
            foreach (var property in GetType().GetFields())
            {
                res += $"  {property.Name}: {property.GetValue(this)}\n";
            }

            return res;
        }
    }
}