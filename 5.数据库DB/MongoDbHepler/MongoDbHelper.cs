using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Molde;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace MongoDbHelp
{
    public static class MongoDbHelper
    {

        /// <summary>
        /// 获取数据库实例接口对象
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="dbName">数据库名称</param>
        /// <returns></returns>
        public static IMongoDatabase GetIDatabase(string connectionString, string dbName)
        {
            MongoClient client = new MongoClient(connectionString);
            return client.GetDatabase(dbName);
        }


        #region 新增
        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="dbName">数据名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="model">数据对象</param>
        public static void Insert<T>(string connectionString, string dbName, string collectionName, T

model) where T : EntityBase
        {
            if (model == null)
            {
                throw new ArgumentNullException("model", "待插入数据不能为空");
            }
            var db = GetIDatabase(connectionString, dbName);
            var collection = db.GetCollection<T>(collectionName);
            collection.InsertOne(model);
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="dbName">数据名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="models">数据对象</param>
        public static void InsertList<T>(string connectionString, string dbName, string collectionName, List<T>

models) where T : EntityBase
        {
            if (models.Count == 0)
            {
                throw new ArgumentNullException("models", "待插入数据不能为空");
            }
            var db = GetIDatabase(connectionString, dbName);
            var collection = db.GetCollection<T>(collectionName);
            collection.InsertMany(models);
        }
        #endregion

        #region 查询

        /// <summary>
        /// 根据ID获取数据对象
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="id">ID</param>
        /// <returns>数据对象</returns>
        public static T GetById<T>(string connectionString, string dbName, string collectionName, ObjectId

id)
           where T : EntityBase
        {
            var db = GetIDatabase(connectionString, dbName);
            var collection = db.GetCollection<T>(collectionName);

            return collection.AsQueryable<T>().Where(item => item.Id == id).First();
        }

        /// <summary>
        /// 根据查询条件获取一条数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="query">查询条件</param>
        /// <returns>数据对象</returns>
        public static T GetOneByCondition<T>(string connectionString, string dbName, string

collectionName, FilterDefinition<T> filter)
        {
            var db = GetIDatabase(connectionString, dbName);
            var collection = db.GetCollection<T>(collectionName);
            return collection.Find(filter).First();
        }

        /// <summary>
        /// 根据查询条件获取多条数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="query">查询条件</param>
        /// <returns>数据对象集合</returns>
        public static List<T> GetManyByCondition<T>(string connectionString, string dbName, string

collectionName, FilterDefinition<T> filter)
            where T : EntityBase
        {
            var db = GetIDatabase(connectionString, dbName);
            var collection = db.GetCollection<T>(collectionName);
            return collection.Find(filter).ToList();
        }

        /// <summary>
        /// 根据集合中的所有数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <returns>数据对象集合</returns>
        public static List<T> GetAll<T>(string connectionString, string dbName, string collectionName)
             where T : EntityBase
        {
            var db = GetIDatabase(connectionString, dbName);
            var collection = db.GetCollection<T>(collectionName);
            return collection.AsQueryable().ToList();
        }

        /// <summary>
        /// 获取分页
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns>数据对象集合</returns>
        public static List<T> GetListToPage<T>(string connectionString, string dbName, string collectionName,int pageIndex,int pageSize, Expression<Func<T, bool>> predicate)
        {
            var db = GetIDatabase(connectionString, dbName);
            var collection = db.GetCollection<T>(collectionName);
            if (predicate == null) 
                return collection.AsQueryable().ToList();
            else
                return collection.AsQueryable().Where(predicate).Skip(pageIndex * pageSize).Take(pageSize).ToList();

        }
        #endregion

        #region 删除

        /// <summary>
        /// 删除集合中符合条件的数据
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        /// <param name="query">查询条件</param>
        public static long DeleteByCondition<T>(string connectionString, string dbName, string
collectionName, FilterDefinition<T> filter)
        {
            var db = GetIDatabase(connectionString, dbName);
            var collection = db.GetCollection<T>(collectionName);
            return collection.DeleteMany(filter).DeletedCount;
        }

        /// <summary>
        /// 删除集合中的所有数据
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="dbName">数据库名称</param>
        /// <param name="collectionName">集合名称</param>
        public static long DeleteAll<T>(string connectionString, string dbName, string collectionName)
        {
            var db = GetIDatabase(connectionString, dbName);
            var collection = db.GetCollection<T>(collectionName);
            return collection.DeleteMany(null).DeletedCount;
        }

        #endregion

    }
}
