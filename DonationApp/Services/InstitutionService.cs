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
    public class InstitutionService : IInstitutionService
    {
		private readonly DonationContext _context;

		public InstitutionService(DonationContext context)
		{
			_context = context;
		}

		public async Task<bool> Create(InstitutionModel institution)
		{
			_context.Instituties.Add(institution);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<InstitutionModel> Get(int id)
		{
			return await _context.Instituties.SingleOrDefaultAsync(b => b.Id == id);
		}

		public async Task<IList<InstitutionModel>> GetAll()
		{
			return await _context.Instituties.ToListAsync();
		}

		public async Task<bool> Update(InstitutionModel institution)
		{
			_context.Instituties.Update(institution);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> Delete(int id)
		{
			var institution = await _context.Instituties.SingleOrDefaultAsync(b => b.Id == id);
			if (institution == null)
				return false;

			_context.Instituties.Remove(institution);
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
