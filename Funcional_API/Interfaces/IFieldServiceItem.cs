using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using System;

namespace Funcional_API.Interfaces
{
    public interface IFieldServiceItem
    {
        void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp);
    }

    public interface IFieldMutationServiceItem : IFieldServiceItem
    {
    }

    public interface IFieldQueryServiceItem : IFieldServiceItem
    {
    }
    public interface IFieldSubscriptionServiceItem : IFieldServiceItem
    {

    }
}
