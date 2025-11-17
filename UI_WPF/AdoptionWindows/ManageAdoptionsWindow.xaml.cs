using Application.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.Xml.Linq;
using Application.UseCases;
using Application.Mappers;

namespace UI_WPF.AdoptionWindows
{
    /// <summary>
    /// Logica di interazione per ManageAdoptionsWindow.xaml
    /// </summary>
    public partial class ManageAdoptionsWindow : Window
    {
        public ObservableCollection<AdoptionDTO> Adoptions { get; set; }
        private readonly AdoptionService _adoptionService;

        public ManageAdoptionsWindow()
        {
            InitializeComponent();
            _adoptionService = ServiceManager.Instance.AdoptionService;
            Adoptions = new ObservableCollection<AdoptionDTO>();
            lstAdoptions.ItemsSource = Adoptions;
            LoadAdoptions();
        }

        private void LoadAdoptions()
        {
            var adoptions = _adoptionService.GetAllAdoptions();
            foreach (var adoption in adoptions)
            {
                Adoptions.Add(AdoptionMapper.ToDTO(adoption));
            }
        }

        private void BtnAggiungi_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddAdoptionWindow();
            if (addWindow.ShowDialog() == true)
            {
                AdoptionDTO newAdoption = addWindow.NewAdoption;
                _adoptionService.AddAdoption(AdoptionMapper.ToEntity(newAdoption));
                LoadAdoptions();
            }
        }

        private void BtnModifica_Click(object sender, RoutedEventArgs e)
        {
            if (lstAdoptions.SelectedItem == null)
            {
                MessageBox.Show("Seleziona un'adozione da modificare.", "Attenzione",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            AdoptionDTO selectedAdoption = (AdoptionDTO)lstAdoptions.SelectedItem;
            MessageBox.Show("Funzionalità di modifica da implementare.", "Info",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnElimina_Click(object sender, RoutedEventArgs e)
        {
            if (lstAdoptions.SelectedItem == null)
            {
                MessageBox.Show("Seleziona un'adozione da eliminare.", "Attenzione",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            AdoptionDTO selectedAdoption = (AdoptionDTO)lstAdoptions.SelectedItem;

            var result = MessageBox.Show(
                $"Sei sicuro di voler eliminare l'adozione di {selectedAdoption.AdoptedCat.Name} da parte di {selectedAdoption.AdopterData.FirstName} {selectedAdoption.AdopterData.LastName}?",
                "Conferma eliminazione",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var adoptionEntity = AdoptionMapper.ToEntity(selectedAdoption);
                _adoptionService.RemoveAdoption(adoptionEntity);
                LoadAdoptions();
            }
        }

        private void BtnAggiorna_Click(object sender, RoutedEventArgs e)
        {
            LoadAdoptions();
            MessageBox.Show("Elenco aggiornato.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void LstAdoptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool hasSelection = lstAdoptions.SelectedItem != null;
            btnModifica.IsEnabled = hasSelection;
            btnElimina.IsEnabled = hasSelection;
        }
    }
}