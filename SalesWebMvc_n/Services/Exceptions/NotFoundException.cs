using System;

namespace SalesWebMvc_n.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message){ 
        
        }
    }
}
