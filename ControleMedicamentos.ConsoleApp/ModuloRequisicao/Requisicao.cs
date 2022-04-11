using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class Requisicao : EntidadeBase
    {
        public Requisicao(string nome, int quantidade )
        {
            Nome = nome;
            Quantidade = quantidade;
        }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
       
        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Nome: " + Nome + Environment.NewLine +
                "CPF: " + Quantidade + Environment.NewLine;
        }
    }
}
