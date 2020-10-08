using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetVet.Domain.Repositories;
using Mehdime.Entity;

namespace NetVet.Service
{
    partial class AppointmentSearchService
    {
        private IDbContextScopeFactory _contextScopeFactory;
        private IAppointmentRepository _appointmentRepository { get; set; }

        public AppointmentSearchService(IDbContextScopeFactory contextScopeFactory,IAppointmentRepository appointmentRepository)
        {
            _contextScopeFactory = contextScopeFactory ?? throw new ArgumentNullException("contextScopeFactory");
            _appointmentRepository = appointmentRepository ?? throw new ArgumentNullException("appointmentRepository");
        }
    }
}
