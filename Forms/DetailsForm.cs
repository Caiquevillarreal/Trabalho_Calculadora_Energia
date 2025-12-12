using System;
using System.Windows.Forms;
using Tema1App.Models;

namespace Tema1App.Forms
{
    public partial class DetailsForm : Form
    {
        private readonly Account _account;
        public DetailsForm(Account account)
        {
            InitializeComponent();
            _account = account;
            LoadData();
        }

        private void LoadData()
        {
            lblTypeValue.Text = _account.AccountType;
            lblRegValue.Text = _account.RegistrationNumber;
            lblConsValue.Text = _account.Consumption.ToString();
            lblWithoutValue.Text = _account.ValueWithoutTax().ToString("0.00");
            lblTaxValue.Text = _account.TaxAmount().ToString("0.00");
            lblTotalValue.Text = _account.TotalValue().ToString("0.00");
        }
    }
}
