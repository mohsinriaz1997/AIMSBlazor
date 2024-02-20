using Backend.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using FrontEnd.Interfaces.MasterData;

namespace FrontEnd.General
{
    public partial class DetailDialog
    {
        #region InjectService

        [Inject]
        public IDialogService Dialog { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IResourceMasterData _mstResource { get; set; }
        #endregion InjectService

        #region Variables

        private bool Loading = false;

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public MstResourceDetail oDetailParaTax { get; set; } = new MstResourceDetail();
        [Parameter]
        public MstResource oDetailPara { get; set; } = new MstResource();
        [Parameter]
        public MstResource oModelResource { get; set; } = new MstResource();
        [Parameter]
        public string DialogFor { get; set; }
        [Parameter]
        public string ProductCode { get; set; }
        [Parameter]
        public string year { get; set; }
        [Parameter]
        public string month { get; set; }
        private string searchString1 = "";
        private MstResourceDetail oModelResouceType = new MstResourceDetail();
        private List<MstResourceDetail> oResouceTypeList = new List<MstResourceDetail>();
        private MstResourceDetail oModelDetail = new MstResourceDetail();
        private MstResourceDetail oModelMstResourceDetail = new MstResourceDetail();
        private List<MstResourceDetail> oMstResourceMachineDetailList = new List<MstResourceDetail>();
        private List<MstResourceDetail> oMstResourceElectricityDetailList = new List<MstResourceDetail>();
        private List<MstResourceDetail> oMstResourceToolsDetailList = new List<MstResourceDetail>();
        private List<MstResourceDetail> oMstResourceGasolineDetailList = new List<MstResourceDetail>();
        private List<MstResourceDetail> oMstResourceDyesDetailList = new List<MstResourceDetail>();
        private int selectedRowNumber = -1;

        private List<string> clickedEvents = new();
        private void Cancel() => MudDialog.Cancel();

        #endregion Variables

        #region Functions

        //private async Task GetAllCostType()
        //{
        //    try
        //    {
        //        oCostTypeList = await _mstCostType.GetAllData();
        //    }
        //    catch (Exception ex)
        //    {
        //        //Logs.GenerateLogs(ex);
        //    }
        //}



        private async Task<IEnumerable<MstResourceDetail>> searchResourceDescriptionDyes(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oMstResourceDyesDetailList.Where(t => t.TypeOfResr == "Dyes").Select(o => new MstResourceDetail
                    {
                        Id = o.Id,
                        //Cost = o.Cost,
                        ResrDescription = o.ResrDescription
                    }).ToList();
                var res = oMstResourceDyesDetailList.Where(x => x.ResrDescription.ToUpper().Contains(value.ToUpper()) && x.TypeOfResr == "Dyes").ToList();
                return res.Select(x => new MstResourceDetail
                {
                    Id = x.Id,
                    //Cost = x.Cost,
                    ResrDescription = x.ResrDescription
                }).ToList();
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstResourceDetail>> searchResourceDescriptionMachine(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oMstResourceMachineDetailList.Select(o => new MstResourceDetail
                    {
                        Id = o.Id,
                        Fkid = o.Fkid,
                        ResrDescription = o.ResrDescription
                    }).ToList();
                var res = oMstResourceMachineDetailList.Where(x => x.ResrDescription.ToUpper().Contains(value.ToUpper())).ToList();
                return res.Select(x => new MstResourceDetail
                {
                    Id = x.Id,
                    Fkid = x.Fkid,
                    ResrDescription = x.ResrDescription
                }).ToList();
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex);
                return null;
            }
        }


        private async Task<IEnumerable<MstResourceDetail>> searchResourceCostMachine(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oMstResourceMachineDetailList.Where(t => t.TypeOfResr == "Dyes").Select(o => new MstResourceDetail
                    {
                        Id = o.Id,
                        Cost = o.Cost,
                        ResrDescription = o.ResrDescription
                    }).ToList();
                var res = oMstResourceMachineDetailList.Where(x => x.ResrDescription.ToUpper().Contains(value.ToUpper()) && x.TypeOfResr == "Machine").ToList();
                return res.Select(x => new MstResourceDetail
                {
                    Id = x.Id,
                    Cost = x.Cost,
                    ResrDescription = x.ResrDescription
                }).ToList();
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstResourceDetail>> searchResourceCostTools(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oMstResourceMachineDetailList.Where(t => t.TypeOfResr == "Tools").Select(o => new MstResourceDetail
                    {
                        Id = o.Id,
                        Cost = o.Cost,
                        ResrDescription = o.ResrDescription
                    }).ToList();
                var res = oMstResourceMachineDetailList.Where(x => x.ResrDescription.ToUpper().Contains(value.ToUpper()) && x.TypeOfResr == "Tools").ToList();
                return res.Select(x => new MstResourceDetail
                {
                    Id = x.Id,
                    Cost = x.Cost,
                    ResrDescription = x.ResrDescription
                }).ToList();
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstResourceDetail>> searchResourceCostDyes(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oMstResourceMachineDetailList.Where(t => t.TypeOfResr == "Dyes").Select(o => new MstResourceDetail
                    {
                        Id = o.Id,
                        Cost = o.Cost,
                        ResrDescription = o.ResrDescription
                    }).ToList();
                var res = oMstResourceMachineDetailList.Where(x => x.ResrDescription.ToUpper().Contains(value.ToUpper()) && x.TypeOfResr == "Dyes").ToList();
                return res.Select(x => new MstResourceDetail
                {
                    Id = x.Id,
                    Cost = x.Cost,
                    ResrDescription = x.ResrDescription
                }).ToList();
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstResourceDetail>> searchResourceDescriptionElectricity(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oMstResourceElectricityDetailList.Where(t => t.TypeOfResr == "Electricity").Select(o => new MstResourceDetail
                    {
                        Id = o.Id,
                        ResrDescription = o.ResrDescription
                    }).ToList();
                var res = oMstResourceElectricityDetailList.Where(x => x.ResrDescription.ToUpper().Contains(value.ToUpper()) && x.TypeOfResr == "Electricity").ToList();
                return res.Select(x => new MstResourceDetail
                {
                    Id = x.Id,
                    ResrDescription = x.ResrDescription
                }).ToList();
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstResourceDetail>> searchResourceDescriptionTools(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oMstResourceToolsDetailList.Where(t => t.TypeOfResr == "Tools").Select(o => new MstResourceDetail
                    {
                        Id = o.Id,
                        ResrDescription = o.ResrDescription
                    }).ToList();
                var res = oMstResourceToolsDetailList.Where(x => x.ResrDescription.ToUpper().Contains(value.ToUpper()) && x.TypeOfResr == "Tools").ToList();
                return res.Select(x => new MstResourceDetail
                {
                    Id = x.Id,
                    ResrDescription = x.ResrDescription
                }).ToList();
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex);
                return null;
            }
        }

        private async Task<IEnumerable<MstResourceDetail>> searchResourceDescriptionGasoline(string value)
        {
            try
            {
                await Task.Delay(1);
                if (string.IsNullOrWhiteSpace(value))
                    return oMstResourceGasolineDetailList.Where(t => t.TypeOfResr == "Gasoline").Select(o => new MstResourceDetail
                    {
                        Id = o.Id,
                        ResrDescription = o.ResrDescription
                    }).ToList();
                var res = oMstResourceGasolineDetailList.Where(x => x.ResrDescription.ToUpper().Contains(value.ToUpper()) && x.TypeOfResr == "Gasoline").ToList();
                return res.Select(x => new MstResourceDetail
                {
                    Id = x.Id,
                    ResrDescription = x.ResrDescription
                }).ToList();
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex);
                return null;
            }
        }
        private async Task GetAllResourceDesciption()
        {
            try
            {
                //oMstResourceDyesDetailList = await _mstResource.GetAllDataDyes();
                //oMstResourceDyesDetailList.Where()
                oMstResourceMachineDetailList = await _mstResource.GetAllDataDyes();
                //oMstResourceElectricityDetailList = await _mstResource.GetAllData();
                oMstResourceToolsDetailList = await _mstResource.GetAllDataTools();
                oMstResourceGasolineDetailList = await _mstResource.GetAllDataGasoline();
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex);
            }
        }

        private void OnChange()
        {
            try
            {

                double cost = 0;
                if (oModelDetail.Rate == null)
                {
                    oModelDetail.Rate = 0;
                }
                if (oModelDetail.Price == null)
                {
                    oModelDetail.Price = 0;
                }
                if (oModelDetail.LandedFactor == null)
                {
                    oModelDetail.LandedFactor = 0;
                }
                cost = Convert.ToDouble(oModelDetail.Rate * oModelDetail.Price * oModelDetail.LandedFactor);
                oModelDetail.Cost = Convert.ToDecimal(cost);
            }
            catch (Exception ex)
            {

                //Logs.GenerateLogs(ex);
            }
        }
        private async Task Submit()
        {
            try
            {
                await Task.Delay(2);
                if (DialogFor == "ResourceMaster")
                {
                    if (string.IsNullOrWhiteSpace(oModelDetail.TypeOfResr) || oModelDetail.ResrDescription == null || oModelDetail.CurrCodeSap == null)
                    {
                        Snackbar.Add("Fill the required field(s).", Severity.Error, (options) => { options.Icon = Icons.Sharp.Error; });
                        return;
                    }
                    MudDialog.Close(DialogResult.Ok<MstResourceDetail>(oModelDetail));
                }


            }
            catch (Exception ex)
            {

                //Logs.GenerateLogs(ex);
            }
        }

        #endregion Functions

        #region Events

        protected override async Task OnInitializedAsync()
        {

            try
            {
                //await GetallVoh();
                Loading = true;

                if (DialogFor == "ResourceMaster")
                {
                    if (oDetailPara.CurrencySap == "PKR")
                    {
                        oDetailParaTax.Rate = 0;
                    }
                    else
                    {
                        var rate = oDetailPara.RateSap;
                        oModelDetail.Rate = rate;
                    }
                    if (oDetailParaTax.TypeOfResr != null)
                    {
                        oModelDetail = oDetailParaTax;
                    }
                    else
                    {
                        //oModelDetail.Price = 0;
                        //oModelDetail.Cost = 0;
                        //oModelDetail.LandedFactor = 0;
                        //oModelDetail.Rate = 0;
                    }
                }

                Loading = false;
                //await GetAllResourceDesciption();
                //await GetAllCostType();
                //await GetAllCostDriverType();
                //await GetAllActivityType();
            }
            catch (Exception ex)
            {
                //Logs.GenerateLogs(ex);
                Loading = false;
            }
        }

        #endregion Events
    }
}