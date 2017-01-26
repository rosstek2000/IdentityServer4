using ALPAIdentityServer.Models;
using ALPAIdentityServer.Models.AIROViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ALPAIdentityServer.Controllers.AIROAPI
{
    public class AERORepository : IAERORepository
    {
        private AIRODbContext _context;

        public AERORepository()
        {
            _context = AIRODbContext.Create();
        }
        public List<PersonViewModel> GetPerson(int Id)
        {
            List<PersonViewModel> test = new List<PersonViewModel>();
            var Queryablemodel = (from x in _context.Person

                                  select new PersonViewModel
                                  {
                                      Id = x.Id,
                                      FirstName = x.FirstName,
                                      FirstLast = x.FirstLast
                                  }).Where(c=> c.Id == Id).AsQueryable().ToList<PersonViewModel>();

            return Queryablemodel;

        }

        public List<PersonViewModel> GetPersonByAlpaId(string Id)
        {
            List<PersonViewModel> test = new List<PersonViewModel>();
            var Queryablemodel = (from x in _context.vwPersons
                                  select new PersonViewModel
                                  {
                                      Id = x.ID,
                                      FirstName = x.FirstName,
                                      FirstLast = x.FirstLast,
                                      AddressID = x.AddressID ?? 0,
                                      AddressLine1 = x.AddressLine1,
                                      AddressLine2 = x.AddressLine2,
                                      City = x.City,
                                      State = x.State,
                                      ZipCode = x.ZipCode,
                                      Gender = x.Gender,
                                      ALPAID__c = x.ALPAID__c,
                                      FormattedAddress = x.FormattedAddress,
                                      Birthday = x.Birthday,
                                      FormattedPhone = x.FormattedPhone,
                                      Country = x.Country
                                  }).Where(c => c.ALPAID__c == Id).AsQueryable().ToList<PersonViewModel>();

            return Queryablemodel;

        }

        public List<PersonViewModel> GetPersonByLastName(string Id)
        {
            List<PersonViewModel> test = new List<PersonViewModel>();
            var Queryablemodel = (from x in _context.vwPersons
                                  select new PersonViewModel
                                  {
                                      Id = x.ID,
                                      FirstName = x.FirstName,
                                      FirstLast = x.FirstLast,
                                      LastName = x.LastName,
                                      AddressID = x.AddressID ?? 0,
                                      AddressLine1 = x.AddressLine1,
                                      AddressLine2 = x.AddressLine2,
                                      City = x.City,
                                      State = x.State,
                                      ZipCode = x.ZipCode,
                                      Gender = x.Gender,
                                      ALPAID__c = x.ALPAID__c,
                                      FormattedAddress = x.FormattedAddress,
                                      Birthday = x.Birthday,
                                      FormattedPhone = x.FormattedPhone,
                                      Country = x.Country
                                  }).Where(c => c.LastName == Id).AsQueryable().ToList<PersonViewModel>();

            return Queryablemodel;

        }

      

        public List<PersonViewModel> GetPersonUsingView(int personId)
        {
            List<PersonViewModel> test = new List<PersonViewModel>();
            var Queryablemodel = (from x in _context.vwPersons

                                  select new PersonViewModel
                                  {
                                      Id = x.ID,
                                      FirstName = x.FirstName,
                                      FirstLast = x.FirstLast,
                                      AddressLine1 = x.AddressLine1,
                                      AddressLine2 = x.AddressLine2,
                                      City = x.City,
                                      State = x.State,
                                      ZipCode = x.ZipCode,
                                      Gender = x.Gender
                                                                           
                                  }).Where(c => c.Id == personId).AsQueryable().ToList<PersonViewModel>();

            return Queryablemodel;

        }

      
    }
}