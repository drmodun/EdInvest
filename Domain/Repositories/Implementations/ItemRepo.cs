using Data.Entities;
using Data.Entities.Models;
using Data.Entities.Models.Items;
using Data.Enums;
using Domain.Contracts.Requests.Items.Item;
using Domain.Contracts.Responses.Items.Item;
using Domain.Mappers;
using Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Implementations 
{
    public class ItemRepo : IReadRepo<Item, Guid, GetAllItemsRequest, GetAllItemsResponse>, IItemRepo
    {
        private readonly EdInvestContext _context;
        private readonly ApplicationMapper _applicationMapper;
        private readonly CourseMapper _courseMapper;
        private readonly OnlineCourseMapper _onlineCourseMapper;
        private readonly EventMapper _eventMapper;

        public ItemRepo(EdInvestContext edInvest, ApplicationMapper applicationMapper,
            OnlineCourseMapper onlineCourseMapper, EventMapper eventMapper, CourseMapper courseMapper)
        {
            _context = edInvest;
            _applicationMapper = applicationMapper;
            _courseMapper = courseMapper;
            _onlineCourseMapper = onlineCourseMapper;
            _eventMapper = eventMapper;
        }
        

        public async Task<Item?> GetById(Guid id)
        {
            var item = await _context.Items
                .Include(x => x.Investments)
                .FirstOrDefaultAsync(x=>x.Id==id);
            switch (item.Type) {
                case ItemType.Application:
                    return item as Application;
                case ItemType.Event:
                    return item as Event;
                case ItemType.Course:
                    return item as Course;
                case ItemType.OnlineCourse:
                    return item as OnlineCourse;
                default : return null;
            }
        }
        public async Task<GetAllItemsResponse> GetAll(GetAllItemsRequest options)
        {
            var list = _context.Items
                .Include(x => x.Investments)
                .Where(x => x.Type == options.ItemType || options.ItemType == null)
                .Where(x => x.Name.Contains(options.Name) || options.Name == null)
                .Where(x => x.CategoryId == options.CategoryId || options.CategoryId == null)
                .Where(x => x.SubcategoryId == options.SubcategoryId || options.SubcategoryId == null)
                .Where(x => x.OrganisationId == options.OrganisationId || options.OrganisationId == null);
            var applications = list.OfType<Application>().Select(_applicationMapper.ToDTO).ToList();
            var courses = list.OfType<Course>().Select(_courseMapper.ToDTO).ToList();
            var onlineCourses =list.OfType<OnlineCourse>().Select(_onlineCourseMapper.ToDTO).ToList();
            var events = list.OfType<Event>().Select(_eventMapper.ToDTO).ToList();
            return new GetAllItemsResponse()
            {
                Applications = applications,
                OnlineCourses = onlineCourses,
                Events = events,
                Courses = courses,
            };

        }
    }
}
