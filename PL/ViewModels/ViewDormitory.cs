namespace PL.ViewModels;

public class ViewDormitory
{
    public int Id { get; set; }
    public int FreeSeats { get; set; }
    
    public override string ToString()
    {
        return $"Id: {Id}, FreeSeats: {FreeSeats}";
    }
}