using System;
using System.Collections.Generic;

#nullable disable

namespace TeleAtlanticoClients_API.Models
{
    public partial class Comment
    {
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime CommentTimestamp { get; set; }
        public string SendingPersonName { get; set; }

        public virtual Issue IssueNumberNavigation { get; set; }
    }
}
