using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario
{
    /*4. Controle de Funcionário
        Registrar Funcionário: O funcionário deverá ser registrado com as seguintes 
        informações: nome, telefone e CPF.
        Visualizar Funcionários: Exibe uma lista exibindo detalhes de todos os 
        funcionários registrados.
        Editar Funcionário: Oferece a possibilidade de modificar informações de um 
        funcionário cadastrado.
        Excluir Funcionário: Permite remover um registro de funcionário do sistema.
    */
    internal class TelaFuncionario : TelaBase
    {
        public void VisualizarFuncionarios(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Funcionários");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, =15} | {3, -15}",
                "id", "Nome", "Telefone", "CPF"
                );

            EntidadeBase[] funcionariosCadastrados = repositorio.SelecionarTodos();

            foreach (Funcionario funcionario in funcionariosCadastrados)
            {
                if (funcionario == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, =15} | {3, -15}",
                    funcionario.Id, funcionario.Nome, funcionario.Telefone, funcionario.CPF
                );
            }
            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine("Digite o nome do funcionário: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o telefone do funcionário: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Digite o cpf do funcionário: ");
            string cpf = Console.ReadLine();
            string cpfFormatado = Convert.ToInt32(cpf).ToString(@"000\.000\.000\-00");
            cpf = cpfFormatado;

            Paciente novoPaciente = new Paciente(nome, telefone, cpf);
            return novoPaciente;
        }

        public override void VisualizarRegistros(bool exibirTitulo)
        {
            throw new NotImplementedException();
        }
    }
}
