using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyNLayerProject.Core.DTOs
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}
