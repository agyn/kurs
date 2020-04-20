using Autofac;
using System.Reflection;

namespace Kurs.Identity.Api.Startups
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            const string assemblyBranch = "Identity";

            var assembly = Assembly.Load(new AssemblyName("Kurs.Shared.Data"));
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Repo"))
                .AsImplementedInterfaces();
            assembly = Assembly.Load(new AssemblyName("Kurs.Shared.Logic"));
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Logic"))
                .AsImplementedInterfaces();
            assembly = Assembly.Load(new AssemblyName($"Kurs.{assemblyBranch}.Data"));
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Repo"))
                .AsImplementedInterfaces();
            assembly = Assembly.Load(new AssemblyName($"Kurs.{assemblyBranch}.Logic"));
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Logic"))
                .AsImplementedInterfaces();
        }
    }
}