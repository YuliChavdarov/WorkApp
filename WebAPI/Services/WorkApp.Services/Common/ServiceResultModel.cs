using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkApp.Services.Common
{
    public class ServiceResultModel
    {
        public ServiceResultModel()
        {
            Errors = new List<string>();
        }

        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }

    public class ServiceResultModel<T>
    {
        public ServiceResultModel()
        {
            Errors = new List<string>();
        }

        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public T Result { get; set; }
    }
}
