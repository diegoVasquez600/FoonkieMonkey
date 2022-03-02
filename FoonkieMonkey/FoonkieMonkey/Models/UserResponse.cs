using System;
using System.Collections.Generic;
using System.Text;

namespace FoonkieMonkey.Models
{
    public partial class UserResponse
    {
        public int Page { get; set; }
        public int Per_Page { get; set; }
        public int Total { get; set; }
        public int Total_Page { get; set; }
        public List<User> Data { get; set; }
    }
}
