using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gramium.Data.Common.Repositories;
using Gramium.Data.Models;
using Gramium.Services.Data;
using Gramium.Web.ViewModels.Settings;
using Microsoft.AspNetCore.Mvc;

namespace Gramium.Api.Controllers
{
    public class SettingsController : ApiController
    {
        private readonly ISettingsService settingsService;
        private readonly IRepository<Setting> sittingRepo;

        public SettingsController(ISettingsService settingsService, IRepository<Setting> sittingRepo)
        {
            this.settingsService = settingsService;
            this.sittingRepo = sittingRepo;
        }

        [HttpGet("Count")]
        public ActionResult<int> GetCount()
        {
            return Ok(this.settingsService.GetCount());
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<SettingViewModel>> GetAll()
        {
            this.HttpContext.Response.Headers.Add("TRASHY-HEADER", "VALUE");
            
            return Ok(this.settingsService.GetAll<SettingViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var random = new Random();
            var setting = new Setting { Name = $"Name_{random.Next()}", Value = $"Value_{random.Next()}" };

            await this.sittingRepo.AddAsync(setting);
            await this.sittingRepo.SaveChangesAsync();

            return Ok();
        }
    }
}
