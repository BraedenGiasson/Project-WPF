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
        List<string> modelNames;

        public AddingWindow()
        {
            List<Body> bodyTypes = Enum.GetValues(typeof(Body))
                            .Cast<Body>()
                            .ToList();

            modelNames = new List<string>() 
                { "A3", "A4", "A5", "A6", "A7", "A8", "Q3", "Q5", "Q7", "Q8", "R8", "TT", "e-tron", "e-tron GT", "Q4 e-tron" };

            InitializeComponent();

            // Binding
            cmbBodyType.ItemsSource = bodyTypes;
            cmbModelNames.ItemsSource = modelNames;
            //txtColour.Visibility = Visibility.Hidden;
        }
        
        private void cmbModelNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string model = cmbModelNames.SelectedValue as string;

            // If the selection changed is anything for the 1st constructor
            if ( model == modelNames[0] || model == modelNames[4] || model == modelNames[5] 
                || model == modelNames[7] || model == modelNames[9] || model == modelNames[13])
                MessageBox.Show("Constructor 1 (2 parameters)");
            // If the selection changed is anything for the 2nd constructor
            else if ( model == modelNames[1] || model == modelNames[2] || model == modelNames[10] || model == modelNames[11] 
                || model == modelNames[12] || model == modelNames[14] )
                MessageBox.Show("Constructor 2 (3 parameters - Body Type)");
            // If the selection changed is anything for the 3rd constructor
            else if ( model == modelNames[6] || model == modelNames[8] )
                MessageBox.Show("Constructor 3 (3 parameters - Engine)");
            // If the selection changed is anything for the 4th constructor
            else if (model == modelNames[3] )
                MessageBox.Show("Constructor 4 (4 parameters)");
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
