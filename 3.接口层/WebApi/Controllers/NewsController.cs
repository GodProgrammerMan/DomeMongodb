using DotNet.Utilities;
using MongoDB.Molde;
using MongoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/New")]
    public class NewsController : ApiController
    {
        /// <summary>
        /// 获取新闻首页信息
        /// </summary>
        /// <returns></returns>
        [Route("GetNewList")]
        [HttpGet]
        public async Task<JSONResult<List<New>>> GetNewList(int pageIndex,int pageSize)
        {
            return await Task.Run(() =>
            {
                return new BaseJsonResult().UnifiedFucn(() =>
                {
                    var model = new JSONResult<List<New>>();
                    NewService service = new NewService();
                    var newList  = service.GetNewListByPage(pageIndex, pageSize);
                    model.ret = 0;
                    model.Result = "获取成功";
                    model.Success = true;
                    model.Content = newList;
                    return model;
                });

            });
        }

    }
}
