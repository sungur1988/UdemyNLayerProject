using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyNLayerProject.Core.DTOs
{
    public class ProductWithCategoryDto : ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
