using Dapper;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Dapper;
using TesteBasisBook.Domain.Adapters.Driven.Storage.Repositories;
using TesteBasisBook.PostgreSQL.Dapper;

namespace TesteBasisBook.PostgreSQL.Repositories
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private static IEnumerable<string> _listOfProperties;
        private static IEnumerable<string> _listOfPropertiesAlias;

        private static string _selectFields = string.Empty;

        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly string _tableName;
        private readonly string _schema;
        private readonly string _className;

        static GenericRepositoryAsync()
        {
            _listOfProperties = GenerateListOfProperties(typeof(T).GetProperties());
            _listOfPropertiesAlias = GenerateListOfPropertiesWhithAlias(typeof(T).GetProperties());
        }

        protected GenericRepositoryAsync(ISqlConnectionFactory sqlConnectionFactory, string tableName, string schema, string className)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _tableName = tableName;
            _schema = schema;
            _className = className;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var connection = _sqlConnectionFactory.GetOpenConnection();
                return await LoadFields(async () =>
                {
                    return await connection.QueryAsyncWithToken<T>($"SELECT {_selectFields} FROM {_schema}.\"{_tableName}\"",
                        cancellationToken: cancellationToken);
                }, true);
            }
            catch
            {
                throw;
            }
        }

        public async Task<T> GetAsync(object id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await LoadFields(async () =>
                {
                    var columPrimaryKey = GetPrimaryKey<T>();

                    using var connection = _sqlConnectionFactory.GetOpenConnection();
                    var result1 =
                        await connection.QuerySingleOrDefaultWithToken<object>($"SELECT {_selectFields} FROM {_schema}.\"{_tableName}\" WHERE \"{columPrimaryKey}\" =@Id",
                            new { Id = id }, cancellationToken: cancellationToken);
                    var result =
                        await connection.QuerySingleOrDefaultWithToken<T>($"SELECT {_selectFields} FROM {_schema}.\"{_tableName}\" WHERE \"{columPrimaryKey}\" =@Id",
                            new { Id = id }, cancellationToken: cancellationToken);
                    if (result == null) throw new KeyNotFoundException($"{_schema}.\"{_tableName}\" with {columPrimaryKey} [{id}] could not be found.");

                    return result;
                }, true);
            }
            catch(Exception e)
            {
                var x = e;
                throw;
            }
        }

        public async Task<int> InsertAsync(T t, CancellationToken cancellationToken = default)
        {
            try
            {
                var insertQuery = GenerateInsertQuery();
                var parameters = GenerateParameters(t);

                using var connection = _sqlConnectionFactory.GetOpenConnection();
                var result = await connection.ExecuteScalarAsyncWithToken(insertQuery, parameters, cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                Console.Write(result);
                return result;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred: {ex.Message}");
                Console.Error.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
        }


        public async Task UpdateAsync(T t, CancellationToken cancellationToken = default)
        {
            try
            {
                var updateQuery = GenerateUpdateQuery();

                using var connection = _sqlConnectionFactory.GetOpenConnection();
                var parameters = GenerateParameters(t);
                await connection.ExecuteAsyncWithToken(updateQuery, parameters, cancellationToken: cancellationToken);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteAsync(object id, CancellationToken cancellationToken = default)
        {
            try
            {
                var columPrimaryKey = GetPrimaryKey<T>();
                using var connection = _sqlConnectionFactory.GetOpenConnection();
                await connection.ExecuteAsyncWithToken($"DELETE FROM {_schema}.\"{_tableName}\" WHERE \"{columPrimaryKey}\"=@Id", new { Id = id },
                    cancellationToken: cancellationToken);
            }
            catch
            {
                throw;
            }
        }

        //uses transaction
        public async Task InsertRangeAsync(IEnumerable<T> t, CancellationToken cancellationToken = default)
        {
            var insertQuery = GenerateInsertQuery();

            using var dbConnection = _sqlConnectionFactory.GetOpenConnection();
            using var tran = dbConnection.BeginTransaction();

            try
            {
                await dbConnection.ExecuteAsyncWithToken(insertQuery, t, tran, cancellationToken: cancellationToken);
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw;
            }
        }

        #region PrivateHelperMethods

        private TU LoadFields<TU>(Func<TU> method, bool includeId = false)
        {
            try
            {
                if (string.IsNullOrEmpty(_selectFields)) _selectFields = GenerateSelectFields(_listOfPropertiesAlias, includeId);
                return method.Invoke();
            }
            catch
            {
                throw;
            }
        }

        private static IEnumerable<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            try
            {
                return (from prop in listOfProperties
                        let descriptionAttributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                        where descriptionAttributes.Length <= 0 || (descriptionAttributes[0] as DescriptionAttribute)?.Description != "ignore"
                        let columnAttributes = prop.GetCustomAttributes(typeof(ColumnAttribute), false)
                        select columnAttributes.Length > 0
                            ? $"\"{((ColumnAttribute)columnAttributes[0]).Name}\"" // Retorna o valor de [Column(Name = "value")]
                            : prop.Name // Caso não tenha [Column], retorna o nome da propriedade
                       ).ToList();
            }
            catch
            {
                throw;
            }
        }
        private static IEnumerable<string> GenerateListOfPropertiesWhithAlias(IEnumerable<PropertyInfo> listOfProperties)
        {
            try
            {
                return (from prop in listOfProperties
                        let descriptionAttributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                        where descriptionAttributes.Length <= 0 || (descriptionAttributes[0] as DescriptionAttribute)?.Description != "ignore"
                        let columnAttributes = prop.GetCustomAttributes(typeof(ColumnAttribute), false)
                        select columnAttributes.Length > 0
                            ? $"\"{((ColumnAttribute)columnAttributes[0]).Name}\" AS {prop.Name}"  // Retorna o valor de [Column(Name = "value")]
                            : prop.Name // Caso não tenha [Column], retorna o nome da propriedade
                       ).ToList();
            }
            catch
            {
                throw;
            }
        }
        private void IgnoreId(string property, Action action)
        {
            try
            {
                var columPrimaryKey = GetPrimaryKey<T>();

                if (!(property == $"\"{columPrimaryKey}\"")) action.Invoke();
            }
            catch
            {
                throw;
            }
        }

        private string GenerateSelectFields(IEnumerable<string> properties, bool includeId)
        {
            try
            {
                var fields = new StringBuilder();
                foreach (var property in properties)
                {
                    if (includeId == false)
                    {
                        IgnoreId(property, () => { fields.Append($"{property},"); });
                    }
                    else
                    {
                        fields.Append($"{property},");
                    }
                }

                fields.Remove(fields.Length - 1, 1);
                return fields.ToString();
            }
            catch
            {
                throw;
            }
        }

        private string GenerateInsertQuery()
        {
            try
            {
                var insertQuery = new StringBuilder($"INSERT INTO {_schema}.\"{_tableName}\" ");

                insertQuery.Append("(");
                foreach (var listOfProperty in _listOfProperties)
                {
                    //TODO: extract this check
                    IgnoreId(listOfProperty, () => { insertQuery.Append($"{listOfProperty},"); });
                }

                insertQuery.Remove(insertQuery.Length - 1, 1).Append(") VALUES (");

                foreach (var listOfProperty in _listOfProperties)
                {
                    IgnoreId(listOfProperty, () => { insertQuery.Append($"@{listOfProperty.Replace("\"","")},"); });
                }
                var columPrimaryKey = GetPrimaryKey<T>();
                if(columPrimaryKey != null)
                {
                    insertQuery.Remove(insertQuery.Length - 1, 1).Append($") RETURNING \"{columPrimaryKey}\";");

                }
                else
                {
                    insertQuery.Remove(insertQuery.Length - 1, 1).Append($")");

                }

                return insertQuery.ToString();
            }
            catch
            {
                throw;
            }
        }

        private string GenerateUpdateQuery()
        {
            try
            {
                var updateQuery = new StringBuilder($"UPDATE {_schema}.\"{_tableName}\" SET  ");

                foreach (var listOfProperty in _listOfProperties)
                {
                    IgnoreId(listOfProperty, () => { updateQuery.Append($"{listOfProperty} = @{listOfProperty.Replace("\"","")},"); });
                }

                updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
                var columPrimaryKey = GetPrimaryKey<T>();
                updateQuery.Append($" WHERE \"{columPrimaryKey}\" = @{columPrimaryKey}");

                return updateQuery.ToString();
            }
            catch
            {
                throw;
            }
        }
        private DynamicParameters GenerateParameters<T>(T entity)
        {
            try
            {
                var parameters = new DynamicParameters();
                var entityType = typeof(T);
                var properties = entityType.GetProperties();

                foreach (var property in properties)
                {
                    var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
                    var columnName = columnAttribute != null ? columnAttribute.Name : property.Name;

                    var value = property.GetValue(entity);
                    parameters.Add($"@{columnName}", value); // O nome do parâmetro ainda é baseado na propriedade
                }

                return parameters;
            }
            catch
            {
                throw;
            }
        }
        public static string GetPrimaryKey<T>()
        {
            var type = typeof(T);

            // Identifica as propriedades que têm o atributo [Key]
            var keyProperties = type.GetProperties()
                                    .Where(prop => prop.GetCustomAttribute<KeyAttribute>() != null)
                                    .ToList();

            // Se houver mais de uma propriedade com [Key], é uma chave composta
            if (keyProperties.Count > 1)
            {

                return string.Join(", ", keyProperties.Select(p => p.GetCustomAttribute<ColumnAttribute>().Name));
            }

            // Se houver uma propriedade com [Key], retorna o nome dessa propriedade
            if (keyProperties.Count == 1)
            {
                return keyProperties?.First()?.GetCustomAttribute<ColumnAttribute>()?.Name;
            }

            return null; // Caso não tenha nenhuma chave definida
        }
        #endregion
    }
}
