using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;

namespace TeduShop.Web.API
{
    [RoutePrefix("api/postCategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpRespons(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                else
                {
                    var listPostCate = _postCategoryService.GetAll();
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listPostCate);
                }
                return response;
            });
        }
        [Route("post")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpRespons(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                else
                {
                    var postCate = _postCategoryService.Add(postCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, postCate);
                }
                return response;
            });
        }
        [Route("put")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpRespons(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                else
                {
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpRespons(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                else
                {
                     _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }


    }
}