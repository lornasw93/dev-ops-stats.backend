﻿using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Web.Http;
using DevOpsStats.Api.Models;
using DevOpsStats.Api.Queries.Repos.PullRequests;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsStats.Api.Controllers.Repos
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/repos/[controller]")]
    [ApiController]
    [Authorize]
    public class PullRequestsController : ControllerBase
    {
        private readonly IPullRequestsQuery _query;

        public PullRequestsController(IPullRequestsQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// Get list of pull requests
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<object> Get(string project)
        {
            return Ok(_query.Execute(project));
        }

        /// <summary>
        /// Pull requests count
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("count")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<ListCount> GetCount(string project)
        {
            return Ok(_query.Count(project));
        }
    }
}