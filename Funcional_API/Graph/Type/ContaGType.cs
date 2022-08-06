using GraphQL.Types;
using Funcional_API.Interfaces;
using Funcional_API.Models;
using System;
using System.Linq;

namespace Funcional_API.Graph.Type
{
    public class ContaGType : ObjectGraphType<Conta>
    {
        public IServiceProvider Provider { get; set; }
        public ContaGType(IServiceProvider provider)
        {
            Field(x => x.conta, type: typeof(IntGraphType));
            Field(x => x.saldo, type: typeof(FloatGraphType));
            
        }
    }
}
