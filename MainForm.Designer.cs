using System;
using System.Windows.Forms;
using System.Drawing;

namespace Tema1App
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnAddConsumer;
        private Button btnAddAccount;
        private Button btnSaveJson;
        private Button btnSaveXml;
        private Button btnDetails;
        private ListBox listConsumers;
        private ListBox listAccounts;
        private Label lblConsumers;
        private Label lblAccounts;
        private TextBox txtQueryId;
        private Button btnQuery;
        private Label lblQuery;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAddConsumer = new Button();
            this.btnAddAccount = new Button();
            this.btnSaveJson = new Button();
            this.btnSaveXml = new Button();
            this.btnDetails = new Button();
            this.listConsumers = new ListBox();
            this.listAccounts = new ListBox();
            this.lblConsumers = new Label();
            this.lblAccounts = new Label();
            this.txtQueryId = new TextBox();
            this.btnQuery = new Button();
            this.lblQuery = new Label();

           
            
            this.btnAddConsumer.Location = new Point(12,12);
            this.btnAddConsumer.Size = new Size(180,30);
            this.btnAddConsumer.Text = "Adicionar Consumidor";
            this.btnAddConsumer.Click += new EventHandler(this.btnAddConsumer_Click);
            
           
            
            this.btnAddAccount.Location = new Point(12,48);
            this.btnAddAccount.Size = new Size(180,30);
            this.btnAddAccount.Text = "Adicionar Conta";
            this.btnAddAccount.Click += new EventHandler(this.btnAddAccount_Click);
             
            
            
            this.btnSaveJson.Location = new Point(12,84);
            this.btnSaveJson.Size = new Size(180,30);
            this.btnSaveJson.Text = "Salvar JSON";
            this.btnSaveJson.Click += new EventHandler(this.btnSaveJson_Click);
            
            this.btnSaveXml.Location = new Point(12,120);
            this.btnSaveXml.Size = new Size(180,30);
            this.btnSaveXml.Text = "Salvar XML";
            this.btnSaveXml.Click += new EventHandler(this.btnSaveXml_Click);
           
            this.lblConsumers.Location = new Point(210,12);
            this.lblConsumers.Size = new Size(200,20);
            this.lblConsumers.Text = "Consumidores";

            
            this.listConsumers.Location = new Point(210,36);
            this.listConsumers.Size = new Size(420,120);
            
            this.lblAccounts.Location = new Point(12,165);
            this.lblAccounts.Size = new Size(200,20);
            this.lblAccounts.Text = "Contas";
            
            this.listAccounts.Location = new Point(12,188);
            this.listAccounts.Size = new Size(618,160);
           
            this.btnDetails.Location = new Point(12,356);
            this.btnDetails.Size = new Size(180,30);
            this.btnDetails.Text = "Detalhes Conta";
            this.btnDetails.Click += new EventHandler(this.btnDetails_Click);
           
            this.lblQuery.Location = new Point(210,165);
            this.lblQuery.Size = new Size(300,20);
            this.lblQuery.Text = "Consultar por ID do Consumidor (cole o GUID):";
           
            this.txtQueryId.Location = new Point(210,188);
            this.txtQueryId.Size = new Size(420,23);
            
            this.btnQuery.Location = new Point(210,217);
            this.btnQuery.Size = new Size(120,30);
            this.btnQuery.Text = "Consultar";
            this.btnQuery.Click += new EventHandler(this.btnQuery_Click);

            
            this.ClientSize = new Size(650,400);
            this.Controls.Add(this.btnAddConsumer);
            this.Controls.Add(this.btnAddAccount);
            this.Controls.Add(this.btnSaveJson);
            this.Controls.Add(this.btnSaveXml);
            this.Controls.Add(this.listConsumers);
            this.Controls.Add(this.listAccounts);
            this.Controls.Add(this.lblConsumers);
            this.Controls.Add(this.lblAccounts);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.txtQueryId);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.lblQuery);
            this.Text = "Controle de Contas de Energia";
            this.Load += new EventHandler(this.MainForm_Load);
        }
    }
}
