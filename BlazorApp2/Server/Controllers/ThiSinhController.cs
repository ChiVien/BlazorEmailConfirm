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

        enum TrangThaiAnh
        {
            Moi,
            Cu,
            Xoa
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

            thiSinhData.images.ForEach(item =>
            {
                HinhAnh image = new HinhAnh();
                image.Image = _hinhAnhService.UploadFile(item.anh).Result;
                thiSinhData.thiSinh.HinhAnhs.Add(image);
            });
            _context.ThiSinh.Add(thiSinhData.thiSinh);
            await _context.SaveChangesAsync();
            return Ok();
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
        public async Task<ActionResult<ThiSinh>> UpdateThiSinh(ThiSinhData thiSinhData, int id)
        {
            IHinhAnhService _hinhAnhService = new HinhAnhService(_environment);
            var result = await _context.ThiSinh.Include(ts => ts.HinhAnhs).FirstOrDefaultAsync(ts => ts.Id == id);
            if (result == null)
            {
                return NotFound("Không tìm thấy thí sinh");
            }

            thiSinhData.images.ForEach(async item =>
            {
                switch (ThayDoiHinhAnh(item.status))
                {
                    case TrangThaiAnh.Moi:
                        {
                            HinhAnh image = new HinhAnh();
                            image.Image = await _hinhAnhService.UploadFile(item.anh);
                            result.HinhAnhs.Add(image);
                            break;
                        }
                    case TrangThaiAnh.Cu:
                        break;
                    case TrangThaiAnh.Xoa:
                        {
                            var name = item.anh;
                            _hinhAnhService.DeleteFile(name);
                            result.HinhAnhs.RemoveAll(i => i.Image == name);
                        }
                        break;

                    default:
                        break;
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
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteThiSinh(int id)
        {
            var result = await _context.ThiSinh.Include(ts => ts.HinhAnhs).FirstOrDefaultAsync(ts => ts.Id == id);
            if (result == null)
            {
                return NotFound("Khong tim thay thi sinh");
            }
            _context.ThiSinh.Remove(result);
            await _context.SaveChangesAsync();

            return Ok("Delete Success");
        }

        private TrangThaiAnh ThayDoiHinhAnh(int status)
        {
            switch (status)
            {
                case 0:
                    return TrangThaiAnh.Moi;
                case 1:
                    return TrangThaiAnh.Cu;
                case 2:
                    return TrangThaiAnh.Xoa;
                default:
                    return TrangThaiAnh.Moi;
            }
        }
    }
}
