using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Project.Models;


namespace WPF_Project
{
    /// <summary>
    /// Interaction logic for AddingWindow.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
        // Saving For Adding Window
        private bool changedData = false;

        public AddingWindow()
        {
            List<Body> bodyTypes = Enum.GetValues(typeof(Body))
                            .Cast<Body>()
                            .ToList();

            List<string> modelNames = new List<string>() 
                { "A3", "A4", "A5", "A7", "A8", "Q3", "Q5", "Q7", "Q8", "R8", "TT", "e-tron", "e-tron GT", "Q4 e-tron" };

            InitializeComponent();

            // Binding
            cmbBodyType.ItemsSource = bodyTypes;
            cmbModelNames.ItemsSource = modelNames;
            //txtColour.Visibility = Visibility.Hidden;
        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (!changedData) // **** CHANGE TO !
            {
                //this.Close();
                // Double checking if user really wants to go back
                MessageBoxResult result =
                    MessageBox.Show("Are you sure you want to go back?", "Unsaved changes", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                // If the result from the user answer is no, return true
                if (result == MessageBoxResult.No)
                    return;
                // If the result from the user answer is yes, save the data
                if (result == MessageBoxResult.Yes)
                    this.Close();
            }
            
        }
    }
}
