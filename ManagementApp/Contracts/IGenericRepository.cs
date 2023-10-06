﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace ManagementApp.Contracts
    {
        public interface IGenericRepository<T> where T : class
        {
            Task<T> Get (int id);
            Task<IReadOnlyList<T>> GetAll();
            Task<T> Create (T entity);
            Task<T> Add(T entity);
            Task Update (T entity);
            Task Delete (T entity);

            //Validation
            Task<bool> RequestExists(int id);
    }
    }
