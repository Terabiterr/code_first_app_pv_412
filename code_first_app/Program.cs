namespace code_first_app
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Shop_pv412())
            {
                Console.WriteLine($"Database connected successfully ...");
            }
            Console.ReadKey();
        }
    }
}
