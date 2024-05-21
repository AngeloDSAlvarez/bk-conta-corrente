namespace ContaCorrente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente1 = new Cliente("Angelo", "Daniel", "11111111");
            ContaCorrente cC1 = new ContaCorrente("1621", 1000, false, 500, cliente1);

            Cliente cliente2 = new Cliente("George", "Professor", "222222222");
            ContaCorrente cC2 = new ContaCorrente("1625", 500, true, 800, cliente2);

            cC1.transferirDinheiro(cC2, 300);

            Console.WriteLine(cC1.getSaldo());
            Console.WriteLine(cC2.getSaldo());
            cC1.imprimirExtrato();
            cC2.imprimirExtrato();
        }
    }
}
