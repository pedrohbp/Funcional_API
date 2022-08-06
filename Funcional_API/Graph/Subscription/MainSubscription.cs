using Funcional_API.Interfaces;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Funcional_API.Graph.Subscription
{
    public class MainSubscription : ObjectGraphType
    {
        public MainSubscription(IServiceProvider provider, IWebHostEnvironment env, IFieldService fieldService)
        {
            Name = "MainSubscription";
            fieldService.ActivateFields(this, FieldServiceType.Subscription, env, provider);
        }
    }
}
