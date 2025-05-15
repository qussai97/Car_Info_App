using CarInfoApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInfoApp.Application.Interfaces
{
    public interface INhtsaService
    {
        Task<List<Make>> GetAllMakesAsync();
        Task<List<VehicleType>> GetVehicleTypesForMakeIdAsync(int makeId);
        Task<List<Model>> GetModelsForMakeIdAndYearAsync(int makeId, int year);
    }
}
