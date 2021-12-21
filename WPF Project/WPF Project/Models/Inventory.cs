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
                // If value isn't a number, throw error
                if (!value.ToString().Any(char.IsDigit))
                    throw new ArgumentException("Value has to be numeric", "QuantityTracker");
                // If value is greater than max size for inventory, throw error
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
            QuantityTracker += model.ModelQuantity; // updating inventory total quantity

            // If no models in inventory, add first car
            if (inventoryList.Count == NO_MODELS) 
                AddCarShowSuccessful(model, isFromLoadingCars, "Successfully added car first car!");
            // Making sure the quantity for the dealership is below the max allowed
            else if (quantityTracker <= maxInventory)
            {
                bool notInList = true;

                // Checking if item to be added is already in the inventory list
                int findIndex = inventoryList.FindIndex(x =>
                    model.Name == x.Name
                    && model.Colour == x.Colour
                    && model.EngineOption == x.EngineOption
                    && model.BodyType == x.BodyType
                );

                // If the index isn't found, it isn't in the inventory
                if (findIndex < 0)
                    notInList = false;

                // If it's not in the list, add it to the inventory
                if (!notInList)
                    AddCarShowSuccessful(model, isFromLoadingCars, "Successfully added car!");
                else if (notInList)
                {
                    // Finding where it is in the list, and updating the quantity for the model (since we don't want to have duplicates in the table)
                    inventoryList[findIndex].ModelQuantity += model.ModelQuantity;

                    if (!isFromLoadingCars)
                        ShowStatusMessage("Updated quantity!");
                }

                if (quantityTracker == maxInventory)
                    MessageBox.Show("Maximum Quantity in Inventory reached!", "No inventory", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                throw new ArgumentException($"Inventory quantity cannot exceed {MaxInventorySpace}", "AddItem");
        }
        /// <summary>
        /// Property for how many more different types of models are needed (min 30)
        /// </summary>
        public static int NeedMoreOf
        {
            get { return counterNeedMoreOf; }
        }
        private static void AddCarShowSuccessful(Model model, bool isFromLoadingCars, string message)
        {
            inventoryList.Add(model); // adding to list

            if (!isFromLoadingCars)
                ShowStatusMessage(message);
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

        /// <summary>
        /// Creating the shopping list (models that don't have AT LEAST 2 different types)
        /// </summary>
        /// <returns> List of models </returns>
        public static List<Model> CreateShoppingList()
        {
            List<Model> tempList = new List<Model>();

            for (int i = 0; i < AddingWindow.GetModelNames.Count; i++)
            {
                Model temp = new Model();
                temp.Name = AddingWindow.GetModelNames[i];

                int index = inventoryList.FindIndex(x => x.Name == temp.Name); // getting index from inventory where model is

                // If found, add to list and display quantity and how much needed
                if (index >= 0)
                {
                    if (!inventoryList[index].MinimumQuanitity(inventoryList[index]))
                    {
                        inventoryList[index].QuantityFromName = MIN_QUANTITY_EACH_MODEL - Model.GetMinimumQuantity(inventoryList[index]);
                        inventoryList[index].Information = $"Need {MIN_QUANTITY_EACH_MODEL - Model.GetMinimumQuantity(inventoryList[index])} more of model {inventoryList[index].Name}.";
                        tempList.Add(inventoryList[index]);
                    }
                }
                // If not found, add to list and display quantity and how much needed (2)
                else
                {
                    temp.QuantityFromName = MIN_QUANTITY_EACH_MODEL;
                    temp.Information = $"Need {MIN_QUANTITY_EACH_MODEL} more of model {AddingWindow.GetModelNames[i]}.";
                    tempList.Add(temp);
                }
            }
            return tempList;
        }
        /// <summary>
        /// Printing successful adding car status message
        /// </summary>
        private static void ShowStatusMessage(string message)
        {
            MessageBox.Show(message);
        }
        /// <summary>
        /// Minimum quantity for inventory (30)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool MinimumQuanitity(Model model)
        {
            return counterNeedMoreOf < MINIMUM_QUANTITY;
        }
        /// <summary>
        /// Getting quantity of models to shop for
        /// </summary>
        public static void GetNeedMoreOfQuantity()
        {
            counterNeedMoreOf = 0; // setting to 0 to start loop over

            // For every model type, get amount needed to shop for (has to be MINIMUM 2 different each model)
            for (int i = 0; i < AddingWindow.GetModelNames.Count; i++)
            {
                Model temp = new Model();
                temp.Name = AddingWindow.GetModelNames[i];

                int index = inventoryList.FindIndex(x => x.Name == temp.Name); // getting index from inventory where model is

                // If found, check minimum quantity and get count
                if (index >= 0)
                {
                    if (!inventoryList[index].MinimumQuanitity(inventoryList[index]))
                        counterNeedMoreOf += MIN_QUANTITY_EACH_MODEL - Model.GetMinimumQuantity(inventoryList[index]);
                }
                // If not found, get count needed (2) 
                else
                    counterNeedMoreOf += MIN_QUANTITY_EACH_MODEL;
            }
        }
    }
}
