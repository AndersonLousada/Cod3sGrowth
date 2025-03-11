namespace Cod3rsGrowth
{
    partial class TelaDeCriacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Modelo = new Label();
            InputModelo = new TextBox();
            InputMarca = new TextBox();
            labelMarca = new Label();
            InputProprietario = new TextBox();
            labelProprietario = new Label();
            labelAnoModelo = new Label();
            labelAnoFabricacao = new Label();
            InputAnoFabricacao = new DateTimePicker();
            InputAnoModelo = new DateTimePicker();
            InputVenda = new TextBox();
            label1 = new Label();
            InputCusto = new TextBox();
            labelCusto = new Label();
            InputValorOfertado = new TextBox();
            label2 = new Label();
            label3 = new Label();
            comboBoxCombustivel = new ComboBox();
            Quitado = new CheckBox();
            botaoSalvar = new Button();
            botaoCancelar = new Button();
            SuspendLayout();
            // 
            // Modelo
            // 
            Modelo.AutoSize = true;
            Modelo.Location = new Point(7, 7);
            Modelo.Name = "Modelo";
            Modelo.Size = new Size(48, 15);
            Modelo.TabIndex = 0;
            Modelo.Text = "Modelo";
            // 
            // InputModelo
            // 
            InputModelo.Location = new Point(11, 23);
            InputModelo.Name = "InputModelo";
            InputModelo.Size = new Size(142, 23);
            InputModelo.TabIndex = 1;
            // 
            // InputMarca
            // 
            InputMarca.Location = new Point(165, 23);
            InputMarca.Name = "InputMarca";
            InputMarca.Size = new Size(141, 23);
            InputMarca.TabIndex = 3;
            // 
            // labelMarca
            // 
            labelMarca.AutoSize = true;
            labelMarca.Location = new Point(163, 7);
            labelMarca.Name = "labelMarca";
            labelMarca.Size = new Size(40, 15);
            labelMarca.TabIndex = 2;
            labelMarca.Text = "Marca";
            // 
            // InputProprietario
            // 
            InputProprietario.Location = new Point(11, 71);
            InputProprietario.Name = "InputProprietario";
            InputProprietario.Size = new Size(298, 23);
            InputProprietario.TabIndex = 5;
            // 
            // labelProprietario
            // 
            labelProprietario.AutoSize = true;
            labelProprietario.Location = new Point(8, 53);
            labelProprietario.Name = "labelProprietario";
            labelProprietario.Size = new Size(69, 15);
            labelProprietario.TabIndex = 4;
            labelProprietario.Text = "Proprietário";
            // 
            // labelAnoModelo
            // 
            labelAnoModelo.AutoSize = true;
            labelAnoModelo.Location = new Point(165, 106);
            labelAnoModelo.Name = "labelAnoModelo";
            labelAnoModelo.Size = new Size(73, 15);
            labelAnoModelo.TabIndex = 6;
            labelAnoModelo.Text = "Ano modelo";
            // 
            // labelAnoFabricacao
            // 
            labelAnoFabricacao.AutoSize = true;
            labelAnoFabricacao.Location = new Point(9, 106);
            labelAnoFabricacao.Name = "labelAnoFabricacao";
            labelAnoFabricacao.Size = new Size(87, 15);
            labelAnoFabricacao.TabIndex = 7;
            labelAnoFabricacao.Text = "Ano fabricação";
            // 
            // InputAnoFabricacao
            // 
            InputAnoFabricacao.CustomFormat = "yyyy";
            InputAnoFabricacao.Format = DateTimePickerFormat.Custom;
            InputAnoFabricacao.Location = new Point(12, 122);
            InputAnoFabricacao.MaxDate = new DateTime(2025, 3, 11, 0, 0, 0, 0);
            InputAnoFabricacao.MinDate = new DateTime(2010, 1, 1, 0, 0, 0, 0);
            InputAnoFabricacao.Name = "InputAnoFabricacao";
            InputAnoFabricacao.ShowUpDown = true;
            InputAnoFabricacao.Size = new Size(141, 23);
            InputAnoFabricacao.TabIndex = 8;
            InputAnoFabricacao.Value = new DateTime(2025, 3, 11, 0, 0, 0, 0);
            // 
            // InputAnoModelo
            // 
            InputAnoModelo.CustomFormat = "yyyy";
            InputAnoModelo.Format = DateTimePickerFormat.Custom;
            InputAnoModelo.Location = new Point(165, 122);
            InputAnoModelo.MaxDate = new DateTime(2025, 12, 31, 0, 0, 0, 0);
            InputAnoModelo.MinDate = new DateTime(2010, 1, 1, 0, 0, 0, 0);
            InputAnoModelo.Name = "InputAnoModelo";
            InputAnoModelo.ShowUpDown = true;
            InputAnoModelo.Size = new Size(144, 23);
            InputAnoModelo.TabIndex = 9;
            InputAnoModelo.Value = new DateTime(2025, 3, 11, 0, 0, 0, 0);
            // 
            // InputVenda
            // 
            InputVenda.Location = new Point(113, 171);
            InputVenda.Name = "InputVenda";
            InputVenda.Size = new Size(94, 23);
            InputVenda.TabIndex = 13;
            InputVenda.KeyPress += AoInformarValorVenda;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(110, 155);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 12;
            label1.Text = "$ Venda mínima";
            // 
            // InputCusto
            // 
            InputCusto.Location = new Point(13, 171);
            InputCusto.Name = "InputCusto";
            InputCusto.Size = new Size(94, 23);
            InputCusto.TabIndex = 11;
            InputCusto.KeyPress += AoInformarValorCusto;
            // 
            // labelCusto
            // 
            labelCusto.AutoSize = true;
            labelCusto.Location = new Point(9, 155);
            labelCusto.Name = "labelCusto";
            labelCusto.Size = new Size(47, 15);
            labelCusto.TabIndex = 10;
            labelCusto.Text = "$ Custo";
            // 
            // InputValorOfertado
            // 
            InputValorOfertado.Location = new Point(215, 171);
            InputValorOfertado.Name = "InputValorOfertado";
            InputValorOfertado.Size = new Size(94, 23);
            InputValorOfertado.TabIndex = 14;
            InputValorOfertado.KeyPress += AoInformarValorOfertado;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(212, 153);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 15;
            label2.Text = "$ Ofertado por";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 203);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 16;
            label3.Text = "Combustível";
            // 
            // comboBoxCombustivel
            // 
            comboBoxCombustivel.FormattingEnabled = true;
            comboBoxCombustivel.Location = new Point(13, 221);
            comboBoxCombustivel.Name = "comboBoxCombustivel";
            comboBoxCombustivel.Size = new Size(140, 23);
            comboBoxCombustivel.TabIndex = 17;
            // 
            // Quitado
            // 
            Quitado.AutoSize = true;
            Quitado.Location = new Point(199, 225);
            Quitado.Name = "Quitado";
            Quitado.Size = new Size(110, 19);
            Quitado.TabIndex = 19;
            Quitado.Text = "Com alienação?";
            Quitado.UseVisualStyleBackColor = true;
            // 
            // botaoSalvar
            // 
            botaoSalvar.BackColor = SystemColors.ActiveCaption;
            botaoSalvar.Location = new Point(113, 265);
            botaoSalvar.Name = "botaoSalvar";
            botaoSalvar.Size = new Size(94, 23);
            botaoSalvar.TabIndex = 20;
            botaoSalvar.Text = "Salvar";
            botaoSalvar.UseVisualStyleBackColor = false;
            botaoSalvar.Click += AoClicarEmSalvar;
            // 
            // botaoCancelar
            // 
            botaoCancelar.Location = new Point(215, 265);
            botaoCancelar.Name = "botaoCancelar";
            botaoCancelar.Size = new Size(94, 23);
            botaoCancelar.TabIndex = 21;
            botaoCancelar.Text = "Cancelar";
            botaoCancelar.UseVisualStyleBackColor = true;
            botaoCancelar.Click += AoClicarEmCancelar;
            // 
            // TelaDeCriacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 298);
            Controls.Add(botaoCancelar);
            Controls.Add(botaoSalvar);
            Controls.Add(Quitado);
            Controls.Add(comboBoxCombustivel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(InputValorOfertado);
            Controls.Add(InputVenda);
            Controls.Add(label1);
            Controls.Add(InputCusto);
            Controls.Add(labelCusto);
            Controls.Add(InputAnoModelo);
            Controls.Add(InputAnoFabricacao);
            Controls.Add(labelAnoFabricacao);
            Controls.Add(labelAnoModelo);
            Controls.Add(InputProprietario);
            Controls.Add(labelProprietario);
            Controls.Add(InputMarca);
            Controls.Add(labelMarca);
            Controls.Add(InputModelo);
            Controls.Add(Modelo);
            Name = "TelaDeCriacao";
            Text = "Veículo";
            Load += InicializarTela;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Modelo;
        private TextBox InputModelo;
        private TextBox InputMarca;
        private Label labelMarca;
        private TextBox InputProprietario;
        private Label labelProprietario;
        private Label labelAnoModelo;
        private Label labelAnoFabricacao;
        private DateTimePicker InputAnoFabricacao;
        private DateTimePicker InputAnoModelo;
        private TextBox InputVenda;
        private Label label1;
        private TextBox InputCusto;
        private Label labelCusto;
        private TextBox InputValorOfertado;
        private Label label2;
        private Label label3;
        private ComboBox comboBoxCombustivel;
        private CheckBox Quitado;
        private Button botaoSalvar;
        private Button botaoCancelar;
    }
}