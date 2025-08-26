namespace HomeMAUI.Models;

public class Device
{
    public string Name { get; set; } = string.Empty;
    public int Rssi { get; set; }
    public string BleAddress { get; set; } = string.Empty;
}

