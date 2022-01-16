using System.Collections.Generic;

namespace WorkApp.Web.OutputModels
{
    public class ErrorOutputModel
    {
        public ErrorOutputModel(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        public IEnumerable<string> Errors { get; set; }
    }
}
