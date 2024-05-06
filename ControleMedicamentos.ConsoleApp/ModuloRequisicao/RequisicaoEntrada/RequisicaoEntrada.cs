using System.Collections;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloFornecedor;
using ControleMedicamentos.ConsoleApp.ModuloFuncionario;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao.RequisicaoEntrada
{
    internal class RequisicaoEntrada : EntidadeBase
    {
        // Registrar Requisição de Entrada: O usuário poderá fazer uma requisição de entrada de medicamento que incluirá:
        // data da requisição, dados do medicamento, dados do fornecedor, dados do funcionário e a quantidade requisitada do medicamento.
        // A quantidade do medicamento deve ser atualizada.

        public Medicamento Medicamento { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime DataRequisicao { get; set; }
        public int QuantidadeAdicionada { get; set; }

        public RequisicaoEntrada(Medicamento medicamentoSelecionado, Fornecedor fornecedorSelecionado, Funcionario funcionarioSelecionado, int quantidade)
        {
            Medicamento = medicamentoSelecionado;
            Fornecedor = fornecedorSelecionado;
            Funcionario = funcionarioSelecionado;
            DataRequisicao = DateTime.Now;
            QuantidadeAdicionada = quantidade;

            AtualizarQuantidadeMedicamento();
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (Medicamento == null)
                erros.Add("O medicamento precisa ser preenchido");

            if (Fornecedor == null)
                erros.Add("O fornecedor precisa ser informado");

            if (Funcionario == null)
                erros.Add("O funcionário precisa ser informado");

            if (QuantidadeAdicionada == null)
                erros.Add("Por favor informe uma quantidade válida");
            
            return erros;
        }

        public bool AdicionarMedicamento()
        {
            if (QuantidadeAdicionada < 0)
            {
                return false;
            }

            QuantidadeAdicionada += Medicamento.Quantidade;
            AtualizarQuantidadeMedicamento();
            return true;
        }

        private void AtualizarQuantidadeMedicamento()
        {
            Medicamento.Quantidade += QuantidadeAdicionada;
        }
    }
}