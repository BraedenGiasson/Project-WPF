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
using System.Windows.Shapes;
using WPF_Project.Models;

namespace WPF_Project
{
    /// <summary>
    /// Interaction logic for AddingWindow.xaml
    /// </summary>
    public partial class AddingWindow : Window
    {
        public AddingWindow()
        {
            List<Body> bodyTypes = Enum.GetValues(typeof(Body))
                            .Cast<Body>()
                            .ToList();

            InitializeComponent();

            // Binding
            cmbBodyType.ItemsSource = bodyTypes;
            //txtColour.Visibility = Visibility.Hidden;
        }
    }
}
