using System;
using NetVet.Domain.Entities;

namespace NetVet.Service
{
    public interface INotificationServiceRegistry
    {
        /// <summary>
        /// Returns a notification service for the provided contact type, if any.
        /// #null is returned if there is no supported notification for the contact type.
        /// </summary>
        INotificationService FindNotificationService(ContactTypes contactType);
    }
}
