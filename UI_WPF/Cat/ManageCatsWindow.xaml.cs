using Application.Dto;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace UI_WPF
{
    public partial class ManageCatsWindow : Window
    {
        public ObservableCollection<CatDTO> Cats { get; set; }
        private const string JsonFilePath = "cats.json";

        public ManageCatsWindow()
        {
            InitializeComponent();
            Cats = new ObservableCollection<CatDTO>();
            lstCats.ItemsSource = Cats;
            LoadCatsFromJson();
        }

        // Carica i gatti dal file JSON
        private void LoadCatsFromJson()
        {
            Cats.Clear();

            if (File.Exists(JsonFilePath))
            {
                string json = File.ReadAllText(JsonFilePath);
                List<CatDTO>? loadedCats = JsonSerializer.Deserialize<List<CatDTO>>(json);

                if (loadedCats != null)
                {
                    foreach (CatDTO cat in loadedCats)
                    {
                        Cats.Add(cat);
                    }
                }
            }
        }

        // Salva i gatti nel file JSON
        private void SaveCatsToJson()
        {
            List<CatDTO> listToSave = new List<CatDTO>();
            foreach (CatDTO cat in Cats)
            {
                listToSave.Add(cat);
            }

            string json = JsonSerializer.Serialize(listToSave, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(JsonFilePath, json);
        }

        // BOTTONE: Add Cat
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddCatWindow addWindow = new AddCatWindow();
            if (addWindow.ShowDialog() == true)
            {
                CatDTO newCat = addWindow.NewCat;
                Cats.Add(newCat);
                SaveCatsToJson();
            }
        }


        // BOTTONE: Delete Cat
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstCats.SelectedItem is not CatDTO selectedCat) return;

            MessageBoxResult result = MessageBox.Show(
                $"Sei sicuro che vuoi eliminare {selectedCat.Name}?",
                "Conferma Eliminazione",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                int index = lstCats.SelectedIndex;
                if (index >= 0)
                {
                    Cats.RemoveAt(index);
                    SaveCatsToJson();
                }
            }
        }

        // BOTTONE: Refresh
        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadCatsFromJson();
        }

        // Abilita/Disabilita Edit e Delete
        private void LstCats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool hasSelection = lstCats.SelectedItem != null;
            btnEdit.IsEnabled = hasSelection;
            btnDelete.IsEnabled = hasSelection;
        }

        // Salva alla chiusura
        protected override void OnClosed(EventArgs e)
        {
            SaveCatsToJson();
            base.OnClosed(e);
        }
    }
}