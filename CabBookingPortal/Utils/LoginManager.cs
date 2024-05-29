namespace CabBookingPortal.Utils
{
    public static class LoginManager
    {
        public static Employee? User = null;

        public static void Login(Employee employee)
        {
            if (employee is not null) User = employee;
        }

        public static void Logout()
        {
            User = null;
        }
    }
}
