using FinalProject.Application.Features.Orders.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Common.Models.WorkerService
{
    public class WorkerServiceNewOrderAddedDto
    {
        public OrderGetByIdDto Order { get; set; }
        public string AccessToken { get; set; }

        public WorkerServiceNewOrderAddedDto(OrderGetByIdDto order, string accessToken)
        {
            Order = order;

            AccessToken = accessToken;
        }
    }
}
