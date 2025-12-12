using System;
using System.Linq;
using System.Windows.Forms;
using Tema1App.Data;
using Tema1App.Models;

namespace Tema1App
{
    public partial class MainForm : Form
    {
        private readonly Repository _repo;

        public MainForm()
        {
            InitializeComponent();
            _repo = new Repository("data.json", "data.xml");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshLists();
        }

        private void RefreshLists()
        {
            listConsumers.DataSource = null;
            listConsumers.DataSource = _repo.AllConsumers().ToList();
            listConsumers.DisplayMember = "Name";

            listAccounts.DataSource = null;
            listAccounts.DataSource = _repo.AllAccounts().ToList();
            listAccounts.DisplayMember = "RegistrationNumber";
        }

        private void btnAddConsumer_Click(object sender, EventArgs e)
        {
            using var f = new Forms.AddConsumerForm(_repo);
            if (f.ShowDialog() == DialogResult.OK) RefreshLists();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            using var f = new Forms.AddAccountForm(_repo);
            if (f.ShowDialog() == DialogResult.OK) RefreshLists();
        }

        private void btnSaveJson_Click(object sender, EventArgs e)
        {
            _repo.SaveJson();
            MessageBox.Show("Dados salvos em JSON.");
        }

        private void btnSaveXml_Click(object sender, EventArgs e)
        {
            _repo.SaveXml();
            MessageBox.Show("Dados salvos em XML.");
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (listAccounts.SelectedItem is Account a)
            {
                using var f = new Forms.DetailsForm(a);
                f.ShowDialog();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            var idText = txtQueryId.Text.Trim();
            if (!Guid.TryParse(idText, out var id))
            {
                MessageBox.Show("ID inválido. Cole o ID do consumidor (GUID).");
                return;
            }
            var consumer = _repo.GetConsumer(id);
            if (consumer == null)
            {
                MessageBox.Show("Consumidor não encontrado.");
                return;
            }
            var accounts = _repo.AllAccounts().Where(a => a.ConsumerId == consumer.Id).ToList();
            if (!accounts.Any())
            {
                MessageBox.Show("Consumidor não possui contas cadastradas.");
                return;
            }

            // Respond the three questions per account and aggregated
            decimal totalConsumption = 0;
            decimal totalWithoutTax = 0;
            decimal totalWithTax = 0;
            string details = $"Consumidor: {consumer.Name}\n\n";
            foreach (var a in accounts)
            {
                details += $"Conta: {a.RegistrationNumber} ({a.AccountType})\n";
                details += $" - Consumo (mês): {a.Consumption} kW/h\n";
                details += $" - Valor sem impostos: R$ {a.ValueWithoutTax():0.00}\n";
                details += $" - Valor total: R$ {a.TotalValue():0.00}\n\n";
                totalConsumption += a.Consumption;
                totalWithoutTax += a.ValueWithoutTax();
                totalWithTax += a.TotalValue();
            }
            details += "Resumo (todas as contas):\n";
            details += $" - Consumo total: {totalConsumption} kW/h\n";
            details += $" - Valor sem impostos total: R$ {totalWithoutTax:0.00}\n";
            details += $" - Valor total (com impostos): R$ {totalWithTax:0.00}\n";
            MessageBox.Show(details, "Consulta por Consumidor");
        }
    }
}
