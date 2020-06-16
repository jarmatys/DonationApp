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
    public class CategoryService : ICategoryService
    {
		private readonly DonationContext _context;

		public CategoryService(DonationContext context)
		{
			_context = context;
		}

		public async Task<bool> Create(CategoryModel category)
		{
			_context.Categories.Add(category);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<CategoryModel> Get(int id)
		{
			return await _context.Categories.SingleOrDefaultAsync(b => b.Id == id);
		}

		public async Task<IList<CategoryModel>> GetAll()
		{
			return await _context.Categories.ToListAsync();
		}

		public async Task<bool> Update(CategoryModel category)
		{
			_context.Categories.Update(category);
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> Delete(int id)
		{
			var category = await _context.Categories.SingleOrDefaultAsync(b => b.Id == id);
			if (category == null)
				return false;

			_context.Categories.Remove(category);
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
