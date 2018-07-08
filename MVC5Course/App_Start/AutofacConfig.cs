using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using MVC5Course.Models;

namespace MVC5Course
{
    public class AutofacConfig
    {/// <summary>
        /// 註冊DI注入物件資料
        /// </summary>
        public static void Register()
        {
            // 容器建立者
            ContainerBuilder builder = new ContainerBuilder();

            // 註冊Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.Register<IUnitOfWork>(c => RepositoryHelper.GetUnitOfWork());
            builder.Register<IClientRepository>(c => RepositoryHelper.GetClientRepository(c.Resolve<IUnitOfWork>()));
            builder.Register<IOccupationRepository>(c => RepositoryHelper.GetOccupationRepository(c.Resolve<IUnitOfWork>()));
            builder.Register<IProductRepository>(c => RepositoryHelper.GetProductRepository(c.Resolve<IUnitOfWork>()));
            builder.Register<IOrderLineRepository>(c => RepositoryHelper.GetOrderLineRepository(c.Resolve<IUnitOfWork>()));

            // 建立容器
            IContainer container = builder.Build();

            //// 解析容器內的型別
            //AutofacWebApiDependencyResolver resolverApi = new AutofacWebApiDependencyResolver(container);
            AutofacDependencyResolver resolver = new AutofacDependencyResolver(container);

            //// 建立相依解析器
            //GlobalConfiguration.Configuration.DependencyResolver = resolverApi;
            DependencyResolver.SetResolver(resolver);
        }
    }
}