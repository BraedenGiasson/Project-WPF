using System;
using System.Collections.Generic;
using System.Text;
using WPF_Project.Interfaces;
using System.Linq;
using System.Windows;
using System.ComponentModel;

namespace WPF_Project.Models
{
    public class Inventory : IQuantity
    {
        // Backing fields
        private static readonly int maxInventory = 100;
        private static List<Model> inventoryList;
        private static int quantityTracker = 0;
        private static int counterNeedMoreOf = 30;
        private const int NO_MODELS = 0;
        private const int MINIMUM_QUANTITY = 30; // 2 of each car (15 cars)
        private const int MIN_QUANTITY_EACH_MODEL = 2;

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
        /// Tracking quantity for a model
        /// </summary>
        public static int QuantityTracker
        {
            get { return quantityTracker; }
            set
            {
                if (!value.ToString().Any(char.IsDigit))
                    throw new ArgumentException("Value has to be numeric", "QuantityTracker");
                if (value > maxInventory)
                    throw new ArgumentException($"Quantity in Inventory List cannot exceed {maxInventory}.", "QuantityTracker");

                quantityTracker = value;
            }
        }
        /// <summary>
        /// Property to get the maximum space allowed for the dealership
        /// </summary>
        public static int MaxInventorySpace
        {
            get { return maxInventory; }
        }
        /// <summary>
        /// Adding item to inventory list
        /// </summary>
        /// <param name="model"> Model (car) to be added </param>
        public static void AddItem(Model model, bool isFromLoadingCars)
        {
            QuantityTracker += model.ModelQuantity; // change to use Interface

            int index = 0;

            // If no models in inventory, add first car
            if (inventoryList.Count == NO_MODELS) 
            {
                inventoryList.Add(model);
                
                if(!isFromLoadingCars)
                    ShowStatusMessage("Successfully added car first car!");
            }
            // Making sure the quantity for the dealership is below the max allowed
            else if (quantityTracker <= maxInventory)
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
                bool notInList = true;

                for (int i = 0; i < inventoryList.Count; i++)
                {
                    // Checking if item to be added isn't already in the inventory list
                    /*if (model.Name != inventoryList[i].Name
                        || model.Colour != inventoryList[i].Colour
                        || model.EngineOption != inventoryList[i].EngineOption
                        || model.BodyType != inventoryList[i].BodyType)*/
                    if (!IsEqualTo(inventoryList[i], model))
                    {
                        notInList = false;
                    }
                    else
                    {
                        index = i;
                        break;
                    }
                }

                /* PROBLEM: HAS BEEN FIXED
                    When I add a car and then add another one the exact same after, it works,
                    BUT, if I add a car with colour red, then one with yellow, then another one with red, it stills adds it
                    as another car instead of updating the quantity 
                 */

                // If it's not in the list, add it to the inventory
                if (!notInList)
                {
                    inventoryList.Add(model);

                    if (!isFromLoadingCars)
                        ShowStatusMessage("Successfully added car!");
                }
                else if (notInList)
                {
                    // Finding where it is in the list, and updating the quantity for the model (since we don't want to have duplicates in the table)
                    inventoryList[index].ModelQuantity += model.ModelQuantity;

                    if (!isFromLoadingCars)
                        ShowStatusMessage("Updated quantity!");
                }

                if (quantityTracker == maxInventory)
                    MessageBox.Show("Maximum Quantity in Inventory reached!", "No inventory", MessageBoxButton.OK, MessageBoxImage.Warning);

                int count = Model.GetMinimumQuantity(model);

                if (count < 2)
                {
                    counterNeedMoreOf -= count;
                }
            }
            else
                throw new ArgumentException($"Inventory quantity cannot exceed {MaxInventorySpace}", "AddItem");
        }
        public static int GetNeedMoreOf
        {
            get { return counterNeedMoreOf; }
        }
        /// <summary>
        /// Checking if both models are the EXACT same (for every input field)
        /// </summary>
        /// <param name="model"> 1st model </param>
        /// <param name="secondModel"> 2nd model </param>
        /// <returns></returns>
        public static bool IsEqualTo(Model model, Model secondModel)
        {
            bool answer;
            if (model.Name == secondModel.Name && model.Colour == secondModel.Colour 
                && model.EngineOption == secondModel.EngineOption && model.BodyType == secondModel.BodyType)
            {
                answer = true;
            }
            else
                answer = false;

            return answer;
        }

        public static void UpdateItem(Model model, int quantity)    //NEEDS TO BE IMPLEMENTED OR DELETED
        {
            if (inventoryList.Count == inventoryList.Capacity)
                throw new ArgumentException("You cannot add this many cars. Your parking lot is full!", "UpdateItem");

            model.ModelQuantity = quantity;
        }

        public static List<Model> CreateShoppingList()
        {
            List<Model> tempList = new List<Model>();
            for (int i = 0; i < AddingWindow.GetModelNames.Count; i++)
            {
                Model temp = new Model();
                temp.Name = AddingWindow.GetModelNames[i];

                int index = inventoryList.FindIndex(x => x.Name == temp.Name);

                if (index >= 0)
                {
                    if (!inventoryList[index].MinimumQuanitity(inventoryList[index]))
                    {
                        inventoryList[index].QuantityFromName = MIN_QUANTITY_EACH_MODEL - Model.GetMinimumQuantity(inventoryList[index]);
                        inventoryList[index].Information = $"Need {MIN_QUANTITY_EACH_MODEL - Model.GetMinimumQuantity(inventoryList[index])} more of model {inventoryList[index].Name}.";
                        tempList.Add(inventoryList[index]);
                    }
                }
                else
                {
                    temp.QuantityFromName = MIN_QUANTITY_EACH_MODEL;
                    temp.Information = $"Need {MIN_QUANTITY_EACH_MODEL} more of model {AddingWindow.GetModelNames[i]}.";
                    tempList.Add(temp);
                }
            }
            return tempList;
        }


        /*public static void LoadItems()                    CAN EVENTUALLY PROBABLY BE DELETED
        {
            string car = "a3, red";

            Model model = Model.FromCSV(car);
            //Inventory.AddItem(model); // was adding straight to model

           // Model.FromCSV(Inventory.me);
        }*/

        /// <summary>
        /// Printing successful adding car status message
        /// </summary>
        private static void ShowStatusMessage(string message)
        {
            MessageBox.Show(message);
        }

        public bool MinimumQuanitity(Model model)
        {
            return inventoryList.Count < 30;
        }
    }
}
