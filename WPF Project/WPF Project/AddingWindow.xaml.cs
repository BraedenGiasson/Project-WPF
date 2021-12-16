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
        int currentConstructorValue;

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

            // Setting constructor value
            currentConstructorValue = 0;
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
            {
                //MessageBox.Show("Constructor 3 (3 parameters - Engine)");
                Constructor3();

                // If the model name is "Q3", send specific engine options
                if(model == modelNames[6])
                    EngineOptions(new Engine[] { Engine.Fourty, Engine.FourtyFive });
                // If the model name is "Q7", send specific engine options
                else if (model == modelNames[8])
                    EngineOptions(new Engine[] { Engine.FourtyFive, Engine.FiftyFive });
            }
            // If the selection changed is anything for the 4th constructor
            else if (model == modelNames[3])
            {
                //MessageBox.Show("Constructor 4 (4 parameters)");
                Constructor4();
                EngineOptions(new Engine[] { Engine.FourtyFive, Engine.FiftyFive });
                BodyTypeOptions(cmbBodyType4, new Body[] { Body.Limousine, Body.Wagon });
            }
        }
        /// <summary>
        /// Adding a model (car) object to the models list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            Model model = null; // maybe take off null

            if (string.IsNullOrEmpty(cmbModelNames.Text))
                ValidatingInputFields();

            if ( currentConstructorValue == 1 )
            {
                // Create new model (car) object if constructor needed is 1
                if (ValidatingInputFields())
                {
                    model = new Model(cmbModelNames.Text, cmbColours.Text);
                    MessageBox.Show("Cons 1");
                }
            }
            else if (currentConstructorValue == 2)
            {
                // Create new model (car) object if constructor needed is 2
                if (ValidatingInputFields())
                {
                    model = new Model(cmbModelNames.Text, cmbColours.Text, (Body)cmbBodyType2.SelectedItem);
                    MessageBox.Show("Cons 2");
                }
            }
            else if(currentConstructorValue == 3)
            {
                // Create new model (car) object if constructor needed is 3
                if (ValidatingInputFields())
                {
                    model = new Model(cmbModelNames.Text, cmbColours.Text, (Engine)cmbEngine.SelectedItem);
                    MessageBox.Show("Cons 3");
                }
            }
            else if (currentConstructorValue == 4)
            {
                // Create new model (car) object if constructor needed is 4
                if (ValidatingInputFields())
                {
                    model = new Model(cmbModelNames.Text, cmbColours.Text, (Engine)cmbEngine.SelectedItem, (Body)cmbBodyType4.SelectedItem);
                    MessageBox.Show("Cons 4");
                }
            }
        }
        private bool ValidatingInputFields()
        {
            StringBuilder errorMessage = new StringBuilder();

            // FIRST, validating if the model name is filled out
            CheckModelNameField(ref errorMessage);

            // If the constructor is 1 (constructor 1 only needs to validate colour now), 2, 3, or 4, validate specific fields
            if (currentConstructorValue == 1 || currentConstructorValue == 2 || currentConstructorValue == 3 || currentConstructorValue == 4)
            {
                CheckColourField(ref errorMessage);

                // If the constructor is 2, validate body type field
                if (currentConstructorValue == 2)
                    CheckBodyTypeField(ref errorMessage, cmbBodyType2);
                // If the constructor is 3, validate engine field
                else if (currentConstructorValue == 3)
                    CheckEngineField(ref errorMessage);
                // If the constructor is 4, validate body type & engine fields
                else if (currentConstructorValue == 4)
                {
                    CheckEngineField(ref errorMessage);
                    CheckBodyTypeField(ref errorMessage, cmbBodyType4);
                }
            }

            // If no errors, return true with no message
            if (string.IsNullOrEmpty(errorMessage.ToString()))
                return true;

            // Displaying error
            MessageBox.Show(errorMessage.ToString(), "Required User Input", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }
        /// <summary>
        /// Validating the model name field
        /// </summary>
        /// <param name="errorMessage"> Reference to the error message stringbuilder </param>
        private void CheckModelNameField(ref StringBuilder errorMessage)
        {
            if (string.IsNullOrEmpty(cmbModelNames.Text))
                errorMessage.AppendLine("Model Name is a required field");
        }
        /// <summary>
        /// Validating the colour field
        /// </summary>
        /// <param name="errorMessage"> Reference to the error message stringbuilder </param>
        private void CheckColourField(ref StringBuilder errorMessage)
        {
            if (string.IsNullOrEmpty(cmbColours.Text))
                errorMessage.AppendLine("Colour is a required field");
        }
        /// <summary>
        /// Validating the body type field
        /// </summary>
        /// <param name="errorMessage"> Reference to the error message stringbuilder </param>
        /// <param name="bodyType"> The specific Body Type (cmbBodyType2 or cmbBodyType4) </param>
        private void CheckBodyTypeField(ref StringBuilder errorMessage, ComboBox bodyType)
        {
            if (string.IsNullOrEmpty(bodyType.Text))
                errorMessage.AppendLine("Body Type is a required field");
        }
        /// <summary>
        /// Validating the engine field
        /// </summary>
        /// <param name="errorMessage"> Reference to the error message stringbuilder </param>
        private void CheckEngineField(ref StringBuilder errorMessage)
        {
            if(string.IsNullOrEmpty(cmbEngine.Text))
                errorMessage.AppendLine("Engine is a required field");
        }
        
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (!changedData) // **** CHANGE TO !
            {
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
        /// Binding engine options
        /// </summary>
        /// <param name="engines"> Array of engines to bind </param>
        private void EngineOptions(Engine[] engines)
        {
            cmbEngine.ItemsSource = engines;
        }
        /// <summary>
        /// Binding Body Type options
        /// </summary>
        /// <param name="body"> Specific Body Type (cmbBodyType2 or cmbBodyType4) </param>
        /// <param name="bodies"> Array of body types to bind </param>
        private void BodyTypeOptions(ComboBox body, Body[] bodies)
        {
            body.ItemsSource = bodies;
        }
        
        /// <summary>
        /// Showing the options for the 1st type of constructor
        /// </summary>
        private void Constructor1()
        {
            currentConstructorValue = 1; // setting the current constructor value

            ShowColour();
            HideEngine();
            HideBodyType();
        }
        /// <summary>
        /// Showing the options for the 2nd type of constructor
        /// </summary>
        private void Constructor2()
        {
            currentConstructorValue = 2; // setting the current constructor value

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
            currentConstructorValue = 3; // setting the current constructor value

            ShowColour();
            ShowEngine();
            HideBodyType();
        }
        /// <summary>
        /// Showing the options for the 4th type of constructor
        /// </summary>
        private void Constructor4()
        {
            currentConstructorValue = 4; // setting the current constructor value

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
