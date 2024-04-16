using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class SqlServerContext
    {


        private SqlConnection sqlConn;

        /// <summary>
        /// Constructor de la clase Conexión
        /// </summary>
        public SqlServerContext()
        {
            var _configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();

            if (!string.IsNullOrEmpty(_configuration.GetConnectionString("ProveeduriaWeb")))
                this.sqlConn = new SqlConnection(_configuration.GetConnectionString("ProveeduriaWeb")?.ToString());
            else
                throw new ArgumentNullException("No se ha obtenido un string de conexión desde el archivo de configuración.");
        }

        public void EjecutarSQL(string ConsultaEjecutar)
        {
            try
            {
                // objeto que ejecutará la consulta en la base de datos
                SqlCommand cmd = new(ConsultaEjecutar, this.sqlConn);

                // abrir la conexión a la base de datos
                this.sqlConn.Open();

                // ejecuta la consulta en la base de datos
                cmd.ExecuteNonQuery();

                // cierra la conexión con la base de datos
                this.sqlConn.Close();
            }
            catch (Exception ex)
            {
                // valida que la conexión esté abierta para cerrarla
                if (this.sqlConn.State == ConnectionState.Open)
                    this.sqlConn.Close();

                // retorna el error
                throw new Exception("Se ha producido un error al realizar el registro de la información en la base de datos", ex);
            }
        }

        public void EjecutarSP(string NombreSP, List<SqlParameter> listaParametro)
        {
            try
            {
                // objeto que ejecutará la consulta en la base de datos
                SqlCommand cmd = new()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = NombreSP,
                    Connection = this.sqlConn
                };

                foreach (SqlParameter sqlParam in listaParametro)
                    cmd.Parameters.Add(sqlParam);

                // abrir la conexión a la base de datos
                this.sqlConn.Open();

                // ejecuta la consulta en la base de datos
                cmd.ExecuteNonQuery();

                // cierra la conexión con la base de datos
                this.sqlConn.Close();
            }
            catch (Exception ex)
            {
                // valida que la conexión esté abierta para cerrarla
                if (this.sqlConn.State == ConnectionState.Open)
                    this.sqlConn.Close();

                // retorna el error
                throw new Exception("Se ha producido un error al realizar el registro de la información en la base de datos", ex);
            }
        }

        public DataTable EjecutarSQLWithData(string ConsultaEjecutar)
        {
            try
            {
                // objeto que ejecutará la consulta en la base de datos
                SqlCommand cmd = new(ConsultaEjecutar, this.sqlConn);

                SqlDataAdapter adap = new SqlDataAdapter()
                {
                    SelectCommand = cmd
                };

                DataTable dtDatos = new DataTable();

                adap.Fill(dtDatos);

                return dtDatos;
            }
            catch (Exception ex)
            {
                // valida que la conexión esté abierta para cerrarla
                if (this.sqlConn.State == ConnectionState.Open)
                    this.sqlConn.Close();

                // retorna el error
                throw new Exception("Se ha producido un error al realizar el registro de la información en la base de datos", ex);
            }
        }

        public DataTable EjecutarSPWithData(string NombreSP, List<SqlParameter> listaParametro)
        {
            try
            {
                // objeto que ejecutará la consulta en la base de datos
                SqlCommand cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = NombreSP,
                    Connection = this.sqlConn
                };

                foreach (SqlParameter sqlParam in listaParametro)
                    cmd.Parameters.Add(sqlParam);

                SqlDataAdapter adap = new SqlDataAdapter()
                {
                    SelectCommand = cmd
                };

                DataTable dtDatos = new DataTable();

                adap.Fill(dtDatos);

                return dtDatos;
            }
            catch (Exception ex)
            {
                // valida que la conexión esté abierta para cerrarla
                if (this.sqlConn.State == ConnectionState.Open)
                    this.sqlConn.Close();

                // retorna el error
                throw new Exception("Se ha producido un error al realizar el registro de la información en la base de datos", ex);
            }
        }

        public DataSet EjecutarSPWithddata(string NombreSP, List<SqlParameter> listaParametro)
        {
            try
            {
                // objeto que ejecutará la consulta en la base de datos
                SqlCommand cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = NombreSP,
                    Connection = this.sqlConn
                };

                foreach (SqlParameter sqlParam in listaParametro)
                    cmd.Parameters.Add(sqlParam);

                SqlDataAdapter adap = new SqlDataAdapter()
                {
                    SelectCommand = cmd
                };

                DataSet dtDatos = new DataSet();

                adap.Fill(dtDatos);

                return dtDatos;
            }
            catch (Exception ex)
            {
                // valida que la conexión esté abierta para cerrarla
                if (this.sqlConn.State == ConnectionState.Open)
                    this.sqlConn.Close();

                // retorna el error
                throw new Exception("Se ha producido un error al realizar el registro de la información en la base de datos", ex);
            }
        }
    }
}
