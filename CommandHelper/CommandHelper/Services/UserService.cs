﻿using CommandHelper.Data.DataDB;
using CommandHelper.Data.IdentityService;
using CommandHelper.DtoModels;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommandHelper.Services
{
    public class UserService : IUserService
    {
        private CommanderContext _dbContext;

        public UserService(CommanderContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Login(UserLoginDTO model)
        {
            using (_dbContext)
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.UserName == model.Username);
                if (user != null)
                {
                    if (user.Password == Hash(model.Password))
                    {
                        var token = TokenGenerator(model.Username);

                        return token;
                    }
                }
                return string.Empty;
            }
        }

        public string Register(UserRegisterDTO model)
        {
            try
            {
                using (_dbContext)
                {
                    if (_dbContext.Users.FirstOrDefault(x => x.UserName == model.Username) == null)
                    {
                        bool passwordValidation = CheckUserPassword(model);
                        if (passwordValidation == true)
                        {
                            string hashedPassword = Hash(model.Password);
                            _dbContext.Users.Add(new Models.User()
                            {
                                UserName = model.Username,
                                Password = hashedPassword
                            });
                            _dbContext.SaveChanges();
                        }

                        return TokenGenerator(model.Username);
                    }
                    return string.Empty;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private string TokenGenerator(string username)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = Path.Combine(path, "appsettings.json");
            string salt;
            string issuer;
            string audience;
            double accessExpiration;

            using (StreamReader sr = new StreamReader(file))
            {
                string content = sr.ReadToEnd();
                JObject jsonObject = (JObject)JsonConvert.DeserializeObject(content);
                salt = jsonObject["secret"].Value<string>();
                issuer = jsonObject["Issuer"].Value<string>();
                audience = jsonObject["audience"].Value<string>();
                accessExpiration = jsonObject["AccessExpiration"].Value<double>();

            }
            var claim = new List<Claim>()
                                {
                                  new Claim(ClaimTypes.Name,username),

                                };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(salt));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer,
                audience,
                claim,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
            );
            string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            SecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken decodedJsonWebToken = handler.ReadToken(token) as JwtSecurityToken;
            DateTime jwtExpirationDate = decodedJsonWebToken.ValidTo.ToLocalTime();
            return token;
        }
        private string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            return Convert.ToBase64String(hashBytes);
        }

        private bool CheckUserPassword(UserRegisterDTO model)
        {
            bool result = model.Password.Any(c => char.IsDigit(c));
                          
            if (result == true)
            {
                if (model.Password == model.ConfirmPassword)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
