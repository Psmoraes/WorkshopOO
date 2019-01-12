using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkshopGrilo.Enums;

namespace WorkshopGrilo
{
    internal class Conta
    {
        public int Numero { get; private set; }
        public int Agencia { get; private set; }
        public TipoConta TipoConta { get; private set; }
        public decimal Saldo { get; private set; }
        public Banco Banco { get; private set; }
        public List<Transacao> Transacoes { get; private set; }
        public Conta(int agencia, int numero, TipoConta tipoconta, Banco banco)
        {
            TipoConta = tipoconta;
            Agencia = agencia;
            Numero = numero;
            Banco = banco;
            Transacoes = new List<Transacao>();
        }
        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor solicitado é inválido;");
            if (valor > Saldo)
                throw new Exception("Saldo insuficiente para realizar o saque.");
            var transacao = new Transacao("Saque", valor, TipoTransacao.Debito);
            Debitar("Retirada", valor);
            Console.WriteLine("Saque realido com sucesso.");
        }
        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor é inválido.");
            var transacao = new Transacao("Dpositar", valor, TipoTransacao.Credito);
            Creditar("Deposito", valor);
            Console.WriteLine("Deposito realizado com sucesso.");
            
        }
        public void Transferir(int agencia, int numeroConta, decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor é inválido;");
            if (valor > Saldo)
                throw new Exception("Saldo insuficiente para realizar a transferencia.");
            var contaDestino = Banco.ObterConta(agencia, numeroConta);
            contaDestino.Creditar("Transferencia", valor);
            Debitar("Transferencia", valor);
            Saldo -= valor;

        }
        public void TirarExtrato()
        {
            if (Transacoes.Any())
            {
                foreach(var transacao in Transacoes)
                {
                    var cor = transacao.TipoTransacao == TipoTransacao.Debito ? ConsoleColor.Red : ConsoleColor.Green;
                    Console.ForegroundColor = cor;
                    Console.WriteLine($"{transacao.Descricao.PadRight(20, '-')}{transacao.Valor.ToString("C")}");
                }
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(string.Empty);
                var saldoDescricao = "Saldo".PadRight(20, '-') + Saldo.ToString("C");
                Console.WriteLine(saldoDescricao);
            }


        }
        private void Creditar(string descricao, decimal valor)
        {
            var transacao = new Transacao(descricao, valor, TipoTransacao.Credito);
            Transacoes.Add(transacao);
            Saldo += valor;
        }
        private void Debitar(string descricao, decimal valor)
        {
            var transacao = new Transacao(descricao, valor, TipoTransacao.Debito);
            Transacoes.Add(transacao);
            Saldo -= valor;
        }
    }
}
