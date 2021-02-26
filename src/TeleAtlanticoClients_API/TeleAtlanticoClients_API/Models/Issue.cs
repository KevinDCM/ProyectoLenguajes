using System;
using System.Collections.Generic;

#nullable disable

namespace TeleAtlanticoClients_API.Models
{
    public partial class Issue
    {
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime RegisterTimestamp { get; set; }
        public int ClientId { get; set; }
        public string ClientFullname { get; set; }
        public string Status { get; set; }
        public string SupporterName { get; set; }

        public virtual Client Client { get; set; }
    }
}
