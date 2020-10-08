using System;

namespace NetVet.Service
{
    /// <summary>
    /// Data container for notification message data. 
    /// </summary>
    /// <remarks>
    /// Each notification service will manage formatting of the 
    /// message to suit the media sent. (I.e. SMS vs. e-mail)
    /// </remarks>
    public sealed class NotificationData
    {
        public string ContactData { get; private set; }
        public string OwnerName { get; private set; }
        public string PetName { get; private set; }
        public DateTime AppointmentDate { get; private set; }

        public NotificationData(string contactData, string ownerName, string petName, DateTime appointmentDate)
        {
            ContactData = contactData;
            OwnerName = ownerName;
            PetName = petName;
            AppointmentDate = appointmentDate;
        }
    }
}
