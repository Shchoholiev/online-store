using Store.DAL.EF;
using Store.DAL.Entities.ItemProperties;
using Store.DAL.Entities.Laptop;
using Store.DAL.Entities.Orders;
using Store.DAL.Entities.Phone;

namespace Store.DAL.DataInitializer;

public class DbInitializer
{
    public static void Initialize(StoreContext context)
    {
        context.Database.EnsureCreated();

        var apple = new Brand() { Name = "Apple" };
        var asus = new Brand() { Name = "Asus" };
        var samsung = new Brand() { Name = "Samsung" };
        var xiaomi = new Brand() { Name = "Xiaomi" };
        var lenovo = new Brand() { Name = "Lenovo" };

        var brands = new List<Brand>
        {
            apple,
            asus,
            samsung,
            xiaomi
        };

        foreach (var b in brands)
        {
            context.Brands.Add(b);
        }
        context.SaveChanges();

        var tufGaming = new Model() { Name = "TUF Gaming" };
        var strix = new Model() { Name = "Strix" };
        var iphone13 = new Model() { Name = "IPhone 13" };
        var iphone11 = new Model() { Name = "IPhone 11" };

        var models = new List<Model>
        {
            tufGaming,
            strix,
            iphone13,
            iphone11,
        };

        foreach (var m in models)
        {
            context.Models.Add(m);
        }
        context.SaveChanges();

        var pink = new Color() { Name = "Pink", Hex = "fbe2dd" };
        var blue = new Color() { Name = "Blue", Hex = "437791" };
        var midnight = new Color() { Name = "Midnight", Hex = "42474d" };
        var red = new Color() { Name = "Red", Hex = "c82332" };
        var starlight = new Color() { Name = "Starlight", Hex = "fbf7f4" };
        var grey = new Color() { Name = "Grey", Hex = "333333" };

        var colors = new List<Color>()
        {
            pink,
            blue,
            midnight,
            red,
            starlight,
            grey
        };

        foreach (var c in colors)
        {
            context.Colors.Add(c);
        }
        context.SaveChanges();

        var image13Pink = new Image() { Link = "https://firebasestorage.googleapis.com/v0/b/store-4a733.appspot.com/o/13Pink.jpg?alt=media&token=bac56beb-fc7f-4350-982f-08f01e7d826e" };
        var image13Blue = new Image() { Link = "https://firebasestorage.googleapis.com/v0/b/store-4a733.appspot.com/o/13Blue.jpg?alt=media&token=e6dc9c63-4cb7-43f3-bab2-1e33d9fd5311" };
        var image13Midnight = new Image() { Link = "https://firebasestorage.googleapis.com/v0/b/store-4a733.appspot.com/o/13Midnight.jpg?alt=media&token=62808164-6f10-44fa-b545-76e375b03974" };
        var image13Red = new Image() { Link = "https://firebasestorage.googleapis.com/v0/b/store-4a733.appspot.com/o/13Red.jpg?alt=media&token=68f88097-a882-4665-8a6d-9667956e7403" };
        var image13Starlight = new Image() { Link = "https://firebasestorage.googleapis.com/v0/b/store-4a733.appspot.com/o/13Starlight.jpg?alt=media&token=c4746048-61e7-4632-a50d-66226da193de" };

        var images = new List<Image>()
        {
            image13Pink,
            image13Blue,
            image13Midnight,
            image13Red,
            image13Starlight,
        };

        foreach (var i in images)
        {
            context.Images.Add(i);
        }
        context.SaveChanges();

        var Laptops = new List<Laptop>
            {
                new Laptop{ Price = 1000, Amount = 11, Brand = asus, Model = tufGaming, Color = grey,
                            Processor = "Ryzen 7 4700H", RAM = 16, Memory = 512 },
                new Laptop{ Price = 1300, Amount = 5, Brand = lenovo, Model = tufGaming, Color = grey,
                            Processor = "Intel Core i7 11700", RAM = 16, Memory = 1024 },
                new Laptop{ Price = 800, Amount = 0, Brand = asus, Model = strix, Color = grey,
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

        var phones = new List<Phone>
        {
            new Phone{ Price = 700, Amount = 32, Brand = apple, Specifications = specs13,
                       Model = iphone11, Memory = 128, Color = pink, Image = image13Pink },
            new Phone{ Price = 750, Amount = 0, Brand = apple, Specifications = specs13,
                       Model = iphone11, Memory = 256, Color = pink, Image = image13Pink },
            new Phone{ Price = 810, Amount = 8, Brand = apple, Specifications = specs13,
                       Model = iphone11, Memory = 512, Color = pink, Image = image13Pink },

                new Phone{ Price = 980, Amount = 32, Brand = apple, Specifications = specs13,
                           Model = iphone13, Memory = 128, Color = pink, Image = image13Pink },
                new Phone{ Price = 1080, Amount = 0, Brand = apple, Specifications = specs13,
                           Model = iphone13, Memory = 256, Color = pink, Image = image13Pink },
                new Phone{ Price = 1170, Amount = 8, Brand = apple, Specifications = specs13,
                           Model = iphone13, Memory = 512, Color = pink, Image = image13Pink },

                new Phone{ Price = 970, Amount = 10, Brand = apple, Specifications = specs13,
                           Model = iphone13, Memory = 128, Color = blue, Image = image13Blue },
                new Phone{ Price = 1070, Amount = 10, Brand = apple, Specifications = specs13, 
                           Model = iphone13, Memory = 256, Color = blue, Image = image13Blue },
                new Phone{ Price = 1200, Amount = 0, Brand = apple, Specifications = specs13,
                           Model = iphone13, Memory = 512, Color = blue, Image = image13Blue },

                new Phone{ Price = 990, Amount = 0, Brand = apple, Specifications = specs13,
                           Model = iphone13, Memory = 128, Color = midnight, Image = image13Midnight },
                new Phone{ Price = 1100, Amount = 0, Brand = apple, Specifications = specs13,
                           Model = iphone13, Memory = 256, Color = midnight, Image = image13Midnight },
                new Phone{ Price = 1220, Amount = 0, Brand = apple, Specifications = specs13,
                           Model = iphone13, Memory = 512, Color = midnight, Image = image13Midnight },

                new Phone{ Price = 970, Amount = 10, Brand = apple, Specifications = specs13,
                           Model = iphone13, Memory = 128, Color = red, Image = image13Red },
                new Phone{ Price = 1090, Amount = 0, Brand = apple, Specifications = specs13,
                           Model = iphone13, Memory = 256, Color = red, Image = image13Red },
                new Phone{ Price = 1190, Amount = 10, Brand = apple, Specifications = specs13,
                           Model = iphone13, Memory = 512, Color = red, Image = image13Red },

                new Phone{ Price = 960, Amount = 0, Brand = apple, Specifications = specs13,
                           Model = iphone13, Memory = 128, Color = starlight, Image = image13Starlight },
                new Phone{ Price = 1070, Amount = 10, Brand = apple, Specifications = specs13,
                           Model = iphone13, Memory = 256, Color = starlight, Image = image13Starlight },
                new Phone{ Price = 1200, Amount = 10, Brand = apple, Specifications = specs13,
                           Model = iphone13, Memory = 512, Color = starlight, Image = image13Starlight },

        };

        foreach (var p in phones)
        {
            context.Phones.Add(p);
        }
        context.SaveChanges();

        var deliveryOptions = new List<DeliveryOption>
        {
            new DeliveryOption { Name = "In Store" },
            new DeliveryOption { Name = "NovaPoshta" },
            new DeliveryOption { Name = "UkrPoshta" },
            new DeliveryOption { Name = "Justin" },
        };

        foreach (var d in deliveryOptions)
        {
            context.DeliveryOptions.Add(d);
        }
        context.SaveChanges();

        var paymentOptions = new List<PaymentOption>
        {
            new PaymentOption { Name = "Card" },
            new PaymentOption { Name = "Cash" },
        };

        foreach (var p in paymentOptions)
        {
            context.PaymentOptions.Add(p);
        }
        context.SaveChanges();

    }

    public static void Delete(StoreContext context)
    {
        context.Database.EnsureDeleted();
    }
}
