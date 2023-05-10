using Data.Entities;
using Data.Entities.Models;
using Data.Entities.Models.Items;
using Data.Entities.Models.Users;
using Domain.Contracts.Items.Item;
using Domain.Contracts.Requests.Category;
using Domain.Contracts.Requests.Items.Application;
using Domain.Contracts.Requests.Items.Course;
using Domain.Contracts.Requests.Items.Event;
using Domain.Contracts.Requests.Items.Item;
using Domain.Contracts.Requests.Items.OnlineCourse;
using Domain.Contracts.Requests.Subcategory;
using Domain.Contracts.Requests.Users.Investor;
using Domain.Contracts.Requests.Users.organisation;
using Domain.Contracts.Requests.Users.Organisation;
using Domain.Contracts.Requests.Users.Student;
using Domain.Contracts.Requests.Users.User;
using Domain.Contracts.Responses.Category;
using Domain.Contracts.Responses.Items.Application;
using Domain.Contracts.Responses.Items.Course;
using Domain.Contracts.Responses.Items.Event;
using Domain.Contracts.Responses.Items.Item;
using Domain.Contracts.Responses.Items.OnlineCourse;
using Domain.Contracts.Responses.Subcategory;
using Domain.Contracts.Responses.Users.Investor;
using Domain.Contracts.Responses.Users.Organisation;
using Domain.Contracts.Responses.Users.User;
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
                CreateCategoryRequest, UpdateCategoryRequest, GetCategoryRequest, GetAllCategoriesRequest, Guid, GetCategoryResponse,
                GetAllCategoriesResponse, List<Category>
                >>();
            services.AddScoped<BaseService<Subcategory, SubcategoryMapper, SubcategoryRepo, WriteRepo<Subcategory, Guid>,
                CreateSubcategoryRequest, UpdateSubcategoryRequest, GetSubcategoryRequest, GetAllSubcategoriesRequest, Guid, GetSubcategoryResponse,
                GetAllCategoriesResponse, List<Subcategory>
                >>();
            services.AddScoped<BaseService<Application, ApplicationMapper, ItemRepo<Application, GetAllApplicationsRequest>, WriteRepo<Application, Guid>,
                CreateApplicationRequest, UpdateApplicationRequest, GetApplicationRequest, GetAllApplicationsRequest, Guid, GetaApplicationResponse,
                GetAllCategoriesResponse, List<Application>
                >>(); 
            services.AddScoped<BaseService<Event, EventMapper, ItemRepo<Event, GetAllEventsRequest>, WriteRepo<Event, Guid>,
                CreateEventRequest, UpdateEventRequest, GetEventRequest, GetAllEventsRequest, Guid, GetEventResponse,
                GetAlleventsResponse, List<Event>
            >>();
             services.AddScoped<BaseService<Item, ItemMapper, ItemRepo<Item, GetAllItemsRequest>, WriteRepo<Item, Guid>,
                CreateItemRequest, UpdateItemRequest, GetItemRequest, GetAllItemsRequest, Guid, GetItemResponse,
                GetAllItemsResponse, List<Item>
                >>();

            
           services.AddScoped<BaseService<OnlineCourse, OnlineCourseMapper, ItemRepo<OnlineCourse, GetAllOnlineCoursesRequest>, WriteRepo<OnlineCourse, Guid>,
                CreateOnlineCourseRequest, UpdateOnlineCourseRequest, GetOnlineCourseRequest, GetAllOnlineCoursesRequest, Guid, GetOnlineCourseResponse,
                GetAllOnlineCoursesReponse, List<OnlineCourse>
                >>();
            services.AddScoped<BaseService<Course, CourseMapper, ItemRepo<Course, GetAllCoursesRequest>, WriteRepo<Course, Guid>,
                CreateCourseRequest, UpdateCourseRequest, GetCourseRequest, GetAllCoursesRequest, Guid, GetCourseResponse,
                GetAllCoursesResponse, List<Course>
                >>();
             services.AddScoped<BaseService<Investor, InvestorMapper, UserRepo<Investor, GetAllInvestorsRequest>, WriteRepo<Investor, Guid>,
                CreateInvestorRequest, UpdateInvestorRequest, GetInvestorRequest, GetAllInvestorsRequest, Guid, GetInvestorResponse,
                GetAllInvestorResponse, List<Investor>
                >>();
            services.AddScoped<BaseService<Organisation, OrganisationMapper, UserRepo<Organisation, GetAllOrganisationsRequest>, WriteRepo<Organisation, Guid>,
                CreateOrganisationRequest, UpdateOrganisationRequest, GetOrganisationRequest, GetAllOrganisationsRequest, Guid, GetOrganisationResponse,
                GetAllOrganisationsResponse, List<Organisation>
                >>();
             services.AddScoped<BaseService<User, UserMapper, UserRepo<User, GetAllUsersRequest>, WriteRepo<User, Guid>,
                CreateUserRequest, UpdateUserRequest, GetUserRequest, GetAllUsersRequest, Guid, GetUserResponse,
                GetAllUsersResponse, List<User>
                >>();
            return services;
            
            //I experimented with generics, sorry if the code is too messy
            //add repos for base classes
        }


        }
}