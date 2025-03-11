using Cod3rsGrowth.DOMINIO.Carros;
using Cod3rsGrowth.DOMINIO.Extencoes;

namespace Cod3rsGrowth
{
    public partial class TelaDeCriacao : Form
    {
        private readonly DateTime _dataPadrao = new DateTime(2000, 01, 01, 00, 00, 00);
        private readonly ServicoCarro _servicoCarro;
        public TelaDeCriacao(ServicoCarro servico)
        {
            InitializeComponent();
            CarregarTelaInicial();
            _servicoCarro = servico;
        }

        private void InicializarTela(object sender, EventArgs e)
        {
            CarregarTelaInicial();
        }

        private void CarregarTelaInicial()
        {
            DefinirCombustiveisParaFiltro();
            LimparCampos();
        }

        private void DefinirCombustiveisParaFiltro()
        {
            comboBoxCombustivel.DataSource = ExtensaoEnum.GetEnumDescriptions<Combustivel>();
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Deseja realmente cancelar o cadastro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
                Close();
        }

        private void LimparCampos()
        {
            InputModelo.Text = string.Empty;
            InputMarca.Text = string.Empty;
            InputProprietario.Text = string.Empty;
            InputCusto.Text = string.Empty;
            InputValorOfertado.Text = string.Empty;
            InputVenda.Text = string.Empty;
            InputAnoFabricacao.MinDate = _dataPadrao;
            InputAnoFabricacao.Value = _dataPadrao;
            InputAnoModelo.MinDate = _dataPadrao;
            InputAnoModelo.Value = _dataPadrao;
            Quitado.Checked = false;
        }

        private void AoClicarEmSalvar(object sender, EventArgs e)
        {
            try
            {
                var carro = new Carro
                {
                    Modelo = InputModelo.Text,
                    Marca = InputMarca.Text,
                    ProprietarioNome = InputProprietario.Text,
                    ValorCusto = ObterValor(InputCusto.Text),
                    ValorOfertado = ObterValor(InputValorOfertado.Text),
                    ValorVenda = ObterValor(InputVenda.Text),
                    AnoFabricacao = InputAnoFabricacao.Value,
                    AnoModelo = InputAnoModelo.Value,
                    Quitado = Quitado.Checked,
                    Combustivel = ObterCombustivelSelecionado()
                };

                _servicoCarro.Criar(carro);
                DialogResult = DialogResult.OK;
                Close();
                MessageBox.Show("Veículo criado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AoInformarValorVenda(object sender, KeyPressEventArgs e)
        {
            AoInformarValor(e, InputVenda.Text);
        }

        private void AoInformarValorCusto(object sender, KeyPressEventArgs e)
        {
            AoInformarValor(e, InputCusto.Text);
        }

        private void AoInformarValorOfertado(object sender, KeyPressEventArgs e)
        {
            AoInformarValor(e, InputValorOfertado.Text);
        }

        private void AoInformarValor(KeyPressEventArgs e, string valorInformado)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                e.KeyChar = ',';

                if (valorInformado.Contains(","))
                {
                    e.Handled = true;
                }
            }

            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private decimal ObterValor(string valorInformado)
        {
            if (string.IsNullOrWhiteSpace(valorInformado))
                return decimal.Zero;

            decimal.TryParse(valorInformado, out var valor);
            return valor;
        }

        private Combustivel ObterCombustivelSelecionado()
        {
            int indiceSelecionado = comboBoxCombustivel.FindString(comboBoxCombustivel.Text);
            return ExtensaoEnum.GetEnum<Combustivel>(indiceSelecionado + 1);
        }
    }
}