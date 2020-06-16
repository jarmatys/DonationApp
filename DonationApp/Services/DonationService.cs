using DonationApp.Context;
using DonationApp.Models.Db;
using DonationApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonationApp.Services
{
    public class DonationService : IDonationService
    {
		private readonly DonationContext _context;

		public DonationService(DonationContext context)
		{
			_context = context;
		}

		public async Task<bool> Create(DonationModel donation)
		{
			_context.Donations.Add(donation);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<DonationModel> Get(int id)
		{
			return await _context.Donations.SingleOrDefaultAsync(b => b.Id == id);
		}

		public async Task<IList<DonationModel>> GetAll()
		{
			return await _context.Donations.ToListAsync();
		}

		public async Task<bool> Update(DonationModel donation)
		{
			_context.Donations.Update(donation);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> Delete(int id)
		{
			var donation = await _context.Donations.SingleOrDefaultAsync(b => b.Id == id);
			if (donation == null)
				return false;

			_context.Donations.Remove(donation);
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
