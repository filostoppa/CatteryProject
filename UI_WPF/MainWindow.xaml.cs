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
using Infrastracture.Persistance.Repositories;
using UI_WPF.AdoptionWindows;

namespace UI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ServiceManager _serviceManager;

        public MainWindow()
        {
            InitializeComponent();

            // Inizializza il ServiceManager con il repository concreto
            var repository = new JsonCatteryRepository();
            ServiceManager.Initialize(repository);

            _serviceManager = ServiceManager.Instance;
            RefreshStatistics();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void RefreshStatistics()
        {
            var allCats = _serviceManager.CatService.GetAllCats();
            int totalCats = allCats.Count;
            int maleCats = 0;
            int femaleCats = 0;

            foreach (var cat in allCats)
            {
                if (cat.IsMale)
                    maleCats++;
                else
                    femaleCats++;
            }

            TxtBlockNumeroGattiTotali.Text = totalCats.ToString();
            TxtBlockNumeroGattiMaschi.Text = maleCats.ToString();
            TxtBlockNumeroGattiFemmine.Text = femaleCats.ToString();
        }

        private void AddCat(object sender, RoutedEventArgs e)
        {
            AddCatWindow manageCatsWindow = new AddCatWindow();
            manageCatsWindow.ShowDialog();
            RefreshStatistics();
        }

        private void ManageCats(object sender, RoutedEventArgs e)
        {
            ManageCatsWindow manageCatsWindow = new ManageCatsWindow();
            manageCatsWindow.ShowDialog();
            RefreshStatistics();
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
            RefreshStatistics();
        }

        private void ManageAdoptions(object sender, RoutedEventArgs e)
        {
            ManageAdoptionsWindow manageAdoptionsWindow = new ManageAdoptionsWindow();
            manageAdoptionsWindow.ShowDialog();
            RefreshStatistics();
        }
    }
}