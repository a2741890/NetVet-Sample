using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetVet.Domain.Entities;

namespace NetVet.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        /// <summary>
        /// Returns active appointments.
        /// </summary>
        IQueryable<Appointment> GetAppointments(bool includeDeleted = false);
    }
}
