using Application.Dto;
using Application.Mappers;
using Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace UI_WPF.AdoptionWindows
{
    /// <summary>
    /// Logica di interazione per AddAdoptionWindow.xaml
    /// </summary>
    public partial class AddAdoptionWindow : Window
    {
        public AdoptionDTO NewAdoption { get; private set; }
        private List<CatDTO> availableCats;
        private List<AdopterDTO> availableAdopters;
        private readonly CatService _catService;
        private readonly AdopterService _adopterService;

        public AddAdoptionWindow()
        {
            InitializeComponent();
            _catService = ServiceManager.Instance.CatService;
            _adopterService = ServiceManager.Instance.AdopterService;
            dpAdoptionDate.SelectedDate = DateTime.Today;
            LoadAvailableData();
        }

        private void LoadAvailableData()
        {
            // Carica i gatti disponibili (senza data di partenza)
            availableCats = _catService.GetAllCats();

            // Carica tutti gli adottanti
            availableAdopters = _adopterService.GetAllAdopters()
                .Select(a => AdopterMapper.ToDTO(a))
                .ToList();

            cmbCat.ItemsSource = availableCats;
            cmbAdopter.ItemsSource = availableAdopters;
        }

        private void BtnSalva_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCat.SelectedItem == null)
            {
                MessageBox.Show("Seleziona un gatto.", "Attenzione",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbCat.Focus();
                return;
            }

            if (cmbAdopter.SelectedItem == null)
            {
                MessageBox.Show("Seleziona un adottante.", "Attenzione",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                cmbAdopter.Focus();
                return;
            }

            if (dpAdoptionDate.SelectedDate == null)
            {
                MessageBox.Show("Seleziona la data di adozione.", "Attenzione",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            CatDTO selectedCat = (CatDTO)cmbCat.SelectedItem;
            AdopterDTO selectedAdopter = (AdopterDTO)cmbAdopter.SelectedItem;
            DateOnly adoptionDate = DateOnly.FromDateTime(dpAdoptionDate.SelectedDate.Value);

            if (selectedCat.ArrivalDate > adoptionDate)
            {
                MessageBox.Show("La data di adozione non può essere precedente alla data di arrivo del gatto.",
                    "Attenzione", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            NewAdoption = new AdoptionDTO(
                AdoptedCat: selectedCat,
                AdoptionDate: adoptionDate,
                AdopterData: selectedAdopter,
                Status: true
            );

            _adopterService.AddAdopter(AdopterMapper.ToEntity(selectedAdopter));

            DialogResult = true;
            Close();
        }

        private void BtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void CmbCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbCat.SelectedItem != null)
            {
                CatDTO selectedCat = (CatDTO)cmbCat.SelectedItem;
                txtCatInfo.Text = $"Arrivo: {selectedCat.ArrivalDate:dd/MM/yyyy}";

                // Set minimum date for adoption based on arrival date
                dpAdoptionDate.DisplayDateStart = new DateTime(
                    selectedCat.ArrivalDate.Year,
                    selectedCat.ArrivalDate.Month,
                    selectedCat.ArrivalDate.Day);
            }
            else
            {
                txtCatInfo.Text = string.Empty;
                dpAdoptionDate.DisplayDateStart = null;
            }
        }
    }
}