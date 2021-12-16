﻿using System;
using System.Collections.Generic;
using System.Text;
using WPF_Project.Interfaces;
using System.Linq;

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

<<<<<<< HEAD

            inventoryList[0] = new Model("A3", "Black");
            inventoryList[1] = new Model("R8", "Blue");
            inventoryList[2] = new Model("A4", "Red");
=======
            //inventoryList[0] = new Model("A3", "Black");
            //inventoryList[1] = new Model("R8", "Blue");
            //inventoryList[2] = new Model("A4", "Red");
>>>>>>> 850ecb03c0f2fec06ac075accf776d08292c2f12

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
                //bool isEmpty = !inventoryList.Any();
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
<<<<<<< HEAD

            //if (inventoryList.Contains(model))
               // model.ModelQuantity++;

            inventoryList.Add(model);
            
=======
            
            if(inventoryList.Count < inventoryList.Capacity)
                inventoryList.Add(model);
>>>>>>> 850ecb03c0f2fec06ac075accf776d08292c2f12
        }

        public static void RemoveItem(Model model)
        {
            for (int i = 0;i < inventoryList.Capacity; i++)
            {
                if (inventoryList[i] == model)
<<<<<<< HEAD
                {
                    inventoryList.RemoveAt(i);
                    model.ModelQuantity--;
                }

                return;
=======
                    inventoryList.RemoveAt(i); // make it null
>>>>>>> 850ecb03c0f2fec06ac075accf776d08292c2f12
            }
        }

        public static void UpdateItem(Model model, int quantity)
        {
            if (inventoryList.Count == inventoryList.Capacity)
                throw new ArgumentException("You cannot add this many cars. Your parking lot is full!", "UpdateItem");

            model.ModelQuantity = quantity;
        }


        public static void LoadItems()
        {
            string car = "a3, red";

            Model model = Model.FromCSV(car);
            Inventory.AddItem(model);

           // Model.FromCSV(Inventory.me);
        }



        /*public string CSVData
        {
            get
            {
                return string.Format($"{Name}, {Colour}, {EngineOption}, {BodyType}");
            }
            set
            {
                //string comma separated and set the fields of the visitor
                string[] allData = value.Split(',');
                try
                {
                    Model.Name = allData[0];
                    Colour = allData[1];
                    EngineOption = allData[2];
                    BodyType = allData[3];
                }
                catch (Exception ex)
                {
                    throw new Exception("All Data Property value not valid " + ex.Message);
                }
            }
        }*/



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
