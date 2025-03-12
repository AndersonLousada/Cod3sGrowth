using Cod3rsGrowth.DOMINIO.Carros;
using Cod3rsGrowth.DOMINIO.Extencoes;

namespace Cod3rsGrowth
{
    public partial class TelaDeCriacao : Form
    {
        private readonly DateTime _dataPadrao = new DateTime(2000, 01, 01, 00, 00, 00);
        private readonly ServicoCarro _servicoCarro;
        private int? _idCarro = null;

        public TelaDeCriacao(ServicoCarro servico)
        {
            InitializeComponent();
            CarregarTelaInicial();
            _servicoCarro = servico;
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
            _idCarro = null;
            InputModelo.Text = string.Empty;
            InputMarca.Text = string.Empty;
            InputProprietario.Text = string.Empty;
            InputCusto.Text = string.Empty;
            InputValorOfertado.Text = string.Empty;
            InputVenda.Text = string.Empty;
            InputAnoFabricacao.Value = _dataPadrao;
            InputAnoModelo.Value = _dataPadrao;
            CheckBoxQuitado.Checked = false;
        }

        public void CarregaTelaModoEdicao(Carro carro)
        {
            _idCarro = carro.Id;
            InputModelo.Text = carro.Modelo;
            InputMarca.Text = carro.Marca;
            InputProprietario.Text = carro.ProprietarioNome;
            InputCusto.Text = carro.ValorCusto.ToString();
            InputValorOfertado.Text = carro.ValorOfertado.ToString();
            InputVenda.Text = carro.ValorVenda.ToString();
            InputAnoFabricacao.Value = carro.AnoFabricacao;
            InputAnoModelo.Value = carro.AnoModelo;
            CheckBoxQuitado.Checked = carro.Quitado;
        }

        private void AoClicarEmSalvar(object sender, EventArgs e)
        {
            try
            {
                var carro = new Carro
                {
                    Id = _idCarro,
                    Modelo = InputModelo.Text,
                    Marca = InputMarca.Text,
                    ProprietarioNome = InputProprietario.Text,
                    ValorCusto = ObterValor(InputCusto.Text),
                    ValorOfertado = ObterValor(InputValorOfertado.Text),
                    ValorVenda = ObterValor(InputVenda.Text),
                    AnoFabricacao = InputAnoFabricacao.Value,
                    AnoModelo = InputAnoModelo.Value,
                    Quitado = CheckBoxQuitado.Checked,
                    Combustivel = ObterCombustivelSelecionado()
                };

                var ehModoCriacao = _idCarro is null;

                if (ehModoCriacao)
                    _servicoCarro.Criar(carro);
                else
                    _servicoCarro.Atualizar(carro);

                DialogResult = DialogResult.OK;
                Close();

                string tipoDeAcao = ehModoCriacao ? "cadastrado" : "atualizado";
                MessageBox.Show($"Veículo {tipoDeAcao} com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.None);
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
            const int enumeradorPadrao = 1;
            int indiceSelecionado = comboBoxCombustivel.FindString(comboBoxCombustivel.Text);

            return ExtensaoEnum.GetEnum<Combustivel>(indiceSelecionado + enumeradorPadrao);
        }

        private void LimparCampos(object sender, FormClosedEventArgs e)
        {
            LimparCampos();
        }
    }
}