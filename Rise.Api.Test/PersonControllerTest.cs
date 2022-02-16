using Microsoft.AspNetCore.Mvc;
using Moq;
using Rise.Api.Controllers;
using Rise.Core;
using Rise.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rise.Api.Test
{
    //*******************************//
    //Merhaba öncelikle kusura bakmayın bu alan için çünkü ilk defa unittest yapıyorum. Bunun için eğitimde izledim. Ama bu alanı 
    //test etme kısmını başarılı bir şekilde yapamadım. İncelediğiniz için teşekkür ederim.
    //*******************************//
    public class PersonControllerTest
    {
        private readonly Mock<IPersonService> _mockpersonService;
        private readonly PersonController _controller;
        private List<Person> persons;

        public PersonControllerTest()
        {
            _mockpersonService = new Mock<IPersonService>();
            //_controller = new PersonController(_mockpersonService.Object);
            persons = new List<Person>() { 
                new Person { Id = 1, Name = "Sinemm", Surname = "Şimşek", FirmName="Deneme" },
                new Person { Id = 2, Name = "Yasin", Surname = "Kara", FirmName="Denemeee" },
            };
        }

        [Theory]
        [InlineData(0)]
        public async void GetPerson_IdInValid_ReturnNotFound(int personId)
        {
            Person person = null;

            _mockpersonService.Setup(x => x.GetByIdAsync(personId));

            var result = await _controller.GetById(personId);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
