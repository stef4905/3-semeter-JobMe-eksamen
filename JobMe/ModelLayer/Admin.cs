using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    [DataContract]
    public class Admin
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string FName { get; set; }
        [DataMember]
        public string LName { get; set; }
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Constructor for admin
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="email"></param>
        public Admin(string username, string password, string fName, string lName, string email)
        {
            this.Username = username;
            this.Password = password;
            this.FName = fName;
            this.LName = lName;
            this.Email = email;
        }

        /// <summary>
        /// Empty constructor for admin
        /// </summary>
        public Admin()
        {
        }
    }
}
