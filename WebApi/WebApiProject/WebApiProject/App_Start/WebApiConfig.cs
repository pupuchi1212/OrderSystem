using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using WebApiProject.Models;
using WebApiProject.Services.Order;
using WebApiProject.Services.Product;

namespace WebApiProject
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            // 註冊 Web API 控制器
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // 註冊 DbContext
            builder.RegisterType<OrderDbContext>()
                   .InstancePerRequest();

            // 註冊 Service 及 Interface
            builder.RegisterType<ProductService>()
                   .As<IProductService>()
                   .InstancePerRequest();

            builder.RegisterType<OrderService>()
                   .As<IOrderService>()
                   .InstancePerRequest();

            // 建立 Autofac 容器
            var container = builder.Build();

            // 設定 Web API 使用 Autofac
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
