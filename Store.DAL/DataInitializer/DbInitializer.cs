using Store.DAL.EF;
using Store.DAL.Entities.Laptop;
using Store.DAL.Entities.Phone;

namespace Store.DAL.DataInitializer;

public class DbInitializer
{
    public static void Initialize(StoreContext context)
        {
            context.Database.EnsureCreated();

            var Laptops = new List<Laptop>
            {
                new Laptop{ Price = 1000, Amount = 11, Make = "Asus", Model = "TUF Gaming", 
                            Processor = "Ryzen 7 4700H", RAM = 16, Memory = 512 },
                new Laptop{ Price = 1300, Amount = 5, Make = "Lenovo", Model = "TUF Gaming", 
                            Processor = "Intel Core i7 11700", RAM = 16, Memory = 1024 },
                new Laptop{ Price = 800, Amount = 0, Make = "Asus", Model = "Strix", 
                            Processor = "Ryzen 5 4500U", RAM = 8, Memory = 256 },
            };

            foreach (var l in Laptops)
            {
                context.Laptops.Add(l);
            }
            context.SaveChanges();

            PhoneSpecifications specs13 = new PhoneSpecifications
            {
                Diagonal = 6.1,
                Resolution = " 2532x1170",
                Processor = "A15 Bionic",
                Camera = "12 Mp + 12 Mp",
                Diaphragm = "f/1.6 + f/2.4",
                VideoRecord = "4К UHD (3840x2160)",
                AboutCamera = "12MP dual camera system: wide-angle and ultra-wide-angle Wide-angle: " +
                              "ƒ / 1.6 aperture Ultra wide-angle: ƒ / 2.4 aperture and 120 ° viewing " +
                              "angle Optical zoom 2x zoom out Digital zoom up to 5 × Portrait mode " +
                              "with improved bokeh and Depth function Portrait Lighting (six options: " +
                              "Natural Light, Studio Light, Contour Light, Stage Light, Stage Light - B / W, " +
                              "Light Key - B / W) Sensor shift optical image stabilization (wide-angle camera) " +
                              "Seven-element lens (wide-angle camera); five-element lens (ultra wide-angle camera) " +
                              "True Tone Flash with Slow Sync Panoramic shooting (up to 63 MP) Sapphire lens protection " +
                              "Full-sensor Focus Pixels support (wide-angle camera) Night mode Deep Fusion technology " +
                              "Smart HDR 4 Photographic Styles Wide color range for photos and Live Photos Lens " +
                              "Distortion Correction (Ultra Wide-Angle Camera) Advanced Red-Eye Removal System " +
                              "Automatic image stabilization Burst shooting Linking photos to the shooting location " +
                              "Picture Formats: HEIF and JPEG",
                OS = "iOS 15",
                Wifi = "IEEE 802.11 a/b/g/n/ac/ax",
                GPS = "A-GPS, GPS",
                Bluetooth = "5.0",
                NFC = true,
                WirelessCharging = true,
                WaterProtection = "IP68",
                Technologies = "Accelerometer | Barometer | Gyroscope | Light sensor | Proximity sensor | Compass | Face scanner",
                Sizes = " 146.7 x 71.5 x 7.65 mm",
                Weight = 173,
                InBox = "Smartphone USB-C to Lightning cable Instructions Warranty card",
                Warranty = 12,

            };

            context.PhoneSpecifications.Add(specs13);
            context.SaveChanges();

            byte[] imageI11 = System.IO.File.ReadAllBytes(@"C:\Users\rareb\Desktop\images\iphone11.jpg");
            //byte[] imageI13 = System.IO.File.ReadAllBytes(@"C:\Users\rareb\Desktop\images\iphone13.jpg");
            byte[] imageSas = System.IO.File.ReadAllBytes(@"C:\Users\rareb\Desktop\images\samsung.jpg");
            byte[] imageXi = System.IO.File.ReadAllBytes(@"C:\Users\rareb\Desktop\images\xiaomi.jpg");
            byte[] imageI13ProMax = System.IO.File.ReadAllBytes(@"C:\Users\rareb\Desktop\images\13promax.jpg");
            byte[] image13Pink = System.IO.File.ReadAllBytes(@"C:\Users\rareb\Desktop\images\13Pink.jpg");
            byte[] image13Blue = System.IO.File.ReadAllBytes(@"C:\Users\rareb\Desktop\images\13Blue.jpg");
            byte[] image13Midnight = System.IO.File.ReadAllBytes(@"C:\Users\rareb\Desktop\images\13Midnight.jpg");
            byte[] image13Red = System.IO.File.ReadAllBytes(@"C:\Users\rareb\Desktop\images\13Red.jpg");
            byte[] image13Starlight = System.IO.File.ReadAllBytes(@"C:\Users\rareb\Desktop\images\13Starlight.jpg");

            var Phones = new List<Phone>
            {
                new Phone{ Price = 1000, Amount = 30, Make = "Apple", 
                           Model = "IPhone 11", Memory = 256, Image = imageI11 },
                new Phone{ Price = 1500, Amount = 25, Make = "Samsung", 
                           Model = "Galaxy 25", Memory = 512, Image = imageSas },
                new Phone{ Price = 200, Amount = 99, Make = "Xiaomi", 
                           Memory = 32, Image = imageXi },

                new Phone{ Price = 980, Amount = 32, Make = "Apple", Specifications = specs13, ColorHex = "fbe2dd",
                           Model = "IPhone 13", Memory = 128, Color = "Pink", Image = image13Pink },
                new Phone{ Price = 1080, Amount = 0, Make = "Apple", Specifications = specs13, ColorHex = "fbe2dd",
                           Model = "IPhone 13", Memory = 256, Color = "Pink", Image = image13Pink },
                new Phone{ Price = 1170, Amount = 8, Make = "Apple", Specifications = specs13, ColorHex = "fbe2dd",
                           Model = "IPhone 13", Memory = 512, Color = "Pink", Image = image13Pink },

                new Phone{ Price = 970, Amount = 10, Make = "Apple", Specifications = specs13, ColorHex = "437791",
                           Model = "IPhone 13", Memory = 128, Color = "Blue", Image = image13Blue },
                new Phone{ Price = 1070, Amount = 10, Make = "Apple", Specifications = specs13, ColorHex = "437791",
                           Model = "IPhone 13", Memory = 256, Color = "Blue", Image = image13Blue },
                new Phone{ Price = 1200, Amount = 0, Make = "Apple", Specifications = specs13, ColorHex = "437791",
                           Model = "IPhone 13", Memory = 512, Color = "Blue", Image = image13Blue },

                new Phone{ Price = 990, Amount = 0, Make = "Apple", Specifications = specs13, ColorHex = "42474d",
                           Model = "IPhone 13", Memory = 128, Color = "Midnight", Image = image13Midnight },
                new Phone{ Price = 1100, Amount = 0, Make = "Apple", Specifications = specs13, ColorHex = "42474d",
                           Model = "IPhone 13", Memory = 256, Color = "Midnight", Image = image13Midnight },
                new Phone{ Price = 1220, Amount = 0, Make = "Apple", Specifications = specs13, ColorHex = "42474d",
                           Model = "IPhone 13", Memory = 512, Color = "Midnight", Image = image13Midnight },

                new Phone{ Price = 970, Amount = 10, Make = "Apple", Specifications = specs13, ColorHex = "c82332",
                           Model = "IPhone 13", Memory = 128, Color = "Red", Image = image13Red },
                new Phone{ Price = 1090, Amount = 0, Make = "Apple", Specifications = specs13, ColorHex = "c82332",
                           Model = "IPhone 13", Memory = 256, Color = "Red", Image = image13Red },
                new Phone{ Price = 1190, Amount = 10, Make = "Apple", Specifications = specs13, ColorHex = "c82332",
                           Model = "IPhone 13", Memory = 512, Color = "Red", Image = image13Red },

                new Phone{ Price = 960, Amount = 0, Make = "Apple", Specifications = specs13, ColorHex = "fbf7f4",
                           Model = "IPhone 13", Memory = 128, Color = "Starlight", Image = image13Starlight },
                new Phone{ Price = 1070, Amount = 10, Make = "Apple", Specifications = specs13, ColorHex = "fbf7f4",
                           Model = "IPhone 13", Memory = 256, Color = "Starlight", Image = image13Starlight },
                new Phone{ Price = 1200, Amount = 10, Make = "Apple", Specifications = specs13, ColorHex = "fbf7f4",
                           Model = "IPhone 13", Memory = 512, Color = "Starlight", Image = image13Starlight },
                
            };

            foreach (var p in Phones)
            {
                context.Phones.Add(p);
            }
            context.SaveChanges();
        }

        public static void Delete(StoreContext context)
        {
            context.Database.EnsureDeleted();
        }
}