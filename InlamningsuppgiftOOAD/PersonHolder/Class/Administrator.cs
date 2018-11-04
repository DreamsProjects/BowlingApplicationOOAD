using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHolder.Class
{
    public class Administrator
    {
        private static Administrator _instance;
        private string _adminEmail { get; }

        // Constructor is 'protected'

        protected Administrator()
        {
            _adminEmail = "admin@mail.com";
        }

        public static Administrator GetInstance()
        {
            // Uses lazy initialization.

            // Note: this is not thread safe.

            if (_instance == null)
            {
                _instance = new Administrator();
            }

            return _instance;
        }

        public bool IsAdmin(string email)
        {
            return _adminEmail.Equals(email);
        }
    }
}
