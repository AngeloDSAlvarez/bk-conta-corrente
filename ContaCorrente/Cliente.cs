using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContaCorrente
{
    internal class Cliente
    {
        public string nome;
        public string sobrenome;
        public string cpf;

        public Cliente(string nome, string sobrenome, string cpf)
        {
            this.nome = nome;
            this.sobrenome = sobrenome;
            this.cpf = cpf;
        }
    }
}
