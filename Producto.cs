using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaClase_CLASE_PARAMETRIZADA_
{
    internal class Producto<Tipo>
    {
        int32 _intClave;
        string _strDescripcion;
        string _strDepartamento;
        Tipo _PuntoReorden;

        public int Clave
        {
            get { return _intClave; }
            set { _intClave = value; }
        }
        public string Descripcion
        {
            get { return _strDescripcion; }
            set { _strDescripcion = value; }
        }
        public string Departamento
        {
            get { return _strDepartamento; }
            set { _strDepartamento = value; }
        }
        public Tipo PuntoReorden
        {
            get { return _PuntoReorden; }
            set { _PuntoReorden = value; }
        }
        public Producto() 
        {
            _intClave = 0;
            _strDescripcion = "DESCRIPCION";
            _strDepartamento = "DESCONOCIDO";
            _PuntoReorden = default ;
        }
        public Producto(int c, String descripcion,string depa ,Tipo punto)
        {
            _intClave = c;
            _strDescripcion= descripcion;
            _strDepartamento = depa;
            _PuntoReorden = punto;
        }
    }
}
