using System;
using System.Linq;
using NetVet.Domain.Repositories;
using NUnit.Framework;

namespace NetVet.Domain
{
    class TestMock
    {
        /// <summary>
        /// Just a simple assertion to check that the mock service is returning data. Feel free to 
        /// create unit tests for your MVC controllers, though right now the mock repository
        /// returns randomized-ish data, so you would be better off with a custom mock for tests. 
        /// I.e. Moq  :)
        /// </summary>
        [Test]
        public void TestMyMock()
        {
            IAppointmentRepository repository = new MockAppointmentRepository();
            var test = repository.GetAppointments().ToList();
            Assert.IsTrue(test.Count > 0);
        }
    }
}
