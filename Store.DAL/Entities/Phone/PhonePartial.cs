namespace Store.DAL.Entities.Phone;

public partial class Phone
{
    public override string ToString()
    {
        return $"{this.Make} {this.Model} {Memory}GB: {this.Amount} available for ${Price}.";
    }

    public string GetFullName()
    {
        return $"{Make} {Model} {Memory}GB {Color}";
    }
}