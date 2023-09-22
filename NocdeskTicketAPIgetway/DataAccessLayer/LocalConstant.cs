using NocdeskTicketAPIgetway.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TectonaDatabaseHandlerDLL;

namespace NocdeskTicketAPIgetway.DataAccessLayer
{
    public class LocalConstant
    {
        public static DatabasePool poolNocdesk;

        public static DatabasePool TicketMasterPool;

        public static DatabasePool ServiceDeliveryPool;

        public static DatabasePool TemplateMasterPool;

        public static DatabasePool NotificationMasterpool;

        public static string NocdeskTicket = "";
        public static string LINUX_ROOT_PATH = "";
        public static string LINUX_WWW_PATH = "";

        public static string MESSAGING_FILE = ".xml";
        public static TecRedisTCP objRedis;
        public static string RedisServer = "127.0.0.1";
        public static int RedisServerPort = 6379;
        public static int RedisDB = 12;

    }
}
