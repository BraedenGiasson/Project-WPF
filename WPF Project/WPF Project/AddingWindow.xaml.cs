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
            cmbModelNames.ItemsSource = modelNames;
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
        }
        /// <summary>
        /// When an option in the dropdown of model names is changed, preform behavior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbModelNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeNameWhenFieldIsSelected();
            string model = cmbModelNames.SelectedValue as string;

            // If the selection changed is anything for the 1st constructor
            if (model == modelNames[0] || model == modelNames[4] || model == modelNames[5]
                || model == modelNames[7] || model == modelNames[9] || model == modelNames[13])
                //MessageBox.Show("Constructor 1 (2 parameters)");
                Constructor1();
            // If the selection changed is anything for the 2nd constructor
            else if (model == modelNames[1] || model == modelNames[2] || model == modelNames[10] || model == modelNames[11]
                || model == modelNames[12] || model == modelNames[14])
                //MessageBox.Show("Constructor 2 (3 parameters - Body Type)");
                Constructor2();
            // If the selection changed is anything for the 3rd constructor
            else if (model == modelNames[6] || model == modelNames[8])
                //MessageBox.Show("Constructor 3 (3 parameters - Engine)");
                Constructor3();
            // If the selection changed is anything for the 4th constructor
            else if (model == modelNames[3])
                //MessageBox.Show("Constructor 4 (4 parameters)");
                Constructor4();
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
        /// <summary>
        /// Showing the options for the 1st type of constructor
        /// </summary>
        private void Constructor1()
        {
            ShowColour();
            HideEngine();
            HideBodyType();
        }
        /// <summary>
        /// Showing the options for the 2nd type of constructor
        /// </summary>
        private void Constructor2()
        {
            ShowColour();
            HideEngine();
            HideBodyType();
            ShowBodyType(txtBodyType2, cmbBodyType2);
        }
        /// <summary>
        /// Showing the options for the 3rd type of constructor
        /// </summary>
        private void Constructor3()
        {
            ShowColour();
            ShowEngine();
            HideBodyType();
        }
        /// <summary>
        /// Showing the options for the 4th type of constructor
        /// </summary>
        private void Constructor4()
        {
            ShowColour();
            HideBodyType();
            ShowEngine();
            ShowBodyType(txtBodyType4, cmbBodyType4);
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
        /// Showing the engine text and dropdown
        /// </summary>
        private void ShowEngine()
        {
            txtEngine.Visibility = Visibility.Visible;
            cmbEngine.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Showing the body type text and dropdown
        /// </summary>
        /// <param name="bodyTypeText"> body type text (either the 1st or second in order on XAML) </param>
        /// <param name="bodyTypes"> body type dropdown (either the 1st or second in order on XAML) </param>
        private void ShowBodyType(TextBlock bodyTypeText, ComboBox bodyTypes)
        {
            bodyTypeText.Visibility = Visibility.Visible;
            bodyTypes.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Hiding the engine text and dropdown
        /// </summary>
        private void HideEngine()
        {
            txtEngine.Visibility = Visibility.Hidden;
            cmbEngine.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Hiding both body types text and dropdown
        /// </summary>
        private void HideBodyType()
        {
            txtBodyType2.Visibility = Visibility.Hidden;
            cmbBodyType2.Visibility = Visibility.Hidden;

            txtBodyType4.Visibility = Visibility.Hidden;
            cmbBodyType4.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Changing the name of 'Choose a name' to 'Model Name' when FIRST selection is changed
        /// </summary>
        private void ChangeNameWhenFieldIsSelected()
        {
            txtCarName.Text = "Model Name";
        }
    }
}
