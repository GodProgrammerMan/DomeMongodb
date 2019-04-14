using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.Molde
{
    public class New : EntityBase
    {
        /// <summary>
        /// 标题
        /// </summary>
        [BsonElement("Title")]
        public string Title { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [BsonElement("Author")]
        public string Author { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        [BsonElement("Logo")]
        public string Logo { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [BsonElement("Content")]
        public string Content { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        [BsonElement("ReleaseDate")]
        public DateTime ReleaseDate { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        [BsonElement("View")]
        public int View { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        [BsonElement("Source")]
        public string Source { get; set; }
        /// <summary>
        /// 新闻类型
        /// </summary>
        [BsonElement("NewType")]
        public string NewType { get; set; }
    }
}
