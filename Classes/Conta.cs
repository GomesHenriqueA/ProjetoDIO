using System;

namespace ProjetoDIO{
    public class Conta{
                private TipoConta TipoConta{get; set;}
        private double Saldo {get; set;}
        private double Credito{get; set;}
        private string Nome{get; set;}
        public Conta(TipoConta tipoConta, double Saldo, double Credito, string Nome){
            this.TipoConta = tipoConta;
            this.Saldo = Saldo;
            this.Credito = Credito;
            this.Nome = Nome;
        }
        //Verificação de Saldo Insuficiente
        public bool Saque(double valorSaque){
            if(this.Saldo - valorSaque < this.Credito *-1){
                Console.WriteLine("=====================");
                Console.WriteLine("OPERAÇÃO ILEGAL: Saldo Insuficiente!");
                Console.WriteLine("=====================");
                return false;
            }
            //Verificação de Saldo Positivo
            this.Saldo = this.Saldo - valorSaque;
            Console.WriteLine("===============================");
            Console.WriteLine("OPERAÇÃO REALIZADA COM SUCESSO!");
            Console.WriteLine("===============================");
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é de {this.Saldo}");
            Console.WriteLine("-------------------------------");
            return true;
        }
        //Deposito
        public void Deposito(double valorDeposito){
            this.Saldo = this.Saldo + valorDeposito;
            Console.WriteLine($"Saldo Atual da conta de {this.Nome} é {this.Saldo}.");
            Console.WriteLine("-------------------------------");
        }
        //Transferencia entre contas
        public void Transferir(double valorTransf, Conta contaDestino){
            if(this.Saque(valorTransf)){
                contaDestino.Deposito(valorTransf);
            }
        }
        public override string ToString(){

            string retorno = "";
            retorno += "Tipo de Conta: " + this.TipoConta + "|";
            retorno += "Nome: " + this.Nome + "|";
            retorno += "Saldo: " + this.Saldo + "|";
            retorno += "Crédito: " + this.Credito;
            return retorno;
        }
    }
}