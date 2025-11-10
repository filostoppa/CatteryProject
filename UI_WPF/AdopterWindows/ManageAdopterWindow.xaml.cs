using Application.Dto;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace UI_WPF
{
    public partial class ManageAdoptersWindow : Window
    {
        private ObservableCollection<AdopterDTO> _adopters;

        public ManageAdoptersWindow()
        {
            InitializeComponent();
            LoadAdopters();
        }

        private void LoadAdopters()
        {
            _adopters = new ObservableCollection<AdopterDTO>{};

            lstAdopters.ItemsSource = _adopters;
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
                _adopters.Add(addWindow.NewAdopter);
            }
        }

        private void BtnModifica_Click(object sender, RoutedEventArgs e)
        {
            
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
                    _adopters.Remove(adopter);
                }
            }
        }

        private void BtnAggiorna_Click(object sender, RoutedEventArgs e)
        {
            LoadAdopters(); // Ricarica da DB
            MessageBox.Show("Elenco aggiornato.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}