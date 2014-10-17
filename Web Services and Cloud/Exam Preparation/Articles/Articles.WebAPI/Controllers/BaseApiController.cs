namespace Articles.WebAPI.Controllers
{
    using System.Web.Http;

    using Articles.Data;

    public class BaseApiController : ApiController
    {
        protected IArticlesData data;

        public BaseApiController(IArticlesData data)
        {
            this.data = data;
        }
    }
}