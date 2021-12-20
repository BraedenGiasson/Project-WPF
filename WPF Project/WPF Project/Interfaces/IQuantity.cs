using System;
using System.Collections.Generic;
using System.Text;
using WPF_Project.Models;

namespace WPF_Project.Interfaces
{
    internal interface IQuantity
    {
        /// <summary>
        /// Minimum quantity for a model
        /// </summary>
        /// <param name="model"> Name of the model </param>
        /// <returns> boolean </returns>
        bool MinimumQuanitity(Model model);
        
    }
}
