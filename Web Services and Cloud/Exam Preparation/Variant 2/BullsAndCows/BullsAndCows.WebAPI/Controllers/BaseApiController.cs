namespace BullsAndCows.WebAPI.Controllers
{
    using System.Web.Http;

    using BullsAndCows.Data;

    public class BaseApiController : ApiController
    {
        protected IGameData data;

        public BaseApiController(IGameData data)
        {
            this.data = data;
        }
    }
}