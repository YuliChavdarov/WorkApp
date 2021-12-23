using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkApp.Data.Models.Common
{
    /// <summary>
    /// Constants for the application models. Migration must be applied for changes to take effect.
    /// </summary>
    public static class ModelConstants
    {
        public static class ApplicationUser
        {
            public const int FirstNameMaxLength = 50;
            public const int LastNameMaxLength = 50;
        }

        public static class Client
        {
            public const int CompanyNameMaxLength = 100;
        }

        public static class Job
        {
            public const int TitleMaxLength = 200;
            public const int DescriptionMaxLength = 2000;
            public const int MinHourlyPayment = 0;
            public const int MaxHourlyPayment = 1000000;
            public const string HourlyPaymentColumnTypeName = "decimal(18,2)";
        }

        public static class Worker
        {
            public const int MinHourlyPayment = 0;
            public const int MaxHourlyPayment = 1000000;
            public const int DescriptionMaxLength = 1000;
            public const int AddressMaxLength = 150;
            public const string HourlyPaymentColumnTypeName = "decimal(18,2)";
        }
    }
}
