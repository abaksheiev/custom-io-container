using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomIoC;

public class SettingsManager
{
    public Guid Id { get; set; }
    public SettingsManager() {
        Id = Guid.NewGuid();    
    }

    internal void WriteHello()
    {
        Console.WriteLine($"Helo: {Id}");
    }
}
