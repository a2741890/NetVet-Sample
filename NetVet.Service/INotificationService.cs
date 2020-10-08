using System;
using NetVet.Domain.Entities;

namespace NetVet.Service
{
    public interface INotificationService
    {
        ContactTypes ContactType { get; }

        void SendNotification(NotificationData data);
    }
}
