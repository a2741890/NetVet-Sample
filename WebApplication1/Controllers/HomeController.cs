using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetVet.Domain.Repositories;
using NetVet.Domain.Entities;
using PagedList;
using System.Globalization;
using NetVet.Service;
using WebApplication1.Models;
using Mehdime.Entity;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IAppointmentSearchService appointmentSearchService = null;
        public HomeController()
        {
            var dbContextScopeFactory = new DbContextScopeFactory();
            var mockAppointmentRepository = new MockAppointmentRepository();

            this.appointmentSearchService = new AppointmentSearchService(dbContextScopeFactory, mockAppointmentRepository);
        }
        public HomeController(IAppointmentSearchService appointmentSearchService)
        {
            this.appointmentSearchService = appointmentSearchService;
        }

        public ActionResult Index(string searchString, string startDate, string endDate, string currentFilter, string currentStartDate, string currentEndDate, int? page, int? head)
        {

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
            ViewBag.CurrentEndDate = endDate;

            var appointmentList = appointmentSearchService.FilterAppointment(searchString, startDate, endDate);

            ViewBag.ResultCount = appointmentList.Count;
            ViewBag.head = head ?? 1;
            int pageSize = 25;
            int pageNumber = (page ?? 1);

            IndexViewModel indexViewModel = new IndexViewModel
            {
                appointmentsViewModel = null,
                appointmentsViewModelsList = appointmentList.OrderByDescending(a => a.AppointmentDate)
            .Select(a =>
            {
                return (
                        new AppointmentsViewModel
                        {
                            appointmentDateTime = a.AppointmentDate,
                            ownerName = a.OwnerName,
                            petName = a.PetName,
                            contactDetail = a.ContactData
                        });
            }).ToPagedList(pageNumber, pageSize)
            };

            return View(indexViewModel);
        }
    }
}