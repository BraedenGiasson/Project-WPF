﻿using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        // Saving For Adding Window
        private bool changedData = false;
        List<string> modelNames;
        int currentConstructorValue;

        public UpdateWindow()
        {
            List<Body> bodyTypes = Enum.GetValues(typeof(Body))
                            .Cast<Body>()
                            .ToList();
            List<Colour> colourTypes = Enum.GetValues(typeof(Colour))
                            .Cast<Colour>()
                            .ToList();
            List<Engine> engineTypes = Enum.GetValues(typeof(Engine))
                            .Cast<Engine>()
                            .ToList();

            modelNames = new List<string>()
                { "A3", "A4", "A5", "A6", "A7", "A8", "Q3", "Q5", "Q7", "Q8", "R8", "TT", "e-tron", "e-tron GT", "Q4 e-tron" };

            InitializeComponent();

            // Binding all input fields
            cmbBodyType4.ItemsSource = bodyTypes;
            cmbBodyType2.ItemsSource = bodyTypes;
            cmbModelNames.ItemsSource = GettingNamesOfModelsInInventory();
            cmbColours.ItemsSource = colourTypes;
            cmbEngine.ItemsSource = engineTypes;

            // Hidding all items initally
            txtColour.Visibility = Visibility.Hidden;
            cmbColours.Visibility = Visibility.Hidden;

            txtEngine.Visibility = Visibility.Hidden;
            cmbEngine.Visibility = Visibility.Hidden;

            txtBodyType2.Visibility = Visibility.Hidden;
            cmbBodyType2.Visibility = Visibility.Hidden;

            txtBodyType4.Visibility = Visibility.Hidden;
            cmbBodyType4.Visibility = Visibility.Hidden;

            // Setting constructor value
            currentConstructorValue = 0;
        }
        private List<string> GettingNamesOfModelsInInventory() // add validation to avoid duplicates
        {
            List<string> names = new List<string>();
            for (int i = 0; i < Inventory.InventoryList.Count; i++)
            {
                if (Inventory.InventoryList[i].Name != "" && !names.Contains(Inventory.InventoryList[i].Name))
                    names.Add(Inventory.InventoryList[i].Name);
            }
            return names;
        }
        private List<string> GetColourFromModel(string model) // add validation to avoid duplicates
        {
            List<string> colours = new List<string>();
            for (int i = 0; i < Inventory.InventoryList.Count; i++)
            {
                if (Inventory.InventoryList[i].Name == model)
                {
                    if (Inventory.InventoryList[i].Colour != "" && !colours.Contains(Inventory.InventoryList[i].Colour))
                        colours.Add(Inventory.InventoryList[i].Colour);
                }
            }
            return colours;
        }

        private void cmbModelNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeNameWhenFieldIsSelected();
            string model = cmbModelNames.SelectedValue as string;

            ShowColour();
            cmbModelNames.ItemsSource = GettingNamesOfModelsInInventory();
            cmbColours.ItemsSource = GetColourFromModel(model);
        }
        private void cmbColours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string colour = cmbColours.SelectedValue as string;
            

            MessageBox.Show(GetModelInfoFromNameAndColour(), "Hi", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private string GetModelInfoFromNameAndColour()
        {
            string model = cmbModelNames.SelectedValue as string;
            string colour = cmbColours.SelectedValue as string;

            int index = Inventory.InventoryList.FindIndex(x => x.Name == model && x.Colour == colour);
            //txtTheText.Text = Inventory.InventoryList[index].ToString();
            return Inventory.InventoryList[index].EngineOption.ToString();
        }
        /// <summary>
        /// Showing the color text and dropdown
        /// </summary>
        private void ShowColour()
        {
            txtColour.Visibility = Visibility.Visible;
            cmbColours.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Changing the name of 'Choose a name' to 'Model Name' when FIRST selection is changed
        /// </summary>
        private void ChangeNameWhenFieldIsSelected()
        {
            txtCarName.Text = "Model Name";
        }

        private void btnSelectCar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbColours.Visibility == Visibility.Visible)
            {

            }
            if (cmbEngine.Visibility == Visibility.Visible)
            {

            }
            if (cmbBodyType2.Visibility == Visibility.Visible)
            {

            }
            if (cmbBodyType4.Visibility == Visibility.Visible)
            {

            }
        }
    }
}
