using DonationApp.Models.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationApp.Services.Interfaces
{
    public interface IInstitutionService
    {
        Task<bool> Create(InstitutionModel institution);
        Task<InstitutionModel> Get(int id);
        Task<IList<InstitutionModel>> GetAll();
        Task<bool> Update(InstitutionModel institution);
        Task<bool> Delete(int id);
    }
}
