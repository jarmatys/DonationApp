using DonationApp.Models.Db;
using DonationApp.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationApp.Services.Interfaces
{
    public interface IDonationService
    {
        Task<bool> Create(DonationModel donation);
        Task<DonationModel> Get(int id);
        Task<IList<DonationModel>> GetAll();
        Task<bool> Update(DonationModel donation);
        Task<bool> Delete(int id);
        Task<int> DonationCount();
        Task<int> DonatedInstitionsCount();
        
        // ZAPYTAĆ
        Task<DonationView> PrepareViewModel(DonationView result = null);
    }
}
