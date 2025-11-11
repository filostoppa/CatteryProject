using Application.Dto;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace UI_WPF
{
    public partial class AddAdopterWindow : Window
    {
        public AdopterDTO NewAdopter { get; private set; }

        public AddAdopterWindow()
        {
            InitializeComponent();
        }

        private void BtnSalva_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                ShowError("Inserisci il nome.", txtFirstName);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                ShowError("Inserisci il cognome.", txtLastName);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !IsValidEmail(txtEmail.Text))
            {
                ShowError("Inserisci un'email valida.", txtEmail);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtFiscalCode.Text) && !IsValidFiscalCode(txtFiscalCode.Text))
            {
                ShowError("Codice Fiscale non valido (16 caratteri alfanumerici).", txtFiscalCode);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtCityCap.Text) && !Regex.IsMatch(txtCityCap.Text, @"^\d{5}$"))
            {
                ShowError("Il CAP deve essere di 5 cifre.", txtCityCap);
                return;
            }

            NewAdopter = new AdopterDTO(
                FirstName: txtFirstName.Text.Trim(),
                LastName: txtLastName.Text.Trim(),
                Address: string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim(),
                Phone: string.IsNullOrWhiteSpace(txtPhones.Text) ? null : txtPhones.Text.Trim(),
                FiscalCode: string.IsNullOrWhiteSpace(txtFiscalCode.Text) ? null : txtFiscalCode.Text.Trim().ToUpper(),
                City: string.IsNullOrWhiteSpace(txtCity.Text) ? null : txtCity.Text.Trim(),
                CityCap: string.IsNullOrWhiteSpace(txtCityCap.Text) ? null : txtCityCap.Text.Trim(),
                Notes: string.IsNullOrWhiteSpace(txtNotes.Text) ? null : txtNotes.Text.Trim()
            );

            DialogResult = true;
            Close();
        }

        private void BtnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void ShowError(string message, Control control)
        {
            MessageBox.Show(message, "Attenzione", MessageBoxButton.OK, MessageBoxImage.Warning);
            control.Focus();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email.Trim();
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidFiscalCode(string cf)
        {
            return Regex.IsMatch(cf, @"^[A-Z0-9]{16}$", RegexOptions.IgnoreCase);
        }
    }
}