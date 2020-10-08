using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetVet.Domain.Entities;
using System.Globalization;
using PagedList;


namespace NetVet.Service
{
    public partial class AppointmentSearchService : IAppointmentSearchService
    {
        List<NotificationData> IAppointmentSearchService.FilterAppointment(string petName, string startDate, string endDate)
        {
            using (var contextScope = _contextScopeFactory.CreateReadOnly())
            {
                var appointmentDataList = _appointmentRepository.GetAppointments();

                if (!String.IsNullOrEmpty(petName))
                {
                    appointmentDataList = appointmentDataList
                                        .Where(a => a.Pet.Name.ToUpper().Contains(petName.ToUpper()));
                }

                if (!String.IsNullOrEmpty(startDate))
                {
                    appointmentDataList = _appointmentRepository.GetAppointments()
                        .Where(a => a.AppointmentDateTime >= DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InstalledUICulture));
                }

                if (!String.IsNullOrEmpty(endDate))
                {
                    appointmentDataList = _appointmentRepository.GetAppointments()
                        .Where(a => a.AppointmentDateTime <= DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InstalledUICulture).AddHours(11).AddMinutes(59));
                }

                var result = appointmentDataList.ToList()
                    .Select(r =>
                {
                    return (new NotificationData(
                        r.Pet.Owner.Contacts.Find(c => c.IsPreferred).ContactData,
                        r.Pet.Owner.PreferredName ?? String.Concat(r.Pet.Owner.FirstName, r.Pet.Owner.LastName),
                        r.Pet.Name,
                        r.AppointmentDateTime
                        ));
                });

                return result.ToList();
            }
        }
    }
}
