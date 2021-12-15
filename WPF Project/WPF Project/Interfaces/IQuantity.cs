using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Project.Interfaces
{
    internal interface IQuantity
    {

        int AvailableQuantity();

        int MinimumQuanitity();

        bool QuantityIsValid();
        
    }
}
