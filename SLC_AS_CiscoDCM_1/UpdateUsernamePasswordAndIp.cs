using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1
{
    public abstract class UpdateUsernamePasswordAndIp
    {
        public string Username;
        public string Password;
        public string Ip;

        public void Update(string username, string password, string ip)
        {
            Username = username;
            Password = password;
            Ip = ip;
        }
    }
}
