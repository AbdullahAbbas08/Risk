using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Business_Layer.IUnitOfWork.IUnitOfWork_Crud;
using Risk_Domain_Layer.DTO_S;
using Risk_Domain_Layer.DTO_S.CallReasonClientType;

namespace Risk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallReasonClientTypeController : ControllerBase
    {
        private readonly IClientTypeBusiness<ClientType> clientTypeBusiness;
        private readonly IUnitOfWork_Crud unitOfWork;
        private readonly ICallReasonClientTypeBusiness callReasonClientType;

        public CallReasonClientTypeController(IClientTypeBusiness<ClientType> clientTypeBusiness, IUnitOfWork_Crud unitOfWork, ICallReasonClientTypeBusiness callReasonClientType)
        {
            this.clientTypeBusiness = clientTypeBusiness;
            this.unitOfWork = unitOfWork;
            this.callReasonClientType = callReasonClientType;
        }

        [HttpGet]
        public async Task<ActionResult<GeneralResponse<IdNameList>>> GetRelatedClientType(int ID)
        {
            try
            {
                GeneralResponse<IdNameList> response = new GeneralResponse<IdNameList>();
                var query = (await unitOfWork.CallReasonClientType.GetAll()).ToList();
                var ClientTypesExist = query.Where(x => x.CallReasonId == ID).Select(y => y.ClientTypeId).ToList();
                var Filter = (await clientTypeBusiness.Find(x => ClientTypesExist.Contains(x.TypeId))).ToList();
                var res = (from item in Filter
                           select new IdNameList
                           {
                               Id = item.TypeId.ToString(),
                               Name = item.Title
                           }).ToList();

                response.Data = res;
                response.Message = "success";
                return response;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
            }

        }

        [HttpPost("CallReasonClientType")]
        public async Task<ActionResult> CallReasonClientType(List<CallReasonClientTypeDto> model)
        {
            try
            {
                await callReasonClientType.AddAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException);
            }
        }

    }
}
