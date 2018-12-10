using System;
using Project.BLL.DTO;
using Project.DAL.Entities;
using Project.DAL.Interfaces;
using Project.BLL.Interfaces;
using Project.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Project.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService()//IUnitOfWork uow
        {
            Database = new EFUnitOfWork(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public UserDto GetUser(int? id)
        {
            if (id == null)
                throw new Exception("user id is not set");
            var user = Database.Users.Get(id.Value);
            if (user == null)
                throw new Exception("User not found");

            return new UserDto { Password = user.Password, Id = user.Id, UserName = user.UserName };
        }
        public void AddQuery(UserQueryDto queryDto)
        {
            User user = Database.Users.Get(queryDto.UserId);

            // валидация
            if (user == null)
                throw new Exception("User not found");
            // применяем скидку
            
            UserQuery query = new UserQuery
            {
               Date = DateTime.Now,
               UserId = queryDto.UserId,
               Path = queryDto.Path,
            };
            Database.UserQueries.Create(query);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<UserDto> GetUsers()
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>()).CreateMapper();
            //return mapper.Map<IEnumerable<User>, List<UserDto>>(Database.Users.GetAll());
           return Database.Users.GetAll().Select(x => MapUser(x));
        }
     
        public void LogInUser(UserDto userDto)
        {
            User user = MapUser(userDto);
            user.IsLoggedIn = true;
            Database.Users.Update(user);

        }
        public void LogInOut(UserDto userDto)
        {
            User user = MapUser(userDto);
            user.IsLoggedIn = false;
            Database.Users.Update(user);

        }
        public User MapUser(UserDto userDto)
        {
            User user = new User()
            {
                Id = userDto.Id,
                IsLoggedIn = userDto.IsLoggedIn,
                Password = userDto.Password,
                UserName = userDto.UserName
            };
            return user;
        }
        public UserDto MapUser(User user)
        {
            UserDto userDto = new UserDto()
            {
                Id = user.Id,
                IsLoggedIn = user.IsLoggedIn,
                Password = user.Password,
                UserName = user.UserName
            };
            return userDto;
        }

    }
}
