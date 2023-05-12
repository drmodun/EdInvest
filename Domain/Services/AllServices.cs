using Shared.Models;
using Shared.Models.Items;
using Shared.Models.Users;
using Shared.Contracts.Items.Item;
using Shared.Contracts.Requests.Category;
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
using Shared.Contracts.Responses.Items.Application;
using Shared.Contracts.Responses.Items.Course;
using Shared.Contracts.Responses.Items.Event;
using Shared.Contracts.Responses.Items.Item;
using Shared.Contracts.Responses.Items.OnlineCourse;
using Shared.Contracts.Responses.Subcategory;
using Shared.Contracts.Responses.Users.Investor;
using Shared.Contracts.Responses.Users.Organisation;
using Shared.Contracts.Responses.Users.User;
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
               GetAllEventsResponse, List<Event>
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
                GetAllInvestorsResponse, List<Investor>
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
