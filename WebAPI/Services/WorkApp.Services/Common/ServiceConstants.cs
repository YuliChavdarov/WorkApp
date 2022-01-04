using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkApp.Services.Common
{
    public static class ServiceConstants
    {
        public static class Errors
        {
            public static string UserEmailNotFound = "User with this email was not found.";
            public static string ProfileAlreadyCreated = "Profile is already created.";
            public static string UserIdNotFound = "User not found.";
            public static string IncorrectPassword = "Incorrect password.";
            public static string UnknownUserType = "Unknown user type.";
        }

        public static class ClaimNames
        {
            public const string Address = "Address";
            public const string Description = "Description";
            public const string Title = "Title";
            public const string HourlyRate = "HourlyRate";
            public const string CompanyName = "CompanyName";
            public const string City = "City";

            public const string UserType = "UserType";
        }

        public static class ClaimValues
        {
            public const string ClientUserType = "Client";
            public const string WorkerUserType = "Worker";
        }

        public static class PolicyNames
        {
            public const string WorkersOnly = "WorkersOnly";
            public const string ClientsOnly = "ClientsOnly";
        }
    }
}
