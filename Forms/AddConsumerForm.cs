using System;
using System.Windows.Forms;
using Tema1App.Data;
using Tema1App.Models;

namespace Tema1App.Forms
{
    public partial class AddConsumerForm : Form
    {
        private readonly Repository _repo;
        public AddConsumerForm(Repository repo)
        {
            InitializeComponent();
            _repo = repo;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();
            var doc = txtDocument.Text.Trim();
            if (string.IsNullOrEmpty(name)) { MessageBox.Show("Nome obrigatório"); return; }
            var c = new Consumer { Name = name, Document = doc, Type = rbPJ.Checked ? ConsumerType.PessoaJuridica : ConsumerType.PessoaFisica };
            _repo.AddConsumer(c);
            MessageBox.Show($"Consumidor cadastrado. ID: {c.Id}");
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
