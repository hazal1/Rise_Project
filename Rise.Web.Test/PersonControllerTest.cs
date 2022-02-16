using Microsoft.AspNetCore.Mvc;
using Moq;
using Rise.Core;
using Rise.Core.DTOs;
using Rise.Web.Controllers;
using Rise.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rise.Web.Test
{//*******************************//
    //Merhaba öncelikle kusura bakmayın bu alan için çünkü ilk defa unittest yapıyorum. Bunun için eğitimde izledim. Ama bu alanı 
    //test etme kısmını başarılı bir şekilde yapamadım. İncelediğiniz için teşekkür ederim.
    //*******************************//
    public class PersonControllerTest
    {
        private readonly Mock<PersonApiService> _mockapiservice;
        private readonly PersonController _controller;
        //private List<Person> persons;
        private List<PersonDto> persons;
        public PersonControllerTest()
        {
            _mockapiservice = new Mock<PersonApiService>();
            _controller = new PersonController(_mockapiservice.Object);
            persons = new List<PersonDto>()
        {
            new PersonDto{Id=5, Name="Hatice", Surname="Çakır", FirmName="Çakiroglu"},
            new PersonDto{Id=6, Name="Selvi", Surname="Çınar", FirmName="Çınar"}
        };
        }

        [Fact]
        public async void Index_ActionExecutes_ReturnView()
        {
            var result = await _controller.Index();
            Assert.IsType<ViewResult>(result);
        }

        //[Fact]
        //public async void Index_ActionExecute_ReturnPersonList()
        //{
        //    _mockapiservice.Setup(repo => repo.GetPersonWithContact()).ReturnsAsync(persons);
        //    var result = await _controller.Index();
        //    var viewResult = Assert.IsType<ViewResult>(result);

        //    var personList = Assert.IsAssignableFrom<IEnumerable<PersonWithContactDto>>(viewResult.Model);

        //    Assert.Equal<int>(2, personList.Count());
        //}

        [Fact]
       
        public void Save_ActionExecutes_ReturnView()
        {
            var result = _controller.Save();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async void SavePOST_InValidModelState_ReturnView()
        {
            _controller.ModelState.AddModelError("Name", "Name alanı gereklidir");
            _controller.ModelState.AddModelError("Surname", "Surname alanı gereklidir");
            _controller.ModelState.AddModelError("FirmName", "FirmName alanı gereklidir");
            var result = await _controller.Save(persons.First());

            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.IsType<Person>(viewResult.Model);
        }

        [Fact]
        public async void SavePOST_ValidModelState_ReturnRedirectToIndexAction()
        {
            var result = await _controller.Save(persons.First());

            var redirect = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", redirect.ActionName);
        }
        [Fact]
        public async void Update_IdIsNull_ReturnRedirectToIndexAction()
        {
            var result = await _controller.Update(null);

            var redirect = Assert.IsType<RedirectToActionResult>(result);

            Assert.Equal("Index", redirect.ActionName);
        }

        [Theory]
        [InlineData(3)]
        public async void Update_IdInValid_ReturnNotFound(int personId)
        {
            Person person = null;

            _mockapiservice.Setup(x => x.GetByIdAsync(personId));

            var result = await _controller.Update(personId);

            var redirect = Assert.IsType<NotFoundResult>(result);

            Assert.Equal<int>(404, redirect.StatusCode);
        }

        [Theory]
        [InlineData(2)]
        public async void Update_ActionExecutes_ReturnPerson(int personId)
        {
            var person = persons.First(x => x.Id == personId);

            _mockapiservice.Setup(repo => repo.GetByIdAsync(personId));

            var result = await _controller.Update(personId);

            var viewResult = Assert.IsType<ViewResult>(result);

            var resultPerson = Assert.IsAssignableFrom<Person>(viewResult.Model);

            Assert.Equal(person.Id, resultPerson.Id);

            Assert.Equal(person.Name, resultPerson.Name);
            Assert.Equal(person.Surname, resultPerson.Surname);
            Assert.Equal(person.FirmName, resultPerson.FirmName);
        }

     

 

    
        [Theory]
        [InlineData(0)]
        public async void Delete_IdIsNotEqualPerson_ReturnNotFound(int personId)
        {
            Person person = null;

            _mockapiservice.Setup(x => x.GetByIdAsync(personId));

            var result = await _controller.Remove(personId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(1)]
        public async void Delete_ActionExecutes_ReturnPerson(int personId)
        {
            var person = persons.First(x => x.Id == personId);

            _mockapiservice.Setup(repo => repo.GetByIdAsync(personId));

            var result = await _controller.Remove(personId);

            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.IsAssignableFrom<Person>(viewResult.Model);
        }

     

    }
}
