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
using UI_WPF.Adopter;
using UI_WPF.Adoptions;
using Application.Dto;

namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            List<CatDTO> catDTOList;
            InitializeComponent();
            catDTOList = new List<CatDTO>();
            DataContext = this;
        }
        public List<CatDTO> CatDTOList;

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
        public void AddCat(object sender, RoutedEventArgs e)
        {
            AddCatWindow addCatWindow = new AddCatWindow();
            addCatWindow.ShowDialog();
            RefreshTotalCatsNumber();
        }
        private void ManageCat(object sender, RoutedEventArgs e)
        {
            ManageCatsWindow manageCatsWindow = new ManageCatsWindow();
            manageCatsWindow.ShowDialog();
            RefreshTotalCatsNumber();
        }
        private void AddAdoption(object sender, RoutedEventArgs e)
        {
            AddAdoption addAdoption = new AddAdoption();
            addAdoption.ShowDialog();
            RefreshTotalCatsNumber();
        }
        public void ManageAdoptions(object sender, RoutedEventArgs e)
        {
            ManageAdoptions manageAdoptions = new ManageAdoptions();
            manageAdoptions.ShowDialog();
            RefreshTotalCatsNumber();
        }
        private void AddAdopter(object sender, RoutedEventArgs e)
        {
            AddAdopterWindow addAdopterWindow = new AddAdopterWindow();
            addAdopterWindow.ShowDialog();
            RefreshTotalCatsNumber();
        }
        private void ManageAdopter(object sender, RoutedEventArgs e)
        {
            ManageAdopterWindow manageAdopterWindow = new ManageAdopterWindow();
            manageAdopterWindow.ShowDialog();
            RefreshTotalCatsNumber();
        }
    }
}