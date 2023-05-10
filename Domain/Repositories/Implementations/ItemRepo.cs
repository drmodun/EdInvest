﻿using Data.Entities;
using Data.Entities.Models;
using Data.Entities.Models.Items;
using Data.Enums;
using Domain.Contracts.Requests.Items.Item;
using Domain.Contracts.Responses.Items.Item;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Implementations
{
    public class ItemRepo
    {
        private readonly EdInvestContext _context;

        public ItemRepo(EdInvestContext context)
        {
            _context = context;
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
            var applications = await list.OfType<Application>().ToListAsync();
            var courses = await list.OfType<Course>().ToListAsync();
            var onlineCourses = await list.OfType<OnlineCourse>().ToListAsync();
            var events = await list.OfType<Event>().ToListAsync();
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
