using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public static class Messages
    {
        public static string addedEntity = "Entity is added";
        public static string operationSuccessfully = "the operation was successfully performed.";
        public static string AuthorizationDenied = "Authorization Denied";
        public static string UserRegistered = "User Registered";
        public static string UserNotFound ="User Not Found";

        public static string PasswordError="Password Error";
        public static string SuccessfulyLogin="Succesfly Login";
        public static string UserAlreadyExists = "User Already Exists";
        public static string AccessTokenCreated="Access Token Created";
    }
}
