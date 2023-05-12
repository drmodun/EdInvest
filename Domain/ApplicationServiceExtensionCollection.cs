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

namespace Domain
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddDbContext<EdInvestContext>(options => options.UseNpgsql("Host=localhost;Database=EdInvestment;Username=postgres;Password=postgres;IncludeErrorDetail=True;"));
            services.AddScoped<BaseService<Category, CategoryMapper, CategoryRepo, WriteRepo<Category, Guid>,
                CreateCategoryRequest, UpdateCategoryRequest, GetCategoryRequest, 
                GetAllCategoriesRequest, Guid, GetCategoryResponse,
                GetAllCategoriesResponse, List<Category>
                >>();
            services.AddScoped<BaseService<Subcategory, SubcategoryMapper, SubcategoryRepo, WriteRepo<Subcategory, Guid>,
                CreateSubcategoryRequest, UpdateSubcategoryRequest, GetSubcategoryRequest, 
                GetAllSubcategoriesRequest, Guid, GetSubcategoryResponse,
                GetAllCategoriesResponse, List<Subcategory>
                >>();
            services.AddScoped<BaseService<Application, ApplicationMapper, ItemRepo<Application, GetAllApplicationsRequest>, WriteRepo<Application, Guid>,
                CreateApplicationRequest, UpdateApplicationRequest, GetApplicationRequest, 
                GetAllApplicationsRequest, Guid, GetaApplicationResponse,
                GetAllApplicationsResponse, List<Application>
                >>(); 
            services.AddScoped<BaseService<Event, EventMapper, ItemRepo<Event, GetAllEventsRequest>, WriteRepo<Event, Guid>,
                CreateEventRequest, UpdateEventRequest, GetEventRequest, 
                GetAllEventsRequest, Guid, GetEventResponse,
                GetAllEventsResponse, List<Event>
            >>();
             services.AddScoped<BaseService<Item, ItemMapper, ItemRepo<Item, GetAllItemsRequest>, WriteRepo<Item, Guid>,
                CreateItemRequest, UpdateItemRequest, GetItemRequest, 
                GetAllItemsRequest, Guid, GetItemResponse,
                GetAllItemsResponse, List<Item>
                >>();

            
           services.AddScoped<BaseService<OnlineCourse, OnlineCourseMapper, ItemRepo<OnlineCourse, GetAllOnlineCoursesRequest>, WriteRepo<OnlineCourse, Guid>,
                CreateOnlineCourseRequest, UpdateOnlineCourseRequest, 
                GetOnlineCourseRequest, GetAllOnlineCoursesRequest, Guid, GetOnlineCourseResponse,
                GetAllOnlineCoursesReponse, List<OnlineCourse>
                >>();
            services.AddScoped<BaseService<Course, CourseMapper, ItemRepo<Course, GetAllCoursesRequest>, WriteRepo<Course, Guid>,
                CreateCourseRequest, UpdateCourseRequest, GetCourseRequest, 
                GetAllCoursesRequest, Guid, GetCourseResponse,
                GetAllCoursesResponse, List<Course>
                >>();
             services.AddScoped<BaseService<Investor, InvestorMapper, UserRepo<Investor, GetAllInvestorsRequest>, WriteRepo<Investor, Guid>,
                CreateInvestorRequest, UpdateInvestorRequest, GetInvestorRequest, 
                GetAllInvestorsRequest, Guid, GetInvestorResponse,
                GetAllInvestorsResponse, List<Investor>
                >>();
            services.AddScoped<BaseService<Organisation, OrganisationMapper, UserRepo<Organisation, GetAllOrganisationsRequest>, WriteRepo<Organisation, Guid>,
                CreateOrganisationRequest, UpdateOrganisationRequest, 
                GetOrganisationRequest, GetAllOrganisationsRequest, Guid, GetOrganisationResponse,
                GetAllOrganisationsResponse, List<Organisation>
                >>();
             services.AddScoped<BaseService<User, UserMapper, UserRepo<User, GetAllUsersRequest>, WriteRepo<User, Guid>,
                CreateUserRequest, UpdateUserRequest, GetUserRequest, 
                GetAllUsersRequest, Guid, GetUserResponse,
                GetAllUsersResponse, List<User>
                >>();
            services.AddScoped<BaseService<Investments, InvestmentMapper, InvestmentRepo, WriteRepo<Investments, N_NKey>, 
                CreateInvestmentRequest, UpdateInvestmentRequest, GetInvestmentRequest, 
                GetAllInvestmentsRequest, N_NKey, GetInvestmentResponse, 
                GetAllInvestmentsResponse, List<Investments>>>();


            services.AddScoped<UserRepo<User, GetAllUsersRequest>>();
            services.AddScoped<WriteRepo<User, Guid>>();
            services.AddScoped<UserMapper>();
            services.AddScoped<ItemRepo<Item, GetAllItemsRequest>>();
            services.AddScoped<WriteRepo<Item, Guid>>();
            services.AddScoped<ItemMapper>();
            services.AddScoped<UserRepo<Organisation, GetAllOrganisationsRequest>>();
            services.AddScoped<WriteRepo<Organisation, Guid>>();
            services.AddScoped<OrganisationMapper>();
            services.AddScoped<UserRepo<Investor, GetAllInvestorsRequest>>();
            services.AddScoped<WriteRepo<Investor, Guid>>();
            services.AddScoped<InvestorMapper>();
            services.AddScoped<ItemRepo<OnlineCourse, GetAllOnlineCoursesRequest>>();
            services.AddScoped<WriteRepo<OnlineCourse, Guid>>();
            services.AddScoped<OnlineCourseMapper>();
            services.AddScoped<ItemRepo<Course, GetAllCoursesRequest>>();
            services.AddScoped<WriteRepo<Course, Guid>>();
            services.AddScoped<CourseMapper>();
            services.AddScoped<ItemRepo<Event, GetAllEventsRequest>>();
            services.AddScoped<WriteRepo<Event, Guid>>();
            services.AddScoped<EventMapper>();
            services.AddScoped<ItemRepo<Application, GetAllApplicationsRequest>>();
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


            return services;
            
            //I experimented with generics, sorry if the code is too messy
            //try to see if there is a good way to store theese
        }


        }
}