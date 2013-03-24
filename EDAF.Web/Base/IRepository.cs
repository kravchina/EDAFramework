using System.Collections.Generic;

namespace EDAF.Web.Base
{
    public interface IRepository<T, TQuery, TId>
    {
        IEnumerable<T> Query(TQuery query);
        T Get(TId id);
    }
}