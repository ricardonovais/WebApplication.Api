using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Api.Context;
using WebApplication.Api.Models;

namespace WebApplication.Api.Services
{
    public class ClienteService
    {
        private readonly AppDbContext _dbContext;
        public ClienteService(AppDbContext ctx)
        {
            _dbContext = ctx;
        }

        public async Task<IList<Cliente>> Get()
        {
            try
            {
                return await _dbContext.Clientes.AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> Get(int id)
        {
            try
            {
                return await _dbContext.Clientes.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task Add(Cliente cliente)
        {
            try
            {
                await _dbContext.Clientes.AddAsync(cliente);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(Cliente cliente)
        {
            try
            {
                _dbContext.Entry(cliente).State = EntityState.Modified;                 
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var cliente = _dbContext.Clientes.FirstOrDefault(x => x.Id == id);

                if (cliente != null)
                {
                    _dbContext.Clientes.Remove(cliente);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
