using InsertJsonData.Dto;
using InsertJsonData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsertJsonData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsertDataController : ControllerBase
    {
        private readonly CakeDb _CakeDb;
        public InsertDataController(CakeDb cakeDb)
        {
            _CakeDb = cakeDb;
        }

        [HttpPost]
        public async Task<IActionResult> InsertJsonData(CakeDto dto)
        {
            List<CakeModel> CakeModelList=new List<CakeModel>();
            foreach (var batters in dto.batters.batter)
            {
                foreach (var topping in dto.Topping)
                {
                    CakeModel cakeModel = new CakeModel() {
                        CakeId = Convert.ToInt32(dto.id),
                        CakeType=dto.type,
                        CakeName=dto.name,
                        CakePpu=dto.ppu,
                        BatterID= Convert.ToInt32(batters.id),
                        BatterType= batters.type,
                        ToppingId= topping.id,
                        ToppingType = topping.type

                    };
                    CakeModelList.Add(cakeModel);
                }
            }
           await _CakeDb.Cake.AddRangeAsync(CakeModelList);
           await _CakeDb.SaveChangesAsync();
            return Ok();
        }
    }
  

}
