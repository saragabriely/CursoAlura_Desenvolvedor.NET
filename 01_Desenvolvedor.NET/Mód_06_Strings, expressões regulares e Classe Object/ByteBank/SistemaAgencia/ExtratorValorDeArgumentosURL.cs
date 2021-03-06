﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgencia
{
    public class ExtratorValorDeArgumentosURL
    {
        // prop + tab + tab - criar argumentos / atributos

        // criar construtor: ctor + tab + tab

        // Readonly - só é possível atribuir valor a variavel no construtor ou
        // explicitamente na declaração.
        private readonly string _argumentos;

        public  string URL { get; }

        public ExtratorValorDeArgumentosURL(string url)
        {
            // string.IsNullOrEmpty(url) - Método estático

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento URL não pode ser nulo ou vazio.", nameof(url));
            }

            #region Comentário / Primeiro código
            /*
            if(url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }
            if(url == "")
            {
                throw new 
                    ArgumentException("O argumento URL não pode ser uma string vazia",
                        nameof(url));
            }*/
            #endregion
            
            int indeceInterrogacao = url.LastIndexOf("?");

            _argumentos = url.Substring(indeceInterrogacao + 1);

            URL = url;
            
        }
        
       // moedaOrigem=real&moedaDestino=dolar
       public string GetValor(string nomeDoParametro)
       {
            nomeDoParametro = nomeDoParametro.ToUpper(); // VALOR 

            string argumentoEmCaixaAlta = _argumentos.ToUpper(); // MOEDAORIGEM=REAL


            string termo = nomeDoParametro + "=";

            int indiceTermo = argumentoEmCaixaAlta.IndexOf(termo);


            string resultado = _argumentos.Substring(indiceTermo + termo.Length);

            int indiceEComercial = resultado.IndexOf('&');

            if(indiceEComercial == -1)
            {
                return resultado;
            }

            return resultado.Remove(indiceEComercial); // remove parte da string a partir de determinado indice
       }

    }
}
