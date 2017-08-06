using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if NETFX
using System.Data.SqlClient;
#endif

namespace FullNetLibrary
{
    public class WelcomeService
    {
        public string Hello() => "Hello";

#if NETFX
        private SqlConnection connection;
#endif
    }

}
