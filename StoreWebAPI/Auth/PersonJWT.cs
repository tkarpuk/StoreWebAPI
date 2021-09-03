using Microsoft.IdentityModel.Tokens;
using StoreWebAPI.Models.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace StoreWebAPI.Auth
{
    public class PersonJWT
    {
        private readonly Person Person;

        public PersonJWT(Person person)
        {
            Person = person;
        }

        private ClaimsIdentity GetIdentity()
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, Person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, Person.Role)
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        public ResponseJWT CreateJWT()
        {
            var identity = GetIdentity();
            var now = DateTime.UtcNow;

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new ResponseJWT() {access_token = encodedJwt, username = identity.Name };
        }
    }
}
