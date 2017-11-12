using Data.Interfaces;
using System;
using System.Collections.Generic;
using Models.Tables;
using System.Data.SqlClient;
using System.Data;

namespace Data.ADO
{
    public class StatesRepoAdo : IStatesRepo
    {
        public List<State> GetAll()
        {
            List<State> states = new List<State>();

            using (var cn = new SqlConnection(Settings.GetConn()))
            {
                SqlCommand cmd = new SqlCommand("StatesSelectAll",cn);
                cmd.CommandType = CommandType.StoredProcedure;
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
