using System;
using System.Collections.Generic;
using System.Text;
using WPF_Project.Interfaces;

namespace WPF_Project.Models
{
    internal class Inventory : IQuantity
    {

        private static List<Model> inventoryList;
        private static readonly int maxInventory = 100;

        static Inventory()
        {
            inventoryList = new List<Model>(maxInventory);
        }

        public static int GetAvailableParkingSpots()
        {
            return inventoryList.Count;
        }

        public static int GetFirstAvailableParkingSpot()
        {
            for (int i = 0; i < inventoryList.Count; i++)
            {
                if (inventoryList[i] == null)
                    return i;
            }
            return -1;
        }

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
