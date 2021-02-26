using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeleAtlantico_Clients.Models.Domain
{
    public class Client
    {

        private int id;
        private string name;
        private string firstsurname;
        private string secondsurname;
        private string email;
        private string password;
        private string phonenumber;
        private string secondcontact;
        private string fulladdress;
        private DateTime registrationdate;
        private ICollection<Issue> issues;

        public Client() { }

        public Client(int id, string name, string firstsurname, string secondsurname, string email, string password, string phonenumber, string secondcontact, string fulladdress, DateTime registrationdate)
        {
            this.id = id;
            this.name = name;
            this.firstsurname = firstsurname;
            this.secondsurname = secondsurname;
            this.email = email;
            this.password = password;
            this.phonenumber = phonenumber;
            this.secondcontact = secondcontact;
            this.fulladdress = fulladdress;
            this.registrationdate = registrationdate;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Firstsurname { get => firstsurname; set => firstsurname = value; }
        public string Secondsurname { get => secondsurname; set => secondsurname = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Secondcontact { get => secondcontact; set => secondcontact = value; }
        public string Fulladdress { get => fulladdress; set => fulladdress = value; }
        public DateTime Registrationdate { get => registrationdate; set => registrationdate = value; }
        public ICollection<Issue> Issues { get; set; }

    }

}
