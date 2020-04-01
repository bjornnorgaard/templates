using System.Collections.Generic;

namespace Models.Users
{
    public class GetUsers
    {
        public class Request
        {
            public int Take { get; set; } = 50;
            public int Skip { get; set; } = 0;
        }

        public class Response
        {
            public IEnumerable<User> Users { get; set; }
        }
    }
}
