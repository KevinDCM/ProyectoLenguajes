using System;
using System.Collections.Generic;

#nullable disable

namespace TeleAtlanticoClients_API.Models
{
    public partial class UsersService
    {
        public int ClientId { get; set; }
        public int ServiceCode { get; set; }
        public DateTime? ContractDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual Service ServiceCodeNavigation { get; set; }
    }
}
