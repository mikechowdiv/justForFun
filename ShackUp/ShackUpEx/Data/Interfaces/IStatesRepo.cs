using Models.Tables;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface IStatesRepo
    {
        List<State> GetAll();
    }
}
