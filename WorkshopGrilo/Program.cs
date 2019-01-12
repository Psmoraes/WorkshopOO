using System;

namespace WorkshopGrilo
{
    internal class Program
    {
        private static readonly Banco banco = new Banco();
        private static readonly Conta contaDestino;
        static Program()
        {
            var cidade = new Cidade("Jundiai"," SP");
            var endereco = new Endereco("Rua 15","Vl Arens", "12201004", 142, cidade);
            var cliente = new Cliente("Pedro", "123123", new DateTime(1997, 12, 18), endereco);
            contaDestino = banco.AbrirConta(cliente);
        }
        private static void Main(string[] args)
        {
            try
            {
                var cidade = new Cidade("Jundiai", " SP");
                var endereco = new Endereco("Rua 15", "Vl Arens", "12201004", 142, cidade);
                var cliente = new Cliente("Pedro", "123123", new DateTime(1997, 12, 18), endereco);
                var contaRicardo = banco.AbrirConta(cliente);

                contaRicardo.Depositar(2500);
                contaRicardo.Sacar(350);
                contaRicardo.TirarExtrato();
                contaRicardo.Transferir(1, 1, 1000);
                contaRicardo.TirarExtrato();
                contaDestino.TirarExtrato();
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
            Console.ResetColor();
            Console.WriteLine(string.Empty);
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
