using Microsoft.AspNetCore.Mvc;
using TCCApi.FachadeApi.Model.TO;
using TCCApi.FachadeApi.Negocio;

namespace TCCApi.FachadeApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Feedback")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackNegocio _feedbackNegocio;

        public FeedbackController(IFeedbackNegocio feedbackNegocio)
        {
            this._feedbackNegocio = feedbackNegocio;
        }

        [HttpGet]
        [Route("Evento/{codEvento}")]
        public async System.Threading.Tasks.Task<IActionResult> GetFeedbackEventoAsync([FromRoute]string codEvento)
        {
            if (string.IsNullOrWhiteSpace(codEvento))
            {
                return BadRequest(new { message = "Informe o codEvento"});
            }

            var feeds = await _feedbackNegocio.GetListaFeedbacksAsync(codEvento);

            return Ok(feeds);
        }
        [HttpGet]
        [Route("{id}")]
        public async System.Threading.Tasks.Task<IActionResult> GetFeedbackAsync([FromRoute]int id)
        {
            if (id == 0)
            {
                return BadRequest(new { message = "Informe o codEvento" });
            }

            var feed = await _feedbackNegocio.GetAsync(id);

            return Ok(feed);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> PostFeedbackAsync([FromBody]Feedback feedback)
        {
            if (feedback == default(Feedback))
            {
                return BadRequest(new { message = "Informe o codEvento" });
            }

            var feeds = await _feedbackNegocio.PostFeedbackAsync(feedback);

            return Ok(feeds);
        }
    }
}