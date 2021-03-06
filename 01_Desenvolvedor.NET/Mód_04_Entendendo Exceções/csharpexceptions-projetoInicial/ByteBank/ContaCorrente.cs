﻿// using _05_ByteBank;

using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente       Titular                             { get; set; }

        public int           ContadorSaquesNaoPermitidos         { get; private set; }

        public int           ContadorTransferenciasNaoPermitidas { get; private set; }

        public static double TaxaOperacao                        { get; private set; }

        // Propriedade estática: característica da classe e não de cada objeto criado 
        // a partir dessa classe
        public static int    TotalDeContasCriadas                { get; private set; }
        
       // private int _agencia;

        public  int Agencia { get; } // propriedade privada / somente leitura
        // o campo privado '_agencia' não tem mais utilidade
        /*
        {
            get
            {
                return _agencia;
            }
            private set
            {
                if (value <= 0)
                {
                    return;
                }
                _agencia = value;
            }
        } */


        // O campo READONLY só pode ser atribuido dentro do construtor da classe

        // Ao colocar somente GET, o campo é visto como privado e somente leitura

       // public  int    Numero { get; set; }

        public  int    Numero { get; }

        private double _saldo = 100;

        public  double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int numeroAgencia, int numeroConta)
        {
            if(numeroAgencia <= 0)
            {
                throw new ArgumentException(
                    "O argumento 'agencia' deve ser maior que 0 (zero)", 
                    nameof(numeroAgencia)); // numeroAgencia = nome do argumento que deu erro
            }

            if (numeroConta <= 0)
            {
                throw new ArgumentException(
                    "O argumento 'número' deve ser maior que 0 (zero)", 
                    nameof(numeroConta));
            }

            #region Comentários
            /*
            if (agencia <= 0 || numero <= 0)
            {
                // ArgumentException: exceção de argumento

                //Exception excecao = new Exception("Agencia e/ou numero da conta é zero!");

                ArgumentException excecao = new ArgumentException("Agencia e/ou numero da conta é zero!");

                // Lançar exceção
                //throw new Exception();
                throw excecao;
            } */
            #endregion

            Agencia = numeroAgencia;
            Numero  = numeroConta;
            
            TotalDeContasCriadas++; // Contador de contas criadas

            // Quanto mais contas, menor será a taxa de operação
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }


        public void Sacar(double valor)
        {
            if(valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                //  throw new 
                //      SaldoInsuficienteException("Saldo insuficiente para o saque no valor de R$ " + valor);

                ContadorSaquesNaoPermitidos++;

                throw new
                    SaldoInsuficienteException(Saldo, valor);

                /*  A máquina virtual do VS (CLR) é quem preenche o StackTrace.   */
            }

            _saldo -= valor;
        }

        #region Sacar - 01

        /*
          public bool Sacar(double valor)
        {
            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;

            return true;
        }
             */

        #endregion

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        // bool
        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

           // Sacar(valor);
                   
            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;

                throw new OperacaoFinanceiraException("Operação não realizada.", ex); // passa a exceção adiante

            } 

            /* if (_saldo < valor)  {  return false;   }
               _saldo -= valor;                             */

            contaDestino.Depositar(valor);

           // return true;
        }
    }
}
