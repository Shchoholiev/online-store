﻿namespace Store.ViewModels;

public partial class PhoneViewModel
{
    public string GetFullName()
    {
        return $"{Brand} {Model} {Memory}GB {Color}";
    }
}