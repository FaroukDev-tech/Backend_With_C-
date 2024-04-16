using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppApi.Dtos.Post
{
    public class UpdatePostRequestDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt {get; set;}  
    }
}