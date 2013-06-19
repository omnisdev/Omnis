using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Omnis.Web.Api
{
    using global::Omnis.Business.Models;
    using global::Omnis.Data;
    using global::Omnis.Managers;

    public class ColorMapController : ApiController
    {
        #region Public Methods and Operators

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public void Delete(int id)
        {
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// </returns>
        public IEnumerable<ColorMap> Get()
        {
            var manager = new ColorMapManager();
            return manager.Get();
        }

        // GET api/<controller>/5
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The predicate.
        /// </param>
        /// <returns>
        /// </returns>
        public ColorMap GetById(int id)
        {
            var manager = new ColorMapManager();
            return manager.Get().Single(p => p.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ColorMap GetByName(string name)
        {
            var manager = new ColorMapManager();
            return manager.Get().Single(p => p.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [HttpPost]
        public void Add([FromBody]ColorMap item)
        {
            var manager = new ColorMapManager();
            manager.AddOrUpdate(item);
        }

        #endregion
    }
}