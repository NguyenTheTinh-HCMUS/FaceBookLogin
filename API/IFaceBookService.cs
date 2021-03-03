using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public interface IFaceBookService
    {
       
        public Task<FaceBookTokenValidationResult> ValidateAccessTokenAccess(string accessToken);
        public Task<FaceBookUserInfoResult> GetUserInforAsync(string accessToken);
    }
}
