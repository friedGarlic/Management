﻿using ManagementApp.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Persistence.Repositories
{
    public class GenericRepositories<T> : IGenericRepository<T> where T : class
    {
        private readonly ManagementdbContext _context;

        public GenericRepositories(ManagementdbContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Create(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> RequestExists(int id)
        {
            var foundId = await Get(id);

            return foundId != null;
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
