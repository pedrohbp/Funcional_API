using GraphQL.Types;
using Funcional_API.Interfaces;
using Funcional_API.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using GraphQL;

namespace Funcional_API.Graph.Mutation
{
    public class DeleteContaMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<IntGraphType>("deletar",
            arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" }               
            ),
            resolve: context =>
            {
                var conta = context.GetArgument<int>("conta");
                var contaRepository = (IGenericRepository<Conta>)sp.GetService(typeof(IGenericRepository<Conta>));
                var foundConta = contaRepository.GetByConta(conta);

                if (foundConta == null)
                {
                    throw new ExecutionError("Não existe esta conta");
                }     

                return contaRepository.Delete(conta);
            });
        }
    }
}
