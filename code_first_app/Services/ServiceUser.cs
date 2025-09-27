using code_first_app.Models;
using Microsoft.EntityFrameworkCore;
/*
 USE PV_412
GO
INSERT INTO [Users](UserName) VALUES 
('Liam O''Connor'),
('Sofia Rossi'),
('Mikhail Ivanov'),
('Yuki Tanaka'),
('Carlos Alvarez'),
('Fatima Zahra'),
('Hans Müller'),
('Emily Johnson'),
('Aarav Patel'),
('Chen Wei'),
('Noura Haddad'),
('Mateusz Kowalski'),
('Isabella Brown'),
('Igor Popescu'),
('Linda Bergström'),
('Thiago Costa'),
('Mehmet Kaya'),
('Olena Shevchenko'),
('Nguyen Minh'),
('Amara Diallo');
 
 INSERT INTO UserProfiles (Address, Phone, UserId) VALUES 
('12 Dublin Rd, Dublin, Ireland', '+353 85 123 4567', 1),
('Via Roma 45, Rome, Italy', '+39 06 123 4567', 2),
('Lenina St. 10, Moscow, Russia', '+7 495 123 4567', 3),
('Shinjuku 5-3, Tokyo, Japan', '+81 3 1234 5678', 4),
('Av. Reforma 123, Mexico City, Mexico', '+52 55 1234 5678', 5),
('Rue des Roses, Casablanca, Morocco', '+212 6 12 34 56 78', 6),
('Hauptstrasse 22, Berlin, Germany', '+49 30 123456', 7),
('25 Elm St, New York, USA', '+1 212 555 7890', 8),
('MG Road 14, Mumbai, India', '+91 22 1234 5678', 9),
('No. 8 Nanjing Rd, Shanghai, China', '+86 21 1234 5678', 10),
('Al Hamra St., Beirut, Lebanon', '+961 1 234 567', 11),
('ul. Piękna 3, Warsaw, Poland', '+48 22 123 45 67', 12),
('Queens Rd, London, UK', '+44 20 7946 0958', 13),
('Str. Eminescu, Bucharest, Romania', '+40 21 123 4567', 14),
('Sveavägen 18, Stockholm, Sweden', '+46 8 123 456', 15),
('Av. Paulista, São Paulo, Brazil', '+55 11 91234 5678', 16),
('İstiklal Cd. 10, Istanbul, Turkey', '+90 212 123 4567', 17),
('Khreshchatyk St, Kyiv, Ukraine', '+380 44 123 4567', 18),
('Le Duan St, Hanoi, Vietnam', '+84 24 1234 5678', 19),
('Rue 123, Dakar, Senegal', '+221 33 123 45 67', 20);
 
 */
namespace code_first_app.Services
{
    public interface IServiceUser
    {
        public void CreateUser(User user);
        public User? GetUserById(int id);
        public void UpdateUser(int id, User user);
        public void DeleteUser(int id);
        public IEnumerable<User> GetAllUsers();
    }
    public class ServiceUser : IServiceUser, IDisposable
    {
        private readonly Shop_pv412 _db;
        public ServiceUser(Shop_pv412 db)
        {
            _db = db;
        }
        public void CreateUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IEnumerable<User> GetAllUsers() => _db.Users.Include(u => u.Profile);

        public User? GetUserById(int id) => _db.Users.Include(u => u.Profile).FirstOrDefault(u => u.Id == id);

        public void UpdateUser(int id, User user)
        {
            var userFromDb = GetUserById(id);
            if (userFromDb != null)
            {
                userFromDb.UserName = user.UserName;
                userFromDb.Profile = user.Profile;
                _db.SaveChanges();
            }
        }
    }
}
