using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DTO
{
    public class UserQueryDto
    {

        public int Id { get; set; }
        public string Path { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
    }
}
