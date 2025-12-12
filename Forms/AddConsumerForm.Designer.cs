using System;
using System.Windows.Forms;

namespace Tema1App.Forms
{
    partial class AddConsumerForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblName;
        private TextBox txtName;
        private Label lblDocument;
        private TextBox txtDocument;
        private RadioButton rbPF;
        private RadioButton rbPJ;
        private Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblName = new Label();
            txtName = new TextBox();
            lblDocument = new Label();
            txtDocument = new TextBox();
            rbPF = new RadioButton();
            rbPJ = new RadioButton();
            btnSave = new Button();

            lblName.Location = new System.Drawing.Point(12,9);
            lblName.Size = new System.Drawing.Size(80,20);
            lblName.Text = "Nome:";

            txtName.Location = new System.Drawing.Point(12,32);
            txtName.Size = new System.Drawing.Size(420,23);

            lblDocument.Location = new System.Drawing.Point(12,66);
            lblDocument.Size = new System.Drawing.Size(80,20);
            lblDocument.Text = "Documento:";

            txtDocument.Location = new System.Drawing.Point(12,89);
            txtDocument.Size = new System.Drawing.Size(420,23);

            rbPF.Location = new System.Drawing.Point(12,122);
            rbPF.Text = "Pessoa Física (CPF)";
            rbPF.Checked = true;

            rbPJ.Location = new System.Drawing.Point(220,122);
            rbPJ.Text = "Pessoa Jurídica (CNPJ)";

            btnSave.Location = new System.Drawing.Point(12,155);
            btnSave.Size = new System.Drawing.Size(100,30);
            btnSave.Text = "Salvar";
            btnSave.Click += new EventHandler(this.btnSave_Click);

            this.ClientSize = new System.Drawing.Size(460,200);
            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblDocument);
            this.Controls.Add(txtDocument);
            this.Controls.Add(rbPF);
            this.Controls.Add(rbPJ);
            this.Controls.Add(btnSave);
            this.Text = "Adicionar Consumidor";
        }
    }
}
