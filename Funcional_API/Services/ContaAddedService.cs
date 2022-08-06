using Funcional_API.Dto;
using System.Reactive.Subjects;

namespace Funcional_API.Services
{
    public class ContaAddedService
    {
        private readonly ISubject<ContaAddedMensage> _messageStream = new ReplaySubject<ContaAddedMensage>(1);
        public ContaAddedMensage AddContaAddedMessage(ContaAddedMensage message)
        {
            _messageStream.OnNext(message);
            return message;
        }
    }
}
