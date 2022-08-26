using MN.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;


namespace MN.Data.Services
{
    public class UserRepository : DataRepository<User>
    {
        public UserRepository() : base(new Persona5Context())
        {
            
        }
        
        public bool UserExists(string username, string passwordHash)
        {
            return _context.Set<User>().SingleOrDefault(u=>u.Username == username && u.Password == passwordHash) != null;
        }
        public bool UserExists(string username)
        {
            return _context.Set<User>().SingleOrDefault(u=>u.Username == username) != null;
        }

        public User? GetUser(string username, string passwordHash)
        {
            return _context.Set<User>().Include(u=>u.UserType).SingleOrDefault(u=>u.Username == username && u.Password == passwordHash);
        }

        
        public async Task<string> GetHashedPasswordAsync(string password)
        {
            return await Task.Run(()=>{
                using (SHA256 hash = SHA256.Create())
                {
                    byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            });
        }



        public void AddUser(string username, string hashedPw)
        {
            // Add a new user to the context and add the relation to the UserType
            _context.Set<User>().Add(new User() {
                Username = username,
                Password = hashedPw,
                UserTypeId = _context.Set<UserType>().Single(t=>t.TypeName == "User").Id
            });
        }
    }
}