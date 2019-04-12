using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Molde
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class EntityBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        [BsonId]
        public ObjectId Id { get; set; }
    }

}
