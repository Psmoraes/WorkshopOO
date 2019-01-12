using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopGrilo
{
    internal class Cidade
    {
        public string Nome { get; private set; }
        public string Uf { get; private set; }
        public Cidade(string nome,string uf)
        {
            Nome = nome;
            Uf = uf;
        }
    }
}
