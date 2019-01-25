﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Funcionarios
{
    public class Diretor : Funcionario
    {
        // Ao chamar o construtor de um tipo derivado, será chamado primeiro
        // o construtor da classe base (no caso Funcionario)
        public Diretor(string cpf) : base(5000, cpf)
        {
            Console.WriteLine("Criando DIRETOR");
            Console.WriteLine();
        }

        // override: diz que o método está sobrepondo um comportamento
        public override double GetBonificacao()
        {
            //  return Salario + ( Salario * 0.10 );
            // return Salario + base.GetBonificacao();

            return Salario * 0.5;

            // está somando a bonificação do diretor (salario) com 
            // a bonificação de funcionario implementada na classe original (salario * 0.10)

            // 'base': busca a implementação original do método
        }

        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }

    }
}
