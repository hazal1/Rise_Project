using Moq;
using Rise.Api.Controllers;
using Rise.Core;
using Rise.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rise.Api.Test
{
    public class PersonControllerTest
    {
        private readonly Mock<IPersonService> _mockpersonService;
        private readonly PersonController _controller;

        public PersonControllerTest()
        {
            _mockpersonService = new Mock<IPersonService>();
           // _controller= new PersonController(_mockpersonService.Ob)
        }
    }
}
