using Project.BLL.DTO;
using System.Collections.Generic;
namespace Project.BLL.Interfaces
{
    public interface IUserService
    {
        UserDto GetUser(int? id);
        IEnumerable<UserDto> GetUsers();
        void Dispose();
    }
}
