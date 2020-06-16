
using DonationApp.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationApp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> Create(CategoryModel category);
        Task<CategoryModel> Get(int id);
        Task<IList<CategoryModel>> GetAll();
        Task<bool> Update(CategoryModel category);
        Task<bool> Delete(int id);
    }
}
