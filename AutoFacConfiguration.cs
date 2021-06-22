using Autofac;
using AutoMapper;
using MemberProject.Common.Interfaces;
using MemberProject.Models;
using MemberProject.Repository.Members;
using MemberProject.Services.Members;
using MemberProject.UOW;

namespace MemberProject
{
    public class AutoFacConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            #region DbContext
            // Register Unit of work service
            builder.RegisterType<MemberdbContext>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).InstancePerLifetimeScope();

            // Register ResponseDTO
            builder.RegisterType<ResponseDTO>().As<IResponseDTO>().InstancePerLifetimeScope();
            #endregion

            #region Member

            builder.RegisterType<MemberRepository>().As<IMemberRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MemberService>().As<IMemberService>().InstancePerLifetimeScope();

            #endregion

            #region Profile
            builder.RegisterAssemblyTypes(typeof(AutoFacConfiguration).Assembly).As<Profile>();

            builder.Register(
                 c => new MapperConfiguration(cfg =>
                 {
                     cfg.AddProfile(new MappingProfile());
                 }))
                 .AsSelf()
                 .SingleInstance();

            builder.Register(
                c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();
            #endregion
        }
    }
}
