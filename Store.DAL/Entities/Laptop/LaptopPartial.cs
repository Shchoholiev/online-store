namespace Store.DAL.Entities.Laptop;

public partial class Laptop
{
    public override string ToString()
    {
        return $"{BrandId} {Model} with {Processor}, {RAM}GB RAM " +
               $"and {Memory}GB memory: {Amount} available for ${Price}.";
    }
}