using Domain.Contracts.Responses.Items.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Responses.Items.Application
{
    public class UpdateApplicaionResponse : UpdateItemResponse
    {
        public GetaApplicationResponse Application { get; set; }
    }
}
