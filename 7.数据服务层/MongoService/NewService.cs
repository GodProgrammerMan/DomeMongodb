using MongoDB.DTO;
using MongoDB.Molde;
using MongoDbHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoService
{
    public class NewService
    {
        /// <summary>
        /// 获取新闻列表分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<New> GetNewListByPage(int pageIndex,int pageSize)
        {
            var newList = MongoDbHelper.GetListToPage<New>(DbConfigParams.ConntionString, DbConfigParams.DbName, CollectionNames.New, pageIndex, pageSize);
            return newList;
        } 
    }
}
