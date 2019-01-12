using System;
using System.Collections.Generic;
using System.Text;
using WorkshopGrilo.Enums;

namespace WorkshopGrilo
{
    internal class Transacao
    {
        public TipoTransacao TipoTransacao { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataHora { get; private set; }
        public Transacao(string descricao, decimal valor, TipoTransacao tipotransacao)
        {
            Descricao = descricao;
            Valor = valor;
            TipoTransacao = tipotransacao;
            DataHora = DateTime.Now;
        }
    }
}
