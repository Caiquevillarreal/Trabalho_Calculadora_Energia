using System;
using System.Windows.Forms;

namespace Tema1App.Forms
{
    partial class AddAccountForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblConsumer;
        private ComboBox comboConsumers;
        private Label lblReg;
        private TextBox txtReg;
        private Label lblPrev;
        private TextBox txtPrev;
        private Label lblCur;
        private TextBox txtCur;
        private RadioButton rbResidencial;
        private RadioButton rbComercial;
        private Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblConsumer = new Label();
            comboConsumers = new ComboBox();
            lblReg = new Label();
            txtReg = new TextBox();
            lblPrev = new Label();
            txtPrev = new TextBox();
            lblCur = new Label();
            txtCur = new TextBox();
            rbResidencial = new RadioButton();
            rbComercial = new RadioButton();
            btnSave = new Button();

            lblConsumer.Location = new System.Drawing.Point(12,9);
            lblConsumer.Text = "Consumidor:";

            comboConsumers.Location = new System.Drawing.Point(12,32);
            comboConsumers.Size = new System.Drawing.Size(420,23);

            lblReg.Location = new System.Drawing.Point(12,66);
            lblReg.Text = "Registro:";

            txtReg.Location = new System.Drawing.Point(12,89);
            txtReg.Size = new System.Drawing.Size(420,23);

            lblPrev.Location = new System.Drawing.Point(12,122);
            lblPrev.Text = "Leitura Anterior:";

            txtPrev.Location = new System.Drawing.Point(12,145);
            txtPrev.Size = new System.Drawing.Size(200,23);

            lblCur.Location = new System.Drawing.Point(232,122);
            lblCur.Text = "Leitura Atual:";

            txtCur.Location = new System.Drawing.Point(232,145);
            txtCur.Size = new System.Drawing.Size(200,23);

            rbResidencial.Location = new System.Drawing.Point(12,180);
            rbResidencial.Text = "Residencial";
            rbResidencial.Checked = true;

            rbComercial.Location = new System.Drawing.Point(120,180);
            rbComercial.Text = "Comercial";

            btnSave.Location = new System.Drawing.Point(12,210);
            btnSave.Size = new System.Drawing.Size(100,30);
            btnSave.Text = "Salvar";
            btnSave.Click += new EventHandler(this.btnSave_Click);

            this.ClientSize = new System.Drawing.Size(460,260);
            this.Controls.Add(lblConsumer);
            this.Controls.Add(comboConsumers);
            this.Controls.Add(lblReg);
            this.Controls.Add(txtReg);
            this.Controls.Add(lblPrev);
            this.Controls.Add(txtPrev);
            this.Controls.Add(lblCur);
            this.Controls.Add(txtCur);
            this.Controls.Add(rbResidencial);
            this.Controls.Add(rbComercial);
            this.Controls.Add(btnSave);
            this.Text = "Adicionar Conta";
        }
    }
}
