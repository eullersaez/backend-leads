using System.Reflection.Metadata.Ecma335;
using leads_backend.Data;
using leads_backend.DTOs;
using leads_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace leads_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly GetAcceptedLeadsService getAcceptedLeadsService;
        private readonly GetInvitedLeadsService getInvitedLeadsService;
        private readonly AcceptLeadService acceptLeadService;
        private readonly DeclineLeadService declineLeadService;
        public LeadsController(ApplicationDbContext dbContext, 
            GetAcceptedLeadsService getAcceptedLeadsService, 
            GetInvitedLeadsService getInvitedLeadsService,
            AcceptLeadService acceptLeadService,
            DeclineLeadService declineLeadService)
        {
            this.dbContext = dbContext;
            this.getAcceptedLeadsService = getAcceptedLeadsService;
            this.getInvitedLeadsService = getInvitedLeadsService;
            this.acceptLeadService = acceptLeadService;
            this.declineLeadService = declineLeadService;
        }

        [HttpGet("getAcceptedLeads")]
        public IActionResult GetAcceptedLeads()
        {
            return Ok(getAcceptedLeadsService.GetAcceptedLeads());
        }

        [HttpGet("getInvitedLeads")]
        public IActionResult GetInvitedLeads() 
        {
            return Ok(getInvitedLeadsService.GetInvitedLeads());
        }

        [HttpPatch("{id}/acceptLead")]
        public IActionResult PatchAcceptLead(int id)
        {
            var response = acceptLeadService.AcceptLead(id);

            return response is null? NotFound() : Ok(response);
        }
        
        [HttpPatch("{id}/declineLead")]
        public IActionResult PatchDeclineLead(int id)
        {
            var response = declineLeadService.DeclineLead(id);

            return response is null? NotFound() : Ok(response);
        }
    }
}
