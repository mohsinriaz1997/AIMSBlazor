using Backend.Models;
using FrontEnd.General;
using FrontEnd.Interfaces.MasterData;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace FrontEnd.Pages.MasterData
{
    public partial class ResourceMasterData
    {
        #region InjectService

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IResourceMasterData _mstUserProfiled { get; set; }

        [Parameter]
        public MstResourceDetail _mstResourceDetail { get; set; }

        #endregion InjectService

        #region Variables

        private bool Loading = false;

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; } = new MudDialogInstance();

        private MstResource oModel = new MstResource();
        private List<MstResourceDetail> oDetailList = new List<MstResourceDetail>();
        private List<MstResourceDetail> oDetail = new List<MstResourceDetail>();

        private MstCostType oModelCostType = new MstCostType();
        private List<MstCostType> oCostTypeList = new List<MstCostType>();
        
        private UserDataAccess oModelMstUserProfile = new UserDataAccess();
        private List<UserDataAccess> oMstUserProfileList = new List<UserDataAccess>();

        private DialogOptions FullView = new DialogOptions() { MaxWidth = MaxWidth.ExtraExtraLarge, FullWidth = true, CloseButton = true, DisableBackdropClick = true, CloseOnEscapeKey = true };


        private string LoginUserCode = "";
        



        #endregion Variables

        #region Functions

        private void OnDateChange()
        {
            try
            {

                oModel.CurrencySap = null;
                oModel.RateSap = null;
            }
            catch (Exception ex)
            {

               
            }
        }

        private async Task OpenAddDialog(DialogOptions options, MstResource oModel)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("DialogFor", "ResourceMaster");
                parameters.Add("oDetailPara", oModel);
                var dialog = Dialog.Show<DetailDialog>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstResourceDetail)result.Data;
                    var update = oDetailList.Where(x => x.TypeOfResr == res.TypeOfResr && x.ResrDescription.ToLower() == res.ResrDescription.ToLower()).FirstOrDefault();
                    if (update != null)
                    {
                        Snackbar.Add("Record already exits.", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                    }
                    else
                    {
                        oDetail.Add(res);
                        oDetailList = oDetail;
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        private async Task OpenEditDialog(DialogOptions options, MstResourceDetail oDetailPara)
        {
            try
            {
                var parameters = new DialogParameters();
                parameters.Add("oDetailParaTax", oDetailPara);
                parameters.Add("DialogFor", "ResourceMaster");
                var dialog = Dialog.Show<DetailDialog>("", parameters, options);
                var result = await dialog.Result;
                if (!result.Cancelled)
                {
                    var res = (MstResourceDetail)result.Data;
                    var update = oDetailList.Where(x => x.TypeOfResr == res.TypeOfResr && x.ResrDescription.ToLower() == res.ResrDescription.ToLower()
                    && x.CurrCodeSap.ToLower() == res.CurrCodeSap.ToLower()
                    && x.CurrNameSap.ToLower() == res.CurrNameSap.ToLower()
                    && x.Rate == res.Rate
                    && x.Price == res.Price
                    && x.Cost == res.Cost).FirstOrDefault();
                    if (update != null)
                    {
                        oDetail.Remove(update);
                    }
                    MstResourceDetail oRDDetail = new MstResourceDetail();
                    oRDDetail.Id = res.Id;
                    oRDDetail.Fkid = res.Fkid;
                    oRDDetail.TypeOfResr = res.TypeOfResr;
                    oRDDetail.ResrDescription = res.ResrDescription;
                    oRDDetail.CurrCodeSap = res.CurrCodeSap;
                    oRDDetail.CurrNameSap = res.CurrNameSap;
                    oRDDetail.Rate = res.Rate;
                    oRDDetail.Price = res.Price;
                    oRDDetail.LandedFactor = res.LandedFactor;
                    oRDDetail.Cost = res.Cost; ;
                    oDetail.Add(oRDDetail);
                    oDetailList = oDetail.ToList();
                }
            }
            catch (Exception ex)
            {
               
            }
        }



        private async Task<IEnumerable<UserDataAccess>> SearchCostType(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oMstUserProfileList.Select(o => new UserDataAccess
                    {
                        FkCostId = o.FkCostId,
                        Description = o.Description
                    }).ToList();
                var res = oMstUserProfileList.Where(x => x.Description.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new UserDataAccess
                {
                    FkCostId = x.FkCostId,
                    Description = x.Description
                }).ToList();
            }
            catch (Exception ex)
            {
               
                return null;
            }
        }


        public void RemoveRecord(string TypeOfRescr, string RescDesc, string CurrCodeSap, string CurrNameSAP, decimal? Rate, decimal? Price, decimal? Cost)
        {
            try
            {
                var remove = oDetailList.Where(x => x.TypeOfResr == TypeOfRescr && x.ResrDescription.ToLower() == RescDesc.ToLower()
                    && x.CurrCodeSap.ToLower() == CurrCodeSap.ToLower()
                    && x.CurrNameSap.ToLower() == CurrNameSAP.ToLower()
                    && x.Rate == Rate
                    && x.Price == Price
                    && x.Cost == Cost).FirstOrDefault();
                if (remove != null)
                {
                    oDetailList.Remove(remove);
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        private async Task<ApiResponseModel> Save()
        {
            try
            {
                Loading = true;
                var res = new ApiResponseModel();
                await Task.Delay(3);
                if (!string.IsNullOrWhiteSpace(Convert.ToString(oModel.Id)))
                {
                    try
                    {
                        Loading = true;
                        var res1 = new ApiResponseModel();
                        await Task.Delay(1);
                        oModel.FkcostTypeId = oModelCostType.Id;
                        oModel.CostTypeDesc = oModelCostType.Description;
                        oModel.MstResourceDetails = oDetailList.ToList();
                        if (oModel.ResrListName == null || oModel.CurrencySap == null || oModel.RateSap == null || oModel.FkcostTypeId == null)
                        {
                            Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            Loading = false;
                            return null;
                        }
                        if (oModel != null && oModel.MstResourceDetails != null && oModel.MstResourceDetails.Count > 0)
                        {
                            if (oModel.Id == 0)
                            {
                                oModel.CreatedBy = LoginUserCode;
                                oModel.CreatedDate = DateTime.Now;
                                res1 = await _mstUserProfiled.Insert(oModel);
                            }
                            else
                            {
                                oModel.UpdatedBy = LoginUserCode;
                                oModel.UpdatedDate = DateTime.Now;
                                res1 = await _mstUserProfiled.Update(oModel);
                            }
                        }
                        else
                        {
                            Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            Loading = false;
                            return null;
                        }
                        if (res1 != null && res1.Id == 1)
                        {
                            Snackbar.Add(res1.Message, Severity.Info, (options) => { options.Icon = Icons.Sharp.Info; });
                            await Task.Delay(1000);
                            Navigation.NavigateTo("/ResourceMasterData", forceLoad: true);
                        }
                        else
                        {
                            Snackbar.Add(res.Message, Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                            Loading = false;
                            return null;
                        }
                        oModel.FlgActive = true;
                        Loading = false;
                        return res;
                    }
                    catch (Exception ex)
                    {
                       
                        Loading = false;
                        return null;
                    }
                }
                else
                {
                    Snackbar.Add("Please fill the required field(s)", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                }
                Loading = false;
                return res;
            }
            catch (Exception ex)
            {
               
                Loading = false;
                return null;
            }
        }

        private async void Reset()
        {
            try
            {
                Loading = true;
                await Task.Delay(1);
                Navigation.NavigateTo("/ResourceMasterData", forceLoad: true);
                Loading = false;
            }
            catch (Exception ex)
            {
               
                Loading = false;
            }
        }
        

        #endregion Functions

        #region Events

        protected override async Task OnInitializedAsync()
        {
            Loading = true;

            //var Session = await _localStorageService.GetItemAsync<MstUserProfile>("User");
            //if (Session != null)
            //{
            //    var res = await _mstUserProfile.FetchUserAuth(Session.Id);
            //    if (res.Where(x => x.MenuName == "Resource Master Data" && x.UserRights != 1).ToList().Count > 0)
            //    {
            //LoginUserCode = Session.UserCode;
            oModel.FlgActive = true;
            oModel.FlgDefaultResrMst = true;
            oModel.DocDate = DateTime.Today;
            //await GetAllCostType();
            //}
            //}
            //else
            //{
            //    Navigation.NavigateTo("/Login", forceLoad: true);
            //}
            Loading = false;
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                try
                {
                    Loading = true;
                    //var Session = await _localStorageService.GetItemAsync<MstUserProfile>("User");
                    //if (Session != null)
                    //{
                    //    LoginUserCode = Session.UserCode;
                    //    oModel.FlgActive = true;
                    //    oModel.FlgDefaultResrMst = true;
                    //    oModel.DocDate = DateTime.Today;
                    //    //await GetAllCostType();
                    //}
                    Loading = false;

                    StateHasChanged();
                }
                catch (Exception ex)
                {
                    //Logs.GenerateLogs(ex);
                    Loading = false;
                }

            }
        }

        #endregion Events
    }
}