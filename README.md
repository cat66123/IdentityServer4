# IdentityServer4

## 链接

[IdentityServer4 官网文档](http://docs.identityserver.io/en/latest/quickstarts/1_client_credentials.html#setting-up-the-asp-net-core-application?tdsourcetag=s_pcqq_aiomsg)

[link](http://localhost:5000/.well-known/openid-configuration)

## 运行

###### 先开启 IdentityServerCenter,再开启 Api，最后开启 TP 自动运行

###### post http://localhost:5000/connect/token

###### client_id catClient

###### client_secret catSecret

###### grant_type client_credentials

###### get http://localhost:5002/api/values

###### Authorization Bearer token

## 版本

#### v0.0.1

###### 通过第三方程序向 Server 获取 token，再访问 API 获取数据

#### v0.0.2

###### 通过第三方程序向 Server 获取 token，再访问 API 获取数据.多个 API 的处理

#### v0.0.3

#### 更改客户端模式为密码模式
