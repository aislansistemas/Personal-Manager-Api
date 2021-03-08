using Microsoft.EntityFrameworkCore;
using PersonalManagement.Api.Context;
using PersonalManagement.Api.Exceptions;
using PersonalManagement.Api.Models;
using PersonalManagement.Api.Repositories.Contracts;
using PersonalManagement.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalManagement.Api.Repositories
{
    public class ControlPointRepository : IControlPointRepository
    {
        private readonly PersonalManagerContext _context;
        public ControlPointRepository(PersonalManagerContext context)
        {
            _context = context;
        }

        public async Task Create(ControlPoint controlPoint)
        {
            try
            {
                controlPoint.TotalHours = CalculateTotalHour(controlPoint);
                _context.ControlPoints.Add(controlPoint);
                await _context.SaveChangesAsync();
            }catch(Exception)
            {
                throw new Exception("Não foi possível realizar o cadastro!");
            }
        }

        private int CalculateTotalHour(ControlPoint controlPoint)
        {
            var totalHour = controlPoint.HourInputOne.Hour
                + controlPoint.HourInputTwo.Hour 
                + controlPoint.HourExitOne.Hour 
                + controlPoint.HourExitTwo.Hour;

            return totalHour;
        }

        public async Task Delete(ControlPoint controlPoint)
        {
            try
            {
                _context.ControlPoints.Remove(controlPoint);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Não foi possível realizar a deleção!");
            }
        }

        public async Task Edit(ControlPoint controlPoint)
        {
            try
            {
                _context.ControlPoints.Update(controlPoint);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception("Não foi possível realizar a Edição!");
            }
        }

        public async Task<IList<ControlPoint>> GetAll(ControlPointViewModel controlPointViewModel)
        {
            
            var controlPoint = await _context.ControlPoints
                .AsNoTrackingWithIdentityResolution()
                .Where(
                    c => c.ApplicationUserId == controlPointViewModel.ApplicationUserId
                    && 
                    c.Date.Month == DateTime.Now.Month
                )
                .ToListAsync();

            if(controlPoint == null)
            {
                throw new NotFoundException("Nenhum registro encontrado!");
            }

            return controlPoint;
          
        }

        public async Task<ControlPoint> GetById(int id)
        {
            
            var controlPoint = await _context.ControlPoints
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(c => c.Id == id);

            if(controlPoint == null)
            {
                throw new NotFoundException("Nenhum registro encontrado!");
            }

            return controlPoint;
            
        }
    }
}
