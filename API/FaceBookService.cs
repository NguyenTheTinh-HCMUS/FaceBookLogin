using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API
{
    public class FaceBookService : IFaceBookService
    {
        private const string TokenValidationUrl = "https://graph.facebook.com/debug_token?input_token={0}&access_token={1}|{2}";
        private const string UserInfoUrl = "https://graph.facebook.com/me?fields=id,email,picture,first_name,last_name&access_token={0}";
        private readonly FaceBookOption _faceBookOption;
        private readonly IHttpClientFactory _httpClientFactory;
        public FaceBookService(FaceBookOption faceBookOption,IHttpClientFactory httpClientFactory)
        {
            _faceBookOption = faceBookOption;
            _httpClientFactory = httpClientFactory;


        }
        public async Task<FaceBookUserInfoResult> GetUserInforAsync(string accessToken)
        {
            var formattedUrl = string.Format(UserInfoUrl,
                                                accessToken);
            var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);
            result.EnsureSuccessStatusCode();
            var responseAsString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FaceBookUserInfoResult>(responseAsString);
        }

        public async Task<FaceBookTokenValidationResult> ValidateAccessTokenAccess(string accessToken)
        {
            var formattedUrl = string.Format(TokenValidationUrl, 
                                                accessToken,
                                                _faceBookOption.AppId, 
                                                _faceBookOption.AppSecret);
            var result = await _httpClientFactory.CreateClient().GetAsync(formattedUrl);
            result.EnsureSuccessStatusCode();
            var responseAsString = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FaceBookTokenValidationResult>(responseAsString);
        }
    }
}
