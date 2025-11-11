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
using Application.UseCases;
using Application.Mappers;

namespace UI_WPF
{
    public partial class ManageCatsWindow : Window
    {
        public ObservableCollection<CatDTO> Cats { get; set; }
        private readonly CatService catService;

        public ManageCatsWindow()
        {
            InitializeComponent();
            Cats = new ObservableCollection<CatDTO>();
            lstCats.ItemsSource = Cats;
            LoadCats();
        }

        private void LoadCats()
        {
            var cats = catService.GetAllCats();
            foreach (var cat in cats)
            {
                Cats.Add(cat);
            }
        }

        private void BtnAggiungi_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddCatWindow();
            if (addWindow.ShowDialog() == true)
            {
                CatDTO newCat = addWindow.NewCat;

                catService.AddCat(newCat);

                Cats.Add(newCat);
            }
        }

        private void BtnModifica_Click(object sender, RoutedEventArgs e)
        {
            if (lstCats.SelectedItem == null)
            {
                MessageBox.Show("Seleziona un gatto da modificare.", "Attenzione",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            CatDTO selectedCat = (CatDTO)lstCats.SelectedItem;

            // TODO: Open edit window with selected cat data
            MessageBox.Show("Funzionalità di modifica da implementare.", "Info",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnElimina_Click(object sender, RoutedEventArgs e)
        {
            if (lstCats.SelectedItem == null)
            {
                MessageBox.Show("Seleziona un gatto da eliminare.", "Attenzione",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            CatDTO selectedCat = (CatDTO)lstCats.SelectedItem;

            var result = MessageBox.Show(
                $"Sei sicuro di voler eliminare {selectedCat.Name}?",
                "Conferma eliminazione",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // TODO: Delete from database using your service/repository
                // catService.Delete(selectedCat.Id);

                Cats.Remove(selectedCat);
            }
        }

        private void BtnAggiorna_Click(object sender, RoutedEventArgs e)
        {
            Cats.Clear();
            LoadCats();
        }

        private void LstCats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool hasSelection = lstCats.SelectedItem != null;
            btnModifica.IsEnabled = hasSelection;
            btnElimina.IsEnabled = hasSelection;
        }
    }
}