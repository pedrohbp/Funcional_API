using GraphQL.Types;
using Funcional_API.Dto;
using Funcional_API.Graph.Type;
using Funcional_API.Interfaces;
using Funcional_API.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using GraphQL;

namespace Funcional_API.Graph.Mutation
{
    public class AddContaMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<ContaGType>("addConta",
            arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" },
               new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "saldo" }             
            ),
            resolve: (Func<ResolveFieldContext<object>, object>)(context =>
            {                
                var conta = context.GetArgument<int>("conta");
                var saldo = context.GetArgument<double>("saldo");

                var contaRepository = (IGenericRepository<Conta>)sp.GetService(typeof(IGenericRepository<Conta>));
                var saldoRepository = (IGenericRepository<Conta>)sp.GetService(typeof(IGenericRepository<Conta>));

                var foundConta = contaRepository.GetByConta(conta);

                if (foundConta != null)
                {
                    throw new ExecutionError("Essa conta já existe.");
                }
                 
                var newConta = new Conta
                {
                    conta = conta,
                    saldo = saldo
                };
                
                var addedConta = contaRepository.Insert(newConta);
                
                return addedConta;

            }));
        }
    }
}
