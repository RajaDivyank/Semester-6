using System;
using System.Text;

class Program
{
    static void Main()
    {
        string routeId = "ShSQx8V18oc=";
        byte[] data = Convert.FromBase64String(routeId);
        string decodedRouteId = Encoding.UTF8.GetString(data);
        Console.WriteLine(decodedRouteId);
    }
}
