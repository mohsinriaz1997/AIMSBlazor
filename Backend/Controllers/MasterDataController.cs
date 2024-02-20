using Backend.General;
using Backend.Interface.MasterData;
using Backend.Interfaces.MasterData;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private IActivityType _mstActivityType;
        private IResourceMasterData _mstResouce;
        private IDepartmentMaster _mstDepartment;
        private IDesignationMaster _mstDesignation;



        public MasterDataController
            (IActivityType mstActivityType,
            IResourceMasterData mstResouce,
            IDepartmentMaster mstDepartment,
            IDesignationMaster mstDesignation)
        {
            _mstActivityType = mstActivityType;
            _mstResouce = mstResouce;
            _mstDepartment = mstDepartment;
            _mstDesignation = mstDesignation;
        }

        #region ActivityType

        [Route("getAllActivityType")]
        [HttpGet]
        public async Task<IActionResult> GetAllActivityType()
        {
            List<MstActivityType> oMstActivityType = new List<MstActivityType>();
            try
            {
                oMstActivityType = await _mstActivityType.GetAllData();
                if (oMstActivityType == null)
                {
                    return BadRequest(oMstActivityType);
                }
                else
                {
                    return Ok(oMstActivityType);
                }
            }
            catch (Exception ex)
            {
                ////Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addActivityType")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstActivityType pMstActivityType, string UserCode)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstActivityType.Insert(pMstActivityType, UserCode);
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
                ////Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("updateActivityType")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstActivityType pMstActivityType, string UserCode)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstActivityType.Update(pMstActivityType, UserCode);
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
                ////Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion ActivityType
        #region ResouceMasterData

        [Route("getAllResource")]
        [HttpGet]
        public async Task<IActionResult> GetAllResouce()
        {
            List<MstResource> oMstResource = new List<MstResource>();
            try
            {
                oMstResource = await _mstResouce.GetAllData();
                if (oMstResource == null)
                {
                    return BadRequest(oMstResource);
                }
                else
                {
                    return Ok(oMstResource);
                }
            }
            catch (Exception ex)
            {
                ////Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("getAllResourceDyes")]
        [HttpGet]
        public async Task<IActionResult> GetAllResouceDyes()
        {
            List<MstResourceDetail> oMstResourceDetail = new List<MstResourceDetail>();
            try
            {
                oMstResourceDetail = await _mstResouce.GetAllDataDyes();
                if (oMstResourceDetail == null)
                {
                    return BadRequest(oMstResourceDetail);
                }
                else
                {
                    return Ok(oMstResourceDetail);
                }
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("getAllResourceMachine")]
        [HttpGet]
        public async Task<IActionResult> GetAllResouceMachine()
        {
            List<MstResourceDetail> oMstResourceDetail = new List<MstResourceDetail>();
            try
            {
                oMstResourceDetail = await _mstResouce.GetAllDataMachine();
                if (oMstResourceDetail == null)
                {
                    return BadRequest(oMstResourceDetail);
                }
                else
                {
                    return Ok(oMstResourceDetail);
                }
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("getAllResourceTools")]
        [HttpGet]
        public async Task<IActionResult> GetAllResouceTools()
        {
            List<MstResourceDetail> oMstResourceDetail = new List<MstResourceDetail>();
            try
            {
                oMstResourceDetail = await _mstResouce.GetAllDataTools();
                if (oMstResourceDetail == null)
                {
                    return BadRequest(oMstResourceDetail);
                }
                else
                {
                    return Ok(oMstResourceDetail);
                }
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("getAllResourceGasoline")]
        [HttpGet]
        public async Task<IActionResult> GetAllResouceGasoline()
        {
            List<MstResourceDetail> oMstResourceDetail = new List<MstResourceDetail>();
            try
            {
                oMstResourceDetail = await _mstResouce.GetAllDataGasoline();
                if (oMstResourceDetail == null)
                {
                    return BadRequest(oMstResourceDetail);
                }
                else
                {
                    return Ok(oMstResourceDetail);
                }
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addResource")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstResource pMstResource)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstResouce.Insert(pMstResource);
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
                //Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("updateResource")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstResource pMstResource)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstResouce.Update(pMstResource);
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
                //Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        #endregion ResouceMasterData
        #region Department

        [Route("getAllDepartment")]
        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            List<MstDepartment> oMstDepartment = new List<MstDepartment>();
            try
            {
                oMstDepartment = await _mstDepartment.GetAllData();
                if (oMstDepartment == null)
                {
                    return BadRequest(oMstDepartment);
                }
                else
                {
                    return Ok(oMstDepartment);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addDepartment")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstDepartment pMstDepartment, string UserCode)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDepartment.Insert(pMstDepartment, UserCode);
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

        [Route("updateDepartment")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstDepartment pMstDepartment, string UserCode)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDepartment.Update(pMstDepartment, UserCode);
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

        #endregion Department
        #region Designation

        [Route("getAllDesignation")]
        [HttpGet]
        public async Task<IActionResult> GetAllDesignation()
        {
            List<MstDesignation> oMstDesignation = new List<MstDesignation>();
            try
            {
                oMstDesignation = await _mstDesignation.GetAllData();
                if (oMstDesignation == null)
                {
                    return BadRequest(oMstDesignation);
                }
                else
                {
                    return Ok(oMstDesignation);
                }
            }
            catch (Exception ex)
            {
                Logs.GenerateLogs(ex);
                return BadRequest("Something went wrong.");
            }
        }

        [Route("addDesignation")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MstDesignation pMstDesignation, string UserCode)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDesignation.Insert(pMstDesignation, UserCode);
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

        [Route("updateDesignation")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] MstDesignation pMstDesignation, string UserCode)
        {
            ApiResponseModel response = new ApiResponseModel();
            try
            {
                response = await _mstDesignation.Update(pMstDesignation, UserCode);
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

        #endregion Designation
    }
}