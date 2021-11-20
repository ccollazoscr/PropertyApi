using Property.Common.Configuration;
using Property.Common.Exception;
using Property.Infraestructure.Common.SQLServer;
using Property.Infraestructure.Entity;
using Property.Model.Dto;
using Property.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Property.Infraestructure.Adapter.SQLServer.Repository
{
    public class PropertyRepository : SQLServerBase, IPropertyRepository
    {
        public PropertyRepository(IRepositorySettings repositorySettings) : base(repositorySettings)
        {
        }


        public long Insert(PropertyEntity oPropertyEntity)
        {
            string sql = "INSERT INTO Property (Name,Address,Price,CodeInternal,Year,IdOwner) Values (@Name,@Address,@Price,@CodeInternal,@Year,@IdOwner);" +
                         "SELECT CAST(SCOPE_IDENTITY() as bigint);";
            long id = 0;
            using (var connection = GetConnection())
            {
                try
                {
                    id = connection.QuerySingle<long>(sql, oPropertyEntity);
                }
                catch (SqlException ex) when (ex.Number == 547)
                {
                    throw new CustomErrorException(EnumErrorCode.ConstraintViolated);
                }
            }
            return id;
        }

        public bool ExistProperty(string code)
        {
            string sql = "SELECT COUNT(1) FROM Property WHERE CodeInternal=@code";
            using (var connection = GetConnection())
            {
                return connection.ExecuteScalar<bool>(sql, new { code });
            }
        }

        public bool UpdatePrice(long idProperty, decimal price)
        {
            string sql = "UPDATE Property SET Price=@price WHERE IdProperty=@idProperty";
            using (var connection = GetConnection())
            {
                return connection.Execute(sql, new { price = price, idProperty = idProperty }) > 0;
            }
        }

        public bool ExistPropertyWithCondition(string code, long propertyId)
        {
            string sql = "SELECT COUNT(1) FROM Property WHERE CodeInternal=@code AND IdProperty<>@IdProperty";
            using (var connection = GetConnection())
            {
                return connection.ExecuteScalar<bool>(sql, new { code, IdProperty = propertyId });
            }
        }

        public bool UpdateProperty(PropertyEntity oPropertyEntity)
        {
            string sql = @"UPDATE Property 
                           SET Name=@Name,Address=@Address,Price=@Price,CodeInternal=@CodeInternal,Year=@Year,IdOwner=@IdOwner
                           WHERE IdProperty=@IdProperty";
            using (var connection = GetConnection())
            {
                return connection.Execute(sql, oPropertyEntity) > 0;
            }
        }

        public PropertyEntity GetById(long propertyId)
        {
            string sql = @"SELECT * FROM Property WHERE IdProperty=@IdProperty";
            using (var connection = GetConnection())
            {
                return connection.Query<PropertyEntity>(sql, new { IdProperty = propertyId }).FirstOrDefault();
            }
        }

        public List<GetListPropertyDto> GetList(PropertyBuilding oPropertyBuilding)
        {
            string sql = @"SELECT * FROM Property ";
            List<string> lstFilter = new List<string>();
            if (oPropertyBuilding.Id > 0) {
                lstFilter.Add($"IdProperty = {oPropertyBuilding.Id}");
            }
            if (!string.IsNullOrWhiteSpace(oPropertyBuilding.Name)) {
                lstFilter.Add($"Name = '{oPropertyBuilding.Name}'");
            }
            if (!string.IsNullOrWhiteSpace(oPropertyBuilding.Address))
            {
                lstFilter.Add($"Address = '{oPropertyBuilding.Address}'");
            }
            if (oPropertyBuilding.Price>0)
            {
                lstFilter.Add($"Price = '{oPropertyBuilding.Price}'");
            }
            if (!string.IsNullOrWhiteSpace(oPropertyBuilding.Code))
            {
                lstFilter.Add($"CodeInternal = '{oPropertyBuilding.Code}'");
            }
            if (oPropertyBuilding.Year>0)
            {
                lstFilter.Add($"Year = {oPropertyBuilding.Year}");
            }
            if (oPropertyBuilding.Owner?.Id > 0)
            {
                lstFilter.Add($"IdOwner = {oPropertyBuilding.Owner.Id}");
            }


            if (lstFilter.Count > 0) {
                string filter =" WHERE "+ String.Join(" AND ", lstFilter);
                sql += filter;
            }

            using (var connection = GetConnection())
            {
                return connection.Query<GetListPropertyDto>(sql).ToList();
            }
        }
    }
}
