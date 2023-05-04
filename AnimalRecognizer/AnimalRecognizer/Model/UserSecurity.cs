namespace AnimalRecognizer.Model
{
    public static class UserSecurity
    {
            private static List<User> _users = new List<User>()
            {
                new User { Id = 1, Name = "john", Password = "password" },
                new User { Id = 2, Name = "jane", Password = "password" }
            };

            public static bool Login(string username,  string password)
            {
                var user = _users.SingleOrDefault(u => u.Name == username && u.Password == password);
                return user != null;
            }
    }
    
}
