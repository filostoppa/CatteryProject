using Application.Dto;
using Application.UseCases;
using System;
using System.Windows;
using System.Windows.Controls;

namespace UI_WPF
{
    /// <summary>
    /// Logica di interazione per AddCatWindow.xaml
    /// </summary>
    public partial class AddCatWindow : Window
    {
        public CatDTO NewCat { get; private set; }
        private readonly CatService _catService;

        public AddCatWindow()
        {
            InitializeComponent();
            _catService = ServiceManager.Instance.CatService;
            dpArrivalDate.SelectedDate = DateTime.Today;
        }

        private void BtnSalva_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Inserisci il nome del gatto.", "Attenzione",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                txtName.Focus();
                return;
            }

            if (dpArrivalDate.SelectedDate == null)
            {
                MessageBox.Show("Seleziona la data di arrivo.", "Attenzione",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            NewCat = new CatDTO(
                Name: txtName.Text.Trim(),
                Breed: string.IsNullOrWhiteSpace(txtBreed.Text) ? null : txtBreed.Text.Trim(),
                IsMale: rbMale.IsChecked == true,
                BirthDate: dpBirthDate.SelectedDate.HasValue
                    ? DateOnly.FromDateTime(dpBirthDate.SelectedDate.Value)
                    : null,
                DepartureDate: dpDepartureDate.SelectedDate.HasValue
                    ? DateOnly.FromDateTime(dpDepartureDate.SelectedDate.Value)
                    : null,
                ArrivalDate: DateOnly.FromDateTime(dpArrivalDate.SelectedDate.Value),
                Description: string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim()
            );

            // Salva direttamente nel service (e quindi nel JSON)
            _catService.AddCat(NewCat);

            MessageBox.Show("Gatto aggiunto con successo!", "Successo",
                MessageBoxButton.OK, MessageBoxImage.Information);

            DialogResult = true;
            Close();
        }

        private void BtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}