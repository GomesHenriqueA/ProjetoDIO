using System;
using System.Collections.Generic;

namespace ProjetoDIO{
    class Program{
        static List<Conta> listaContas = new List<Conta>();
        private static int i;

        static void Main(string[] args){
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch(opcaoUsuario){
                    case "9":
                    ListarContar();
                        break;
                    case "2":
                    InserirConta();
                        break;
                    case "3":
                    Transferir();
                        break;
                    case "4":
                    Sacar();
                        break;
                    case "5":
                    Depositar();
                        break;
                    case "C":
                    Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por Utilizar nossos serviços!");
            Console.WriteLine();
        }
        //Exibe a Lista com as Contas cadastradas
        private static void ListarContar(){
            Console.WriteLine("Lista de Contas");
            if(listaContas.Count == 0){
                Console.WriteLine("Nenhuma Conta cadastrada!");
                return;
            }
            for(i = 0; i < listaContas.Count; i ++){
                Conta conta = listaContas[i];
                Console.WriteLine($"{i}");
                Console.WriteLine(conta);
            }
        }
        //Inserir Novas Contas
        private static void InserirConta(){
            Console.WriteLine("Inserir Nova Conta");
            Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Conta Juridica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o nome do cliente:");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Insira o Saldo inicial:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito:");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, Saldo:entradaSaldo, Credito: entradaCredito, Nome: entradaNome);

            listaContas.Add(novaConta);
        }
        //Realizar Transferencia
                private static void Transferir(){
                    Console.WriteLine("Digite o número da conta de origem: ");
                    int indiceContaOrigem = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o número da conta destino: ");
                    int indiceContaDestino = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o Valor da Transferência: ");
                    double valorTransf = double.Parse(Console.ReadLine());

                    listaContas[indiceContaOrigem].Transferir(valorTransf, listaContas[indiceContaDestino]);
        }
        //Realizar Saque
                private static void Sacar(){
                    Console.WriteLine("Digite o Número da Conta: ");
                    int indiceConta = int.Parse(Console.ReadLine());

                    Console.WriteLine("Digite o Valor do Saque: ");
                    double valorSaque = double.Parse(Console.ReadLine());

                    listaContas[indiceConta].Saque(valorSaque);
        }
        //Realizar Depósito
                private static void Depositar(){
                    Console.WriteLine();
        }
        //Menu Inicial
        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Bem Vindo a DIO Bank!");
            Console.WriteLine();
            Console.WriteLine("Selecione a Opção Desejada:");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
