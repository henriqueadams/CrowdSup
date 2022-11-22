using System.Security.Cryptography;
using System.Text;
using CrowdSup.Domain.Interfaces.DomainServices.Hash;

namespace CrowdSup.Domain.DomainServices.Hash
{
    public class HashService : IHashService
    {
        public string GerarMd5(string senha)
        {
            MD5 md5Hash = MD5.Create();
            
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}