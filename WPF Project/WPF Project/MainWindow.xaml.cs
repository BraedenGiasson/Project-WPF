using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Project.Models;

namespace WPF_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        private List<Model> models = new List<Model>();
        private const int NO_MODELS = 0;

        // Saving For Main Window
        private string saveLocation = string.Empty;
        private static bool saved = false;

        // Company information
        /*private static readonly string makeName = "Audi";
        private static readonly string makeCountry = "Germany";
        private static readonly string makeCategory = "luxurious";*/

        public MainWindow()
        {
            try
            {
                InitializeComponent();

                dgModels.ItemsSource = Inventory.InventoryList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            // Displaying company information
            /*txtWelcomeName.Text += $"{makeName}!";
            txtDescription.Text = $"The most {makeCategory} car company in {makeCountry}!";*/
        }
        /// <summary>
        /// Window for the 'Adding car'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddingWindow addingWindow = new AddingWindow();
                addingWindow.ShowDialog();
                dgModels.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
        /// <summary>
        /// Window for the 'Update car'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateWindow updateWindow = new UpdateWindow();

                // If model list has cars, show all cars
                if (Inventory.InventoryList.Count != NO_MODELS)
                    updateWindow.ShowDialog(); // throwing error because initally null
                                               // If not, give message saying no cars in stock
                else
                    MessageBox.Show("Sorry, no cars in stock at the moment!", "No inventory", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }
        /// <summary>
        /// Window for the 'Delete car'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DeleteWindow deleteWindow = new DeleteWindow();
                if (Inventory.InventoryList.Count != NO_MODELS)
                    deleteWindow.ShowDialog();
                else
                    MessageBox.Show("Sorry, no cars in stock at the moment!", "No inventory", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); } 
        }
        /// <summary>
        /// Displaying everything in inventory in table format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ModelWindow modelWindow = new ModelWindow();

                // If model list has cars, show all cars
                if (Inventory.InventoryList.Count != NO_MODELS)
                    modelWindow.ShowDialog(); // throwing error because initally null
                                              // If not, give message saying no cars in stock
                else
                    MessageBox.Show("Sorry, no cars in stock at the moment!", "No inventory", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }
        /// <summary>
        /// Window for the shopping list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShoppingList_Click(object sender, RoutedEventArgs e)
        {

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
        private void WriteDataToFile()
        {
            if (!saved)
            {
                try
                {
                    StringBuilder modelsCSV = new StringBuilder();

                    // Adding each model in the inventory to the list
                    foreach (Model model in Inventory.InventoryList)
                        modelsCSV.AppendLine(model.CSVData);

                    File.WriteAllText(saveLocation, modelsCSV.ToString()); // writing all the text to the file (at the right location)
                    saved = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// Checking to see if the file should really be opened (saved)
        /// </summary>
        /// <returns></returns>
        private bool ChecktoOpen()
        {
            // If the file is already saved, return true
            if (saved)
                return true;
            // If the file is null or their is no models cars, return true
            if (string.IsNullOrEmpty(saveLocation) && models.Count == 0)
                return true;

            // If data is not saved, ask user if they want to save the data
            MessageBoxResult result =
                MessageBox.Show("Do you want to save changes?", "Unsaved changes", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

            // If the result from the user answer is no, return true
            if (result == MessageBoxResult.No)
                return true;
            // If the result from the user answer is cancel, return false and go back to window
            if (result == MessageBoxResult.Cancel)
                return false;
            // If the result from the user answer is yes, save the data
            if (result == MessageBoxResult.Yes)
                SaveData();

            return false; //if the user saved it mean it ok to open a file and if the user cancels then saved will be false
        }

        /// <summary>
        /// Used to check if saving data needed when trying to close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !ChecktoOpen();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
        }

        private void menuAboutUs_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("We are the best team!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (ChecktoOpen())
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "CVS Files|*.csv";
                if (open.ShowDialog() == true)
                {
                    //save location
                    saveLocation = open.FileName;
                    //clear current list
                    Inventory.InventoryList.Clear();
                    //read from file
                    ReadModelsFromFile();
                    //update UI
                    dgModels.Items.Refresh();             //NOT SURE WHAT TO PUT HERE
                    saved = true;
                }
            }
        }

        private void ReadModelsFromFile()
        {
            try
            {
                string[] allValues = File.ReadAllLines(saveLocation);
                //create visitor objects and add them to list
                foreach (string modelInfo in allValues)
                {
                    //visitors.Add(new Visitor() { CSVData = visitorInfo });
                    Model temp = new Model();
                     temp.CSVData = modelInfo;
                    //Inventory.QuantityTracker++;
                    //Inventory.InventoryList.Add(temp);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Property to set the value of saved in other windows
        /// </summary>
        public static bool Saved
        {
            get { return saved; }
            set { saved = value; }
        }

        //private void dgModels_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        //{
        //    if (e.EditAction == DataGridEditAction.Commit)
        //    {
        //        var column = e.Column as DataGridBoundColumn;
        //        if (column != null)
        //        {
                    
        //            var bindingPath = (column.Binding as Binding).Path.Path;
        //            if (bindingPath == "ModelQuantity")
        //            {
        //                int rowIndex = e.Row.GetIndex();
        //                var el = e.EditingElement as TextBox;
        //                //Console.WriteLine(Inventory.InventoryList);
        //                if(Inventory.InventoryList[rowIndex].ModelQuantity > Inventory.MaxInventorySpace)
        //                   MessageBox.Show($"Inventory quantity cannot exceed {Inventory.MaxInventorySpace}", "AddItem");
                        
        //                // rowIndex has the row index
        //                // bindingPath has the column's binding
        //                // el.Text has the new, user-entered value
        //            }
        //        }
        //    }
        //}
    }
}
