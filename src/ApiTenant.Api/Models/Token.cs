using System;

namespace ApiTenant.Api.Common.Controllers
{
    public class Token
    {
        public Token(string tenant)
        {
            if (string.IsNullOrEmpty(tenant))
                throw new ArgumentNullException("Cant generate token without tenant");

            if (tenant != "oi" && tenant != "btc" && tenant != "entelch" && tenant != "entelpe" && tenant != "vodafone")
                throw new InvalidOperationException("Tenant undefined");


            Key = StringCipher.Encrypt(tenant, "");
        }

        public string Key { get; }
    }
}
