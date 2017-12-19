using StayHealthy.Entities;
using StayHealthy.Entities.Model;
using StayHealthy.Entities.UnitOfWork;
using StayHealthy.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web;

namespace StayHealthy.API.Controllers
{
    [RoutePrefix("api")]
    public class UserApiController : ApiController
    {
        UnitOfWork uow = new UnitOfWork();

        [Route("GetUserList")]
        public HttpResponseMessage GetUserList()
        {
            var userList = uow.Repository<UserModel>().SQLQuery("EXEC GetUserList").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, userList);
        }

        [Route("GetUserDetail")]
        public ApiResponse<UserModel> GetUserDetail(string Email, string Password)
        {
            ApiResponse<UserModel> response = new ApiResponse<UserModel>();
            var userDetail = uow.Repository<UserModel>().SQLQuery("EXEC GetUserDetail @Email,@Password",
                new object[]
                {
                    new SqlParameter("@Email",Email),
                    new SqlParameter("@Password",Security.Encrypt(Password))
                }
                ).FirstOrDefault();

            if (userDetail != null)
            {
                response.Success = true;
                response.Data.Add(userDetail);
            }

            return response;
        }

        [Route("RegistrationUser")]
        public ApiResponse<LoginModel> RegistrationUser(LoginModel model)
        {
            ApiResponse<LoginModel> response = new ApiResponse<LoginModel>();
            var userDetail = uow.Repository<LoginModel>().SQLQuery("EXEC spRegisterUser @firstname,@lastname,@email,@password,@gender",
                new object[]
                {
                    new SqlParameter("@firstname",model.FirstName),
                    new SqlParameter("@lastname",model.LastName),
                    new SqlParameter("@email",model.EmailAddress),
                    new SqlParameter("@password",Security.Encrypt(model.Password)),
                    new SqlParameter("@gender",model.GenderType)
                }
                ).FirstOrDefault();

            if (userDetail != null)
            {
                response.Success = true;
                response.Data.Add(userDetail);

                if (userDetail.UserId > 0)
                {
                    System.Net.Mail.MailMessage mailMesg = new System.Net.Mail.MailMessage(System.Configuration.ConfigurationManager.AppSettings["FromMail"], model.EmailAddress);
                    mailMesg.Subject = "Welcome to Stay Healthy World Community";

                    string body = string.Empty;
                    //using streamreader for reading my htmltemplate   

                    using (StreamReader reader = new StreamReader(System.Web.Hosting.HostingEnvironment.MapPath("~/EmailTemplate/RegistrationEmail.html")))
                    {
                        body = reader.ReadToEnd();
                    }

                    body = body.Replace("[Fname]", model.FirstName); //replacing the required things  

                    body = body.Replace("[Lname]", model.LastName);

                    //body = body.Replace("{message}", message);  


                    mailMesg.Body = body;
                    mailMesg.IsBodyHtml = true;

                    var objSMTP = new SmtpClient
                    {
                        Host = System.Configuration.ConfigurationManager.AppSettings["Host"],
                        Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Port"]),
                        EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EnableSsl"]),
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["FromMail"], System.Configuration.ConfigurationManager.AppSettings["Password"])
                    };

                    try
                    {
                        objSMTP.Send(mailMesg);
                    }
                    catch (Exception ex)
                    {
                        mailMesg.Dispose();
                        mailMesg = null;
                    }
                }
            }
            return response;
        }

        [Route("GetUserDetailById")]
        public ApiResponse<UserModel> GetUserDetailById(int Id)
        {
            ApiResponse<UserModel> response = new ApiResponse<UserModel>();
            var userDetail = uow.Repository<UserModel>().SQLQuery("EXEC sp_GetUserDetailById @Id",
                new object[]
                {
                    new SqlParameter("@Id",Id),
                }
                ).FirstOrDefault();

            if (userDetail != null)
            {
                response.Data.Add(userDetail);
            }
            return response;
        }

    }
}
