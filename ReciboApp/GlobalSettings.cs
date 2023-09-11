using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciboApp
{
    public class GlobalSettings
    {
        private static GlobalSettings instance;

        // Global variables
        public string FolioId { get; set; }
        public int Proceso_temp { get; set; }
        public string Rol { get; set; }
        public string Codigo { get; set; }
        public string IdCodigo { get; set; }
        public List<int> OficialCodigo { get; set; }
        public bool CambioColor { get; set; }
        public bool Incompleto { get; set; }
        public bool MasterMulti { get; set; }
        public decimal temporal { get; set; }

        // Private constructor for Singleton pattern
        private GlobalSettings()
        {
            OficialCodigo = new List<int>();
        }

        // Get the instance of GlobalSettings
        public static GlobalSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalSettings();
                }
                return instance;
            }
        }
    }
    public class Articulo
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Medida { get; set; }
        public decimal Precio { get; set; }
        public int Contenido { get; set; }
        public decimal Piezas { get; set; }
        public decimal Recibidas { get; set; }
        public decimal Objetivo { get; set; }
        public decimal Escaneadas { get; set; }
        public decimal Pendiente { get; set; }
        public string Clave { get; set; }
    }
}
