using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp2.Shared
{
    [NotMapped]
    public class ThiSinhData
    {
        public List<AnhUpload> images { get; set; }
        public ThiSinh thiSinh { get; set; }

        public ThiSinhData(ThiSinh thiSinh)
        {
            this.images = new List<AnhUpload>();
            this.thiSinh = thiSinh;
        }
    }
}
