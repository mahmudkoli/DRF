using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DRF.Web.Models.NotificationModels
{
    public class UserHubModel
    {
        public int UserId { get; set; }
        public HashSet<string> ConnectionIds { get; set; }
    }
}