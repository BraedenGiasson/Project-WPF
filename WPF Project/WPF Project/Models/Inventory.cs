using System;
using System.Collections.Generic;
using System.Text;
using WPF_Project.Interfaces;
using System.Linq;
using System.Windows;

namespace WPF_Project.Models
{
    public class Inventory : IQuantity
    {
        private static readonly int maxInventory = 100;
        private static List<Model> inventoryList;
        private static int quantityTracker = 0;
        private const int NO_MODELS = 0;

        /// <summary>
        /// Private constructor to initalize inventory list
        /// </summary>
        static Inventory()
        {
            inventoryList = new List<Model>(maxInventory);
        }
        /// <summary>
        /// Property to get the items in the inventory list
        /// </summary>
        public static List<Model> InventoryList
        {
            get { return inventoryList; }
        }
        /// <summary>
        /// Property to get the maximum space allowed for the dealership
        /// </summary>
        public static int MaxInventorySpace
        {
            get { return maxInventory; }
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
        /// <summary>
        /// Adding item to inventory list
        /// </summary>
        /// <param name="model"> Model (car) to be added </param>
        public static void AddItem(Model model)
        {
            quantityTracker += model.ModelQuantity; // change to use Interface

            // If no models in inventory, add first car
            if (inventoryList.Count == NO_MODELS) 
            {
                inventoryList.Add(model);
                ShowStatusMessage("Successfully added car first car!");
            }
            // Making sure the quantity for the dealership is below the max allowed
            else if (quantityTracker < maxInventory)
            {
                //if (!InventoryList.Contains(model))
                //{
                //    inventoryList.Add(model);
                //    ShowStatusMessage("Successfully added car!");
                //}
                //else
                //{
                //    int index = InventoryList.FindIndex(x => x == model);
                //    inventoryList[index].ModelQuantity += model.ModelQuantity;
                //    ShowStatusMessage("Updated quantity!");
                //}
                bool notInList = false;

                for (int i = 0; i < inventoryList.Count; i++)
                {
                    // Checking if item to be added isn't already in the inventory list
                    if (model.Name != inventoryList[i].Name
                        || model.Colour != inventoryList[i].Colour
                        || model.EngineOption != inventoryList[i].EngineOption
                        || model.BodyType != inventoryList[i].BodyType)
                    {
                        notInList = true;
                        break;
                    }
                }

                /* PROBLEM:
                    When I add a car and then add another one the exact same after, it works,
                    BUT, if I add a car with colour red, then one with yellow, then another one with red, it stills adds it
                    as another car instead of updating the quanitity 
                 */

                // If it's not in the list, add it to the inventory
                if (notInList)
                {
                    inventoryList.Add(model);
                    ShowStatusMessage("Successfully added car!");
                }
                else if (!notInList)
                {
                    // Finding where it is in the list, and updating the quantity for the model (since we don't want to have duplicates in the table)
                    int index = InventoryList.FindIndex(
                            x => (x.Name == model.Name)
                            && (x.Colour == model.Colour)
                            && (x.EngineOption == model.EngineOption)
                            && (x.BodyType == model.BodyType)
                            );
                    inventoryList[index].ModelQuantity += model.ModelQuantity;
                    ShowStatusMessage("Updated quantity!");
                }
            }
            else
                throw new ArgumentException($"Inventory quantity cannot exceed {MaxInventorySpace}", "AddItem");
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
            //Inventory.AddItem(model); // was adding straight to model

           // Model.FromCSV(Inventory.me);
        }
        /// <summary>
        /// Printing successful adding car status message
        /// </summary>
        private static void ShowStatusMessage(string message)
        {
            MessageBox.Show(message);
        }

        public int AvailableQuantity()
        {
            return quantityTracker;
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
