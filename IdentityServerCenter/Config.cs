using System;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace IdentityServerCenter
{
    public class Config
    {
        //Scope定义，定义我们要包含的Api资源
        public static IEnumerable<ApiResource> GetResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api","My Api"),//资源名称，资源显示名称
                new ApiResource("catApi","Cat Api")
            };
        }

        //客户端注册，定义客户端允许访问的Api资源
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client()
                {
                    ClientId = "client",//唯一标识
                    AllowedGrantTypes = GrantTypes.ClientCredentials,//授权模式为客户端模式
                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    },//指定clientSecret
                    AllowedScopes = {"api"}//允许访问的Api资源
                },
                new Client()
                {
                    ClientId = "catClient",//唯一标识
                    AllowedGrantTypes = GrantTypes.ClientCredentials,//授权模式为客户端模式
                    ClientSecrets = {
                        new Secret("catSecret".Sha256())
                    },//指定clientSecret
                    AllowedScopes = {"catApi"}//允许访问的Api资源
                }
            };
        }
    }
}
