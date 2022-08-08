using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace mp4
{
    public class User
    {
        private static IDictionary<int, User> UserExtent = new Dictionary<int, User>();
        public User GetUserByID(int id)
        {
            if (UserExtent.ContainsKey(id))
            {
                return UserExtent[id];
            }
            else
            {
                throw new ArgumentNullException($"There is no user with id {id}");
            }
        }
        public User(int id, string uname, bool vip)
        {
            if (UserExtent.ContainsKey(id))
            {
                throw new ArgumentException($"Extent already contains key {id}!");
            }
            else
            {
                this.UserID = id;
                this.Username = uname;
                this.IsVIP = vip;
                UserExtent.Add(id, this);
            }
        }
        public int UserID { get; private set; }
        public string Username { get; set; }
        public bool IsVIP { get; set; }
    }


}
