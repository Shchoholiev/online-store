namespace Store.ViewModels
{
    public partial class PhoneViewModel : ItemBaseViewModel
    {    
        public ushort Memory { get; set; }
    
        public string Color { get; set; }
    
        public string ColorHex { get; set; }
        
        public double Diagonal { get; set; }
    
        public string Resolution { get; set; }
    
        public string Processor { get; set; }
    
        public string Camera { get; set; }
    
        public string FrontCamera { get; set; }
    
        public string Diaphragm { get; set; }
    
        public string VideoRecord { get; set; }

        public string AboutCamera { get; set; }
    
        public string OS { get; set; }
    
        public string Wifi { get; set; }
    
        public string GPS { get; set; }
    
        public string Bluetooth { get; set; }

        public bool NFC { get; set; }

        public bool WirelessCharging { get; set; }
    
        public string WaterProtection { get; set; }

        public string Technologies { get; set; }
    
        public string Sizes { get; set; }

        public int Weight { get; set; }

        public string InBox { get; set; }

        public int Warranty { get; set; }
    }
}
