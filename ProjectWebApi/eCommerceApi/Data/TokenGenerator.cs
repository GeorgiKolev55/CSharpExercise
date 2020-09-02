using eCommerceApi.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApi.Data
{
    public class TokenGenerator
    {
      //  public static async Task Main(string[] args)
      //  {
      //      var user = new User { UserId = 1, EmailAddress = "cat@houseofcat.io", FirstName = "House", LastName = "Cat" };
      //      var userData = new UserData { AccountId = 1 };
      //      var issuer = "https://houseofcat.io";
      //      var authority = "https://houseofcat.io"; // or https://authorityprovider.com/ etc
      //
      //      //Issuer & Authority Note: If your app or API is the issuer and authority they will be the exact same field. They but don't have to be, key distinction.
      //
      //      //256-bit string generated on https://passwordsgenerator.net/
      //      var privateKey = "J6k2eVCTXDp5b97u6gNH5GaaqHDxCmzz2wv3PRPFRsuW2UavK8LGPRauC4VSeaetKTMtVmVzAC8fh8Psvp8PFybEvpYnULHfRpM8TA2an7GFehrLLvawVJdSRqh2unCnWehhh2SJMMg5bktRRapA8EGSgQUV8TCafqdSEHNWnGXTjjsMEjUpaxcADDNZLSYPMyPSfp6qe5LMcd5S9bXH97KeeMGyZTS2U8gp3LGk2kH4J4F3fsytfpe9H9qKwgjb";
      //      var daysValid = 7;
      //
      //      var createJwt = await CreateJWTAsync(user, userData, issuer, authority, privateKey, daysValid);
      //
      //      await Console.Out.WriteLineAsync(createJwt);
      //      await Console.In.ReadLineAsync();
      //  }
      // public static async Task<string> CreateJWTAsync(
      //     User user,
      //     SqlUserRepository userData,
      //     string issuer,
      //     string authority,
      //     string symSec,
      //     int daysValid)
      // {
      //     var tokenHandler = new JwtSecurityTokenHandler();
      //     var claims = await CreateClaimsIdentities(user, userData);
      //
      //     // Create JWToken
      //     var token = tokenHandler.CreateJwtSecurityToken(issuer: issuer,
      //         audience: authority,
      //         subject: claims,
      //         notBefore: DateTime.UtcNow,
      //         expires: DateTime.UtcNow.AddDays(daysValid),
      //         signingCredentials:
      //         new SigningCredentials(
      //             new SymmetricSecurityKey(
      //                 Encoding.Default.GetBytes(symSec)),
      //                 SecurityAlgorithms.HmacSha256Signature));
      //
      //     return tokenHandler.WriteToken(token);
      // }
       // public static Task<ClaimsIdentity> CreateClaimsIdentities(User user, SqlUserRepository userData)
       // {
       //     ClaimsIdentity claimsIdentity = new ClaimsIdentity();
       //     claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.EmailAddress));
       //     claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
       //     claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.FullName ?? $"{user.Username}"));
       //     claimsIdentity.AddClaim(new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(userData)));
       //
       //     var roles = Enumerable.Empty<Role>(); // Not a real list.
       //
       //     foreach (var role in roles)
       //     { claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.RoleName)); }
       //
       //     return Task.FromResult(claimsIdentity);
       // }

    }
}
