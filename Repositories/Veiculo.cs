using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace WebAPI.Repositories
{
    public class Veiculo
    {
        private readonly SqlConnection _sqlConnection;
        private readonly SqlCommand _sqlCommand;
        public Veiculo(string connectionString) {
            _sqlConnection = new SqlConnection(connectionString);
            _sqlCommand = new SqlCommand();
            _sqlCommand.Connection = _sqlConnection;
        }

        public async Task<List<Models.Veiculo>> GetAllVeiculos()
        {
            List<Models.Veiculo> veiculoList= new List<Models.Veiculo>();
            using(_sqlConnection)
            {
                await _sqlConnection.OpenAsync();
                using(_sqlCommand)
                {
                    _sqlCommand.CommandText = "SELECT id, marca, nome, anoModelo, dataFabricacao, valor, opcionais FROM VEICULOS;";
                    SqlDataReader dataReader = await _sqlCommand.ExecuteReaderAsync();
                    while (await dataReader.ReadAsync())
                    {
                        Models.Veiculo veiculo = new Models.Veiculo();
                        veiculo.Id = (int)dataReader["id"];
                        veiculo.Marca = (string)dataReader["marca"];
                        veiculo.Nome = (string)dataReader["nome"];
                        veiculo.AnoModelo = (int)dataReader["anoModelo"];
                        if (!(dataReader["dataFabricacao"] is DBNull))
                            veiculo.DataFabricacao = (DateTime)dataReader["dataFabricacao"];
                        if (!(dataReader["valor"] is DBNull))
                            veiculo.Valor = (decimal)dataReader["valor"];
                        veiculo.Opcionais = (string)dataReader["opcionais"];
                        veiculoList.Add(veiculo);
                    }
                }
            }
            return veiculoList;
        }

        public async Task<Models.Veiculo> GetVeiculoById(int id)
        {
            Models.Veiculo veiculo = new Models.Veiculo();
            using (_sqlConnection)
            {
                await _sqlConnection.OpenAsync();
                using (_sqlCommand)
                {
                    _sqlCommand.CommandText = "SELECT id, marca, nome, anoModelo, dataFabricacao, valor, opcionais FROM VEICULOS where id = @id;";
                    _sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                    SqlDataReader dataReader= await _sqlCommand.ExecuteReaderAsync();
                    if(await dataReader.ReadAsync())
                    {
                        veiculo.Id = (int)dataReader["id"];
                        veiculo.Marca = (string)dataReader["marca"];
                        veiculo.Nome = (string)dataReader["nome"];
                        veiculo.AnoModelo = (int)dataReader["anoModelo"];
                        if (!(dataReader["dataFabricacao"] is DBNull))
                            veiculo.DataFabricacao = (DateTime)dataReader["dataFabricacao"];
                        if (!(dataReader["valor"] is DBNull))
                            veiculo.Valor = (decimal)dataReader["valor"];
                        veiculo.Opcionais = (string)dataReader["opcionais"];
                    }
                }
            }
            return veiculo;
        }

        public async Task AddVeiculo(Models.Veiculo veiculo)
        {
            using (_sqlConnection)
            {
                await _sqlConnection.OpenAsync();
                using(_sqlCommand)
                {
                    _sqlCommand.CommandText = "insert into veiculos (marca, nome, anoModelo, dataFabricacao, valor, opcionais)" +
                                                            "values (@marca, @nome, @anoModelo, @dataFabricacao, @valor, @opcionais);" +
                                                            "select convert(int,scope_identity());";
                    _sqlCommand.Parameters.Add(new SqlParameter("@marca", SqlDbType.VarChar)).Value = veiculo.Marca;
                    _sqlCommand.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar)).Value = veiculo.Nome;
                    _sqlCommand.Parameters.Add(new SqlParameter("@anoModelo", SqlDbType.Int)).Value = veiculo.AnoModelo;
                    _sqlCommand.Parameters.Add(new SqlParameter("@dataFabricacao", SqlDbType.Date)).Value = veiculo.DataFabricacao;
                    _sqlCommand.Parameters.Add(new SqlParameter("@valor", SqlDbType.Decimal)).Value = veiculo.Valor;
                    _sqlCommand.Parameters.Add(new SqlParameter("@opcionais", SqlDbType.VarChar)).Value = veiculo.Opcionais;
                    veiculo.Id = (int) await _sqlCommand.ExecuteScalarAsync();
                }
            }
        }

        public async Task<bool> UpdateVeiculo(Models.Veiculo veiculo)
        {
            int linhasAfetadas = 0;
            using (_sqlConnection)
            {
                await _sqlConnection.OpenAsync();
                using (_sqlCommand)
                {
                    _sqlCommand.CommandText = "UPDATE veiculos " +
                        "SET marca = @marca, nome = @nome, anoModelo = @anoModelo, dataFabricacao = @dataFabricacao, valor = @valor, opcionais = @opcionais " +
                        "WHERE id = @id";
                    _sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = veiculo.Id;
                    _sqlCommand.Parameters.Add(new SqlParameter("@marca", SqlDbType.VarChar)).Value = veiculo.Marca;
                    _sqlCommand.Parameters.Add(new SqlParameter("nome", SqlDbType.VarChar)).Value = veiculo.Nome;
                    _sqlCommand.Parameters.Add(new SqlParameter("@anoModelo", SqlDbType.Int)).Value = veiculo.AnoModelo;
                    _sqlCommand.Parameters.Add(new SqlParameter("@dataFabricacao", SqlDbType.Date)).Value = veiculo.DataFabricacao;
                    _sqlCommand.Parameters.Add(new SqlParameter("@valor", SqlDbType.Decimal)).Value = veiculo.Valor;
                    _sqlCommand.Parameters.Add(new SqlParameter("@opcionais", SqlDbType.VarChar)).Value = veiculo.Opcionais;
                    linhasAfetadas = await _sqlCommand.ExecuteNonQueryAsync();
                }
            }
            return linhasAfetadas > 0;
        }

        public async Task<bool> DeleteVeiculo(int id)
        {
            int linhasAfetadas = 0;
            using(_sqlConnection)
            {
                await _sqlConnection.OpenAsync();
                using(_sqlCommand)
                {
                    _sqlCommand.CommandText = "DELETE FROM veiculos where id = @id;";
                    _sqlCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int)).Value = id;
                    linhasAfetadas = await _sqlCommand.ExecuteNonQueryAsync();
                }
            }
            return linhasAfetadas > 0;
        }
    }
}