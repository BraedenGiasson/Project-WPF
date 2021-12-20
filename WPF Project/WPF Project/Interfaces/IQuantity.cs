using System;
using System.Collections.Generic;
using System.Text;
using WPF_Project.Models;

namespace WPF_Project.Interfaces
{
    internal interface IQuantity
    {

        int AvailableQuantity();

        bool MinimumQuanitity(Model model);
        
    }
}
