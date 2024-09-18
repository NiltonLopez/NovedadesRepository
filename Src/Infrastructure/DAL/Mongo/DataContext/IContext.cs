using Novedades.DAL.Mongo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Novedades.DAL.Mongo.DataContext
{
    /// <summary>
    /// Interfaz Mongo context contract.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Colleccion de Tipo Contrato
        /// </summary>
        public IMongoCollection<NovedadSQL> Novedades { get; }

}
    
}
