using System;
using System.Threading.Tasks;
using Gramium.Data.Common.Repositories;
using Gramium.Data.Models;
using Gramium.Services.Data;
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

        [HttpGet]
        public ActionResult<int> GetAll()
        {
            return Ok(this.settingsService.GetCount());
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
