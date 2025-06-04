namespace WebApplication1.DTOs;

public class ClientDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public List<PurchasesDTO> Purchases { get; set; }
}
public class PurchasesDTO
{
    public DateTime Date { get; set; }
    public int Rating { get; set; }
    public int Price { get; set; }
    public List<WashingMachineDTO> WashingMachines { get; set; }
    
}

public class WashingMachineDTO
{
    public string Serial { get; set; }
    public int Duration { get; set; }
}