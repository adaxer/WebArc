using System;
using System.Collections.Generic;
using System.Text;

namespace SharedElements
{
    public class GoodbyeService
    {
        public string GoodBye => "Goodbye";

#if NETFX
        System.Data.SqlClient.SqlConnection connection;
#endif
    }
}
