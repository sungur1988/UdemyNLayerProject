using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyNLayerProject.Core.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; set; }
        public int StatusCode { get; set; }
    }
}
