using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rise.Core.Services;

namespace Rise.Api.Controllers
{
    
    public class PersonContactController : CustomBaseController
    {
        private readonly IPersonContactService _personContactService;
        public PersonContactController(IPersonContactService personContactService)
        {
            _personContactService = personContactService;
        }
        [HttpGet("[action]/{contactId}")]
        public async Task<IActionResult> GetContactWithPerson(int contactId)
        {
            return CreateActionResult(await _personContactService.GetContactWithPersonAsync(contactId));

        }
    }
}
