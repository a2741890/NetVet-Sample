using System;
using Mehdime.Entity;
using NetVet.Domain.Repositories;

namespace NetVet.Service
{
    partial class AppointmentNotificationService
    {
        private IDbContextScopeFactory ContextScopeFactory { get; set; }
        private IAppointmentRepository AppointmentRepository { get; set; }
        private INotificationServiceRegistry NotificationServiceRegistry { get; set; }

        public AppointmentNotificationService(IDbContextScopeFactory contextScopeFactory, IAppointmentRepository appointmentRepository, INotificationServiceRegistry notificationServiceRegistry)
        {
            ContextScopeFactory = contextScopeFactory ?? throw new ArgumentNullException("contextScopeFactory");
            AppointmentRepository = appointmentRepository ?? throw new ArgumentNullException("appointmentRepository");
            NotificationServiceRegistry = notificationServiceRegistry ?? throw new ArgumentNullException("notificationServiceRegistry");
        }
    }
}
