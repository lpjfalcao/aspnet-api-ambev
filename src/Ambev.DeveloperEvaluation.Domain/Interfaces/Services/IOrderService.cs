using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces.Services
{
    public interface IOrderService
    {        void ApplyDiscount(Order newOrder, Customer customer);
    }
}
