namespace Store.BLL.Infrastructure;

public class OperationDetails
{
    public bool Succeeded { get; set; } = false;

    public List<string> Errors { get; set; } = new List<string>();

    public void AddError(string error)
    {
        Errors.Add(error);
    }

    public int ErrorsCount()
    {
        return Errors.Count;
    }
}