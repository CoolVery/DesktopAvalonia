using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace TestRepeat.ViewModels.AuthorizationViewModel
{
    public class AuthorizationVMAdditionalMethods
    {
        public static string[] ReadFile(string fullPath)
        {
            string macAddress = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"])
                {
                    macAddress = mo["MacAddress"].ToString();
                    break;
                }
            }
            string[] allLines = new string[3];
            using (BinaryReader reader = new BinaryReader(File.Open(fullPath, FileMode.Open)))
            {
                allLines[0] = reader.ReadString();
                allLines[1] = reader.ReadString();
                allLines[2] = reader.ReadString();

            }
            
            string base64Mac = allLines[0];
            if (Encoding.UTF8.GetString(Convert.FromBase64String(base64Mac)) == macAddress)
            {
                string[] loginAndPassword = new string[2];
                loginAndPassword[0] = Encoding.UTF8.GetString(Convert.FromBase64String(allLines[1]));
                loginAndPassword[1] = Encoding.UTF8.GetString(Convert.FromBase64String(allLines[2]));

                return loginAndPassword;
            }
            else
            {
                return null;
            }
        }

        public static void CreateAndWriteWork(string login, string password)
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string path = Directory.GetCurrentDirectory();
            using SHA256Managed hash = new SHA256Managed();
            string nameFile = Regex.Replace(Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(userName))), @"[\/:*?""<>|]", "");
            string fullPath = path + "\\" + nameFile + ".bin";

            string macAddress = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"])
                {
                    macAddress = mo["MacAddress"].ToString();
                    break;
                }
            }
            using (BinaryWriter writer = new BinaryWriter(File.Open(fullPath, FileMode.Create)))
            {
                writer.Write(Convert.ToBase64String(Encoding.UTF8.GetBytes(macAddress)));
                writer.Write(Convert.ToBase64String(Encoding.UTF8.GetBytes(login)));
                writer.Write(Convert.ToBase64String(Encoding.UTF8.GetBytes(password)));
            }
            hash.Dispose();
            //byte[] line = File.ReadAllBytes(fullPath);
            //if (hash.ComputeHash(Encoding.UTF8.GetBytes(macAddress)).SequenceEqual(line))
            //{
            //    return;
            //}
        }
    }
}

