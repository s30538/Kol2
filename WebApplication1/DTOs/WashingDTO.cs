namespace WebApplication1.DTOs;

public class WashingDTO
{
    public List<WashingDTO> Washings { get; set; }
    public List<AvailableDTO> Availables { get; set; }
}

public class AvailableDTO
{
    public string ProgramName { get; set; }
    public double Price { get; set; }
}

