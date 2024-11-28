using System.Net;

namespace MovieSystem.Application.Helper
{
    public class GetHostName
    {
        public static string? HostName { get; set; } = Dns.GetHostName();
        public static string IPaddress { get; set; } = GetIP(HostName);


        public static string GetIP(string host)
        {
            int cntr = 0;
            string Result = "";
            IPAddress[] ipaddress = Dns.GetHostAddresses(host);

            foreach (IPAddress ip in ipaddress)
            {
                if (cntr != 0)
                {
                    Result += ip.ToString() + "-";
                }
                cntr += 1;
            }
            return Result.Substring(0, Result.Length - 1);
        }
    }
}
