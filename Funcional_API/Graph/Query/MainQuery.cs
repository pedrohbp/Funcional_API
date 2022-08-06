using GraphQL.Types;
using Funcional_API.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Funcional_API.Graph.Query
{
    public class MainQuery : ObjectGraphType
    {
        public MainQuery(IServiceProvider provider, IWebHostEnvironment env, IFieldService fieldService)
        {
            Name = "MainQuery";
            fieldService.ActivateFields(this, FieldServiceType.Query, env, provider);
        }
    }
}
