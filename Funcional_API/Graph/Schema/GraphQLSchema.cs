using Funcional_API.Graph.Mutation;
using Funcional_API.Graph.Query;
using Funcional_API.Graph.Subscription;
using Funcional_API.Interfaces;
using GraphQL;

namespace Funcional_API.Graph.Schema
{
    public class GraphQLSchema : GraphQL.Types.Schema
    {
        public GraphQLSchema(IDependencyResolver resolver) : base(resolver)
        {
            var fieldService = resolver.Resolve<IFieldService>();
            fieldService.RegisterFields();
            Mutation = resolver.Resolve<MainMutation>();
            Query = resolver.Resolve<MainQuery>();
            Subscription = resolver.Resolve<MainSubscription>();
        }
    }
}
