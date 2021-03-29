using MediatR;
using Ninject;
using Ninject.Modules;
using Ninject.Planning.Bindings.Resolvers;

namespace MediatR.Ninject
{
    public class MediatRModule : NinjectModule
    {
        public override void Load()
        {
            Kernel?.Components.Add<IBindingResolver, ContravariantBindingResolver>();

            Kernel?.Bind<IMediator>().To<Mediator>();
            Kernel?.Bind<ServiceFactory>().ToMethod(ctx => t => ctx.Kernel.TryGet(t));
        }
    }
}