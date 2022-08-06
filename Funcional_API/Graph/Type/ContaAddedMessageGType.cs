using Funcional_API.Dto;
using GraphQL.Types;

namespace Funcional_API.Graph.Type
{
    public class ContaAddedMessageGType : ObjectGraphType<ContaAddedMensage>
    {
        public ContaAddedMessageGType()
        {

            Field(x => x.message, type: typeof(StringGraphType));
            Field(x => x.conta, type: typeof(IntGraphType));
            Field(x => x.saldo, type: typeof(FloatGraphType));
        }
    }
}
