using Dapper;
using Models;
using System;
using BaseDatos;
using Interfaces;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Implementaciones
{
    public class PolizaImplementacion : IPoliza
    {
        private readonly Conexion conexionBd;

        public PolizaImplementacion(Conexion conexion)
        {
            conexionBd = conexion;
        }

        public bool Eliminar(int id)
        {
            try
            {
                using (SqlConnection context = new SqlConnection(conexionBd.ObtenerConexion().ConnectionString))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@numeropoliza", id);
                    context.Execute("pp_eliminar", parametros, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }

        public List<Poliza> Listar()
        {
            try
            {
                using (SqlConnection context = new SqlConnection(conexionBd.ObtenerConexion().ConnectionString))
                {
                    return context.Query<Poliza>("pp_listar", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public bool Modificar(Poliza poliza)
        {
            try
            {
                using (SqlConnection context = new SqlConnection(conexionBd.ObtenerConexion().ConnectionString))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@numeropoliza", poliza.NumeroPoliza);
                    parametros.Add("@nombrecliente", poliza.NombreCliente);
                    parametros.Add("@idcliente", poliza.IdCliente);
                    parametros.Add("@fechanacimiento", poliza.FechaNacimiento);
                    parametros.Add("@fechapoliza", poliza.FechaPoliza);
                    parametros.Add("@cobertura", poliza.Coberturas);
                    parametros.Add("@valormaximo", poliza.ValorMaximo);
                    parametros.Add("@nombrepoliza", poliza.NombrePoliza);
                    parametros.Add("@ciudadresidencia", poliza.CiudadResidencia);
                    parametros.Add("@direccionresidencia", poliza.DireccionResidencia);
                    parametros.Add("@placaautomotor", poliza.PlacaAutomotor);
                    parametros.Add("@modeloautomotor", poliza.ModeloAutomotor);
                    parametros.Add("@inspeccion", poliza.Inspeccion);
                    context.Execute("pp_modificar", parametros, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }

        public Poliza Obtener(int numeroPoliza)
        {
            try
            {
                using (SqlConnection context = new SqlConnection(conexionBd.ObtenerConexion().ConnectionString))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@numeropoliza", numeroPoliza);
                    return context.QueryFirstOrDefault<Poliza>("pp_obtener", parametros, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }

        public bool Registrar(Poliza poliza)
        {
            try
            {
                using (SqlConnection context = new SqlConnection(conexionBd.ObtenerConexion().ConnectionString))
                {
                    var parametros = new DynamicParameters();
                    parametros.Add("@numeropoliza", poliza.NumeroPoliza);
                    parametros.Add("@nombrecliente", poliza.NombreCliente);
                    parametros.Add("@idcliente", poliza.IdCliente);
                    parametros.Add("@fechanacimiento", poliza.FechaNacimiento);
                    parametros.Add("@fechapoliza", poliza.FechaPoliza);
                    parametros.Add("@cobertura", poliza.Coberturas);
                    parametros.Add("@valormaximo", poliza.ValorMaximo);
                    parametros.Add("@nombrepoliza", poliza.NombrePoliza);
                    parametros.Add("@ciudadresidencia", poliza.CiudadResidencia);
                    parametros.Add("@direccionresidencia", poliza.DireccionResidencia);
                    parametros.Add("@placaautomotor", poliza.PlacaAutomotor);
                    parametros.Add("@modeloautomotor", poliza.ModeloAutomotor);
                    parametros.Add("@inspeccion", poliza.Inspeccion);
                    context.Execute("pp_registrar", parametros, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }
    }
}