﻿using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class LojaContext : DbContext 
    {
        // Essa classe deve permitir a utilização da API do Entity, e para isso 
        // a classe deve herdar de DbContext
        
        public DbSet<Produto> Produtos { get; set; }

        // Método de configuração do LojaContext
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
        } 
    }
}