// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapLegendController.cs" company="">
//   
// </copyright>
// <summary>
//   The map legend controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Omnis.Web.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using global::Omnis.Business.Models;
    using global::Omnis.Data;
    using global::Omnis.Managers;

    /// <summary>
    /// The map legend controller.
    /// </summary>
    public class MapLegendController : ApiController
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
        public IEnumerable<MapLegend> Get()
        {
            using (var repository = new MapLegendRepository())
            {
                var manager = new MapLegendManager(repository);
                return manager.Get();
            }
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
        public MapLegend GetById(int id)
        {
            using (var repository = new MapLegendRepository())
            {
                var manager = new MapLegendManager(repository);
                return manager.Get().Single(p => p.Id == id);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MapLegend GetByName(string name)
        {
            using (var repository = new MapLegendRepository())
            {
                var manager = new MapLegendManager(repository);
                return manager.Get().Single(p => p.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        [HttpPost]
        public void Add([FromBody]MapLegend item)
        {
            using (var repository = new MapLegendRepository())
            {
                var manager = new MapLegendManager(repository);
                manager.AddOrUpdate(item);
            }
        }

        #endregion
    }
}