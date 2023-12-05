using Laboratorium3_App.Controllers;
using Laboratorium3_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Test_Lab_9
{
    public class ContactControllerTest
    {
        private ContactController _contact;
        private IContactService _service;

        public ContactControllerTest()
        {
            _service = new MemoryContactService(new CurrentDateTimeProvider());
            _service.Add(new Contact() { Id = 1 });
            _service.Add(new Contact() { Id = 2 });
            _contact = new ContactController(_service);
        }

        [Fact]
        public void IndexTest()
        {
            var result = _contact.Index();
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            var model = view.Model as List<Contact>;
            Assert.Equal(2, model.Count());
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]

        public void DeatailsTest(int id)
        {
            var result = _contact.Details(id);
            Assert.IsType<ViewResult>(result);
            var view = result as ViewResult;
            var model = view.Model as Contact;
            Assert.Equal(id, model.Id);
        }
        [Fact]
        public void DeatailstestForNonExistingContact()
        {
            var result = _contact.Details(3);
            Assert.IsType<NotFoundResult>(result);
            
        }
    }
}