using System;
using System.Collections.Generic;
using JeSuisCatho.Web.API.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using JeSuisCatho.Shared.MPESA;

namespace JeSuisCatho.Web.API.Controllers
{
    public class MpesaController : Controller
    {

        private static readonly HttpClient client = new HttpClient();

        public MpesaController()
        {
           
        }

        [Route("mpesa-auth")]
        public async Task<IActionResult> MpesaConsumer()
        {
            var authUrl = "https://sandbox.safaricom.co.ke/oauth/v1/generate?grant_type=client_credentials";
            var appKey = "GGxmkAeepvhZcAqzOVWVFhT0zGzTnNY4";
            var appSecret = "x0xirDzXWxMD4QF5";

            var serverUrl = new Credential
            {
                MpesaHomeUrl = $"{authUrl}",
                AppKey = $"{appKey}",
                AppSecret = $"{appSecret}"

            };





            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("cache-control", "no-cache");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                System.Text.ASCIIEncoding.ASCII.GetBytes($"{serverUrl.AppKey}:{serverUrl.AppSecret}")));

            var responds = await client.GetStringAsync($"{serverUrl.MpesaHomeUrl}");

            return Ok(responds);

        }
    }
}
