using Cod3rsGrowth.DOMINIO.Carros;
using Cod3rsGrowth.DOMINIO.Extencoes;
using System.Windows.Forms;

namespace Cod3rsGrowth
{
    public partial class ListaDeCarros : Form
    {
        private readonly string _titulo = "Atenção";
        private readonly DateTime _dataPadrao = new DateTime(2000, 01, 01, 00, 00, 00);
        private readonly IRepositorioCarro _repositorio;
        private readonly TelaDeCriacao _telaDeCriacao;
        private readonly ServicoCarro _servicoCarro;

        public ListaDeCarros(IRepositorioCarro repositorio, TelaDeCriacao telaDeCriacao, ServicoCarro servicoCarro)
        {
            InitializeComponent();
            _repositorio = repositorio;
            CarregarTelaInicial();
            _telaDeCriacao = telaDeCriacao;
            _servicoCarro = servicoCarro;
        }

        private void CarregarTelaInicial()
        {
            dataGridView1.DataSource = ObterTodos(new Filtro());
            comboBoxCombustivel.DataSource = DefinirCombustiveisParaFiltro();
            FormatarColunasDeData();
            FormatarColunasDeValorMonetario();
            InicializarDadosParaFiltroDeData();
        }

        private void FormatarColunasDeValorMonetario()
        {
            dataGridView1.Columns["ValorCusto"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["ValorVenda"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["ValorOfertado"].DefaultCellStyle.Format = "C2";
        }

        private void FormatarColunasDeData()
        {
            dataGridView1.Columns["AnoModelo"].DefaultCellStyle.Format = "yyyy";
            dataGridView1.Columns["AnoFabricacao"].DefaultCellStyle.Format = "yyyy";
        }

        private static string[] DefinirCombustiveisParaFiltro()
        {
            const string TODOS = "Todos";
            var combustiveis = ExtensaoEnum.GetEnumDescriptions<Combustivel>();
            return new[] { TODOS }.Concat(combustiveis).ToArray();
        }

        private List<Carro> ObterTodos(Filtro filtro)
        {
            return _repositorio.ObterTodos(filtro);
        }

        private void AoClicarEmFiltrar(object sender, EventArgs e)
        {
            var filtro = new Filtro()
            {
                Modelo = filtroModelo.Text,
                ProprietarioNome = filtroProprietario.Text,
                AnoModelo = dateTimePicker1.Value == _dataPadrao ? DateTime.MinValue : dateTimePicker1.Value,
                ValorOfertado = ObterValor(),
                Combustivel = ObterCombustivelSelecionado()
            };

            dataGridView1.DataSource = ObterTodos(filtro);
        }

        private decimal? ObterValor()
        {
            if (string.IsNullOrWhiteSpace(filtroValor.Text))
                return null;

            decimal.TryParse(filtroValor.Text, out var valor);
            return valor;
        }

        private Combustivel? ObterCombustivelSelecionado()
        {
            const int ENUM_INVALIDO = 0;
            int indiceSelecionado = comboBoxCombustivel.FindString(comboBoxCombustivel.Text);

            return indiceSelecionado == ENUM_INVALIDO ? null : ExtensaoEnum.GetEnum<Combustivel>(indiceSelecionado);
        }

        private void AoClicarEmLimparFiltro(object sender, EventArgs e)
        {
            CarregarTelaInicial();
            filtroProprietario.Text = string.Empty;
            filtroModelo.Text = string.Empty;
            filtroValor.Text = string.Empty;
        }

        private void InicializarDadosParaFiltroDeData()
        {
            dateTimePicker1.MinDate = _dataPadrao;
            dateTimePicker1.Value = _dataPadrao;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }

        private void AoInformarValor(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                e.KeyChar = ',';

                if (filtroValor.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }

            else if (!char.IsNumber(e.KeyChar) && !(e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void AoClicarEmAdicionar(object sender, EventArgs e)
        {
            if (_telaDeCriacao.ShowDialog() == DialogResult.OK)
            {
                CarregarTelaInicial();
            }
        }

        private void AoClicarEmRemover(object sender, EventArgs e)
        {
            try
            {
                var linhas = dataGridView1.SelectedRows;
                ValidarQuantidadeDeLinhasSelecionadas(linhas);
                DialogResult resposta = ExibirMensagemDeConfirmacao();

                if (resposta != DialogResult.Yes)
                    return;

                const int INDICE_LINHA = 0;
                const int INDICE_COLUNA_ID = 0;
                var id = (int)linhas[INDICE_LINHA].Cells[INDICE_COLUNA_ID].Value;
                _servicoCarro.Remover(id);
                DialogResult respostaMensagemDeSucesso = ExibirMensagemDeSucesso();

                if (respostaMensagemDeSucesso == DialogResult.OK)
                    CarregarTelaInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, _titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DialogResult ExibirMensagemDeSucesso()
        {
            const string MENSAGEM_DE_SUCESSO = "Removido com sucesso.";
            const string TITULO = "Sucesso";
            return MessageBox.Show(MENSAGEM_DE_SUCESSO, TITULO, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private DialogResult ExibirMensagemDeConfirmacao()
        {
            const string MENSAGEM = "Deseja realmente remover? Essa ação não poderá ser desfeita";
            MessageBoxButtons botao = MessageBoxButtons.YesNo;
            MessageBoxIcon icone = MessageBoxIcon.Question;

            DialogResult resposta = MessageBox.Show(MENSAGEM, _titulo, botao, icone);
            return resposta;
        }

        private void ValidarQuantidadeDeLinhasSelecionadas(DataGridViewSelectedRowCollection linhas)
        {
            const int numeroValidoDeLinhasSelecionadas = 1;
            if (linhas.Count > numeroValidoDeLinhasSelecionadas)
                throw new Exception("Selecione apenas uma linha da tabela");

            if (linhas.Count < numeroValidoDeLinhasSelecionadas)
                throw new Exception("Nenhuma linha foi selecionada");
        }
    }
}