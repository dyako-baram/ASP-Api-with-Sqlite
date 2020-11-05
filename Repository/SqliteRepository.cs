using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;

namespace Api.Repository
{
    public class SqliteRepository : ISqliteRepository
    {
        private readonly IConfiguration _config;
        public SqliteRepository(IConfiguration config)
        {
            _config = config;
        }
        public async Task DeletePerson(int id)
        {
             using(IDbConnection con=new SQLiteConnection(_config.GetConnectionString("SqlLiteConnection")))
            {
                //await con.ExecuteAsync("delete from personTable where Id=@id",new {id=id});
                await con.DeleteAsync(new PersonTable{Id=id});
            }
        }

        public async Task<List<PersonTable>> GetAllPerson()
        {
            using(IDbConnection con=new SQLiteConnection(_config.GetConnectionString("SqlLiteConnection")))
            {
                //var result= await con.QueryAsync<PersonTable>("Select * from PersonTable");
                var result= await con.GetAllAsync<PersonTable>();
                return result.ToList();
            }
        }

        public async Task<PersonTable> GetPerson(int id)
        {
            using(IDbConnection con=new SQLiteConnection(_config.GetConnectionString("SqlLiteConnection")))
            {
               // return await con.QueryFirstOrDefaultAsync<PersonTable>("Select * from PersonTable where Id=@id",new {id});
                return await con.GetAsync<PersonTable>(id);
            }
        }

        public async Task SavePerson(PersonTable person)
        {
           using(IDbConnection con=new SQLiteConnection(_config.GetConnectionString("SqlLiteConnection")))
            {
                //await con.ExecuteAsync("insert into personTable(FullName,Age) Values(@fullName,@age)",new {fullName=person.FullName,age=person.Age});
                await con.InsertAsync(new PersonTable{FullName=person.FullName,Age=person.Age});
            }
        }

        public async Task UpdatePerosn(PersonTable person)
        {
             using(IDbConnection con=new SQLiteConnection(_config.GetConnectionString("SqlLiteConnection")))
            {
               // await con.ExecuteAsync("update personTable set FullName=@fullName, Age=@age where Id=@id",new {fullName=person.FullName,age=person.Age,id=person.Id});
                await con.UpdateAsync<PersonTable>(new PersonTable(){FullName=person.FullName,Age=person.Age,Id=person.Id});
                //this update for sqlite has issue that why we wrote it that way
            }
        }
    }
}