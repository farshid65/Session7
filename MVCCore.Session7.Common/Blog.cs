using System;
using System.Collections.Generic;

namespace MVCCore.Session7.Common
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Post> Posts { get; set; }
    }
}
