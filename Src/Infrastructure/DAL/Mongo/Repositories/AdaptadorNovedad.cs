//using Novedades.DAL.Mongo.DataContext;
//using Novedades.DAL.Mongo.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Novedades.DAL.Mongo.Adaptador
//{
//    public class AdaptadorNovedad
//    {
//        private readonly IContext context;

//        public AdaptadorNovedad(IContext context)
//        {
//            this.context = context;
//        }

//        public void insertarNovedad(NovedadSQL nvn)
//        {
//            context.Novedades.InsertOne(nvn);
//        }
//    }
//}
