using MongoDB.Bson;
using MongoDB.DTO;
using MongoDB.Molde;
using MongoDbHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public List<New> GetNewListByPage(string kw,int pageIndex,int pageSize)
        {
            Expression<Func<New, bool>> kwQuest = null;
            if (!string.IsNullOrWhiteSpace(kw)) {
                kwQuest = t => t.Title.Contains(kw);
            }
            var newList = MongoDbHelper.GetListToPage(DbConfigParams.ConntionString, DbConfigParams.DbName, CollectionNames.New, pageIndex, pageSize, kwQuest);
            return newList;
        }

        /// <summary>
        /// 批量插入新闻
        /// </summary>
        /// <param name="models"></param>
        public void AddNewList(List<New> models) {
            MongoDbHelper.InsertList(DbConfigParams.ConntionString, DbConfigParams.DbName, CollectionNames.New, models);
        }

        public void InsetrNew(New model)
        {
            MongoDbHelper.Insert(DbConfigParams.ConntionString, DbConfigParams.DbName, CollectionNames.New, model);
        }

        public New GetNewInfo(string id)
        {
            var oid = new ObjectId(id);
           return MongoDbHelper.GetById<New>(DbConfigParams.ConntionString, DbConfigParams.DbName, CollectionNames.New, oid);
        }
    }
}
