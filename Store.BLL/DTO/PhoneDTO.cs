﻿namespace Store.BLL.DTO;

public class PhoneDTO : Base
{
    public string Make { get; set; }
    
    public string Model { get; set; }
    
    public ushort Memory { get; set; }
    
    public string Color { get; set; }
    
    public string ColorHex { get; set; }
}