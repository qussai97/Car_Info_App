using CarInfoApp.Application.Interfaces;
using CarInfoApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarInfoApp.API.Pages
{
    public class CarInfoModel : PageModel
    {
        private readonly INhtsaService _nhtsaService;

        public CarInfoModel(INhtsaService nhtsaService)
        {
            _nhtsaService = nhtsaService;
        }

        [BindProperty(SupportsGet = true)]
        public int? MakeId { get; set; }

        public List<Make> Makes { get; set; }
        public List<VehicleType> VehicleTypes { get; set; }
        public List<Model> Models { get; set; }

        public async Task OnGetAsync()
        {
            // Ã·» ﬂ· «·‹ makes
            Makes = await _nhtsaService.GetAllMakesAsync();

            // ≈–« ﬂ«‰ «·‹ MakeId „ÊÃÊœ° Ã·» «·‹ VehicleTypes
            if (MakeId.HasValue)
            {
                VehicleTypes = await _nhtsaService.GetVehicleTypesForMakeIdAsync(MakeId.Value);
            }

            // ≈–« ﬂ«‰ «·‹ MakeId Ê Year „ÊÃÊœÌ‰° Ã·» «·‹ Models
            if (MakeId.HasValue && Request.Query.ContainsKey("year"))
            {
                int year = int.Parse(Request.Query["year"]);
                Models = await _nhtsaService.GetModelsForMakeIdAndYearAsync(MakeId.Value, year);
            }
        }
    }
}
