using System;


namespace SalesWebMvc_n.Services
{
    public class IntegrityException:ApplicationException
    {
        public IntegrityException(string message) : base(message) { 
        
        }
    }
}
