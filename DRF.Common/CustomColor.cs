using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Common
{
    public static class CustomColor
    {
        public static string BadgeColor(int val)
        {
            switch (val)
            {
                case (int)CustomEnum.AppointmentStatus.Approved:
                    return "badge-success";
                case (int)CustomEnum.AppointmentStatus.Rejected:
                    return "badge-error";
                case (int)CustomEnum.AppointmentStatus.Pending:
                case (int)CustomEnum.AppointmentStatus.Requested:
                    return "badge-warning";
                case (int)CustomEnum.AppointmentStatus.Draft:
                    return "";
                default:
                    return "";
            }
        }
        public static string BadgeStatusColor(int val)
        {
            switch (val)
            {
                case (int)CustomEnum.Status.Active:
                    return "badge-success";
                case (int)CustomEnum.Status.Inactive:
                    return "badge-error";
                default:
                    return "";
            }
        }
    }
}
