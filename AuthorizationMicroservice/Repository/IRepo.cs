using AuthorizationMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Repository
{
    public interface IRepo
    {
        dynamic getuserByAadhar(LoginModel loginModel );
       

    }


}
