using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopGrilo
{
    internal class Cliente
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Endereco Endereco { get; set; }
        public Cliente(string nome, string cpf, DateTime datanascimento, Endereco endereco)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = datanascimento;
            Endereco = endereco;

        }
        
    }
}
