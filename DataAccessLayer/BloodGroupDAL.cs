using BusinessLayer.Model;
using BusinessLayer.Services;
using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BloodGroupDAL: IBloodGroupServices 
    {
              DbConnectionOp dBConnectionOp = new DbConnectionOp();



        //-----GET ALL COURSE DETAILS------//
        public IEnumerable<BloodGroup> GetAllBloodGroup()
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
               new SqlParameter("@Action","SELECT")
            };
            using (var reader = dBConnectionOp.GetDataReader("BloodGroupSP", parameters))
            {
                while (reader.Read())
                {
                    yield return new BloodGroup
                    {
                        BloodGroupId = reader.IsDBNull("BloodGroupId") ? 0 : reader.GetInt32("BloodGroupId"),
                        BloodGroupName = reader.IsDBNull("BloodGroupName") ? string.Empty : reader.GetString("BloodGroupName")            
                    };

                }

            }

        }


        //-----GET BLOODGROUP BY ID------//


        public IEnumerable<BloodGroup> GetBloodGroupById(int id)
            {
                List<SqlParameter> parameters = new List<SqlParameter>
            {
               new SqlParameter("@bid",id),
               new SqlParameter("@Action","SELECTBYID")
            };

                using (var reader = dBConnectionOp.GetDataReader("BloodGroupSP",parameters))
                {
                    while (reader.Read())
                    {
                        yield return new BloodGroup
                        {
                            BloodGroupId = reader.IsDBNull("BloodGroupId") ? 0 : reader.GetInt32("BloodGroupId"),
                            BloodGroupName = reader.IsDBNull("BloodGroupName") ? string.Empty : reader.GetString("BloodGroupName")
                        };

                    }

                }
            }



            //-----ADD BLOODGROUP------//

            public void AddNewBloodGroup(BloodGroup bloodgroup)
            {
                List<SqlParameter> parameters = new List<SqlParameter>
              {
                 new SqlParameter("@bgname",bloodgroup.BloodGroupName),
                 new SqlParameter("@Action","INSERT")
              };
                dBConnectionOp.ExecuteNonQuery("BloodGroupSP",parameters);

            }



            //-----UPDATE BLOODGROUP------//

            public void UpdateBloodGroup(int id, BloodGroup bloodgroup)
            {
                List<SqlParameter> parameters = new List<SqlParameter>

            {
                 new SqlParameter("@bgname",bloodgroup.BloodGroupName),
                 new SqlParameter("@Action","UPDATE")
            };
                dBConnectionOp.ExecuteNonQuery("BloodGroupSP",parameters);
            }


            //-----DELETE BLOODGROUP------//

            public void DeleteBloodGroup(int id)
            {

                List<SqlParameter> parameters = new List<SqlParameter>
            {
                  new SqlParameter("@bid",id),
                  new SqlParameter("@Action","DELETE")
            };
                dBConnectionOp.ExecuteNonQuery("BloodGroupSP", parameters);

            }



        }
    }
