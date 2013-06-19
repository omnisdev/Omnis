// -----------------------------------------------------------------------
// <copyright file="ColorMapRepository.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Omnis.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Omnis.Business;
    using Omnis.Business.Models;

    using Raven.Abstractions.Data;
    using Raven.Client;
    using Raven.Client.Document;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ColorMapRepository : IDisposable
    {
        #region Constants and Fields

        /// <summary>
        /// The document store.
        /// </summary>
        private readonly IDocumentStore documentStore;

        /// <summary>
        /// The document url.
        /// </summary>
        private readonly string documentUrl = Globals.DefaultDocumenturl;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MapLegendRepository"/> class. 
        /// Initializes a new instance of the <see cref="Data"/> class. 
        /// The data.
        /// </summary>
        public ColorMapRepository()
        {
            if (ConfigManager.GetValue(Globals.DocumentUrlKeyName) != null)
            {
                this.documentUrl = ConfigManager.GetValue(Globals.DocumentUrlKeyName).ToString();
            }

            this.documentStore = new DocumentStore { Url = this.documentUrl };
            this.documentStore.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapLegendRepository"/> class. 
        /// The map legend repository.
        /// </summary>
        /// <param name="documentUrl">
        /// </param>
        public ColorMapRepository(string documentUrl)
        {
            this.documentUrl = documentUrl;
            this.documentStore = new DocumentStore { Url = this.documentUrl };
            this.documentStore.Initialize();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add or update.
        /// </summary>
        /// <param name="item">
        /// </param>
        public void AddOrUpdate(ColorMap item)
        {
            if (item != null)
            {
                using (var session = this.documentStore.OpenSession())
                {
                    // session.Store(item);
                    session.Store(item);
                    session.SaveChanges();
                }
            }
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.documentStore.Dispose();
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="item">
        /// </param>
        public void Remove(ColorMap item)
        {
            if (item != null)
            {
                using (var session = this.documentStore.OpenSession())
                {
                    session.Delete(item);
                    session.SaveChanges();
                }
            }
        }

        /// <summary>
        /// The clear.
        /// </summary>
        public void RemoveAll()
        {
            string indexName = Globals.MapLegendIndexName;
            var indexQuery = new IndexQuery();
            indexQuery.Query = "Tag:" + Globals.ColorMapCollectionName;
            this.documentStore.DatabaseCommands.DeleteByIndex(indexName, indexQuery, allowStale: false);
        }

        /// <summary>
        /// The select all.
        /// </summary>
        /// <returns>
        /// </returns>
        public List<ColorMap> Select()
        {
            var list = new List<ColorMap>();
            using (IDocumentSession session = this.documentStore.OpenSession())
            {
                RavenQueryStatistics statistics;
                list.AddRange(session.Query<ColorMap>().Statistics(out statistics));
                if (statistics.TotalResults > 128)
                {
                    int toTake = statistics.TotalResults - 128;
                    int taken = 128;
                    while (toTake > 0)
                    {
                        list.AddRange(
                            Queryable.Skip(session.Query<ColorMap>(), taken).Take(toTake > 1024 ? 1024 : toTake));
                        toTake -= 1024;
                        taken += 1024;
                    }
                }
            }

            return list;
        }

        #endregion
    }
}
