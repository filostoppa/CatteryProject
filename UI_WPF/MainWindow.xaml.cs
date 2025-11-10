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
using UI_WPF.AdoptionWindows;

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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void RefreshTotalCatsNumber()
        {
            TxtBlockNumeroGattiTotali.Text = $"Gatti totali: {new CatService().GetAllCats().Count}";
        }
        private void MaleCatsCounter()
        {

        }
        private void AddCat(object sender, RoutedEventArgs e)
        {
            AddCatWindow manageCatsWindow = new AddCatWindow();
            manageCatsWindow.ShowDialog();
            RefreshTotalCatsNumber();
        }
        private void ManageCats(object sender, RoutedEventArgs e)
        {
            ManageCatsWindow manageCatsWindow = new ManageCatsWindow();
            manageCatsWindow.ShowDialog();
            RefreshTotalCatsNumber();
        }
        private void AddAdopter(object sender, RoutedEventArgs e)
        {
            AddAdopterWindow addAdopterWindow = new AddAdopterWindow();
            addAdopterWindow.ShowDialog();
        }
        private void ManageAdopters(object sender, RoutedEventArgs e)
        {
            ManageAdoptersWindow manageAdopterWindow = new ManageAdoptersWindow();
            manageAdopterWindow.ShowDialog();
        }
        private void AddAdoption(object sender, RoutedEventArgs e)
        {
            AddAdoptionWindow addAdoptionWindow = new AddAdoptionWindow();
            addAdoptionWindow.ShowDialog();
        }
        private void ManageAdoptions(object sender, RoutedEventArgs e)
        {
            ManageAdoptionsWindow manageAdoptionsWindow = new ManageAdoptionsWindow();
            manageAdoptionsWindow.ShowDialog();
        }
    }
}