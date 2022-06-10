using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorApp2.Shared.PageSetUp;

namespace BlazorApp2.Shared
{
    [NotMapped]
    public class ThiSinhData
    {
        public List<AnhUpload> images { get; set; }
        public ThiSinh thiSinh { get; set; }

        public ThiSinhData(List<AnhUpload> images, ThiSinh thiSinh)
        {
            this.images = images;
            this.thiSinh = thiSinh; 
        }
    }
}
