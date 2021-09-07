using GastosMensuales.Interfaces;
using GastosMensuales.Models.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GastosMensuales.Infrastructure.DataAccess
{
    public class Sql: IDataAccess
    {
        public static string strConexion = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

        public void CrearGasto(Gasto gasto)
        {
            string sql = @" INSERT INTO Ingresos (Nombre,Descripcion,Monto,Periodicidad,Cuotas,TipoMonto) VALUES (@Nombre,@Descripcion,@Monto,@Periodicidad,@Cuotas,@TipoMonto)  
                            DECLARE @Id_Ingreso AS INT 
                            SET @Id_Gasto =(SELECT DISTINCT TOP (1) Id FROM Gastos WHERE Nombre = @Nombre ORDER BY Id DESC) 
                            INSERT INTO R_PresupuestoGasto (Id_Presupuesto,Id_Gasto) VALUES (@IdPresupuesto,@Id_Gasto) ";

            SqlConnection objConexion = new SqlConnection(strConexion);
            SqlCommand objComAgregar = new SqlCommand(sql, objConexion);
            objComAgregar.Parameters.AddWithValue("@Nombre", gasto.Nombre);
            objComAgregar.Parameters.AddWithValue("@Descripcion", gasto.Descripcion);
            objComAgregar.Parameters.AddWithValue("@Monto", Convert.ToDecimal(gasto.Monto));
            objComAgregar.Parameters.AddWithValue("@Periodicidad", Convert.ToInt32(gasto.Periodicidad));
            objComAgregar.Parameters.AddWithValue("@Cuotas", Convert.ToInt32(gasto.Cuotas));
            objComAgregar.Parameters.AddWithValue("@TipoMonto", Convert.ToInt32(gasto.TipoMonto));
            objComAgregar.Parameters.AddWithValue("@IdPresupuesto", Convert.ToInt32(gasto.IdPresupuesto));
            objComAgregar.CommandType = CommandType.Text;
            try
            {
                objConexion.Open();
                objComAgregar.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                throw new Exception("ERROR EN BASE DE DATOS");
            }
            finally
            {

                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();

            }
        }

        public void CrearIngreso(Ingreso ingreso)
        {
            string sql = @" INSERT INTO Ingresos (Nombre,Descripcion,Monto,Periodicidad,TipoMonto) VALUES (@Nombre,@Descripcion,@Monto,@Periodicidad,@TipoMonto)  
                            DECLARE @Id_Ingreso AS INT 
                            SET @Id_Ingreso =(SELECT DISTINCT TOP (1) Id FROM Ingresos  WHERE Nombre = @Nombre ORDER BY Id DESC) 
                            INSERT INTO R_PresupuestoIngreso (Id_Presupuesto,Id_Ingreso) VALUES (@IdPresupuesto,@Id_Ingreso) ";
              
            SqlConnection objConexion = new SqlConnection(strConexion);
            SqlCommand objComAgregar = new SqlCommand(sql, objConexion);
            objComAgregar.Parameters.AddWithValue("@Nombre", ingreso.Nombre);
            objComAgregar.Parameters.AddWithValue("@Descripcion", ingreso.Descripcion);
            objComAgregar.Parameters.AddWithValue("@Monto", Convert.ToDecimal(ingreso.Monto));
            objComAgregar.Parameters.AddWithValue("@Periodicidad", Convert.ToInt32(ingreso.Periodicidad));
            objComAgregar.Parameters.AddWithValue("@TipoMonto", Convert.ToInt32(ingreso.TipoMonto));
            objComAgregar.Parameters.AddWithValue("@IdPresupuesto", Convert.ToInt32(ingreso.IdPresupuesto));
            objComAgregar.CommandType = CommandType.Text;
            try
            {
                objConexion.Open();
                objComAgregar.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                throw new Exception("ERROR EN BASE DE DATOS");
            }
            finally
            {

                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();

            }
        }

        public void CrearPresupuesto(Presupuesto presupuesto)
        {
            string sql = @" INSERT INTO Presupuestos (Año,Mes,Nombre,Ingresos,Gastos,Total) VALUES (@Año,@Mes,@Nombre,@Ingresos,@Gastos,@Total)";

            SqlConnection objConexion = new SqlConnection(strConexion);
            SqlCommand objComAgregar = new SqlCommand(sql, objConexion);
            objComAgregar.Parameters.AddWithValue("@Año", Convert.ToInt32(presupuesto.Año));
            objComAgregar.Parameters.AddWithValue("@Mes", Convert.ToInt32(presupuesto.Mes));
            objComAgregar.Parameters.AddWithValue("@Nombre", presupuesto.Nombre);
            objComAgregar.Parameters.AddWithValue("@Ingresos", Convert.ToDecimal(presupuesto.Ingresos));
            objComAgregar.Parameters.AddWithValue("@Gastos", Convert.ToDecimal(presupuesto.Gastos));
            objComAgregar.Parameters.AddWithValue("@Total", Convert.ToDecimal(presupuesto.Total));
            objComAgregar.CommandType = CommandType.Text;
            try
            {
                objConexion.Open();
                objComAgregar.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                throw new Exception("ERROR EN BASE DE DATOS");
            }
            finally
            {

                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();

            }
        }

        public void EliminarGasto(int idGasto)
        {
            string sql = "DELETE  FROM Gastos where RTRIM(Id) ='" + idGasto.ToString().Trim() + "'";
            SqlConnection objConexion = new SqlConnection(strConexion);
            SqlCommand objComEliminar = new SqlCommand(sql, objConexion);
            objComEliminar.CommandType = CommandType.Text;
            try
            {
                objConexion.Open();
                objComEliminar.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                throw new Exception("ERROR EN BASE DE DATOS");
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }

        public void EliminarIngreso(int idIngreso)
        {
            string sql = "DELETE  FROM Ingresos where RTRIM(Id) ='" + idIngreso.ToString().Trim() + "'";
            SqlConnection objConexion = new SqlConnection(strConexion);
            SqlCommand objComEliminar = new SqlCommand(sql, objConexion);
            objComEliminar.CommandType = CommandType.Text;
            try
            {
                objConexion.Open();
                objComEliminar.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                throw new Exception("ERROR EN BASE DE DATOS");
            }
            finally
            {
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();
            }
        }

        public DataTable InformePrespuesto(string fechaDesde, string fechaHasta)
        {
            throw new NotImplementedException();
        }

        public void ModificarGasto(Gasto gasto)
        {

            string sql = @"UPDATE Presupuestos
                            SET Nombre = @Nombre, 
                                Descripcion = @Descripcion, 
                                Monto = @Monto, 
                                Periodicidad = @Periodicidad, 
                                Cuotas = @Cuotas, 
                                TipoMonto = @TipoMonto
                             WHERE id = @Id;";

            SqlConnection objConexion = new SqlConnection(strConexion);
            SqlCommand objComModificar = new SqlCommand(sql, objConexion);
            objComModificar.Parameters.AddWithValue("@Id", Convert.ToInt32(gasto.Id));
            objComModificar.Parameters.AddWithValue("@Nombre", gasto.Nombre);
            objComModificar.Parameters.AddWithValue("@Descripcion", gasto.Descripcion);
            objComModificar.Parameters.AddWithValue("@Monto", Convert.ToDecimal(gasto.Monto));
            objComModificar.Parameters.AddWithValue("@Periodicidad", Convert.ToInt32(gasto.Periodicidad));
            objComModificar.Parameters.AddWithValue("@Cuotas", Convert.ToInt32(gasto.Cuotas));
            objComModificar.Parameters.AddWithValue("@TipoMonto", Convert.ToInt32(gasto.TipoMonto));
            objComModificar.Parameters.AddWithValue("@IdPresupuesto", Convert.ToInt32(gasto.IdPresupuesto));
            objComModificar.CommandType = CommandType.Text;
            try
            {
                objConexion.Open();
                objComModificar.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                throw new Exception("ERROR EN BASE DE DATOS");
            }
            finally
            {

                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();

            }
        }

        public void ModificarIngreso(Ingreso ingreso)
        {
            string sql = @"UPDATE Ingresos
                            SET Nombre = @Nombre, 
                                Descripcion = @Descripcion, 
                                Monto = @Monto, 
                                Periodicidad = @Periodicidad, 
                                TipoMonto = @TipoMonto
                             WHERE id = @Id;";

            SqlConnection objConexion = new SqlConnection(strConexion);
            SqlCommand objComModificar = new SqlCommand(sql, objConexion);
            objComModificar.Parameters.AddWithValue("@Id", Convert.ToInt32(ingreso.Id));
            objComModificar.Parameters.AddWithValue("@Nombre", ingreso.Nombre);
            objComModificar.Parameters.AddWithValue("@Descripcion", ingreso.Descripcion);
            objComModificar.Parameters.AddWithValue("@Monto", Convert.ToDecimal(ingreso.Monto));
            objComModificar.Parameters.AddWithValue("@Periodicidad", Convert.ToInt32(ingreso.Periodicidad));
            objComModificar.Parameters.AddWithValue("@TipoMonto", Convert.ToInt32(ingreso.TipoMonto));
            objComModificar.Parameters.AddWithValue("@IdPresupuesto", Convert.ToInt32(ingreso.IdPresupuesto));
            objComModificar.CommandType = CommandType.Text;
            try
            {
                objConexion.Open();
                objComModificar.ExecuteNonQuery();
            }
            catch (SqlException)
            {

                throw new Exception("ERROR EN BASE DE DATOS");
            }
            finally
            {

                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();

            }
        }

        public DataTable TraerGastos(string presupuesto)
        {
            DataTable dt = new DataTable();
            string sql = @" DECLARE @Id_Presupuesto AS INT 
                            SET @Id_Presupuesto =(SELECT DISTINCT TOP (1) Id FROM Presupuestos WHERE Nombre = '" + presupuesto.Trim() + "' ORDER BY Id DESC)"+
                            @"SELECT g.Nombre,g.Monto 
                            FROM Gastos g INNER JOIN 
                                 R_PresupuestoGasto pg ORDER ON g.Id = pg.Id_Gasto
                            WHERE pg.Id_Presupuesto = @Id_Presupuesto
                            BY g.Id DESC";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(sql, strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }

        public DataTable TraerIngresos(string presupuesto)
        {
            DataTable dt = new DataTable();
            string sql = @" DECLARE @Id_Presupuesto AS INT 
                            SET @Id_Presupuesto =(SELECT DISTINCT TOP (1) Id FROM Presupuestos WHERE Nombre = '" + presupuesto.Trim() + "' ORDER BY Id DESC)" +
                            @"SELECT i.Nombre,i.Monto 
                            FROM Ingresos i INNER JOIN 
                                 R_PresupuestoIngreso pi ORDER ON g.Id = pi.Id_Ingreso
                            WHERE pi.Id_Presupuesto = @Id_Presupuesto
                            BY i.Id DESC";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(sql, strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }

        public DataTable TraerNombrePresupuesto()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT Nombre FROM Presupuestos ORDER BY Id DESC";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(sql,strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
    }
}
