﻿using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    internal class TelaFuncionario : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Funcionarios...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                "Id", "Nome", "Telefone", "CPF"
            );

            EntidadeBase[] funcionariosCadastrados = repositorio.SelecionarTodos();

            foreach (Funcionario funcionario in funcionariosCadastrados)
            {
                if (funcionario == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                    funcionario.Id, funcionario.Nome, funcionario.Telefone, funcionario.Cpf
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome do fornecedor: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone do fornecedor: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o CPF: ");
            string cnpj = Console.ReadLine();

            Funcionario novoFuncionario = new Funcionario(nome, telefone, cnpj);

            return novoFuncionario;
        }
    }
}