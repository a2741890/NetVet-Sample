using System;
using System.Linq;

namespace NetVet.Service
{
    /// <summary>
    /// Sample implementation for sending notifications to owners with appointments
    /// tomorrow.
    /// </summary>
    /// <remarks>
    /// This sample is provided as an example of a service that might be running on a schedule
    /// as an example of the unit of work pattern (Mehdime) and repository pattern. This code is
    /// not complete / functional
    /// </remarks>
    public partial class AppointmentNotificationService : IAppoinmentNotificationService
    {
        /// <summary>
        /// <see cref="IAppoinmentNotificationService.SendReminderForUpcomingAppointments"/>
        /// </summary>
        void IAppoinmentNotificationService.SendReminderForUpcomingAppointments()
        {
            // Note: Without a database/DBContext you're going to need to initialize your dependencies for the 
            // ContextScopeFactory and Repository to mocks to return and use the sample data.
            using (var contextScope = ContextScopeFactory.CreateReadOnly())
            {
                DateTime targetStartDate = DateTime.Today.AddDays(1);
                DateTime targetEndDate = targetStartDate.AddDays(1);
                var ownersToSendReminders = AppointmentRepository.GetAppointments()
                    .Where(x => x.AppointmentDateTime >= targetStartDate
                        && x.AppointmentDateTime < targetEndDate
                        && x.Pet.Owner.IsOptInForNotifications)
                    .Select(x => new
                    {
                        Contacts = x.Pet.Owner.Contacts.Select(c => new { c.ContactType, c.ContactData }),
                        OwnerFirstName = x.Pet.Owner.FirstName,
                        OwnerPreferredName = x.Pet.Owner.PreferredName,
                        PetName = x.Pet.Name,
                        x.AppointmentDateTime
                    }).ToList(); // Note: would need to be paged/queued if large #s are expected.

                foreach(var owner in ownersToSendReminders)
                {
                    string ownerName = owner.OwnerPreferredName ?? owner.OwnerFirstName;
                    foreach(var contact in owner.Contacts)
                    {
                        var notificationService = NotificationServiceRegistry.FindNotificationService(contact.ContactType);
                        if (notificationService == null)
                            continue; // No notification applicable here.

                        var notificationData = new NotificationData(contact.ContactData, ownerName, owner.PetName, owner.AppointmentDateTime);
                        notificationService.SendNotification(notificationData);
                    }
                }
            }
        }
    }
}
