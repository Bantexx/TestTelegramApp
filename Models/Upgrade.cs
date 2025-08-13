namespace TestTelegramApp.Models;

public class Upgrade
{
    public string Name { get; set; }
    public decimal Cost { get; set; }
    public decimal Multiplier { get; }
    
    public int Level { get; set; } = 1;

    public Upgrade(string name, decimal cost, decimal multiplier)
    {
        Name = name;
        Cost = cost;
        Multiplier = multiplier;
    }
}