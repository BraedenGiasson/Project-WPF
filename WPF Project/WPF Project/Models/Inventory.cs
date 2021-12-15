using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Project.Models
{
    internal static class Inventory
    {
        //private static bool saved;    not sure if needed
        //private static string savedLocation;      also not sure if needed

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
    }
}
