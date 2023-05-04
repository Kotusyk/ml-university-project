namespace AnimalRecognizer.Model
{
    public class Authentication
    {
        private readonly List<User> _users;
        private readonly List<Role> _roles;
        private readonly List<Token> _tokens;

        public Authentication()
        {
            _users = new List<User>();
            _roles = new List<Role>();
            _tokens = new List<Token>();
        }

        public void Register(User user)
        {
            _users.Add(user);
        }

        public void Register(Role role)
        {
            _roles.Add(role);
        }

        public Token Login(string username, string password)
        {
            var user = _users.SingleOrDefault(u => u.Name == username && u.Password == password);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var role = _roles.SingleOrDefault(r => r.Name == "User");

            if (role == null)
            {
                throw new UnauthorizedAccessException();
            }

            var token = new Token
            {
                Value = Guid.NewGuid().ToString()
            };

            _tokens.Add(token);

            return token;
        }

        public bool IsAuthorized(string tokenValue)
        {
            var token = _tokens.SingleOrDefault(t => t.Value == tokenValue);

            if (token == null)
            {
                return false;
            }

            return true;
        }
    }
}
