namespace Cod3rsGrowth
{
    partial class ListaDeCarros
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            botaoAdicionar = new Button();
            botaoEditar = new Button();
            botaoRemover = new Button();
            filtroModelo = new TextBox();
            labelModelo = new Label();
            filtroProprietario = new TextBox();
            labelProprietario = new Label();
            labelCombustivel = new Label();
            comboBoxCombustivel = new ComboBox();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            BotaoFiltrar = new Button();
            button1 = new Button();
            filtroValor = new TextBox();
            labelValor = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 35);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1299, 367);
            dataGridView1.TabIndex = 0;
            // 
            // botaoAdicionar
            // 
            botaoAdicionar.Location = new Point(981, 408);
            botaoAdicionar.Name = "botaoAdicionar";
            botaoAdicionar.Size = new Size(106, 23);
            botaoAdicionar.TabIndex = 1;
            botaoAdicionar.Text = "Adicionar";
            botaoAdicionar.UseVisualStyleBackColor = true;
            botaoAdicionar.Click += AoClicarEmAdicionar;
            // 
            // botaoEditar
            // 
            botaoEditar.Location = new Point(1093, 408);
            botaoEditar.Name = "botaoEditar";
            botaoEditar.Size = new Size(106, 23);
            botaoEditar.TabIndex = 2;
            botaoEditar.Text = "Editar";
            botaoEditar.UseVisualStyleBackColor = true;
            botaoEditar.Click += AoClicarEmEditar;
            // 
            // botaoRemover
            // 
            botaoRemover.Location = new Point(1205, 408);
            botaoRemover.Name = "botaoRemover";
            botaoRemover.Size = new Size(106, 23);
            botaoRemover.TabIndex = 3;
            botaoRemover.Text = "Remover";
            botaoRemover.UseVisualStyleBackColor = true;
            botaoRemover.Click += AoClicarEmRemover;
            // 
            // filtroModelo
            // 
            filtroModelo.Location = new Point(448, 6);
            filtroModelo.Name = "filtroModelo";
            filtroModelo.Size = new Size(114, 23);
            filtroModelo.TabIndex = 4;
            // 
            // labelModelo
            // 
            labelModelo.AutoSize = true;
            labelModelo.Location = new Point(397, 4);
            labelModelo.Name = "labelModelo";
            labelModelo.Size = new Size(51, 15);
            labelModelo.TabIndex = 5;
            labelModelo.Text = "Modelo:";
            // 
            // filtroProprietario
            // 
            filtroProprietario.Location = new Point(291, 6);
            filtroProprietario.Name = "filtroProprietario";
            filtroProprietario.Size = new Size(100, 23);
            filtroProprietario.TabIndex = 6;
            // 
            // labelProprietario
            // 
            labelProprietario.AutoSize = true;
            labelProprietario.Location = new Point(218, 4);
            labelProprietario.Name = "labelProprietario";
            labelProprietario.Size = new Size(72, 15);
            labelProprietario.TabIndex = 7;
            labelProprietario.Text = "Proprietário:";
            // 
            // labelCombustivel
            // 
            labelCombustivel.AutoSize = true;
            labelCombustivel.Location = new Point(12, 6);
            labelCombustivel.Name = "labelCombustivel";
            labelCombustivel.Size = new Size(77, 15);
            labelCombustivel.TabIndex = 8;
            labelCombustivel.Text = "Combustível:";
            // 
            // comboBoxCombustivel
            // 
            comboBoxCombustivel.FormattingEnabled = true;
            comboBoxCombustivel.Location = new Point(90, 6);
            comboBoxCombustivel.Name = "comboBoxCombustivel";
            comboBoxCombustivel.Size = new Size(121, 23);
            comboBoxCombustivel.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(774, 6);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 10;
            label1.Text = "Ano Modelo:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(853, 6);
            dateTimePicker1.MaxDate = new DateTime(2025, 12, 31, 0, 0, 0, 0);
            dateTimePicker1.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(63, 23);
            dateTimePicker1.TabIndex = 11;
            dateTimePicker1.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // BotaoFiltrar
            // 
            BotaoFiltrar.Location = new Point(1093, 4);
            BotaoFiltrar.Name = "BotaoFiltrar";
            BotaoFiltrar.Size = new Size(106, 25);
            BotaoFiltrar.TabIndex = 12;
            BotaoFiltrar.Text = "Filtrar";
            BotaoFiltrar.UseVisualStyleBackColor = true;
            BotaoFiltrar.Click += AoClicarEmFiltrar;
            // 
            // button1
            // 
            button1.Location = new Point(1205, 4);
            button1.Name = "button1";
            button1.Size = new Size(106, 25);
            button1.TabIndex = 13;
            button1.Text = "Limpar filtros";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AoClicarEmLimparFiltro;
            // 
            // filtroValor
            // 
            filtroValor.Location = new Point(656, 6);
            filtroValor.Name = "filtroValor";
            filtroValor.Size = new Size(114, 23);
            filtroValor.TabIndex = 14;
            filtroValor.KeyPress += AoInformarValor;
            // 
            // labelValor
            // 
            labelValor.AutoSize = true;
            labelValor.Location = new Point(568, 6);
            labelValor.Name = "labelValor";
            labelValor.Size = new Size(86, 15);
            labelValor.TabIndex = 15;
            labelValor.Text = "Valor Ofertado:";
            // 
            // ListaDeCarros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1323, 437);
            Controls.Add(labelValor);
            Controls.Add(filtroValor);
            Controls.Add(button1);
            Controls.Add(BotaoFiltrar);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Controls.Add(comboBoxCombustivel);
            Controls.Add(labelCombustivel);
            Controls.Add(labelProprietario);
            Controls.Add(filtroProprietario);
            Controls.Add(labelModelo);
            Controls.Add(filtroModelo);
            Controls.Add(botaoRemover);
            Controls.Add(botaoEditar);
            Controls.Add(botaoAdicionar);
            Controls.Add(dataGridView1);
            Name = "ListaDeCarros";
            Text = "Listagem de veículos";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button botaoAdicionar;
        private Button botaoEditar;
        private Button botaoRemover;
        private TextBox filtroModelo;
        private Label labelModelo;
        private TextBox filtroProprietario;
        private Label labelProprietario;
        private Label labelCombustivel;
        private ComboBox comboBoxCombustivel;
        private Label label1;
        private Button BotaoFiltrar;
        private Button button1;
        public DateTimePicker dateTimePicker1;
        private TextBox filtroValor;
        private Label labelValor;
    }
}
