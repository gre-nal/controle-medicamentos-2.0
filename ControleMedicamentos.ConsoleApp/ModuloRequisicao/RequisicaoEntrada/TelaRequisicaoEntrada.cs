using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.RequisicaoEntrada
{
    internal class TelaRequisicaoEntrada : TelaBase
    {
        public TelaMedicamento telaMedicamento = null;
        public TelaFornecedor telaFornecedor = null;
        public TelaFuncionario telaFuncionario = null;


        public RepositorioMedicamento repositorioMedicamento = null;
        public RepositorioFornecedor repositorioFornecedor = null;
        public RepositorioFuncionario repositorioFuncionario = null;


        public override void Registrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            RequisicaoEntrada entidade = (RequisicaoEntrada)ObterRegistro();

            string[] erros = entidade.Validar();

            if (erros.Length > 0)
            {
                ApresentarErros(erros);
                return;
            }

            bool conseguiuAdicionar = entidade.AdicionarMedicamento();

            if (!conseguiuAdicionar)
            {
                ExibirMensagem("Não foi possível adicionar.", ConsoleColor.DarkYellow);
                return;
            }

            repositorio.Cadastrar(entidade);

            ExibirMensagem($"A {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
            return;
        }


        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Requisições de Entrada...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -5}",
                "Id", "Medicamento", "Fornecedor", "Data de Requisição", "Quantidade"
            );

            EntidadeBase[] requisicoesCadastradas = repositorio.SelecionarTodos();

            foreach (RequisicaoEntrada requisicao in requisicoesCadastradas)
            {
                if (requisicao == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -20} | {4, -5}",
                    requisicao.Id,
                    requisicao.Medicamento.Nome,
                    requisicao.Funcionario.Nome,
                    requisicao.Fornecedor.Nome,
                    requisicao.DataRequisicao.ToShortDateString(),
                    requisicao.QuantidadeAdicionada
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            telaMedicamento.VisualizarRegistros(false);

            Console.Write("Digite o ID do medicamento: ");
            int idMedicamento = Convert.ToInt32(Console.ReadLine());
            Medicamento medicamentoSelecionado = (Medicamento)repositorioMedicamento.SelecionarPorId(idMedicamento);

            Console.WriteLine("Digite o ID do funcionário: ");
            int idFuncionario = Convert.ToInt32(Console.ReadLine());
            Funcionario funcionarioSelecionado = (Funcionario)repositorioFuncionario.SelecionarPorId(idFuncionario);

            telaFornecedor.VisualizarRegistros(false);
            Console.WriteLine("Digite o ID do fornecedor: \n");
            int idFornecedor = Convert.ToInt32(Console.ReadLine());
            Fornecedor fornecedorSelecionado = (Fornecedor)repositorioFornecedor.SelecionarPorId(idFornecedor);

            Console.WriteLine();

            Console.WriteLine("Digite a quantidade de medicamentos que deseja adicionar: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            RequisicaoEntrada requisicaoEntrada = new RequisicaoEntrada(medicamentoSelecionado, fornecedorSelecionado, funcionarioSelecionado, quantidade);

            return requisicaoEntrada;
        }
    }
}
