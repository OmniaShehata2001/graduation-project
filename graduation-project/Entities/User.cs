using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace graduation_project.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserGuid { get; set; }


        public static User CreateUser
            (
            string userName,
            string password,
            string email,
            string phoneNumber
            )
        {
            return new User
            {
                Email = email,
                Password = password,
                PhoneNumber = phoneNumber,
                UserName = userName,
                UserGuid = Guid.NewGuid().ToString()
            };
        }
    }
}
