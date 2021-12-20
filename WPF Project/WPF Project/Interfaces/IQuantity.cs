using System;
using System.Collections.Generic;
using System.Text;
using WPF_Project.Models;

namespace WPF_Project.Interfaces
{
    internal interface IQuantity
    {
        /// <summary>
        /// Available quantity for either a model or the inventory
        /// </summary>
        /// <returns> int </returns>
        int AvailableQuantity();
        /// <summary>
        /// Minimum quantity for a model
        /// </summary>
        /// <param name="model"> Name of the model </param>
        /// <returns> boolean </returns>
        bool MinimumQuanitity(Model model);
        
    }
}
