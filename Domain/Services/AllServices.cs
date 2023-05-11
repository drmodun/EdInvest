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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AllServices
    {
        public BaseService<Category, CategoryMapper, CategoryRepo, WriteRepo<Category, Guid>,
                CreateCategoryRequest, UpdateCategoryRequest, GetCategoryRequest, GetAllCategoriesRequest, Guid, GetCategoryResponse,
                GetAllCategoriesResponse, List<Category>
                > CategoryService;
        public BaseService<Subcategory, SubcategoryMapper, SubcategoryRepo, WriteRepo<Subcategory, Guid>,
             CreateSubcategoryRequest, UpdateSubcategoryRequest, GetSubcategoryRequest, GetAllSubcategoriesRequest, Guid, GetSubcategoryResponse,
             GetAllCategoriesResponse, List<Subcategory>
             > Subcategoryservice;
        public BaseService<Application, ApplicationMapper, ItemRepo<Application, GetAllApplicationsRequest>, WriteRepo<Application, Guid>,
               CreateApplicationRequest, UpdateApplicationRequest, GetApplicationRequest, GetAllApplicationsRequest, Guid, GetaApplicationResponse,
               GetAllApplicationsResponse, List<Application>
               > ApplicationService;
        public BaseService<Event, EventMapper, ItemRepo<Event, GetAllEventsRequest>, WriteRepo<Event, Guid>,
               CreateEventRequest, UpdateEventRequest, GetEventRequest, GetAllEventsRequest, Guid, GetEventResponse,
               GetAlleventsResponse, List<Event>
           > EventService;
        public BaseService<Item, ItemMapper, ItemRepo<Item, GetAllItemsRequest>, WriteRepo<Item, Guid>,
                CreateItemRequest, UpdateItemRequest, GetItemRequest, GetAllItemsRequest, Guid, GetItemResponse,
                GetAllItemsResponse, List<Item>
                > ItemService;


        public BaseService<OnlineCourse, OnlineCourseMapper, ItemRepo<OnlineCourse, GetAllOnlineCoursesRequest>, WriteRepo<OnlineCourse, Guid>,
                CreateOnlineCourseRequest, UpdateOnlineCourseRequest, GetOnlineCourseRequest, GetAllOnlineCoursesRequest, Guid, GetOnlineCourseResponse,
                GetAllOnlineCoursesReponse, List<OnlineCourse>
                > OnlineCourseService;

        public BaseService<Course, CourseMapper, ItemRepo<Course, GetAllCoursesRequest>, WriteRepo<Course, Guid>,
                CreateCourseRequest, UpdateCourseRequest, GetCourseRequest, GetAllCoursesRequest, Guid, GetCourseResponse,
                GetAllCoursesResponse, List<Course>
                > CourseService;
        public BaseService<Investor, InvestorMapper, UserRepo<Investor, GetAllInvestorsRequest>, WriteRepo<Investor, Guid>,
                CreateInvestorRequest, UpdateInvestorRequest, GetInvestorRequest, GetAllInvestorsRequest, Guid, GetInvestorResponse,
                GetAllInvestorResponse, List<Investor>
                > InvestorService;

        public BaseService<Organisation, OrganisationMapper, UserRepo<Organisation, GetAllOrganisationsRequest>, WriteRepo<Organisation, Guid>,
                CreateOrganisationRequest, UpdateOrganisationRequest, GetOrganisationRequest, GetAllOrganisationsRequest, Guid, GetOrganisationResponse,
                GetAllOrganisationsResponse, List<Organisation>
                > OrganisationService;
        public BaseService<User, UserMapper, UserRepo<User, GetAllUsersRequest>, WriteRepo<User, Guid>,
                CreateUserRequest, UpdateUserRequest, GetUserRequest, GetAllUsersRequest, Guid, GetUserResponse,
                GetAllUsersResponse, List<User>
                > UserService;
    }
}
