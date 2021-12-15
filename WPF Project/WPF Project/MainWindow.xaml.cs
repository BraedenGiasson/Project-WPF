using System;
using System.Collections.Generic;
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
        
        List<BodyType> bodyTypes = new List<BodyType>();

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
    }
}
