using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using ControleMedicamentos.ConsoleApp.ModuloMedicamento;
using ControleMedicamentos.ConsoleApp.ModuloPaciente;


namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class TelaCadastroRequisicao : TelaBase
    {
        private readonly RepositorioMedicamento _repositorioMedicamento;
        private readonly RepositorioPaciente _repositorioPaciente;
        private readonly RepositorioRequisicao _repositorioRequisicao;
        private readonly Notificador _notificador;
        private readonly TelaCadastroPaciente _telaCadastroPaciente;
        private readonly TelaCadastroMedicamento _telaCadastroMedicamento;


        public TelaCadastroRequisicao(TelaCadastroMedicamento telaCadastroMedicamento, TelaCadastroPaciente telaCadastroPaciente, RepositorioRequisicao repositorioRequisicao, RepositorioMedicamento repositorioMedicamento,
            RepositorioPaciente repositorioPaciente, Notificador notificador) : base("Requisitar um medicamento") 
        {
           

            this._telaCadastroMedicamento = telaCadastroMedicamento;
            this._telaCadastroPaciente = telaCadastroPaciente;
            this._repositorioPaciente = repositorioPaciente;
            this._repositorioMedicamento = repositorioMedicamento;
            this._repositorioRequisicao = repositorioRequisicao;
            this._notificador = notificador;
        }

        public override string MostrarOpcoes() // nao esta indo!!! ns como q tira o base ali encima sem dar erro
        {
            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Visualizar");
            return base.MostrarOpcoes();
        }

        public void Inserir()
        {
           
            _telaCadastroPaciente.VisualizarRegistros("pesquisa");
            Console.WriteLine("Digite o id do paciente cadastrado qeu deseja adiquirir um remedio");
            int pacienteSelecionado = Convert.ToInt32(Console.ReadLine());
            _repositorioPaciente.SelecionarRegistro(pacienteSelecionado);

            _telaCadastroMedicamento.VisualizarRegistros("pesquisa");
            Console.WriteLine("Qual o id do remedio que deseja pegar?");
            int remedioSelecionado = Convert.ToInt32(Console.ReadLine());
            _repositorioMedicamento.SelecionarRegistro(remedioSelecionado);

            Console.WriteLine("Qual a quantidade de caixar que dejesa pegar?");
            int quantidade = Convert.ToInt32(Console.ReadLine());
            _repositorioMedicamento.SelecionarRegistro(remedioSelecionado).Quantidade -= quantidade;
            

            _notificador.ApresentarMensagem("Medicamento requisitado com sucesso!", TipoMensagem.Sucesso);     
        }
        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Requisicao");

            List<Requisicao> Requisicoes = _repositorioRequisicao.SelecionarTodos();

            if (Requisicoes.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhuma Requisicao disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Requisicao Requisicao in Requisicoes)
                Console.WriteLine(Requisicao.ToString());

            Console.ReadLine();

            return true;
        }
    }
}
