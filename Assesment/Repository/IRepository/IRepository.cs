using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq.Expressions;
using System.Xml.Serialization;

namespace Assesment.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();

        void Add(T entity);

        void Save();
    }
}
