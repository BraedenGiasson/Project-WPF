using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_Project.Interfaces;
using WPF_Project.Models;

namespace WPF_Project
{
    /// <summary>
    /// Interaction logic for ShoppingListWindow.xaml
    /// </summary>
    public partial class ShoppingListWindow : Window
    {
        // Saving For Main Window
        private string saveLocation = string.Empty;
        private static bool saved = false;

        public ShoppingListWindow()
        {
            InitializeComponent();

            dgShoppingList.ItemsSource = Inventory.CreateShoppingList(); // binding
        }
        /// <summary>
        /// Saving shopping list content to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
        }
        /// <summary>
        /// Saving all the data at the right location
        /// </summary>
        public void SaveData()
        {
            // Logic for if the data is being saved for the first time
            if (string.IsNullOrEmpty(saveLocation))
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "CVS Files|*.csv"; // Only accepts CSV files

                // Saving the data to the specified location
                if (save.ShowDialog() == true)
                    saveLocation = save.FileName;
                else
                    return;
            }
            WriteDataToFile();
        }
        /// <summary>
        /// Writing the data to the file
        /// </summary>
        public void WriteDataToFile()
        {
            if (!saved)
            {
                try
                {
                    StringBuilder modelsCSV = new StringBuilder();

                    // Adding each model in the inventory to the shopping list
                    foreach (Model model in Inventory.CreateShoppingList())
                        modelsCSV.AppendLine(model.ShoppingListCSVData);

                    File.WriteAllText(saveLocation, modelsCSV.ToString()); // writing all the text to the file (at the right location)
                    saved = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
