namespace Store.ViewModels.Phone;

public partial class PhoneViewModel
{
    public override string GetFullName()
    {
        return $"{Brand} {Model} {Memory}GB {Color}";
    }
}