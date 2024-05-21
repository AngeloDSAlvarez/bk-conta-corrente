﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente
{
    internal class ContaCorrente
    {
        public string numConta;
        public float saldo;
        public bool status;
        public float limite;
        public List<List<string>> historico = new List<List<string>>();

        public Cliente titular;



        private string debito = "debito";
        private string credito = "credito";

        public ContaCorrente(string numConta, float saldo, bool status, float limite, Cliente titular)
        {
            this.saldo = saldo;
            this.status = status;
            this.limite = limite;
            this.titular = titular;
            inicializaHistorico();
        }

        private void inicializaHistorico()
        {
            historico.Add(new List<string>());
            historico.Add(new List<string>());
        }

        public void sacar(float valor)
        {
            if (verificarSaldo(valor))
            {
                this.saldo -= valor;
                insereHistorico(valor, debito);
                Console.WriteLine("Saldo atual: R$" + getSaldo());
            } else
            {
                Console.WriteLine("Não é possível sacar mais que o limite disponível! ");
            }
        }

        public void depositar(float valor)
        {
            this.saldo += valor;
            insereHistorico(valor, credito);
            Console.WriteLine("Saldo atual: R$" + getSaldo());
        }

        public float getSaldo()
        {
            return this.saldo;
        }

        private bool verificarSaldo(float valor)
        {
            return valor <= getSaldo() + limite ? true : false;
        }

        public ArrayList getExtrato()
        {
            return null;
        }
        public void receberTransf(float valor)
        {
            this.saldo += valor;
            insereHistorico(valor, credito);
        }

        public void transferirDinheiro(ContaCorrente contaDestino, float valor)
        {
            if (verificarSaldo(valor))
            {
                this.saldo -= valor;
                insereHistorico(valor, debito);
                contaDestino.receberTransf(valor);
                Console.WriteLine("Valor transferido com sucesso! ");
            } else
            {
                Console.WriteLine("Não é possível transferir mais que o limite! "); 
            }
        }



        private void insereHistorico(float valor, string tipo)
        {
            historico[0].Add(Convert.ToString(valor));
            historico[1].Add(tipo);
        }

        public void imprimirExtrato()
        {
            Console.WriteLine($"Extrato do {titular.nome} conta numero: {numConta}");
            Console.WriteLine("Valor | Tipo");
            for (int i = 0; i < historico[0].Count(); i++)
            {
                Console.WriteLine(historico[0][i] + " | " + historico[1][i]);
            }
        }

    }   
}
