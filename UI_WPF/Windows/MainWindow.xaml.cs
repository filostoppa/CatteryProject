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
using Application.UseCases;
using UI_WPF.Windows;

namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RefreshTotalCatsNumber()
        {
            TxtBlockNumeroGattiTotali.Text = $"Gatti totali: {new CatService().GetAllCats().Count}";
        }
        private void MaleCatsCounter()
        {

        }
        private void FemaleCatsCounter()
        {

        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void AddCatButton_Click(object sender, RoutedEventArgs e)
        {
            AddCatWindow addCatWindow = new AddCatWindow();
            addCatWindow.ShowDialog();
            RefreshTotalCatsNumber();
        }
        private void ManageCatButton_Click(object sender, RoutedEventArgs e)
        {
            ManageCatWindow manageCatWindow = new ManageCatWindow();
            manageCatWindow.ShowDialog();
            RefreshTotalCatsNumber();
        }
        private void AddAdoptionButton_Click(object sender, RoutedEventArgs e)
        {
            AddAdoptionWindow addAdoptionWindow = new AddAdoptionWindow();
            addAdoptionWindow.ShowDialog();
            RefreshTotalCatsNumber();
        }
        public void ManageAdoptionButton_Click(object sender, RoutedEventArgs e)
        {
            ManageAdoptionWindow manageAdoptionWindow = new ManageAdoptionWindow();
            manageAdoptionWindow.ShowDialog();
            RefreshTotalCatsNumber();
        }
        private void AddAdopterButton_Click(object sender, RoutedEventArgs e)
        {
            AddAdopterWindow addAdopterWindow = new AddAdopterWindow();
            addAdopterWindow.ShowDialog();
            RefreshTotalCatsNumber();
        }
        private void ManageAdopterButton_Click(object sender, RoutedEventArgs e)
        {
            ManageAdopterWindow manageAdopterWindow = new ManageAdopterWindow();
            manageAdopterWindow.ShowDialog();
            RefreshTotalCatsNumber();
        }
    }
}