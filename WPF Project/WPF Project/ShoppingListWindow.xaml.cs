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
using WPF_Project.Interfaces;
using WPF_Project.Models;

namespace WPF_Project
{
    /// <summary>
    /// Interaction logic for ShoppingListWindow.xaml
    /// </summary>
    public partial class ShoppingListWindow : Window
    {
        public ShoppingListWindow()
        {
            InitializeComponent();

            dgShoppingList.ItemsSource = Inventory.CreateShoppingList();
        }

        private void btnSaveAs_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.SaveAsLogic();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
