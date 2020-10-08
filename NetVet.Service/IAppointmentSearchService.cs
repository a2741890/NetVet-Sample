using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetVet.Domain.Entities;

namespace NetVet.Service
{
    public interface IAppointmentSearchService
    {
        List<NotificationData> FilterAppointment(string petName, string startDate, string endDate);
    }
}
