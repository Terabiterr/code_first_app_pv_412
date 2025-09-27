using code_first_app.Services;

namespace code_first_app
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var serviceUser = new ServiceUser(new Shop_pv412());

                var users = serviceUser.GetAllUsers();

                foreach (var u in users)
                {
                    Console.WriteLine($"UserName: {u.UserName}, Profile Address: {u.Profile.Address}");
                }


            Console.ReadKey();
        }
    }
}
