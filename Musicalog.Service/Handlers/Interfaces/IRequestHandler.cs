using System.Threading.Tasks;

namespace Musicalog.Service.Handlers.Interfaces
{
    public interface IRequestHandler<Tin, Tout>
        where Tin : class
        where Tout : class
    {
        Task<Tout> Handle(Tin request);
    }
}