using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkshopGrilo
{
    internal class Banco
    {
        public string Nome { get; private set; }
        //public Endereco Endereco { get; private set; }
        public int Numero { get; private set; }
        public List<Conta> Contas { get; private set; }
        public Conta AbrirConta(Cliente cliente)
        {
            
            var numeroConta = Contas.Count - 1;
            var conta = new Conta(1,1,Enums.TipoConta.Corrente, this);
            Contas.Add(conta);
            return conta;
        }
        public void FecharConta(Conta conta)
        {
            Contas.Remove(conta);
        }
        public Banco()
        {
            Contas = new List<Conta>();
        }
        public Conta ObterConta(int agencia, int numeroConta)
        {
            var conta = Contas.FirstOrDefault(c => c.Agencia == agencia && c.Numero == numeroConta);
            
            if (conta == null)
                throw new Exception("Conta não encontrada.");
            return conta;
        }
        
    }
}
