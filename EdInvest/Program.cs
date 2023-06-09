using Api.Middleware;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Shared.Constants;
using System.Text;
namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            var config = builder.Configuration;
            builder.Services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                x.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            }
            );
            // Add services to the container.
            builder.Services.AddApplication();
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(config["Jwt:Key"]!)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    ValidateIssuer = true,
                    ValidateAudience = true
                };
            });
            builder.Services.AddAuthorization(x =>
            {
                x.AddPolicy(AuthConstants.AdminUserPolicyName,
                    p => p.RequireClaim(AuthConstants.AdminUserClaimName, "true"));
                x.AddPolicy(AuthConstants.TrustMemberPolicyName,
                p => p.RequireAssertion(c =>
                        c.User.HasClaim(m => m is { Type: AuthConstants.AdminUserClaimName, Value: "true" }) ||
                        c.User.HasClaim(m => m is { Type: AuthConstants.TrustedMemberClaimName, Value: "true" })));
            }); builder.Services.AddApplication();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<ValidationMappingMiddleware>();
            app.MapControllers();


            app.Run();
        }

    }
}
/*
 System.AggregateException
  HResult=0x80131500
  Message=Some services are not able to be constructed (Error while validating the service descriptor 'ServiceType: Domain.Services.BaseService`12[Shared.Models.Items.Application,Domain.Mappers.ApplicationMapper,Domain.Repositories.Implementations.ItemRepo`3[Shared.Models.Items.Application,Shared.Contracts.Requests.Items.Application.GetApplicationRequest,Shared.Contracts.Requests.Items.Application.GetAllApplicationsRequest],Domain.Repositories.Implementations.WriteRepo`2[Shared.Models.Items.Application,System.Guid],Shared.Contracts.Requests.Items.Application.CreateApplicationRequest,Shared.Contracts.Requests.Items.Application.UpdateApplicationRequest,Shared.Contracts.Requests.Items.Application.GetApplicationRequest,Shared.Contracts.Requests.Items.Application.GetAllApplicationsRequest,System.Guid,Shared.Contracts.Responses.Items.Application.GetaApplicationResponse,Shared.Contracts.Responses.Items.Application.GetAllApplicationsResponse,Domain.Validation.ApplicationValidation] Lifetime: Scoped ImplementationType: Domain.Services.BaseService`12[Shared.Models.Items.Application,Domain.Mappers.ApplicationMapper,Domain.Repositories.Implementations.ItemRepo`3[Shared.Models.Items.Application,Shared.Contracts.Requests.Items.Application.GetApplicationRequest,Shared.Contracts.Requests.Items.Application.GetAllApplicationsRequest],Domain.Repositories.Implementations.WriteRepo`2[Shared.Models.Items.Application,System.Guid],Shared.Contracts.Requests.Items.Application.CreateApplicationRequest,Shared.Contracts.Requests.Items.Application.UpdateApplicationRequest,Shared.Contracts.Requests.Items.Application.GetApplicationRequest,Shared.Contracts.Requests.Items.Application.GetAllApplicationsRequest,System.Guid,Shared.Contracts.Responses.Items.Application.GetaApplicationResponse,Shared.Contracts.Responses.Items.Application.GetAllApplicationsResponse,Domain.Validation.ApplicationValidation]': Unable to resolve service for type 'Domain.Repositories.Implementations.CountryRepo' while attempting to activate 'Domain.Validation.ApplicationValidation'.) (Error while validating the service descriptor 'ServiceType: Domain.Services.BaseService`12[Shared.Models.Items.Event,Domain.Mappers.EventMapper,Domain.Repositories.Implementations.ItemRepo`3[Shared.Models.Items.Event,Shared.Contracts.Requests.Items.Event.GetEventRequest,Shared.Contracts.Requests.Items.Event.GetAllEventsRequest],Domain.Repositories.Implementations.WriteRepo`2[Shared.Models.Items.Event,System.Guid],Shared.Contracts.Requests.Items.Event.CreateEventRequest,Shared.Contracts.Requests.Items.Event.UpdateEventRequest,Shared.Contracts.Requests.Items.Event.GetEventRequest,Shared.Contracts.Requests.Items.Event.GetAllEventsRequest,System.Guid,Shared.Contracts.Responses.Items.Event.GetEventResponse,Shared.Contracts.Responses.Items.Event.GetAllEventsResponse,Domain.Validation.EventValidation] Lifetime: Scoped ImplementationType: Domain.Services.BaseService`12[Shared.Models.Items.Event,Domain.Mappers.EventMapper,Domain.Repositories.Implementations.ItemRepo`3[Shared.Models.Items.Event,Shared.Contracts.Requests.Items.Event.GetEventRequest,Shared.Contracts.Requests.Items.Event.GetAllEventsRequest],Domain.Repositories.Implementations.WriteRepo`2[Shared.Models.Items.Event,System.Guid],Shared.Contracts.Requests.Items.Event.CreateEventRequest,Shared.Contracts.Requests.Items.Event.UpdateEventRequest,Shared.Contracts.Requests.Items.Event.GetEventRequest,Shared.Contracts.Requests.Items.Event.GetAllEventsRequest,System.Guid,Shared.Contracts.Responses.Items.Event.GetEventResponse,Shared.Contracts.Responses.Items.Event.GetAllEventsResponse,Domain.Validation.EventValidation]': Unable to resolve service for type 'Domain.Repositories.Implementations.CountryRepo' while attempting to activate 'Domain.Validation.EventValidation'.) (Error while validating the service descriptor 'ServiceType: Domain.Services.BaseService`12[Shared.Models.Items.OnlineCourse,Domain.Mappers.OnlineCourseMapper,Domain.Repositories.Implementations.ItemRepo`3[Shared.Models.Items.OnlineCourse,Shared.Contracts.Requests.Items.OnlineCourse.GetOnlineCourseRequest,Shared.Contracts.Requests.Items.OnlineCourse.GetAllOnlineCoursesRequest],Domain.Repositories.Implementations.WriteRepo`2[Shared.Models.Items.OnlineCourse,System.Guid],Shared.Contracts.Requests.Items.OnlineCourse.CreateOnlineCourseRequest,Shared.Contracts.Requests.Items.OnlineCourse.UpdateOnlineCourseRequest,Shared.Contracts.Requests.Items.OnlineCourse.GetOnlineCourseRequest,Shared.Contracts.Requests.Items.OnlineCourse.GetAllOnlineCoursesRequest,System.Guid,Shared.Contracts.Responses.Items.OnlineCourse.GetOnlineCourseResponse,Shared.Contracts.Responses.Items.OnlineCourse.GetAllOnlineCoursesReponse,Domain.Validation.OnlineCourseValidation] Lifetime: Scoped ImplementationType: Domain.Services.BaseService`12[Shared.Models.Items.OnlineCourse,Domain.Mappers.OnlineCourseMapper,Domain.Repositories.Implementations.ItemRepo`3[Shared.Models.Items.OnlineCourse,Shared.Contracts.Requests.Items.OnlineCourse.GetOnlineCourseRequest,Shared.Contracts.Requests.Items.OnlineCourse.GetAllOnlineCoursesRequest],Domain.Repositories.Implementations.WriteRepo`2[Shared.Models.Items.OnlineCourse,System.Guid],Shared.Contracts.Requests.Items.OnlineCourse.CreateOnlineCourseRequest,Shared.Contracts.Requests.Items.OnlineCourse.UpdateOnlineCourseRequest,Shared.Contracts.Requests.Items.OnlineCourse.GetOnlineCourseRequest,Shared.Contracts.Requests.Items.OnlineCourse.GetAllOnlineCoursesRequest,System.Guid,Shared.Contracts.Responses.Items.OnlineCourse.GetOnlineCourseResponse,Shared.Contracts.Responses.Items.OnlineCourse.GetAllOnlineCoursesReponse,Domain.Validation.OnlineCourseValidation]': Unable to resolve service for type 'Domain.Repositories.Implementations.CountryRepo' while attempting to activate 'Domain.Validation.OnlineCourseValidation'.) (Error while validating the service descriptor 'ServiceType: Domain.Services.BaseService`12[Shared.Models.Items.Course,Domain.Mappers.CourseMapper,Domain.Repositories.Implementations.ItemRepo`3[Shared.Models.Items.Course,Shared.Contracts.Requests.Items.Course.GetCourseRequest,Shared.Contracts.Requests.Items.Course.GetAllCoursesRequest],Domain.Repositories.Implementations.WriteRepo`2[Shared.Models.Items.Course,System.Guid],Shared.Contracts.Requests.Items.Course.CreateCourseRequest,Shared.Contracts.Requests.Items.Course.UpdateCourseRequest,Shared.Contracts.Requests.Items.Course.GetCourseRequest,Shared.Contracts.Requests.Items.Course.GetAllCoursesRequest,System.Guid,Shared.Contracts.Responses.Items.Course.GetCourseResponse,Shared.Contracts.Responses.Items.Course.GetAllCoursesResponse,Domain.Validation.CourseValidation] Lifetime: Scoped ImplementationType: Domain.Services.BaseService`12[Shared.Models.Items.Course,Domain.Mappers.CourseMapper,Domain.Repositories.Implementations.ItemRepo`3[Shared.Models.Items.Course,Shared.Contracts.Requests.Items.Course.GetCourseRequest,Shared.Contracts.Requests.Items.Course.GetAllCoursesRequest],Domain.Repositories.Implementations.WriteRepo`2[Shared.Models.Items.Course,System.Guid],Shared.Contracts.Requests.Items.Course.CreateCourseRequest,Shared.Contracts.Requests.Items.Course.UpdateCourseRequest,Shared.Contracts.Requests.Items.Course.GetCourseRequest,Shared.Contracts.Requests.Items.Course.GetAllCoursesRequest,System.Guid,Shared.Contracts.Responses.Items.Course.GetCourseResponse,Shared.Contracts.Responses.Items.Course.GetAllCoursesResponse,Domain.Validation.CourseValidation]': Unable to resolve service for type 'Domain.Repositories.Implementations.CountryRepo' while attempting to activate 'Domain.Validation.CourseValidation'.) (Error while validating the service descriptor 'ServiceType: Domain.Services.BaseService`12[Shared.Models.Users.Investor,Domain.Mappers.InvestorMapper,Domain.Repositories.Implementations.UserRepo`3[Shared.Models.Users.Investor,Shared.Contracts.Requests.Users.Investor.GetInvestorRequest,Shared.Contracts.Requests.Users.Investor.GetAllInvestorsRequest],Domain.Repositories.Implementations.WriteRepo`2[Shared.Models.Users.Investor,System.Guid],Shared.Contracts.Requests.Users.Investor.CreateInvestorRequest,Shared.Contracts.Requests.Users.Investor.UpdateInvestorRequest,Shared.Contracts.Requests.Users.Investor.GetInvestorRequest,Shared.Contracts.Requests.Users.Investor.GetAllInvestorsRequest,System.Guid,Shared.Contracts.Responses.Users.Investor.GetInvestorResponse,Shared.Contracts.Responses.Users.Investor.GetAllInvestorsResponse,Domain.Validation.InvestorValidation] Lifetime: Scoped ImplementationType: Domain.Services.BaseService`12[Shared.Models.Users.Investor,Domain.Mappers.InvestorMapper,Domain.Repositories.Implementations.UserRepo`3[Shared.Models.Users.Investor,Shared.Contracts.Requests.Users.Investor.GetInvestorRequest,Shared.Contracts.Requests.Users.Investor.GetAllInvestorsRequest],Domain.Repositories.Implementations.WriteRepo`2[Shared.Models.Users.Investor,System.Guid],Shared.Contracts.Requests.Users.Investor.CreateInvestorRequest,Shared.Contracts.Requests.Users.Investor.UpdateInvestorRequest,Shared.Contracts.Requests.Users.Investor.GetInvestorRequest,Shared.Contracts.Requests.Users.Investor.GetAllInvestorsRequest,System.Guid,Shared.Contracts.Responses.Users.Investor.GetInvestorResponse,Shared.Contracts.Responses.Users.Investor.GetAllInvestorsResponse,Domain.Validation.InvestorValidation]': Unable to resolve service for type 'Domain.Repositories.Implementations.CountryRepo' while attempting to activate 'Domain.Validation.InvestorValidation'.) (Error while validating the service descriptor 'ServiceType: Domain.Services.BaseService`12[Shared.Models.Users.Organisation,Domain.Mappers.OrganisationMapper,Domain.Repositories.Implementations.UserRepo`3[Shared.Models.Users.Organisation,Shared.Contracts.Requests.Users.Student.GetOrganisationRequest,Shared.Contracts.Requests.Users.Organisation.GetAllOrganisationsRequest],Domain.Repositories.Implementations.WriteRepo`2[Shared.Models.Users.Organisation,System.Guid],Shared.Contracts.Requests.Users.organisation.CreateOrganisationRequest,Shared.Contracts.Requests.Users.Investor.UpdateOrganisationRequest,Shared.Contracts.Requests.Users.Student.GetOrganisationRequest,Shared.Contracts.Requests.Users.Organisation.GetAllOrganisationsRequest,System.Guid,Shared.Contracts.Responses.Users.Organisation.GetOrganisationResponse,Shared.Contracts.Responses.Users.Organisation.GetAllOrganisationsResponse,Domain.Validation.OrganisationValidation] Lifetime: Scoped ImplementationType: Domain.Services.BaseService`12[Shared.Models.Users.Organisation,Domain.Mappers.OrganisationMapper,Domain.Repositories.Implementations.UserRepo`3[Shared.Models.Users.Organisation,Shared.Contracts.Requests.Users.Student.GetOrganisationRequest,Shared.Contracts.Requests.Users.Organisation.GetAllOrganisationsRequest],Domain.Repositories.Implementations.WriteRepo`2[Shared.Models.Users.Organisation,System.Guid],Shared.Contracts.Requests.Users.organisation.CreateOrganisationRequest,Shared.Contracts.Requests.Users.Investor.UpdateOrganisationRequest,Shared.Contracts.Requests.Users.Student.GetOrganisationRequest,Shared.Contracts.Requests.Users.Organisation.GetAllOrganisationsRequest,System.Guid,Shared.Contracts.Responses.Users.Organisation.GetOrganisationResponse,Shared.Contracts.Responses.Users.Organisation.GetAllOrganisationsResponse,Domain.Validation.OrganisationValidation]': Unable to resolve service for type 'Domain.Repositories.Implementations.CountryRepo' while attempting to activate 'Domain.Validation.OrganisationValidation'.) (Error while validating the service descriptor 'ServiceType: Domain.Validation.ApplicationValidation Lifetime: Scoped ImplementationType: Domain.Validation.ApplicationValidation': Unable to resolve service for type 'Domain.Repositories.Implementations.CountryRepo' while attempting to activate 'Domain.Validation.ApplicationValidation'.) (Error while validating the service descriptor 'ServiceType: Domain.Validation.CourseValidation Lifetime: Scoped ImplementationType: Domain.Validation.CourseValidation': Unable to resolve service for type 'Domain.Repositories.Implementations.CountryRepo' while attempting to activate 'Domain.Validation.CourseValidation'.) (Error while validating the service descriptor 'ServiceType: Domain.Validation.EventValidation Lifetime: Scoped ImplementationType: Domain.Validation.EventValidation': Unable to resolve service for type 'Domain.Repositories.Implementations.CountryRepo' while attempting to activate 'Domain.Validation.EventValidation'.) (Error while validating the service descriptor 'ServiceType: Domain.Validation.OnlineCourseValidation Lifetime: Scoped ImplementationType: Domain.Validation.OnlineCourseValidation': Unable to resolve service for type 'Domain.Repositories.Implementations.CountryRepo' while attempting to activate 'Domain.Validation.OnlineCourseValidation'.) (Error while validating the service descriptor 'ServiceType: Domain.Validation.OrganisationValidation Lifetime: Scoped ImplementationType: Domain.Validation.OrganisationValidation': Unable to resolve service for type 'Domain.Repositories.Implementations.CountryRepo' while attempting to activate 'Domain.Validation.OrganisationValidation'.) (Error while validating the service descriptor 'ServiceType: Domain.Validation.InvestorValidation Lifetime: Scoped ImplementationType: Domain.Validation.InvestorValidation': Unable to resolve service for type 'Domain.Repositories.Implementations.CountryRepo' while attempting to activate 'Domain.Validation.InvestorValidation'.)
  Source=Microsoft.Extensions.DependencyInjection
  StackTrace:
   at Microsoft.Extensions.DependencyInjection.ServiceProvider..ctor(ICollection`1 serviceDescriptors, ServiceProviderOptions options)
   at Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(IServiceCollection services, ServiceProviderOptions options)
   at Microsoft.Extensions.Hosting.HostApplicationBuilder.Build()
   at Microsoft.AspNetCore.Builder.WebApplicationBuilder.Build()
   at Presentation.Program.Main(String[] args) in C:\Users\Korisnik\source\repos\EdInvest\EdInvest\Program.cs:line 19

  This exception was originally thrown at this call stack:
    [External Code]

Inner Exception 1:
InvalidOperationException: Error while validating the service descriptor 'ServiceType: Domain.Services.BaseService`12[Shared.Models.Items.Application,Domain.Mappers.ApplicationMapper,Domain.Repositories.Implementations.ItemRepo`3[Shared.Models.Items.Application,Shared.Contracts.Requests.Items.Application.GetApplicationRequest,Shared.Contracts.Requests.Items.Application.GetAllApplicationsRequest],Domain.Repositories.Implementations.WriteRepo`2[Shared.Models.Items.Application,System.Guid],Shared.Contracts.Requests.Items.Application.CreateApplicationRequest,Shared.Contracts.Requests.Items.Application.UpdateApplicationRequest,Shared.Contracts.Requests.Items.Application.GetApplicationRequest,Shared.Contracts.Requests.Items.Application.GetAllApplicationsRequest,System.Guid,Shared.Contracts.Responses.Items.Application.GetaApplicationResponse,Shared.Contracts.Responses.Items.Application.GetAllApplicationsResponse,Domain.Validation.ApplicationValidation] Lifetime: Scoped ImplementationType: Domain.Services.BaseService`12[Shared.Models.Items.Application,Domain.Mappers.ApplicationMapper,Domain.Repositories.Implementations.ItemRepo`3[Shared.Models.Items.Application,Shared.Contracts.Requests.Items.Application.GetApplicationRequest,Shared.Contracts.Requests.Items.Application.GetAllApplicationsRequest],Domain.Repositories.Implementations.WriteRepo`2[Shared.Models.Items.Application,System.Guid],Shared.Contracts.Requests.Items.Application.CreateApplicationRequest,Shared.Contracts.Requests.Items.Application.UpdateApplicationRequest,Shared.Contracts.Requests.Items.Application.GetApplicationRequest,Shared.Contracts.Requests.Items.Application.GetAllApplicationsRequest,System.Guid,Shared.Contracts.Responses.Items.Application.GetaApplicationResponse,Shared.Contracts.Responses.Items.Application.GetAllApplicationsResponse,Domain.Validation.ApplicationValidation]': Unable to resolve service for type 'Domain.Repositories.Implementations.CountryRepo' while attempting to activate 'Domain.Validation.ApplicationValidation'.

Inner Exception 2:
InvalidOperationException: Unable to resolve service for type 'Domain.Repositories.Implementations.CountryRepo' while attempting to activate 'Domain.Validation.ApplicationValidation'.

 */