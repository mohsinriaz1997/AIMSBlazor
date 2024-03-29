﻿using Backend.General;
using Backend.Interfaces.AdministrationData;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace CA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationDataController : ControllerBase
    {
        private IUserProfile _mstUserProfile;
       

        public AdministrationDataController(IUserProfile mstUserProfile)
        {
            _mstUserProfile = mstUserProfile;
            
        }

        #region MstUserProfile

        [Route("getAllUserProfile")]
        [HttpGet]
        public async Task<IActionResult> GetAllUserProfile()
        {
            List<MstUserProfile> oMstUserProfile = new List<MstUserProfile>();
            try
            {
                oMstUserProfile = await _mstUserProfile.GetAllData();
                if (oMstUserProfile == null)
                {
                    return BadRequest(oMstUserProfile);
                }
                else
                {
                    return Ok(oMstUserProfile);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addUserProfile")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstUserProfile pMstUserProfile)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUserProfile.Insert(pMstUserProfile);
                if (response == null)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("updateUserProfile")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstUserProfile pMstUserProfile)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUserProfile.Update(pMstUserProfile);
                if (response == null)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("validateLogin")]
        [HttpGet]
        public async Task<IActionResult> ValidateLogin([FromBody] MstUserProfile pUser)
        {
            MstUserProfile oUser = new MstUserProfile();
            try
            {
                oUser = await _mstUserProfile.ValidateLogin(pUser.UserCode, pUser.Password);
                if (oUser == null)
                {
                    return BadRequest(oUser);
                }
                else
                {
                    return Ok(oUser);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("getAllMenu")]
        [HttpGet]
        public async Task<IActionResult> GetMenu()
        {
            List<MstMenu> oMstMenu = new List<MstMenu>();
            try
            {
                oMstMenu = await _mstUserProfile.GetAllMenu();
                if (oMstMenu == null)
                {
                    return BadRequest(oMstMenu);
                }
                else
                {
                    return Ok(oMstMenu);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("getUserAuthorization")]
        [HttpGet]
        public async Task<IActionResult> FetchUserAuth(int userID)
        {
            List<UserAuthorization> oUserAuthorization = new List<UserAuthorization>();
            try
            {
                oUserAuthorization = await _mstUserProfile.FetchUserAuth(userID);
                if (oUserAuthorization == null)
                {
                    return BadRequest(oUserAuthorization);
                }
                else
                {
                    return Ok(oUserAuthorization);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addUserAuth")]
        [HttpPost]
        public async Task<IActionResult> AddUserAuth([FromBody] List<UserAuthorization> pUserAuthorization)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUserProfile.AddUserAuthorization(pUserAuthorization);
                if (response == null)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("generateOTP")]
        [HttpGet]
        public async Task<IActionResult> GenerateOTP([FromBody] MstUserProfile pMstUser)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUserProfile.GenerateOTP(pMstUser);
                if (response == null)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("authenticateOTP")]
        [HttpGet]
        public async Task<IActionResult> AuthenticateOTP([FromBody] PasswordReset pPasswordReset)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUserProfile.AuthenticateOTP(pPasswordReset);
                if (response == null)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }
        [Route("changePassword")]
        [HttpGet]
        public async Task<IActionResult> ChangePassword([FromBody] MstUserProfile pMstUser)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUserProfile.ChangePassword(pMstUser);
                if (response == null)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("getAllFormAndCostType")]
        [HttpGet]
        public async Task<IActionResult> GetAllFormCostType(int UserID)
        {
            List<UserDataAccess> oUserDataAccess = new List<UserDataAccess>();
            try
            {
                oUserDataAccess = await _mstUserProfile.GetAllFormAndCostType(UserID);
                if (oUserDataAccess == null)
                {
                    return BadRequest(oUserDataAccess);
                }
                else
                {
                    return Ok(oUserDataAccess);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }
        [Route("GetAllFormAndCostTypesResource")]
        [HttpGet]
        public async Task<IActionResult> GetAllFormCostTypes(string UserID)
        {
            List<UserDataAccess> oUserDataAccess = new List<UserDataAccess>();
            try
            {
                oUserDataAccess = await _mstUserProfile.GetAllFormAndCostTypesResource(UserID);
                if (oUserDataAccess == null)
                {
                    return BadRequest(oUserDataAccess);
                }
                else
                {
                    return Ok(oUserDataAccess);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }
        [Route("GetAllFormAndCostTypesFOHRate")]
        [HttpGet]
        public async Task<IActionResult> GetAllFormAndCostTypesFOHRate(string UserID)
        {
            List<UserDataAccess> oUserDataAccess = new List<UserDataAccess>();
            try
            {
                oUserDataAccess = await _mstUserProfile.GetAllFormAndCostTypesFOHRate(UserID);
                if (oUserDataAccess == null)
                {
                    return BadRequest(oUserDataAccess);
                }
                else
                {
                    return Ok(oUserDataAccess);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }
        [Route("GetAllFormAndCostTypesVariableOverHeadCost")]
        [HttpGet]
        public async Task<IActionResult> GetAllFormAndCostTypesVariableOverHeadCost(string UserID)
        {
            List<UserDataAccess> oUserDataAccess = new List<UserDataAccess>();
            try
            {
                oUserDataAccess = await _mstUserProfile.GetAllFormAndCostTypesVariableOverHeadCost(UserID);
                if (oUserDataAccess == null)
                {
                    return BadRequest(oUserDataAccess);
                }
                else
                {
                    return Ok(oUserDataAccess);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }
        [Route("GetAllFormAndCostTypesDirectMaterial")]
        [HttpGet]
        public async Task<IActionResult> GetAllFormAndCostTypesDirectMaterial(string UserID)
        {
            List<UserDataAccess> oUserDataAccess = new List<UserDataAccess>();
            try
            {
                oUserDataAccess = await _mstUserProfile.GetAllFormAndCostTypesDirectMaterial(UserID);
                if (oUserDataAccess == null)
                {
                    return BadRequest(oUserDataAccess);
                }
                else
                {
                    return Ok(oUserDataAccess);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }


        [Route("addUserDataAccess")]
        [HttpPost]
        public async Task<IActionResult> AddDataAccess([FromBody] List<UserDataAccess> pUserDataAccess)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstUserProfile.AddUserDataAccess(pUserDataAccess);
                if (response == null)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion
       
    }
}