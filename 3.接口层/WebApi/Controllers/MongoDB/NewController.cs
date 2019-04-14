using DotNet.Utilities;
using MongoDB.Bson;
using MongoDB.Molde;
using MongoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers.MongoDB
{
    /// <summary>
    /// 新闻New
    /// </summary>
    [RoutePrefix("api/New")]
    public class NewController : ApiController
    {
        #region 获取新闻List
        /// <summary>
        /// 获取新闻List
        /// </summary>
        /// <param name="kw"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("GetNesList")]
        [HttpGet]
        public JSONResult<List<New>> GetNesList(string kw, int pageIndex, int pageSize)
        {
            return new BaseJsonResult().UnifiedFucn(() =>
            {
                var model = new JSONResult<List<New>>();
                model.Success = true;
                if (pageIndex == 0)
                {
                    pageIndex = 1;
                }
                if (pageSize == 0)
                {
                    pageSize = 8;
                }
                NewService service = new NewService();
                var newList = service.GetNewListByPage(kw, pageIndex, pageSize);
                if (newList.Count > 0)
                {
                    model.ret = 0;
                    model.Result = "获取数据成功";
                    model.Content = newList;
                }
                else
                {
                    model.ret = 5;
                    model.Result = "没有更多记录";
                    model.Content = newList;
                }

                return model;

            });
        }
        #endregion

        #region 获取新闻详情
        /// <summary>
        /// 获取新闻详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetNewInfo")]
        [HttpGet]
        public JSONResult<New> GetNewInfo(string id)
        {
            return new BaseJsonResult().UnifiedFucn(() =>
            {
                var model = new JSONResult<New>();
                model.Success = true;
                NewService service = new NewService();
                var newMolde = service.GetNewInfo(id);
                if (newMolde!= null)
                {
                    model.ret = 0;
                    model.Result = "获取数据成功";
                    model.Content = newMolde;
                }
                else
                {
                    model.ret = 5;
                    model.Result = "找不到该新闻！";
                    model.Content = null;
                }

                return model;

            });
        }
        #endregion
        
    }
}
