using System;

namespace NetVet.Service
{
    public interface IAppoinmentNotificationService
    {
        /// <summary>
        /// Sends out reminder notifications to users that have opted in for notifications
        /// to supported contact details.
        /// </summary>
        void SendReminderForUpcomingAppointments();
    }
}
