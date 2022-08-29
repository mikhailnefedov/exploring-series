using Microsoft.AspNetCore.Mvc;

namespace exploring_graphql.Client
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private IConferenceClient _conferenceClient { get; }


        public ClientController(IConferenceClient conferenceClient)
        {
            _conferenceClient = conferenceClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetSessions()
        {
            var result = await _conferenceClient.GetSessions.ExecuteAsync();
            return Ok(result);
        }
    }
}
