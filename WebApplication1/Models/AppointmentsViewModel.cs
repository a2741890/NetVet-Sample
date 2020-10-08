using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using NetVet.Domain.Entities;
using PagedList.Mvc;

namespace WebApplication1.Models
{
    public class AppointmentsViewModel
    {
        [DisplayName("Owner")]
        public string ownerName { get; set; }

        [DisplayName("Pet Name")]
        public string petName { get; set; }

        [DisplayName("Date")]
        public DateTime appointmentDateTime { get; set; }

        [DisplayName("Contact Details")]
        public string contactDetail { get; set; }

    }

    public class IndexViewModel
    {
        public AppointmentsViewModel appointmentsViewModel;
        public PagedList.IPagedList<AppointmentsViewModel> appointmentsViewModelsList;
    }
}