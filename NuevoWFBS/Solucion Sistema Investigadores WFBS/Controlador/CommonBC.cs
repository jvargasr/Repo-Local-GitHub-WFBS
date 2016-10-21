using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;

namespace Controlador
{
    public class CommonBC
    {

        private static Modelo.WFBSEntities _modeloWfbs;

        public static Modelo.WFBSEntities ModeloWfbs
        {
            get
            {
                if (_modeloWfbs == null)
                {
                    _modeloWfbs = new Modelo.WFBSEntities();
                }
                return _modeloWfbs;
            }
        }

        /*
        public object Deserializar<T>(string xml)
        {
            StringReader reader = new StringReader(xml);
            XmlSerializer serializador = new XmlSerializer(typeof(T));

            return serializador.Deserialize(reader);
        }

        public string Serializar<T>(object b)
        {
            StringWriter writer = new StringWriter();
            XmlSerializer serializador = new XmlSerializer(typeof(T));

            serializador.Serialize(writer, b);

            return writer.ToString();
        } */

    }
}
