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
        private readonly Person _person;

        public PersonJWT(Person person)
        {
            _person = person;
        }

        private ClaimsIdentity GetIdentity()
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, _person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, _person.Role)
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
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LifeTime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new ResponseJWT() 
            {
                Token = encodedJwt, 
                Username = identity.Name,
                CopyForSwaggerTesting = $"Bearer {encodedJwt}"
            };
        }
    }
}
