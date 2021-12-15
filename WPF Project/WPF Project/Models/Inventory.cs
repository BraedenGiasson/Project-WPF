using System;
using System.Collections.Generic;
using System.Text;
using WPF_Project.Interfaces;

namespace WPF_Project.Models
{
    internal class Inventory : IQuantity
    {
        //private static bool saved;    not sure if needed
        //private static string savedLocation;      also not sure if needed

        private static List<Model> inventoryList;
        private static readonly int maxInventory = 100;

        static Inventory()
        {
            inventoryList = new List<Model>(maxInventory);
        }
        /// <summary>
        /// Method to get number of available parking spots
        /// </summary>
        /// <returns>
        /// returns an integer of available spots
        /// </returns>
        public static int GetAvailableParkingSpots()        
        {
            return inventoryList.Count;
        }

        /// <summary>
        /// Method gets the index of the first available parking spot that can be filled with a car
        /// </summary>
        /// <returns> An integer of the index, -1 if not available parking spot is available </returns>
        public static int GetFirstAvailableParkingSpot()
        {
            for (int i = 0; i < inventoryList.Count; i++)
            {
                if (inventoryList[i] == null)
                    return i;
            }
            return -1;
        }


        /// <summary>
        /// Places a car in an available parking spot
        /// </summary>
        /// <param name="model"></param>
        /// <param name="freeSpot"></param>
        /// <returns> Returns true if succesful or false if not </returns>
        public static bool SetParkingSpot(Model model, int freeSpot)
        {
            if (freeSpot < 0)
                return false;
            else
            {
                inventoryList[freeSpot] = model;
                return true;
            }
        }

        public int AvailableQuantity()
        {
            throw new NotImplementedException();
        }

        public int MinimumQuanitity()
        {
            throw new NotImplementedException();
        }

        public bool QuantityIsValid()
        {
            throw new NotImplementedException();
        }
    }
}
