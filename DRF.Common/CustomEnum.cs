using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Common
{
    public static class CustomEnum
    {
        public enum Day { Saturday = 1, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday }
        public enum AppointmentStatus { Requested = 1, Approved, Rejected, Completed }
        public enum AppointmentType { New = 1, Regular, Checkup }

    }
}
