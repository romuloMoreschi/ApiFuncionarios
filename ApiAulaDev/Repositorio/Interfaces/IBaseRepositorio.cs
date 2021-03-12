using ApiAulaDev.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiAulaDev.Repositorio.Interfaces
{
    public interface IBaseRepositorio<T> where T : Base
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task Remove(int id);
        Task<T> Get(int id);
        Task<List<T>> Get();
        bool Exists(int id);
    }
}
