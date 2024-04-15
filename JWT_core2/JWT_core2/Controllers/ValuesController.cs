using JWT_core2.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_core2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;

        public void Connect()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connectionString);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Hello world");
        }

        //[HttpPost("login")] // Specify the route for the login endpoint
        //public IActionResult Login(User user)
        //{
        //    try
        //    {
        //        Connect();
        //        var command = new SqlCommand("dbo.ValidateUser", connection);
        //        command.CommandType = CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@Username", user.UserName);
        //        command.Parameters.AddWithValue("@Password", user.Password);

        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            // User is valid, generate and return a JWT token
        //            var issuer = _configuration["Jwt:Issuer"];
        //            var audience = _configuration["Jwt:Audience"];
        //            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        //            var tokenDescriptor = new SecurityTokenDescriptor
        //            {
        //                Subject = new ClaimsIdentity(new[]
        //                {
        //                    new Claim("Id", Guid.NewGuid().ToString()),
        //                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        //                    new Claim(JwtRegisteredClaimNames.Email, user.UserName),
        //                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //                }),
        //                Expires = DateTime.UtcNow.AddMinutes(5),
        //                Issuer = issuer,
        //                Audience = audience,
        //                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        //            };
        //            var tokenHandler = new JwtSecurityTokenHandler();
        //            var token = tokenHandler.CreateToken(tokenDescriptor);
        //            var jwtToken = tokenHandler.WriteToken(token);
        //            return Ok(jwtToken);
        //        }
        //        else
        //        {
        //            // User is not valid, return an unauthorized response
        //            return Unauthorized();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions, log them, and return an error response
        //        return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
        //    }
        //    finally
        //    {
        //        // Ensure the connection is closed
        //        connection.Close();
        //    }
        //}
    }
}
