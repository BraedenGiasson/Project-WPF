using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        // Backing fields
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
                txtQuantityOnScreen.Text = Inventory.QuantityTracker.ToString();

                txtNeedMoreValue.Visibility = Visibility.Hidden;
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
                txtQuantityOnScreen.Text = Inventory.QuantityTracker.ToString();
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
        //private void btnShowAll_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        ModelWindow modelWindow = new ModelWindow();

        //        // If model list has cars, show all cars
        //        if (Inventory.InventoryList.Count != NO_MODELS)
        //            modelWindow.ShowDialog(); // throwing error because initally null
        //                                      // If not, give message saying no cars in stock
        //        else
        //            MessageBox.Show("Sorry, no cars in stock at the moment!", "No inventory", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        //}
        /// <summary>
        /// Window for the shopping list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShoppingList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ShoppingListWindow shoppingList = new ShoppingListWindow();

                if (Inventory.InventoryList.Count != NO_MODELS)
                    shoppingList.ShowDialog();
                else
                    MessageBox.Show("Sorry, no cars to show! No cars in stock!", "No inventory", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// Saving all the data at the right location
        /// </summary>bt
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
        /// <summary>
        /// Saving content to file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveData();
        }
        /// <summary>
        /// About us message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuAboutUs_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("We are the best team!");
        }
        /// <summary>
        /// Opening file and refreshing inventory to show new models from file
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
        /// <summary>
        /// Reading models (cars) from a file
        /// </summary>
        private void ReadModelsFromFile()
        {
            try
            {
                string[] allValues = File.ReadAllLines(saveLocation);
                Inventory.QuantityTracker = 0;
                //create visitor objects and add them to list
                foreach (string modelInfo in allValues)
                {
                    //visitors.Add(new Visitor() { CSVData = visitorInfo });
                    Model temp = new Model();
                     temp.CSVData = modelInfo;
                    //Inventory.QuantityTracker++;
                    //Inventory.InventoryList.Add(temp);
                }
                txtQuantityOnScreen.Text = Inventory.QuantityTracker.ToString();
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
        /// <summary>
        /// Showing Save As dialog for user to save to fifferent file/location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveAsLogic();
        }
        /// <summary>
        /// Logic for 'Save As' button click
        /// </summary>
        public void SaveAsLogic() // need to figure out how to change logic so that if hit's cancel
        {
            saved = false;
            saveLocation = "";
            SaveData();
        }
        /// <summary>
        /// If the user deletes an item, delete it from the inventory and reduce the inventory quantity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgModels_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // If the user presses delete key (to delete a model)
                if (e.Key == Key.Delete)
                {
                    Model temp = dgModels.SelectedItem as Model;

                    // If the model is not an empty model, remove from inventory
                    if (temp != null)
                    {
                        Inventory.InventoryList.Remove(temp);
                        Inventory.QuantityTracker -= temp.ModelQuantity; // reducing inventory quantity                    
                        dgModels.Items.Refresh(); // refreshing items

                        if (Inventory.QuantityTracker == Inventory.MaxInventorySpace)
                            MessageBox.Show("Maximum Quantity in Inventory reached!", "No inventory", MessageBoxButton.OK, MessageBoxImage.Warning);

                        txtQuantityOnScreen.Text = Inventory.QuantityTracker.ToString();
                        Saved = false; // not saved anymore
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        /// <summary>
        /// When the cell quantity is edited, update 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgModels_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                if (e.EditAction == DataGridEditAction.Commit)
                {
                    var column = e.Column as DataGridBoundColumn;
                    if (column != null)
                    {
                        var bindingPath = (column.Binding as Binding).Path.Path;

                        if (bindingPath == "ModelQuantity")
                        {
                            bool isOverQuantityLimit = false;
                            int rowIndex = e.Row.GetIndex();
                            var el = e.EditingElement as TextBox;

                            Inventory.QuantityTracker -= Inventory.InventoryList[rowIndex].ModelQuantity;

                            if ((Convert.ToInt32(el.Text.ToString()) + Inventory.QuantityTracker) > Inventory.MaxInventorySpace)
                            {
                                MessageBox.Show($"Quantity in Inventory List cannot exceed {Inventory.MaxInventorySpace}.", "ModelQuantity");
                                isOverQuantityLimit = true;
                                el.Text = Inventory.InventoryList[rowIndex].ModelQuantity.ToString();
                            }

                            if (!isOverQuantityLimit)
                                Inventory.InventoryList[rowIndex].ModelQuantity = Convert.ToInt32(el.Text.ToString());
                            
                            

                            Inventory.QuantityTracker += Inventory.InventoryList[rowIndex].ModelQuantity;

                            if (Inventory.QuantityTracker == Inventory.MaxInventorySpace)
                                MessageBox.Show("Maximum Quantity in Inventory reached!", "No inventory", MessageBoxButton.OK, MessageBoxImage.Warning);

                            txtQuantityOnScreen.Text = Inventory.QuantityTracker.ToString();
                            Saved = false;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void ShowLowInventoryMessage(int numberMore)
        {
            txtNeedMoreValue.Visibility = Visibility.Visible;

            txtNeedMoreValue.Foreground = Brushes.Red;
            txtNeedMoreValue.Text = $"Inventory Low! Need {numberMore} more different types of models.";
        }
    }
}
