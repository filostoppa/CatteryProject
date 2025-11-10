using Application.Dto;
using System;
using System.Collections.Generic;
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

namespace UI_WPF
{
    /// <summary>
    /// Logica di interazione per AddCatWindow.xaml
    /// </summary>
    public partial class AddCatWindow : Window
    {
        public CatDTO NewCat { get; private set; }

        public AddCatWindow()
        {
            InitializeComponent();
            dpArrivalDate.SelectedDate = DateTime.Today;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the cat's name.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                txtName.Focus();
                return;
            }

            if (dpArrivalDate.SelectedDate == null)
            {
                MessageBox.Show("Please select the arrival date.", "Warning",
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

            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}