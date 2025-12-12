using System;
using System.Windows.Forms;

namespace Tema1App.Forms
{
    partial class DetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblType;
        private Label lblTypeValue;
        private Label lblReg;
        private Label lblRegValue;
        private Label lblCons;
        private Label lblConsValue;
        private Label lblWithout;
        private Label lblWithoutValue;
        private Label lblTax;
        private Label lblTaxValue;
        private Label lblTotal;
        private Label lblTotalValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblType = new Label();
            lblTypeValue = new Label();
            lblReg = new Label();
            lblRegValue = new Label();
            lblCons = new Label();
            lblConsValue = new Label();
            lblWithout = new Label();
            lblWithoutValue = new Label();
            lblTax = new Label();
            lblTaxValue = new Label();
            lblTotal = new Label();
            lblTotalValue = new Label();

            lblType.Location = new System.Drawing.Point(12,9);
            lblType.Text = "Tipo:";
            lblTypeValue.Location = new System.Drawing.Point(120,9);
            lblTypeValue.Size = new System.Drawing.Size(200,23);

            lblReg.Location = new System.Drawing.Point(12,36);
            lblReg.Text = "Registro:";
            lblRegValue.Location = new System.Drawing.Point(120,36);
            lblRegValue.Size = new System.Drawing.Size(200,23);

            lblCons.Location = new System.Drawing.Point(12,63);
            lblCons.Text = "Consumo (kW/h):";
            lblConsValue.Location = new System.Drawing.Point(120,63);
            lblConsValue.Size = new System.Drawing.Size(200,23);

            lblWithout.Location = new System.Drawing.Point(12,90);
            lblWithout.Text = "Valor sem impostos:";
            lblWithoutValue.Location = new System.Drawing.Point(160,90);
            lblWithoutValue.Size = new System.Drawing.Size(160,23);

            lblTax.Location = new System.Drawing.Point(12,117);
            lblTax.Text = "Imposto:";
            lblTaxValue.Location = new System.Drawing.Point(120,117);
            lblTaxValue.Size = new System.Drawing.Size(100,23);

            lblTotal.Location = new System.Drawing.Point(12,144);
            lblTotal.Text = "Valor total:";
            lblTotalValue.Location = new System.Drawing.Point(120,144);
            lblTotalValue.Size = new System.Drawing.Size(100,23);

            this.ClientSize = new System.Drawing.Size(420,200);
            this.Controls.Add(lblType);
            this.Controls.Add(lblTypeValue);
            this.Controls.Add(lblReg);
            this.Controls.Add(lblRegValue);
            this.Controls.Add(lblCons);
            this.Controls.Add(lblConsValue);
            this.Controls.Add(lblWithout);
            this.Controls.Add(lblWithoutValue);
            this.Controls.Add(lblTax);
            this.Controls.Add(lblTaxValue);
            this.Controls.Add(lblTotal);
            this.Controls.Add(lblTotalValue);
            this.Text = "Detalhes da Conta";
        }
    }
}
