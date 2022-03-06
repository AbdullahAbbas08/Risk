﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Risk_Business_Layer.Helpers;
using Risk_Business_Layer.IRepositories.IClient;
using Risk_Business_Layer.IRepositories.IEmployee;
using Risk_Business_Layer.Services.Authentication;
using Risk_Business_Layer.Services.AuthenticationModels;
using Risk_Data_Access_Layer.Constants;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Risk_Business_Layer.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork_Crud unitOfWork;
        private readonly IEmployeeRepo employeeRepo;
        private readonly IClient clientRepo;
        private readonly Helper helper;
        private readonly JWT _jwt;
        public AuthService(UserManager<ApplicationUser> userManager,
                            RoleManager<IdentityRole> roleManager,
                            IOptions<JWT> jwt,
                            IUnitOfWork_Crud unitOfWork,
                            IOptions<Helper> _helper ,
                            IEmployeeRepo EmployeeRepo,
                            IClient clientRepo)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            this.unitOfWork = unitOfWork;
            employeeRepo = EmployeeRepo;
            this.clientRepo = clientRepo;
            helper = _helper.Value;
            _jwt = jwt.Value;
        }

        public async Task<AuthModel> RegisterClient(RegisterClientModel model)
        {
            Client user = new Client();
            #region model Validation
            string ValidateModel ="" ;

            if (await _userManager.FindByNameAsync(model.UserName) is not null)
                ValidateModel = "User Name is already registered" ;

            if (string.IsNullOrEmpty(model.Address))
                ValidateModel += " , Address Cannot be Empty";
               

            if (model.Logo == null && model.LogoPath ==null)
                ValidateModel += " , Logo Image Cannot be Empty" ;

            if ((model.Mobile).Length < 11)
                ValidateModel += " , Mobile Number Invalid " ;

            var city = await unitOfWork.City.Find(x => x.Id == model.CityId);
            if (city.Count() == 0)
            {
                ValidateModel += " , City ID Invalid ";
            }

            var clienttype = await unitOfWork.ClientType.Find(x => x.TypeId == model.ClientTypeId);
            if (clienttype.Count() == 0)
            {
                ValidateModel += " , Client Type Id Invalid ";
            }

            if (!string.IsNullOrEmpty(ValidateModel))
                return new AuthModel { Message = ValidateModel };
            #endregion

            #region Fill Client To Insert
            if(model.LogoPath == null && model.Logo != null)
            {
                user.UserName = model.UserName;
                user.Address = model.Address;
                user.Mobile = model.Mobile;
                user.Name = model.Name;
                user.CityId = model.CityId;
                user.ClientTypeId = model.ClientTypeId;
                user.LogoPath = helper.UploadImage(model.Logo);
            } 
            
            if(model.LogoPath != null && model.Logo == null)
            {
                user.UserName = model.UserName;
                user.Address = model.Address;
                user.Mobile = model.Mobile;
                user.Name = model.Name;
                user.CityId = model.CityId;
                user.ClientTypeId = model.ClientTypeId;
                user.LogoPath = model.LogoPath;
            }
            
            if(model.LogoPath != null && model.Logo != null)
            {
                user.UserName = model.UserName;
                user.Address = model.Address;
                user.Mobile = model.Mobile;
                user.Name = model.Name;
                user.CityId = model.CityId;
                user.ClientTypeId = model.ClientTypeId;
                user.LogoPath =helper.UploadImage(model.Logo);
            }
            #endregion

            #region Create Client 
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthModel { Message = errors  };
            }
            #endregion

            //#region Assign Default Role To Client
            //await _userManager.AddToRoleAsync(user, Roles.Client);
            //#endregion

            #region Create Toaken
            var jwtSecurityToken = await CreateJwtToken(user);
            #endregion

            #region return Authentication Model 
            return new AuthModel
            {
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName
            };
            #endregion

        }

        public async Task<GeneralResponseSingleObject<UpdateEmployee>> UpdateEmployee(UpdateEmployee model)
        {
            GeneralResponseSingleObject<UpdateEmployee> response = new GeneralResponseSingleObject<UpdateEmployee>();

            var employee = (await unitOfWork.Employee.Find(x => x.Id == model.Id)).FirstOrDefault();

            if (employee != null)
            {
                employeeRepo.DeleteEmployee(model.Id);
               var res =  await RegisterEmployee(new RegisterEmployeeModel { 
                    Address=model.Address,
                    Mobile=model.Mobile,
                    Name=model.Name,
                    NationalId=model.NationalId,
                    UserName=model.UserName,
                    Password=model.password 
               });

                if(res.IsAuthenticated)
                response.Message = "تم تعديل بيانات الموظف بنجاح";
                else
                {
                    response.Message = "حدث خطأ ما برجاء المحاولة مرة أخرى";
                    response.Data = model;
                }

            }
            else
            response.Message = "لا توجد بيانات لهذا الكود";

            return response;
        }

        public async Task<GeneralResponseSingleObject<UpdateClientModel>> UpdateClient(UpdateClientModel model)
        {
            GeneralResponseSingleObject<UpdateClientModel> response = new GeneralResponseSingleObject<UpdateClientModel>();

            var client = (await unitOfWork.Client.Find(x => x.Id == model.Id)).FirstOrDefault();

            if (client != null)
            {
                clientRepo.DeleteUser(model.Id);
                var res = await RegisterClient(new RegisterClientModel
                {
                   Address=model.Address,
                   CityId=model.CityId,
                   ClientTypeId=model.ClientTypeId,
                   Mobile=model.Mobile,
                   Name = model.Name,
                   UserName=model.UserName,
                   Logo = model.Logo,
                   LogoPath=model.LogoPath,
                   Password= model.Password
                });

                if (res.IsAuthenticated)
                    response.Message = "تم تعديل بيانات العميل بنجاح";
                else
                {
                    response.Message = "حدث خطأ ما برجاء المحاولة مرة أخرى";
                    response.Data = model;
                }

            }
            else
                response.Message = "لا توجد بيانات لهذا الكود";

            return response;

        }

        public async Task<AuthModel> RegisterEmployee(RegisterEmployeeModel model)
        {
            #region model Validation
            string ValidateModel = "";

            if (await _userManager.FindByNameAsync(model.UserName) is not null)
                ValidateModel = "User Name is already registered";

            if (string.IsNullOrEmpty(model.Address))
                ValidateModel += " , Address Cannot be Empty";

            if ((model.NationalId).Length < 14)
                ValidateModel += " , National ID Invalid Or Less than 14 Numbers  ";

            if ((model.Mobile).Length < 11)
                ValidateModel += " , Mobile Number Invalid ";

            if (!string.IsNullOrEmpty(ValidateModel))
                return new AuthModel { Message = ValidateModel };
            #endregion

            #region Fill Employee To Insert
            var user = new Employee
            {
                UserName = model.UserName,
                Address = model.Address,
                Mobile = model.Mobile,
                Name = model.Name,
                NationalId = model.NationalId,
            };
            #endregion

            #region Create Employee 
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthModel { Message = errors };
            }
            #endregion

            #region Create Toaken
            var jwtSecurityToken = await CreateJwtToken(user);
            #endregion

            #region return Authentication Model 
            return new AuthModel
            {
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName
            };
            #endregion
        }

        public async Task<AuthModel> Login(TokenRequestModel model) 
        {
            #region Generate Object typeOf AuthModel => If UserName & Passowrd : True || Login Successfully
            var authModel = new AuthModel();
            #endregion

            #region Check If User Exist 
            var user = await _userManager.FindByNameAsync(model.UserName);
            #endregion

            #region Check If UserName & Passowrd  =>  True
            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "UserName or Password is incorrect!";
                return authModel;
            }
            #endregion

            #region Create Toaken
            var jwtSecurityToken = await CreateJwtToken(user);
            #endregion

            #region Prepare Returned Object
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Username = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            #endregion

            #region return Object typeOf AuthModel
            return authModel;
            #endregion
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        public Task<string> AddRoleAsync(AddRoleModel model)
        {
            throw new NotImplementedException();
        }

    }
}
