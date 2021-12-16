using System;
using System.Collections.Generic;
using System.Text;
using WPF_Project.Interfaces;

namespace WPF_Project.Models
{
    public class Inventory : IQuantity
    {
        private static readonly int maxInventory = 4;
        private static List<Model> inventoryList;

        static Inventory()
        {
            inventoryList = new List<Model>(maxInventory);
            //inventoryList = new List<Model>( new Model[maxInventory] );
            //inventoryList = new List<Model>(  );
            //inventoryList = new List<Model>( maxInventory );
            ////inventoryList.Capacity = maxInventory;

            //inventoryList[0] = new Model("A3", "Black");
            //inventoryList[1] = new Model("R8", "Blue");
            //inventoryList[2] = new Model("A4", "Red");

            //GetAllActualCars();
        }
        public static List<Model> InventoryList
        {
            get { return inventoryList; }
        }

        public static int GetAvailableParkingSpots()
        {
            return inventoryList.Capacity - inventoryList.Count;
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
        public static List<Model> GetAllActualCars()
        {
            List<Model> availableList = new List<Model>();
            foreach (Model model in inventoryList)
            {
                if (model != null)
                    availableList.Add(model);
            }
            return availableList;
        }

        /*public static bool SetParkingSpot(Model model, int freeSpot)
        {
            if (freeSpot < 0)
                return false;
            else
            {
                inventoryList[freeSpot] = model;
                return true;
            }
        }

        public static bool FreeParkingSpot(Model model)
        {
            for (int i = 0;i < inventoryList.Capacity; i++)
            {
                if (inventoryList[i] == model)
                {
                    inventoryList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }*/

        public static void AddItem(Model model)
        {
            //int freeSpot = GetFirstAvailableParkingSpot();

            //if (freeSpot < 0)
            //{
            //    throw new ArgumentOutOfRangeException("Cannot add car because the parking lot is full", "AddItem");
            //}

            //inventoryList[freeSpot] = model;
            
            if(inventoryList.Count < inventoryList.Capacity)
                inventoryList.Add(model);
        }

        public void RemoveItem(Model model)
        {
            for (int i = 0;i < inventoryList.Capacity; i++)
            {
                if (inventoryList[i] == model)
                    inventoryList.RemoveAt(i); // make it null
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
