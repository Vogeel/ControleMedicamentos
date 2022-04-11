using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento : EntidadeBase
    {
        public Medicamento (string nome, string descricao, int quantidade)
        {
            Nome = nome;
            Descricao = descricao;
            Quantidade = quantidade;
        }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        public override string ToString()
        {
            if (Quantidade <= 10)
            {
                return "Id: " + id + Environment.NewLine +
                 "Nome: " + Nome + Environment.NewLine +
                 "Descrição: " + Descricao + Environment.NewLine +
                 "Quantidade em estoque: " + Quantidade + Environment.NewLine +
                 "Medicamento: " + Nome + " Está em falta! contatar fornecedor" +
                 Environment.NewLine;
            }
            else
            {
                return "Id: " + id + Environment.NewLine +
                   "Nome: " + Nome + Environment.NewLine +
                   "Descrição: " + Descricao + Environment.NewLine +
                   "Quantidade em estoque: " + Quantidade + Environment.NewLine;
            }

        }
        
       
    }
}
