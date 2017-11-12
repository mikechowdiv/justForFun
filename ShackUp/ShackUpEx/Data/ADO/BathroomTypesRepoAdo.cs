using Data.Interfaces;
using System.Collections.Generic;
using Models.Tables;
using System.Data.SqlClient;

namespace Data.ADO
{
    public class BathroomTypesRepoAdo : IBathroomTypesRepo
    {
        public List<BathroomType> GetAll()
        {
            List<BathroomType> bathroomTypes = new List<BathroomType>();
            using (var cn = new SqlConnection(Settings.GetConn()))
            {
                SqlCommand cmd = new SqlCommand("BathroomTypesSelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BathroomType currentRow = new BathroomType();
                        currentRow.BathroomTypeId = (int)dr["BathroomTypeId"];
                        currentRow.BathroomTypeName = dr["BathroomTypeName"].ToString();
                        bathroomTypes.Add(currentRow);
                    }
                    
                }
            }
            return bathroomTypes;
        }  
    }
}
