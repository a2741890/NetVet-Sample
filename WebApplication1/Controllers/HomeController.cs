using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetVet.Domain.Repositories;
using NetVet.Domain.Entities;
using WebApplication1.Models;
using PagedList;
using System.Globalization;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IAppointmentRepository mockAppointmentRepository = null;

        public HomeController()
        {
            this.mockAppointmentRepository = new MockAppointmentRepository();
        }
        public HomeController(MockAppointmentRepository mockAppointmentRepository)
        {
            this.mockAppointmentRepository = mockAppointmentRepository;
        }

        public ActionResult Index(string searchString, string startDate, string endDate, string currentFilter, string currentStartDate, string currentEndDate, int? page, int? head)
        {
            IQueryable<Appointment> appointments = mockAppointmentRepository.GetAppointments(false);

            var appointmentList = appointments.ToList();

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            if (startDate != null || endDate != null)
            {
                page = 1;
            }
            else
            {
                startDate = currentStartDate;
                endDate = currentEndDate;
            }


            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentStartDate = startDate;
            ViewBag.CurrentEndDate= endDate;

            if (!String.IsNullOrEmpty(searchString))
                appointmentList = appointmentList.Where(a => a.Pet.Name.ToUpper().Contains(searchString.ToUpper())).ToList();

            if (!String.IsNullOrEmpty(startDate) )
                appointmentList = appointmentList.Where(a => a.AppointmentDateTime >= DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InstalledUICulture)).ToList();

            if (!String.IsNullOrEmpty(endDate))
                appointmentList = appointmentList.Where(a => a.AppointmentDateTime <= DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InstalledUICulture).AddHours(11).AddMinutes(59)).ToList();

            ViewBag.ResultCount = appointmentList.Count;
            ViewBag.head = head ?? 1;
            int pageSize = 25;
            int pageNumber = (page ?? 1);

            IndexViewModel indeViewModel = new IndexViewModel
            {
                appointmentsViewModel=null,
                appointmentsViewModelsList = appointmentList.OrderByDescending(a => a.AppointmentDateTime)
            .Select(a =>
            {
                var pet = a.Pet;
                var owner = pet.Owner;
                return (
                        new AppointmentsViewModel
                        {
                            appointmentDateTime = a.AppointmentDateTime,
                            ownerName = owner.PreferredName ?? $"{owner.FirstName} {owner.LastName}",
                            petName = pet.Name,
                            contactDetails = owner.Contacts.Select(c =>
                            {
                                return $"{c.ContactType}: {c.ContactData} {(c.IsPreferred ? "(Preferred)" : "")}";
                            })
                        });
            }).ToPagedList(pageNumber, pageSize)
            };
            
            return View(indeViewModel);
        }
    }
}