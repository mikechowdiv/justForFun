using Data.Interfaces;
using System.Collections.Generic;
using Models.Tables;
using System.Data.SqlClient;

namespace Data.ADO
{
    public class StatesRepoADO : IStatesRepo
    {
        public List<State> GetAll()
        {
            List<State> states = new List<State>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StatesSelectAll",cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        State currentRow = new State();
                        currentRow.StateId = dr["StateId"].ToString();
                        currentRow.StateName = dr["StateName"].ToString();

                        states.Add(currentRow);
                    }
                   
                }
            }
            return states;
        }
    }
}
