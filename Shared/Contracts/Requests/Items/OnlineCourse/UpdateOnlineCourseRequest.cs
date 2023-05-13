﻿using Shared.Contracts.Items.Item;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Requests.Items.OnlineCourse
{
    public class UpdateOnlineCourseRequest : UpdateItemRequest
    {
        public Dictionary<string, string> LinksToChannels { get; set; }
        public Dictionary<string, string> Lessons { get; set; }
        public List<DateTime> LessonsDate { get; set; }
        public int AvarageDuration { get; set; }
        public ItemType Type = ItemType.OnlineCourse;

        public int ExpectedAudience { get; set; }

    }
}
