namespace Store.ViewModels;

public class Base
{
    public int Id { get; set; }
    
    public uint Price { get; set; }

    public uint Amount { get; set; }

    public byte[]? Image { get; set; }
}