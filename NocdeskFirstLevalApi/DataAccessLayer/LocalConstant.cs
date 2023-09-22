using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TectonaDatabaseHandlerDLL;

namespace NocdeskFirstLevalApi.DataAccessLayer
{
    public class LocalConstant
    {
        public static DatabasePool poolNocdesk;

        public static DatabasePool ServiceDeliveryPool;

        public static string NOCDeskSecondLevelMS = "https://localhost";
        public static string LINUX_ROOT_PATH = "";
        public static string LINUX_WWW_PATH = "";
    }
}
