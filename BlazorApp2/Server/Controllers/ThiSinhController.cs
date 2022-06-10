using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThiSinhController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ThiSinhController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult<List<ThiSinh>>> GetThiSinh()
        {
            var result = await _context.ThiSinh.Include(ts => ts.HinhAnhs).ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<ThiSinh>>> CreateThiSinh(ThiSinhData thiSinhData)
        {
			IHinhAnhService _hinhAnhService = new HinhAnhService(_environment);

			thiSinhData.images.ForEach(async item =>
			{
				HinhAnh image = new HinhAnh();
				image.Image = _hinhAnhService.UploadFile(item.anh).Result;
				thiSinhData.thiSinh.HinhAnhs.Add(image);
			});

			_context.ThiSinh.Add(thiSinhData.thiSinh);

			await _context.SaveChangesAsync();
            return Ok(await GetDbThiSinh());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ThiSinh>> GetThiSinh(int id)
        {
            var result = await _context.ThiSinh.Include(i => i.HinhAnhs).FirstOrDefaultAsync(ts => ts.Id == id);
            if (result == null)
            {
                return NotFound("Không tìm thấy thí sinh");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ThiSinh>>> UpdateThiSinh(ThiSinhData thiSinhData, int id)
        {
            IHinhAnhService _hinhAnhService = new HinhAnhService(_environment);
            var result = await _context.ThiSinh.Include(ts => ts.HinhAnhs).FirstOrDefaultAsync(ts => ts.Id == id);
            if (result == null)
            {
                return NotFound("Không tìm thấy thí sinh");
            }

			thiSinhData.images.ForEach(async item =>
			{
                if (item.status == 0) // cu
                {
                    HinhAnh image = new HinhAnh();
                    image.Image = await _hinhAnhService.UploadFile(item.anh);
                    result.HinhAnhs.Add(image);
                }else if(item.status == 2)//xoa
                {
                    var name = item.anh;
                    _hinhAnhService.DeleteFile(name);
                    result.HinhAnhs.RemoveAll(i => i.Image == name);
                }
			});

			foreach (PropertyInfo prop in result.GetType().GetProperties())
            {
                if (prop.Name != "Id" && prop.Name != "HinhAnhs")
                {
                    prop.SetValue(result, prop.GetValue(thiSinhData.thiSinh));
                }
            }

            await _context.SaveChangesAsync();
            return Ok(await GetDbThiSinh());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ThiSinh>>> DeleteThiSinh(int id)
        {
            var result = await _context.ThiSinh.Include(ts => ts.HinhAnhs).FirstOrDefaultAsync(ts => ts.Id == id);
            if (result == null)
            {
                return NotFound("Khong tim thay thi sinh");
            }
            _context.ThiSinh.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await GetDbThiSinh());
        }

        private async Task<List<ThiSinh>> GetDbThiSinh()
        {
            return await _context.ThiSinh.Include(ts => ts.HinhAnhs).ToListAsync();
        }
     }
}
