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
using WPF_Project.Interfaces;
using WPF_Project.Models;

namespace WPF_Project
{
    /// <summary>
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
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

        /// <summary>
        /// Deleting the item from the inventory list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDelete_Click(object sender, RoutedEventArgs e)
        {
            Model temp = dgModels.SelectedItem as Model;

            if (temp != null)
            {
                Inventory.InventoryList.Remove(temp);
                dgModels.Items.Refresh();
                MainWindow.Saved = false;
            }
        }
    }
}
