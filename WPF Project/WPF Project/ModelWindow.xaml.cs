using System;
using System.Collections.Generic;
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
    /// Interaction logic for ModelWindow.xaml
    /// </summary>
    public partial class ModelWindow : Window
    {
        public ModelWindow()
        {
            InitializeComponent();

            // Binding
            dgModels.ItemsSource = Inventory.InventoryList;
        }
        /// <summary>
        /// Copying the text to clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuCopy_Click(object sender, RoutedEventArgs e)
        {
            Model temp = dgModels.SelectedItem as Model;

            if (temp != null)
                Clipboard.SetText(temp.FullInfo);
        }
    }
}
