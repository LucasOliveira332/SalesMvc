using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesMvc.Data;
using System;
using SalesMvc.Models;

namespace SalesMvc.Models.Services
{
    public class SallerServices
    {
        public  List<Seller> FindAll(SalesMvcContext context)
        {
            return context.Sallers.ToList();
        }
    }
}
