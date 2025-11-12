using Application.Dto;
using Application.Mappers;
using Application.UseCases;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace UI_WPF
{
    public partial class ManageAdoptersWindow : Window
    {
        private ObservableCollection<AdopterDTO> _adopters;
        private readonly AdopterService _adopterService;

        public ManageAdoptersWindow()
        {
            InitializeComponent();
            _adopterService = ServiceManager.Instance.AdopterService;
            _adopters = new ObservableCollection<AdopterDTO>();
            lstAdopters.ItemsSource = _adopters;
            LoadAdopters();
        }

        private void LoadAdopters()
        {
            _adopters.Clear();
            var adopters = _adopterService.GetAllAdopters();
            foreach (var adopter in adopters)
            {
                _adopters.Add(AdopterMapper.ToDTO(adopter));
            }
        }

        private void LstAdopters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool hasSelection = lstAdopters.SelectedItem != null;
            btnModifica.IsEnabled = hasSelection;
            btnElimina.IsEnabled = hasSelection;
        }

        private void BtnAggiungi_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddAdopterWindow();
            if (addWindow.ShowDialog() == true)
            {
                // L'adottante è già stato salvato in AddAdopterWindow, basta ricaricare
                LoadAdopters();
            }
        }

        private void BtnModifica_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Funzionalità di modifica da implementare.", "Info",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnElimina_Click(object sender, RoutedEventArgs e)
        {
            if (lstAdopters.SelectedItem is AdopterDTO adopter)
            {
                var result = MessageBox.Show(
                    $"Eliminare {adopter.FirstName} {adopter.LastName}?",
                    "Conferma Eliminazione",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    var adopterEntity = AdopterMapper.ToEntity(adopter);
                    _adopterService.Remove(adopterEntity);
                    LoadAdopters();
                }
            }
        }

        private void BtnAggiorna_Click(object sender, RoutedEventArgs e)
        {
            LoadAdopters();
            MessageBox.Show("Elenco aggiornato.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}