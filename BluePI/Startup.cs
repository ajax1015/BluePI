using BluePI.Model.ConfigModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using BluePI.AuthHelp;
using BluePI.ExceptionHelp;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BluePI.Model;
using System.Reflection;
using BluePI.Unit;
using System.Linq;
using BluePI.Repository;
using BluePI.Service;

namespace BluePI
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {


        /// <summary>
        /// 启动构造函数
        /// </summary>
        /// <param name="configuration"></param>
        ///<param name="env"></param>
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            BaseConfigModel.SetBaseConfig(Configuration, env.ContentRootPath, env.WebRootPath);
        }
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1.1.0",
                    Title = "Blue WebAPI",
                    Description = "框架集合",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Blue", Email = "878071627@qq.com" }
                });
                //添加注释服务
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var apiXmlPath = Path.Combine(basePath, "APIHelp.xml");
                var entityXmlPath = Path.Combine(basePath, "EntityHelp.xml");
                c.IncludeXmlComments(apiXmlPath, true);//控制器层注释（true表示显示控制器注释）
                c.IncludeXmlComments(entityXmlPath);

                //添加控制器注释
                //c.DocumentFilter<SwaggerDocTag>();

                //添加header验证信息
                //c.OperationFilter<SwaggerHeader>();
                var security = new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } }, };
                c.AddSecurityRequirement(security);//添加一个必须的全局安全信息，和AddSecurityDefinition方法指定的方案名称要一致，这里是Bearer。
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 参数结构: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                    Type = "apiKey"
                });
            });
            #endregion

            #region 认证
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    JwtAuthConfigModel jwtConfig = new JwtAuthConfigModel();
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = "BluePI",
                        ValidAudience = "zsg",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.JWTSecretKey)),

                        /***********************************TokenValidationParameters的参数默认值***********************************/
                        RequireSignedTokens = true,
                        // SaveSigninToken = false,
                        // ValidateActor = false,
                        // 将下面两个参数设置为false，可以不验证Issuer和Audience，但是不建议这样做。
                        ValidateAudience = false,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        // 是否要求Token的Claims中必须包含 Expires
                        RequireExpirationTime = true,
                        // 允许的服务器时间偏移量
                        // ClockSkew = TimeSpan.FromSeconds(300),
                        // 是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                        ValidateLifetime = true
                    };
                });
            #endregion
            /*
                        #region 授权
                        services.AddAuthorization(options =>
                        {

                            //基于角色组的策略
                            options.AddPolicy("RequireClient", policy => policy.RequireRole("Client").Build());
                            options.AddPolicy("RequireAdmin", policy => policy.RequireRole("Admin").Build());
                            options.AddPolicy("RequireAdminOrClient", policy => policy.RequireRole("Admin,Client").Build());
                            //基于用户名
                            //options.AddPolicy("RequireClaim", policy => policy.RequireUserName("张三"));                                                  
                            //基于ClaimType
                            //options.AddPolicy("RequireClaim", policy => policy.RequireClaim(ClaimTypes.Country,"中国"));
                            //自定义值
                            // options.AddPolicy("RequireClaim", policy => policy.RequireClaim("date","2017-09-02"));
                            //}).AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>{
                            //options.LoginPath = new PathString("/login");
                            //options.AccessDeniedPath = new PathString("/denied");
                            //});


                        });
                        #endregion
             */
            #region CORS 自定义的跨域策略           
            var url = Configuration.GetSection("applicationUrl").Value.Split(',');
            services.AddCors(c =>
            {
                c.AddPolicy("Any", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });

                c.AddPolicy("Limit", policy =>
                {
                    policy
                    .WithOrigins(url)  //读取配置文件用逗号分隔的url,指定这些url是可以访问控制器方法的
                    .WithMethods("get", "post", "put", "delete")
                    //.WithHeaders("Authorization");
                    .AllowAnyHeader();
                });
            });
            #endregion
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";//设置时间格式
            });
            #region autofac依赖注入
            var builder = new ContainerBuilder();//实例化AutoFac容器  
            builder.Populate(services);
            /*注册程序集下所有类型
            var assembly = Assembly.GetExecutingAssembly();
            var assembly = this.GetType().GetTypeInfo().Assembly;*/
            builder.RegisterAssemblyTypes(typeof(SystemRepository).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(SystemService).Assembly)
            .Where(t => t.Name.EndsWith("Service"))
            .AsImplementedInterfaces();

            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer); //第三方IOC接管 core内置DI容器  
            #endregion
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseHsts();
            //} 
            app.UseMiddleware<ExceptionFilter>();//自定义异常处理

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });
            #endregion

            //认证
            app.UseAuthentication();

            //使用中间件授权，需要在ajax 请求Headers参数中加入token码
            app.UseMiddleware<JwtAuthorizationFilter>();

            app.UseMvc();

            app.UseStaticFiles();//用于访问wwwroot下的文件 

        }
    }
}
