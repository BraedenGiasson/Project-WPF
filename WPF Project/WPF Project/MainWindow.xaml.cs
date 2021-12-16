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
        List<Body> bodyTypes = new List<Body>();

        // Saving 
        private string saveLocation = string.Empty;
        private bool saved = false;

        public MainWindow()
        {
            InitializeComponent();

            models.Add(new Model("A3", "red"));
            models.Add(new Model("A7", "blue"));
            models.Add(new Model("Q5", "white"));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddingWindow addingWindow = new AddingWindow();
            addingWindow.Show();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            ModelWindow modelWindow = new ModelWindow(models);
            modelWindow.Show();
        }

        private void btnShoppingList_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveLogic()
        {
            if (string.IsNullOrEmpty(saveLocation))
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "CVS Files|*.csv";//"Description|*.xyz|file2|*.file2";
                if (save.ShowDialog() == true)
                {
                    saveLocation = save.FileName;
                }
                else
                    return;
            }
            WriteDataToFile();
        }

        private void WriteDataToFile()
        {
            if (!saved)
            {
                try
                {
                    StringBuilder modelsCSV = new StringBuilder();
                    foreach (Model visitor in models)
                        //modelsCSV.AppendLine(visitor.CSVData);

                    File.WriteAllText(saveLocation, modelsCSV.ToString());
                    saved = true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private bool ChecktoOpen()
        {
            if (saved)
                return true;

            if (string.IsNullOrEmpty(saveLocation) && models.Count == 0)
                return true;


            //Data is not saved
            MessageBoxResult result =
                MessageBox.Show("Do you want to save changes?", "Unsaved changes", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);


            if (result == MessageBoxResult.No)
                return true;

            if (result == MessageBoxResult.Cancel)
                return false;

            if (result == MessageBoxResult.Yes)
                SaveLogic();

            return saved; //if the user saved it mean it ok to open a file and if the user cancels then saved will be false

        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !ChecktoOpen();
        }
    }
}
