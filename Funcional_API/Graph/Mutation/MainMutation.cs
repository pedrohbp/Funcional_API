using GraphQL.Types;
using Funcional_API.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Funcional_API.Graph.Mutation
{
    public class MainMutation : ObjectGraphType
    {
        public MainMutation(IServiceProvider provider, IWebHostEnvironment env, IFieldService fieldService)
        {
            Name = "MainMutation";
            fieldService.ActivateFields(this, FieldServiceType.Mutation, env, provider);
        }
    }
}
