using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Drawing;

/// <summary>
/// Summary description for manzano
/// </summary>
namespace terrasur
{
    public class planimetria
    {
        #region Propiedades
        //Propiedades privadas
        private string _lista_estados = "";
        private string _lista_archivos = "";
        private string _archivo_guia_lotes = "";
        private string _archivo_guia_datos = "";
        private System.Drawing.Size _size;

        //Propiedades públicas
        public string lista_estados { get { return _lista_estados; } set { _lista_estados = value; } }
        public string lista_archivos { get { return _lista_archivos; } set { _lista_archivos = value; } }
        public string archivo_guia_lotes { get { return _archivo_guia_lotes; } set { _archivo_guia_lotes = value; } }
        public string archivo_guia_datos { get { return _archivo_guia_datos; } set { _archivo_guia_datos = value; } }
        public System.Drawing.Size size { get { return _size; } set { _size = value; } }
        #endregion

        #region Constructores
        public planimetria(string Lista_estados, string Lista_archivos, string Archivo_guia_lotes, string Archivo_guia_datos, System.Drawing.Size Size)
        {
            _lista_estados = Lista_estados;
            _lista_archivos = Lista_archivos;
            _archivo_guia_lotes = Archivo_guia_lotes;
            _archivo_guia_datos = Archivo_guia_datos;
            _size = Size;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static void DatosPlanimetriaPorUrbanizacion(int Id_urbanizacion, ref string Lista_archivos, ref string Lista_estados, ref string Archivo_guia_lotes, ref string Archivo_guia_datos)
        {
            //[id_archivo],[nombre],[shp],[dbf],[shx],[guia_datos],[guia_lotes]
            DataTable tabla_archivos = archivo_shape.ListaArchivosPorUrbanizacion(Id_urbanizacion);
            System.Text.StringBuilder str_archivos = new System.Text.StringBuilder();
            foreach (DataRow fila in tabla_archivos.Rows)
            {
                string archivo_shp=Id_urbanizacion.ToString() + "shape" + fila["id_archivo"].ToString() + ".shp";
                if (((bool)fila["guia_lotes"]) == true) Archivo_guia_lotes = archivo_shp;
                if (((bool)fila["guia_datos"]) == true)
                {
                    Archivo_guia_datos = archivo_shp;
                    //if (((bool)fila["guia_lotes"]) == true) { str_archivos.Append(archivo_shp + ";"); }
                    str_archivos.Append(archivo_shp + ";");
                }
                else { str_archivos.Append(archivo_shp + ";"); }
            }
            Lista_archivos = str_archivos.ToString();
            Lista_estados = archivo_shape.ListaEstadoLoteActualPorUrbanizacion(Id_urbanizacion);
        }
        #endregion

        #region Métodos que requieren constructor
        public SharpMap.Map InitializeMap()
        {
            SharpMap.Map map = new SharpMap.Map(_size);
            string[] archivos = _lista_archivos.TrimEnd(';').Split(';');
            for (int j = 0; j < archivos.Length; j++)
            {
                SharpMap.Layers.VectorLayer layer = new SharpMap.Layers.VectorLayer("VectorLayer" + (j + 1).ToString());
                layer.DataSource = new SharpMap.Data.Providers.ShapeFile(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["shape_dir"] + archivos[j]), true);
                if (archivos[j] == _archivo_guia_lotes)
                {
                    layer.Theme = new SharpMap.Rendering.Thematics.CustomTheme(DefinirEstiloLote);
                }
                else if (archivos[j] == _archivo_guia_datos)
                {
                    layer.Theme = new SharpMap.Rendering.Thematics.CustomTheme(DefinirSubEstiloLote);
                }
                else
                {
                    layer.Style.Fill = new System.Drawing.SolidBrush(Color.Transparent);
                    layer.Style.Outline = System.Drawing.Pens.Black;
                    layer.Style.EnableOutline = true;
                }
                map.Layers.Add(layer);
            }
            return map;
        }

        private SharpMap.Styles.VectorStyle DefinirEstiloLote(SharpMap.Data.FeatureDataRow row)
        {
            SharpMap.Styles.VectorStyle style = new SharpMap.Styles.VectorStyle();
            string color_html = "#FFFFFF";

            string dato = archivo_shape.CodigoEstadoPorLote(row["ID"].ToString(), _lista_estados);
            string estado = ""; string condicion = "";

            bool con_muro_construccion = dato.Contains("|");
            if (dato.Contains("|") == true) dato = dato.Split('|')[0];

            if (dato.Contains("-") == true)
            {
                estado = dato.Split('-')[0];
                condicion = dato.Split('-')[1];
            }
            else { estado = dato; }

            //switch (estado)
            //{
            //    case "di": color_html = "#FEFF91"; break;
            //    case "bl": color_html = "#CAC6C6"; break;
            //    case "re": color_html = "#FFD9D9"; break;
            //    case "pr": color_html = "#C5FFFE"; break;
            //    case "ve": color_html = "#A4CEA4"; break;
            //    case "in": color_html = "#000000"; break;
            //    default: color_html = "#FFFFFF"; break;
            //}
            switch (estado)
            {
                case "di": color_html = "#F5760F"; break;
                case "it": color_html = "#0066AE"; break;
                case "ca": color_html = "#FF0000"; break;
                case "na": color_html = "#F6F90B"; break;
                case "ve": color_html = "#F777B9"; break;

                case "pr": color_html = "#00FFFF"; break;
                case "bl": color_html = "#A5A5A5"; break;
                case "re": color_html = "#663300"; break;
                case "in": color_html = "#000000"; break;
                default: color_html = "#000000"; break;
            }
            System.Drawing.Brush fondo_lote = new SolidBrush(ColorTranslator.FromHtml(color_html));
            style.Fill = fondo_lote;

            if (con_muro_construccion == true) { style.EnableOutline = true; style.Outline = new Pen(ColorTranslator.FromHtml("#484848"), 10); }

            return style;
        }

        private SharpMap.Styles.VectorStyle DefinirSubEstiloLote(SharpMap.Data.FeatureDataRow row)
        {
            SharpMap.Styles.VectorStyle style = new SharpMap.Styles.VectorStyle();

            string dato = archivo_shape.CodigoEstadoPorLote(row["ID"].ToString(), _lista_estados);
            string estado = ""; string condicion = "";

            if (dato.Contains("|") == true) dato = dato.Split('|')[0];

            if (dato.Contains("-") == true)
            {
                estado = dato.Split('-')[0];
                condicion = dato.Split('-')[1];

                Brush color_circulo;
                switch (condicion)
                {
                    //case "c": color_circulo = new SolidBrush(ColorTranslator.FromHtml("#7D99FF")); break;
                    //case "m": color_circulo = new SolidBrush(Color.Red); break;
                    //case "r": color_circulo = new SolidBrush(Color.Orange); break;
                    //case "d": color_circulo = new SolidBrush(Color.Green); break;
                    //default: color_circulo = new SolidBrush(Color.Transparent); break;

                    case "r": color_circulo = new SolidBrush(ColorTranslator.FromHtml("#F5760F")); break;
                    case "m": color_circulo = new SolidBrush(ColorTranslator.FromHtml("#FF0000")); break;
                    default: color_circulo = new SolidBrush(Color.Transparent); break;
                }
                style.Fill = color_circulo;
            }
            else { style.Fill = new System.Drawing.SolidBrush(Color.Transparent); }
            return style;
        }

        #endregion
    }
    
    public class archivo_shape
    {
        //Base de datos
        private static Database db1 = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings["conn"]);

        #region Propiedades
        //Propiedades privadas
        private int _id_archivo = 0;
        private int _id_urbanizacion = 0;
        private string _nombre = "";
        private string _shp = "";
        private string _dbf = "";
        private string _shx = "";
        private bool _guia_datos = false;
        private bool _guia_lotes = false;
        private int _id_usuario = 0;
        private DateTime _fecha = DateTime.Now;

        private string _nombre_usuario = "";

        //Propiedades públicas
        public int id_archivo { get { return _id_archivo; } set { _id_archivo = value; } }
        public int id_urbanizacion { get { return _id_urbanizacion; } set { _id_urbanizacion = value; } }
        public string nombre { get { return _nombre; } set { _nombre = value; } }
        public string shp { get { return _shp; } set { _shp = value; } }
        public string dbf { get { return _dbf; } set { _dbf = value; } }
        public string shx { get { return _shx; } set { _shx = value; } }
        public bool guia_datos { get { return _guia_datos; } set { _guia_datos = value; } }
        public bool guia_lotes { get { return _guia_lotes; } set { _guia_lotes = value; } }
        public int id_usuario { get { return _id_usuario; } set { _id_usuario = value; } }
        public DateTime fecha { get { return _fecha; } set { _fecha = value; } }

        public string nombre_usuario { get { return _nombre_usuario; } }
        #endregion

        #region Constructores
        public archivo_shape(int Id_archivo)
        {
            _id_archivo = Id_archivo;
            RecuperarDatos();
        }
        public archivo_shape(int Id_archivo, int Id_urbanizacion, string Nombre, bool Guia_datos, bool Guia_lotes)
        {
            _id_archivo = Id_archivo;
            _id_urbanizacion = Id_urbanizacion;
            _nombre = Nombre;
            _guia_datos = Guia_datos;
            _guia_lotes = Guia_lotes;
        }
        #endregion

        #region Métodos que NO requieren constructor
        public static bool ActualizarImagen(int Id_archivo, string Tipo_archivo, string Nombre_archivo, int Context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("archivo_shape_ActualizarImagen");
                db1.AddInParameter(cmd, "id_archivo", DbType.Int32, Id_archivo);
                db1.AddInParameter(cmd, "tipo_archivo", DbType.String, Tipo_archivo);
                db1.AddInParameter(cmd, "nombre_archivo", DbType.String, Nombre_archivo);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public static DataTable ListaUrbanizacion(int Id_localizacion)
        {
            //[id_urbanizacion],[nombre],[num_lotes],[num_archivos_shape],[fecha],[nombre_usuario]
            DbCommand cmd = db1.GetStoredProcCommand("archivo_shape_ListaUrbanizacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_localizacion", DbType.Int32, Id_localizacion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static DataTable ListaArchivosPorUrbanizacion(int Id_urbanizacion)
        {
            //[id_archivo],[nombre],[shp],[dbf],[shx],[guia_datos],[guia_lotes],[fecha],[nombre_usuario]
            DbCommand cmd = db1.GetStoredProcCommand("archivo_shape_ListaArchivosPorUrbanizacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }

        public static string ListaEstadoLoteActualPorUrbanizacion(int Id_urbanizacion)
        {
            //[id_lote],[codigo_estado]
            DbCommand cmd = db1.GetStoredProcCommand("archivo_shape_ListaEstadoLoteActualPorUrbanizacion");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, Id_urbanizacion);
            DataTable tabla = db1.ExecuteDataSet(cmd).Tables[0];

            System.Text.StringBuilder str = new System.Text.StringBuilder();
            foreach (DataRow fila in tabla.Rows)
                str.Append(fila["id_lote"].ToString() + ',' + fila["codigo_estado"].ToString() + ';');
            if (str.Length > 0) return str.ToString();
            else return ";";
        }

        public static string CodigoEstadoPorLote(string Id_lote, string Lista_lotes)
        {
            string[] lista_items = Lista_lotes.TrimEnd(';').Split(';');
            for (int j = 0; j < lista_items.Length; j++)
                if (lista_items[j].StartsWith(Id_lote + ',') == true)
                    return lista_items[j].Split(',')[1];
            return "";
        }

        public static DataTable ListaUrbanizacionConPlanimetria()
        {
            //[id_urbanizacion],[nombre]
            DbCommand cmd = db1.GetStoredProcCommand("archivo_shape_ListaUrbanizacionConPlanimetria");
            cmd.CommandTimeout = int.Parse(ConfigurationManager.AppSettings["CommandTimeout"]);
            return db1.ExecuteDataSet(cmd).Tables[0];
        }
        #endregion

        #region Métodos que requieren constructor
        private void RecuperarDatos()
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("archivo_shape_RecuperarDatos");
                db1.AddInParameter(cmd, "id_archivo", DbType.Int32, _id_archivo);

                db1.AddOutParameter(cmd, "id_urbanizacion", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre", DbType.String, 50);
                db1.AddOutParameter(cmd, "shp", DbType.String, 20);
                db1.AddOutParameter(cmd, "dbf", DbType.String, 20);
                db1.AddOutParameter(cmd, "shx", DbType.String, 20);
                db1.AddOutParameter(cmd, "guia_datos", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "guia_lotes", DbType.Boolean, 32);
                db1.AddOutParameter(cmd, "fecha", DbType.DateTime, 50);
                db1.AddOutParameter(cmd, "id_usuario", DbType.Int32, 32);
                db1.AddOutParameter(cmd, "nombre_usuario", DbType.String, 50);

                db1.ExecuteNonQuery(cmd);
                _id_urbanizacion = (int)db1.GetParameterValue(cmd, "id_urbanizacion");
                _nombre = (string)db1.GetParameterValue(cmd, "nombre");
                _shp = (string)db1.GetParameterValue(cmd, "shp");
                _dbf = (string)db1.GetParameterValue(cmd, "dbf");
                _shx = (string)db1.GetParameterValue(cmd, "shx");
                _guia_datos = (bool)db1.GetParameterValue(cmd, "guia_datos");
                _guia_lotes = (bool)db1.GetParameterValue(cmd, "guia_lotes");
                _fecha = (DateTime)db1.GetParameterValue(cmd, "fecha");
                _id_usuario = (int)db1.GetParameterValue(cmd, "id_usuario");
                _nombre_usuario = (string)db1.GetParameterValue(cmd, "nombre_usuario");
            }
            catch { }
        }

        public bool Insertar(int Context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("archivo_shape_Insertar");
                db1.AddInParameter(cmd, "id_urbanizacion", DbType.Int32, _id_urbanizacion);
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                db1.AddInParameter(cmd, "guia_datos", DbType.Boolean, _guia_datos);
                db1.AddInParameter(cmd, "guia_lotes", DbType.Boolean, _guia_lotes);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                _id_archivo = (int)db1.ExecuteScalar(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Actualizar(int Context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("archivo_shape_Actualizar");
                db1.AddInParameter(cmd, "id_archivo", DbType.Int32, _id_archivo);
                db1.AddInParameter(cmd, "nombre", DbType.String, _nombre);
                db1.AddInParameter(cmd, "guia_datos", DbType.Boolean, _guia_datos);
                db1.AddInParameter(cmd, "guia_lotes", DbType.Boolean, _guia_lotes);
                db1.AddInParameter(cmd, "id_usuario", DbType.Int32, Context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }

        public bool Eliminar(int Context_id_usuario)
        {
            try
            {
                DbCommand cmd = db1.GetStoredProcCommand("archivo_shape_Eliminar");
                db1.AddInParameter(cmd, "id_archivo", DbType.Int32, _id_archivo);
                db1.AddInParameter(cmd, "id_usuario", DbType.String, Context_id_usuario);
                db1.ExecuteNonQuery(cmd);
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}