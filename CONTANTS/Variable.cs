using COMMON.Utilities;

namespace CONTANTS
{
    public class Variable
    {
        public static String STRINGCONNECTION { get { return (HelperConfiguration.GetParam("STRINGCONNECTION") ?? ""); } }
    }
}
