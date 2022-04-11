using System;
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
{
    public class Paciente : EntidadeBase
    {

        public Paciente(string nome, string cpf, string bairro)
        {
            Nome = nome;
            Cpf = cpf;
            Bairro = bairro;
        }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Bairro { get; set; }

        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Nome: " + Nome + Environment.NewLine +
                "CPF: " + Cpf + Environment.NewLine +
                "bairro: " + Bairro + Environment.NewLine;
        }
    }
}
