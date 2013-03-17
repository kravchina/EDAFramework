using System.Collections.Generic;

namespace EDAF.Web.Base
{
    public interface IRepository<T, TQuery, TId> where T : class
    {
        ICollection<T> Query(TQuery query);
        T Get(TId id);
    }
}