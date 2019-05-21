using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using IdentityServer4;//http://docs.identityserver.io/en/latest/quickstarts/1_client_credentials.html#setting-up-the-asp-net-core-application?tdsourcetag=s_pcqq_aiomsg

namespace IdentityServerCenter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //配置IdentityServer,包括把Api资源，Client集合，密钥保存在内存
            services.AddIdentityServer()
                .AddDeveloperSigningCredential() //是一种RSA证书加密方式，它会生成一个tempkey.rsa证书文件,项目每次启动时，会检查项目根目录是否存在该证书文件，若不存在，则会生成该文件，否则会继续使用该证书文件。
                .AddInMemoryApiResources(Config.GetResources()) //从Config类里面读取刚刚定义的API资源到内存
                .AddInMemoryClients(Config.GetClients())//从Config类里面读取刚刚定义的Client集合到内存
                .AddTestUsers(Config.GetUsers());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            //app.UseMvc();
            app.UseIdentityServer();
        }
    }
}
