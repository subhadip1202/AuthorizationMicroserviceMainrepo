using AuthorizationMicroservice.Data;
using AuthorizationMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Repository
{
    public class Repo : IRepo
    {
        private readonly MOnePensionDbContext _pensionDbContext;

        public Repo(MOnePensionDbContext pensionDbContext)
        {
            _pensionDbContext = pensionDbContext;

        }

        public dynamic getuserByAadhar(LoginModel loginModel)
        {
            
            return _pensionDbContext.loginModels.FirstOrDefault(x => x.aadharno == loginModel.aadharno &&  x.Password == loginModel.Password);
        }
       

    }
}
