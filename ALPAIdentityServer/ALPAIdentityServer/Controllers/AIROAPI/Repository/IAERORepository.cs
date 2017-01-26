using ALPAIdentityServer.Models.AIROViewModels;
using System.Collections.Generic;

namespace ALPAIdentityServer.Controllers.AIROAPI
{
    public interface IAERORepository
    {
        List<PersonViewModel> GetPerson(int personId);
        List<PersonViewModel> GetPersonUsingView(int personId);
        List<PersonViewModel> GetPersonByAlpaId(string personId);
        List<PersonViewModel> GetPersonByLastName(string personId);
    }
}
