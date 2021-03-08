using PersonalManagement.Api.Models;
using PersonalManagement.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalManagement.Api.Repositories.Contracts
{
    public interface IControlPointRepository
    {
        Task<IList<ControlPoint>> GetAll(ControlPointViewModel controlPointViewModel);
        Task<ControlPoint> GetById(int id);
        Task Create(ControlPoint controlPoint);
        Task Edit(ControlPoint controlPoint);
        Task Delete(ControlPoint controlPoint);
    }
}
