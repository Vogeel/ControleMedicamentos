using ControleMedicamentos.ConsoleApp.Compartilhado;

using System;
using System.Collections.Generic;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaCadastroMedicamento : TelaBase, ITelaCadastravel
    {
        private readonly RepositorioMedicamento _repositorioMedicamento;
        private readonly Notificador _notificador;

        public TelaCadastroMedicamento(RepositorioMedicamento repositorioMedicamento, Notificador notificador)
            : base("Cadastro de Medicamento")
        {
            _repositorioMedicamento = repositorioMedicamento;
            _notificador = notificador;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Medicamento");

            Medicamento novoMedicamento = ObterMedicamento();

            _repositorioMedicamento.Inserir(novoMedicamento);

            _notificador.ApresentarMensagem("Medicamento cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Medicamento");

            bool temMedicamentoesCadastrados = VisualizarRegistros("Pesquisando");

            if (temMedicamentoesCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum Medicamento cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroMedicamento = ObterNumeroRegistro();

            Medicamento MedicamentoAtualizado = ObterMedicamento();

            bool conseguiuEditar = _repositorioMedicamento.Editar(numeroMedicamento, MedicamentoAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Medicamento editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Medicamento");

            bool temMedicamentoesRegistrados = VisualizarRegistros("Pesquisando");

            if (temMedicamentoesRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum Medicamento cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroMedicamento = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioMedicamento.Excluir(numeroMedicamento);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Medicamento excluído com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Medicamentos");

            List<Medicamento> Medicamentos = _repositorioMedicamento.SelecionarTodos();

            if (Medicamentos.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum Medicamento disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Medicamento Medicamento in Medicamentos)
                Console.WriteLine(Medicamento.ToString());

            Console.ReadLine();

            return true;
        }

        private Medicamento ObterMedicamento()
        {
            Console.WriteLine("Digite o nome do Medicamento: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite a descrição do Medicamento ");
            string descricao = Console.ReadLine();

            Console.WriteLine("Digite a quantidade de caixas de Medicamentos adicionados ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            return new Medicamento(nome, descricao, quantidade);
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do Medicamento que deseja editar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioMedicamento.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID do Medicamento não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
    }
}
