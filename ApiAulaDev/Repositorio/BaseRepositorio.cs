using System.Linq;
using ApiAulaDev.Data;
using ApiAulaDev.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ApiAulaDev.Repositorio.Interfaces;

namespace ApiAulaDev.Repositorio
{
    public class BaseRepositorio<T> : IBaseRepositorio<T> where T : Base
    {
        private readonly Context _context;

        public BaseRepositorio(Context context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }
        public virtual async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }
        public virtual async Task Remove(int id)
        {
            var obj = await Get(id);

            if(obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> Get(int id)
        {
            var obj = await _context.Set<T>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToListAsync();

            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }
        public virtual bool Exists(int id)
        {
            return _context.Set<T>().Any(e => e.Id == id);
        }
    }
}
