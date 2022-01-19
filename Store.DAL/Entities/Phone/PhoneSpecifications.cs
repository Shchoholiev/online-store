using System.ComponentModel.DataAnnotations;
using Store.DAL.Entities.Base;

namespace Store.DAL.Entities.Phone;

public class PhoneSpecifications : EntityBase
{
    public double Diagonal { get; set; }

    [StringLength(10)]
    public string Resolution { get; set; } = "No info";

    [StringLength(30)]
    public string Processor { get; set; } = "No info";

    [StringLength(30)]
    public string Camera { get; set; } = "No info";

    [StringLength(30)]
    public string FrontCamera { get; set; } = "No info";

    [StringLength(30)]
    public string Diaphragm { get; set; } = "No info";

    [StringLength(30)]
    public string VideoRecord { get; set; } = "No info";

    public string AboutCamera { get; set; } = "No info";

    [StringLength(30)]
    public string OS { get; set; } = "No info";

    [StringLength(50)]
    public string Wifi { get; set; } = "No info";

    [StringLength(50)]
    public string GPS { get; set; } = "No info";

    [StringLength(50)]
    public string Bluetooth { get; set; } = "No info";

    public bool NFC { get; set; }

    public bool WirelessCharging { get; set; }

    [StringLength(10)]
    public string WaterProtection { get; set; } = "No";

    public string Technologies { get; set; } = "No info";

    [StringLength(50)]
    public string Sizes { get; set; } = "No info";

    public int Weight { get; set; }

    public string InBox { get; set; } = "No info";

    public int Warranty { get; set; }
}