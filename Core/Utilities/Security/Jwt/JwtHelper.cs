using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get;  }
        private TokenOptions _tokenOptions;
        private DateTime _accesTokenExpiration;

        public JwtHelper(IConfiguration configuration, TokenOptions tokenOptions, DateTime accesTokenExpiration)
        {
            Configuration = configuration;
            _accesTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            //her seferinde section olarak yazmaktansa direk TokenOptions a atıyoruz appsettings dekini
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }


        public AccessToken CreateToken(UserForJwt userForJwt, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, userForJwt, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accesTokenExpiration
            };



        }

        public JwtSecurityToken CreateJwtSecurityToken(
            TokenOptions tokenOptions, UserForJwt userForJwt, SigningCredentials signingCredentials,
            List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accesTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(userForJwt, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(UserForJwt userForJwt, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(userForJwt.Id.ToString());
            claims.AddEmail(userForJwt.Email);
            claims.AddName($"{userForJwt.FirstName} {userForJwt.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;

        }
    }
}
