using Funcional_API.Dto;
using Funcional_API.Graph.Type;
using Funcional_API.Interfaces;
using GraphQL.Resolvers;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Funcional_API.Graph.Subscription
{
    public class ContaAddedSubscription : IFieldSubscriptionServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.AddField(new EventStreamFieldType
            {
                Name = "contaAdded",
                Type = typeof(ContaAddedMessageGType),
                Resolver = new FuncFieldResolver<ContaAddedMensage>(context => context.Source as ContaAddedMensage),
                Arguments = new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" }
                ),

            });
        }
    }
}
