namespace Store.ViewModels;

public partial class PhoneViewModel
{
    public string GetFullName()
    {
        return $"{Make} {Model} {Memory}GB {Color}";
    }
}