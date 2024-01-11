using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.Database
{
    public class Database_setup
    {
        const string DATABASENAME = "EstablishmentManager"; // Update "EstablishmentManager" if you want another database name.
        const string CONNECTIONSTRING = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";

        public static bool CreatDataBase()
        {
            void CreateDB()
            {
                string qString = $"CREATE DATABASE {DATABASENAME} ON PRIMARY " +
                 $"(NAME = {DATABASENAME}_Data, " +
                 $@"FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\{DATABASENAME}.mdf', " + //Check if your file location is the same and the version of the MSSQL16.SQLEXPRESS.
                 "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
                 $"LOG ON (NAME = {DATABASENAME}_Log, " +
                 $@"FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\{DATABASENAME}.ldf', " + //Check if your file location is the same and the version of the MSSQL16.SQLEXPRESS.
                 "SIZE = 1MB, " +
                 "MAXSIZE = 5MB, " +
                 "FILEGROWTH = 10%);";
                ExecuteQuery(qString);
            }
            CreateDB();

            string queryString = $"use {DATABASENAME};" +
            "create table [permissions] ([id] int primary key identity(1,1), [level] int);" +
            "create table [user] ([id] int primary key identity(1,1),[id_permission] int foreign key references [permissions](id), [login] varchar(50), [password] varchar(50));" +
            "create table [employee] ([id] int primary key identity(1,1), [id_user] int foreign key references [user](id),[birthday] date, [name] varchar(100), [cpf] varchar(11));" +
            "create table [product] ([id] int primary key identity(1,1), [name] varchar(100), [description] varchar(100), [category] varchar(100), [cost_price] decimal, [sell_price] decimal);" +
            "create table [product_addons] ([id] int primary key identity(1,1), [name] varchar(100), [description] varchar(100), [category] varchar(100), [cost_price] decimal, [sell_price] decimal);" +
            "create table [product_observation] ([id] int primary key identity(1,1), [info] varchar(100), [category] varchar(100));" +
            "create table [stock] ([id] int primary key identity(1,1), [id_product] int foreign key references product(id), [quantity] int);" +
            "create table [ids_of_product_addons] ([id] int primary key identity(1,1), [id_product] int foreign key references product(id), [id_product_addons] int foreign key references product_addons(id));" +
            "create table [ids_of_observation] ([id] int primary key identity(1,1), [id_product] int foreign key references product(id), [id_product_observation] int foreign key references product_observation(id));" +
            "create table [group_of_product] ([id] int primary key identity(1,1), [name] varchar(100), [description] varchar(100), [category] varchar(100), [cost_price] decimal, [sell_price] decimal);" +
            "create table [ids_of_product_on_group] ([id] int primary key identity(1,1), [id_of_group_of_product] int foreign key references group_of_product(id), [id_product] int foreign key references product(id));" +
            "create table [promotions] ([id] int primary key identity(1,1), [id_product] int foreign key references product(id), [id_group_of_product] int foreign key references group_of_product(id), [name] varchar(100), [description] varchar(100), [sell_price] decimal, [category] varchar(100));" +
            "create table [table] ([id] int primary key identity(1,1),[id_orders] int, [name] varchar(100), [date] date, [time] time);" +
            "create table [delivery] ([id] int primary key identity(1,1), [id_deliveryman_employee] int foreign key references employee(id), [id_orders] int, [id_client] int, [tax_value] decimal, [date] date, [time] time, [time_deliveryman_arrived] time, [schedule_date] date);" +
            "create table [order] ([id] int primary key identity(1,1), [id_table] int foreign key references [table](id), [id_delivery] int foreign key references delivery(id), [id_payment_value] int, [client_name_note] varchar(100), [observation] varchar(100));" +
            "create table [id_orders] ([id] int primary key identity(1,1), [id_table] int foreign key references [table](id), [id_delivery] int foreign key references delivery(id), [id_order] int foreign key references [order](id));" +
            "create table [payment_method] ([id] int primary key identity(1,1), [type] varchar(100), [name] varchar(100));" +
            "create table [payment_value] ([id] int primary key identity(1,1), [id_payment_method] int foreign key references payment_method(id), [value] decimal);" +
            "create table [transaction] ([id] int primary key identity(1,1), [id_payment_method] int foreign key references payment_method(id), [id_order] int foreign key references [order](id), [date] date, [time] time);" +
            "create table [client] ([id] int primary key identity(1,1), [name] varchar(200), [cpf] varchar(11), [birthday] date, [rg] varchar(9), [creation_date] date);" +
            "create table [client_address] ([id] int primary key identity(1,1), [street_name] varchar (200), [cep] varchar(8), [complement] varchar (200), [reference] varchar (200), [number] varchar(10), [description] varchar (200));" +
            "create table [client_telephone] ([id] int primary key identity(1,1), [number] varchar(13), [description] varchar (200));" +
            "create table [id_client_address] ([id] int primary key identity(1,1), [id_client] int foreign key references client(id), [id_address] int foreign key references client_address(id));" +
            "create table [id_client_telephones] ([id] int primary key identity(1,1), [id_client] int foreign key references client(id), [id_telephones] int foreign key references client_telephone(id));" +
            "alter table [table] add constraint fk_id_orders foreign key (id_orders) references id_orders(id);" +
            "alter table [delivery] add constraint fk_id_orders_delivery foreign key (id_orders) references id_orders(id);" +
            "alter table [delivery] add constraint fk_id_client_delivery foreign key (id_client) references client(id);" +
            "alter table [order] add constraint fk_id_payment_value_order foreign key (id_payment_value) references payment_value(id);";
            ExecuteQuery(queryString);
            return true;
        }


        //public ClientClass SearchClient(string id)
        //{
        //    string searchQuery = $"SELECT * FROM [dbo].[CLIENTS] WHERE [ID] = '{id}'";
        //    ClientClass client = new ClientClass("", "", "", "");

        //    using (SqlConnection connectionString = new SqlConnection(CONNECTIONSTRING))
        //    using (SqlCommand myCommand = new SqlCommand(searchQuery, connectionString))
        //    {
        //        connectionString.Open();
        //        using (SqlDataReader reader = myCommand.ExecuteReader())
        //        {
        //            try
        //            {
        //                while (reader.Read())
        //                {
        //                    client.name = reader[0].ToString();
        //                    client.age = reader[1].ToString();
        //                    client.gender = reader[2].ToString();
        //                    client.id = reader[3].ToString();
        //                }
        //                Console.WriteLine("Query executed successfully!");
        //            }
        //            catch (Exception EX)
        //            {
        //                Console.WriteLine(EX);
        //            }
        //            if (client.name == null)
        //            {
        //                return null;
        //            }
        //            return client;
        //        }
        //    }
        //}

        //public void EditClientInfo(string id, ClientClass client)
        //{
        //    string queryString = $"UPDATE [dbo].[CLIENTS] SET [NAME] = '{client.name}', [AGE] = '{client.age}'," +
        //        $" [GENDER] = '{client.gender}', [ID] = '{client.id}' " +
        //        $" WHERE [ID] = '{id}';";

        //    ExecuteQuery(queryString);
        //}

        //public void DeleteClient(string id)
        //{
        //    string queryString = $"DELETE FROM [dbo].[CLIENTS] WHERE [ID] = '{id}';";
        //    ExecuteQuery(queryString);
        //}

        private static void ExecuteQuery(string queryString, string stringConnection = CONNECTIONSTRING)
        {
            using (SqlConnection connectionString = new SqlConnection(stringConnection))
            using (SqlCommand myCommand = new SqlCommand(queryString, connectionString))
                try
                {
                    connectionString.Open();
                    myCommand.ExecuteNonQuery();
                    Console.WriteLine("Query was executed successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
        }
    }
}
