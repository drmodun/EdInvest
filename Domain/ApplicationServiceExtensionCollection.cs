using Data.Entities;
using Shared.Models;
using Shared.Models.Items;
using Shared.Models.Users;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Category;
using Shared.Contracts.Requests.Investments;
using Shared.Contracts.Requests.Items.Application;
using Shared.Contracts.Requests.Items.Course;
using Shared.Contracts.Requests.Items.Event;
using Shared.Contracts.Requests.Items.Item;
using Shared.Contracts.Requests.Items.OnlineCourse;
using Shared.Contracts.Requests.Subcategory;
using Shared.Contracts.Requests.Users.Investor;
using Shared.Contracts.Requests.Users.organisation;
using Shared.Contracts.Requests.Users.Organisation;
using Shared.Contracts.Requests.Users.Student;
using Shared.Contracts.Requests.Users.User;
using Shared.Contracts.Responses.Category;
using Shared.Contracts.Responses.Investments;
using Shared.Contracts.Responses.Items.Application;
using Shared.Contracts.Responses.Items.Course;
using Shared.Contracts.Responses.Items.Event;
using Shared.Contracts.Responses.Items.Item;
using Shared.Contracts.Responses.Items.OnlineCourse;
using Shared.Contracts.Responses.Subcategory;
using Shared.Contracts.Responses.Users.Investor;
using Shared.Contracts.Responses.Users.Organisation;
using Shared.Contracts.Responses.Users.User;
using Domain.Helpers;
using Domain.Mappers;
using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Domain.Validation;
using Shared.Helpers;
using Microsoft.Extensions.Configuration;
using Shared.Helpers;

namespace Domain
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddDbContext<EdInvestContext>(options => options.UseNpgsql(ConfigurationHelper.GetConfiguration().GetConnectionString("Database")));
            services.AddScoped<BaseService<Category, CategoryMapper, CategoryRepo, WriteRepo<Category, Guid>,
                CreateCategoryRequest, UpdateCategoryRequest, GetCategoryRequest, 
                GetAllCategoriesRequest, Guid, GetCategoryResponse,
                GetAllCategoriesResponse, CategoryValidation
                >>();
            services.AddScoped<BaseService<Subcategory, SubcategoryMapper, SubcategoryRepo, WriteRepo<Subcategory, Guid>,
                CreateSubcategoryRequest, UpdateSubcategoryRequest, GetSubcategoryRequest, 
                GetAllSubcategoriesRequest, Guid, GetSubcategoryResponse,
                GetAllSubcategoriesReponse, SubcategoryValidation
                >>();
            services.AddScoped<BaseService<Application, ApplicationMapper, ItemRepo<Application, GetApplicationRequest, GetAllApplicationsRequest>, WriteRepo<Application, Guid>,
                CreateApplicationRequest, UpdateApplicationRequest, GetApplicationRequest, 
                GetAllApplicationsRequest, Guid, GetaApplicationResponse,
                GetAllApplicationsResponse,ApplicationValidation
                >>(); 
            services.AddScoped<BaseService<Event, EventMapper, ItemRepo<Event, GetEventRequest, GetAllEventsRequest>, WriteRepo<Event, Guid>,
                CreateEventRequest, UpdateEventRequest, GetEventRequest, 
                GetAllEventsRequest, Guid, GetEventResponse,
                GetAllEventsResponse, EventValidation
            >>();
             services.AddScoped<BaseService<Item, ItemMapper, ItemRepo<Item, GetItemRequest, GetAllItemsRequest>, WriteRepo<Item, Guid>,
                CreateItemRequest, UpdateItemRequest, GetItemRequest, 
                GetAllItemsRequest, Guid, GetItemResponse,
                GetAllItemsResponse, ItemValidation<Item>
                >>();

            
           services.AddScoped<BaseService<OnlineCourse, OnlineCourseMapper, ItemRepo<OnlineCourse, GetOnlineCourseRequest, GetAllOnlineCoursesRequest>, WriteRepo<OnlineCourse, Guid>,
                CreateOnlineCourseRequest, UpdateOnlineCourseRequest, 
                GetOnlineCourseRequest, GetAllOnlineCoursesRequest, Guid, GetOnlineCourseResponse,
                GetAllOnlineCoursesReponse, OnlineCourseValidation
                >>();
            services.AddScoped<BaseService<Course, CourseMapper, ItemRepo<Course, GetCourseRequest, GetAllCoursesRequest>, WriteRepo<Course, Guid>,
                CreateCourseRequest, UpdateCourseRequest, GetCourseRequest, 
                GetAllCoursesRequest, Guid, GetCourseResponse,
                GetAllCoursesResponse, CourseValidation
                >>();
             services.AddScoped<BaseService<Investor, InvestorMapper, UserRepo<Investor, GetInvestorRequest, GetAllInvestorsRequest>, WriteRepo<Investor, Guid>,
                CreateInvestorRequest, UpdateInvestorRequest, GetInvestorRequest, 
                GetAllInvestorsRequest, Guid, GetInvestorResponse,
                GetAllInvestorsResponse, InvestorValidation
                >>();
            services.AddScoped<BaseService<Organisation, OrganisationMapper, UserRepo<Organisation, GetOrganisationRequest, GetAllOrganisationsRequest>, WriteRepo<Organisation, Guid>,
                CreateOrganisationRequest, UpdateOrganisationRequest, 
                GetOrganisationRequest, GetAllOrganisationsRequest, Guid, GetOrganisationResponse,
                GetAllOrganisationsResponse, OrganisationValidation
                >>();
             services.AddScoped<BaseService<User, UserMapper, UserRepo<User, GetUserRequest, GetAllUsersRequest>, WriteRepo<User, Guid>,
                CreateUserRequest, UpdateUserRequest, GetUserRequest, 
                GetAllUsersRequest, Guid, GetUserResponse,
                GetAllUsersResponse, UserValidation<User>
                >>();
            services.AddScoped<BaseService<Investments, InvestmentMapper, InvestmentRepo, WriteRepo<Investments, N_NKey>, 
                CreateInvestmentRequest, UpdateInvestmentRequest, GetInvestmentRequest, 
                GetAllInvestmentsRequest, N_NKey, GetInvestmentResponse, 
                GetAllInvestmentsResponse,InvestmentsValidation>>();
            services.AddScoped<CountryService>();
             
            services.AddScoped<ApplicationValidation>();
            services.AddScoped<CategoryValidation>();
            services.AddScoped<CourseValidation>();
            services.AddScoped<EventValidation>();
            services.AddScoped<CategoryValidation>();
            services.AddScoped<InvestmentsValidation>();
            services.AddScoped<ItemValidation<Item>>();
            services.AddScoped<OnlineCourseValidation>();
            services.AddScoped<OrganisationValidation>();
            services.AddScoped<SubcategoryValidation>();
            services.AddScoped<UserValidation<User>>();
            services.AddScoped<InvestorValidation>();


            services.AddScoped<UserRepo<User, GetUserRequest, GetAllUsersRequest>>();
            services.AddScoped<WriteRepo<User, Guid>>();
            services.AddScoped<UserMapper>();
            services.AddScoped<ItemRepo<Item,GetItemRequest, GetAllItemsRequest>>();
            services.AddScoped<WriteRepo<Item, Guid>>();
            services.AddScoped<ItemMapper>();
            services.AddScoped<UserRepo<Organisation, GetOrganisationRequest, GetAllOrganisationsRequest>>();
            services.AddScoped<WriteRepo<Organisation, Guid>>();
            services.AddScoped<OrganisationMapper>();
            services.AddScoped<UserRepo<Investor, GetInvestorRequest, GetAllInvestorsRequest>>();
            services.AddScoped<WriteRepo<Investor, Guid>>();
            services.AddScoped<InvestorMapper>();
            services.AddScoped<ItemRepo<OnlineCourse, GetOnlineCourseRequest, GetAllOnlineCoursesRequest>>();
            services.AddScoped<WriteRepo<OnlineCourse, Guid>>();
            services.AddScoped<OnlineCourseMapper>();
            services.AddScoped<ItemRepo<Course,GetCourseRequest, GetAllCoursesRequest>>();
            services.AddScoped<WriteRepo<Course, Guid>>();
            services.AddScoped<CourseMapper>();
            services.AddScoped<ItemRepo<Event, GetEventRequest, GetAllEventsRequest>>();
            services.AddScoped<WriteRepo<Event, Guid>>();
            services.AddScoped<EventMapper>();
            services.AddScoped<ItemRepo<Application, GetApplicationRequest, GetAllApplicationsRequest>>();
            services.AddScoped<WriteRepo<Application, Guid>>();
            services.AddScoped<ApplicationMapper>();
            services.AddScoped<InvestmentRepo>();
            services.AddScoped<InvestmentMapper>();
            services.AddScoped<WriteRepo<Investments, N_NKey>>();
            services.AddScoped<CategoryRepo>();
            services.AddScoped<CategoryMapper>();
            services.AddScoped<WriteRepo<Category, Guid>>();
            services.AddScoped<SubcategoryRepo>();
            services.AddScoped<SubcategoryMapper>();
            services.AddScoped<WriteRepo<Subcategory, Guid>>();
            services.AddScoped<ICountryRepo, CountryRepo>();

            return services;
            
            //I experimented with generics, sorry if the code is too messy
            //try to see if there is a good way to store theese
        }


        }
}