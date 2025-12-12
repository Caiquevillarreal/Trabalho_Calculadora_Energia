using System;
using System.Linq;
using System.Windows.Forms;
using Tema1App.Data;
using Tema1App.Models;

namespace Tema1App.Forms
{
    public partial class AddAccountForm : Form
    {
        private readonly Repository _repo;
        public AddAccountForm(Repository repo)
        {
            InitializeComponent();
            _repo = repo;
            comboConsumers.DataSource = _repo.AllConsumers().ToList();
            comboConsumers.DisplayMember = "Name";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(comboConsumers.SelectedItem is Consumer consumer)) { MessageBox.Show("Selecione um consumidor"); return; }
            if (!decimal.TryParse(txtPrev.Text.Trim(), out var prev)) { MessageBox.Show("Leitura anterior inválida"); return; }
            if (!decimal.TryParse(txtCur.Text.Trim(), out var cur)) { MessageBox.Show("Leitura atual inválida"); return; }
            Account acc = rbResidencial.Checked ? new ResidentialAccount() as Account : new CommercialAccount() as Account;
            acc.RegistrationNumber = txtReg.Text.Trim();
            acc.ConsumerId = consumer.Id;
            acc.PreviousReading = prev;
            acc.CurrentReading = cur;
            _repo.AddAccount(acc);
            MessageBox.Show($"Conta cadastrada. ID: {acc.Id}");
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
