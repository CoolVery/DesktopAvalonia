using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestRepeat.ViewModels.AuthorizationViewModel
{
    public class AuthorizationVMAdditionalMethods
    {
        public static void CreateAndWrite()
        {
            CreateAndWriteWork();
        }
        static void CreateAndWriteWork()
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string path = Directory.GetCurrentDirectory();
            using SHA256CryptoServiceProvider hash = new SHA256CryptoServiceProvider();
            string nameFile = Regex.Replace(Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(userName))), @"[\/:*?""<>|]", "");
            string fullPath = path + "\\" + nameFile + ".txt";
            File.Create(fullPath);
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface ni in interfaces)
            {
                if (ni.OperationalStatus ==
                    OperationalStatus.Up && ni.GetPhysicalAddress().GetAddressBytes().Length != 0)
                {
                    Console.WriteLine("Название        : {0}", ni.Name);
                    Console.WriteLine("Описание        : {0}", ni.Description);
                    Console.WriteLine("MAC-адрес       : {0}", ni.GetPhysicalAddress().ToString());
                    Console.WriteLine();
                }
            }
            using (FileStream fs = File.OpenWrite(fullPath)) { 
                
            }
        }
    }
}
