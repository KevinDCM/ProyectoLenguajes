using System;
using System.Collections.Generic;

#nullable disable

namespace TeleAtlanticoClients_API.Models
{
    public partial class Client
    {
        public Client()
        {
            Issues = new HashSet<Issue>();
        }



        public int Id { get; set; }
        public string Name { get; set; }
        public string Firstsurname { get; set; }
        public string Secondsurname { get; set; }
        public string Phonenumber { get; set; }
        public string Secondcontact { get; set; }
        public string Email { get; set; }
        public string Fulladdress { get; set; }
        public string Password { get; set; }
        public DateTime Registrationdate { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
