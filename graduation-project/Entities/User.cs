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


        public static (User user,string error) CreateUser
            (
            string userName,
            string password,
            string email,
            string phoneNumber
            )
        {
            if (password.Length <= 4)
            {
                return (user: null, error: "Password is not valid");
            }
            return (user: new User
            {
                Email = email,
                Password = password,
                PhoneNumber = phoneNumber,
                UserName = userName,
                UserGuid = Guid.NewGuid().ToString()
            },error:string.Empty);
        }
    }
}
