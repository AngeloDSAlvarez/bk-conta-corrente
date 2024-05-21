using System;
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
        private string numConta;
        private float saldo;
        private bool status;
        private float limite;
        private List<List<string>> historico = new List<List<string>>();

        private Cliente titular;



        private string debito = "debito";
        private string credito = "credito";

        public ContaCorrente(string numConta, float saldo, bool status, float limite, Cliente titular)
        {
            this.numConta = numConta;
            this.saldo = saldo;
            this.status = status;
            this.limite = limite;
            this.titular = titular;
            inicializaHistorico();
        }
        //inicializa o historico na criação da conta, para criar duas listas dentro da lista
        private void inicializaHistorico()
        {
            historico.Add(new List<string>());
            historico.Add(new List<string>());
        }
        //getSaldo
        public float getSaldo()
        {
            return this.saldo;
        }



        //função para sacar
        public void sacar(float valor)
        {
            //verifica se é possivel realizar o saque com o valor recebido
            if (verificarSaldo(valor))
            {
                //retira o valor da conta e adiciona no historico
                this.saldo -= valor;
                insereHistorico(valor, debito);
                Console.WriteLine("Saldo atual: R$" + getSaldo());
            } else
            {
                //informa que não tem limite
                Console.WriteLine("Não é possível sacar mais que o limite disponível! ");
            }
        }
        //função para depositar
        public void depositar(float valor)
        {
            //adiciona o valor na conta e no histórico
            this.saldo += valor;
            insereHistorico(valor, credito);
            Console.WriteLine("Saldo atual: R$" + getSaldo());
        }

        //verifica se é possivel realizar saque ou transferencia
        private bool verificarSaldo(float valor)
        {
            //retorna TRUE/FALSE caso o valor que queira sacar for menor 
            return valor <= getSaldo() + limite ? true : false;
        }

        //transfere dinheiro, recebe a conta de destino e o valor de parametro
        public void transferirDinheiro(ContaCorrente contaDestino, float valor)
        {
            if (verificarSaldo(valor))
            {
                //retira o saldo da conta que envia e adiciona no historico
                this.saldo -= valor;
                insereHistorico(valor, debito);
                //chama a função para receber a transferencia na conta destino, enviando o valor
                contaDestino.receberTransf(valor);
                Console.WriteLine("Valor transferido com sucesso! ");
            }
            else
            {
                Console.WriteLine("Não é possível transferir mais que o limite! ");
            }
        }

        //função para receber a transferencia de outra conta
        public void receberTransf(float valor)
        {
            //adiciona o valor no saldo e adiciona no historico
            this.saldo += valor;
            insereHistorico(valor, credito);
        }

        //adiciona o valor e o tipo da transferencia no histórico
        //tipo = credito/debito
        private void insereHistorico(float valor, string tipo)
        {
            historico[0].Add(Convert.ToString(valor));
            historico[1].Add(tipo);
        }

        //imprime o extrato 
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
