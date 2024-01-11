namespace EstablishmentManagerLibrary.Database
{
    internal class Database_query_strings
    {
        public static readonly string Database_name = "EstablishmentManager";
        public static readonly string Master_connection_string = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True";
        public static readonly string  Establishment_connection_string = $@"Server=localhost\SQLEXPRESS;Database={Database_name};Trusted_Connection=True";

        
        public static readonly string CreateDataBase = $"CREATE DATABASE {Database_name} ON PRIMARY " +
                 $"(NAME = {Database_name}_Data, " +
                 $@"FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\{Database_name}.mdf', " + //Database instalation must match on this string.
                 "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)" +
                 $"LOG ON (NAME = {Database_name}_Log, " +
                 $@"FILENAME = 'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\{Database_name}.ldf', " + //Database instalation must match on this string.
                 "SIZE = 1MB, " +
                 "MAXSIZE = 5MB, " +
                 "FILEGROWTH = 10%);";

        //Query string to generate all the database tables and relationships.
        public static readonly string CreateTables = "create table [permissions] ([id] int primary key identity(1,1), [level] int);" +
            "create table [user] ([id] int primary key identity(1,1),[id_permission] int foreign key references [permissions](id), [login] varchar(50), [password] varchar(50));" +
            "create table [employee] ([id] int primary key identity(1,1), [id_user] int foreign key references [user](id),[birthday] date, [name] varchar(100), [cpf] varchar(11), [created] date);" +
            "create table [product] ([id] int primary key identity(1,1), [name] varchar(100), [description] varchar(100), [category] varchar(100), [cost_price] decimal, [sell_price] decimal, [created] date);" +
            "create table [product_addons] ([id] int primary key identity(1,1), [name] varchar(100), [description] varchar(100), [category] varchar(100), [cost_price] decimal, [sell_price] decimal, [created] date);" +
            "create table [product_observation] ([id] int primary key identity(1,1), [info] varchar(100), [category] varchar(100));" +
            "create table [stock] ([id] int primary key identity(1,1), [id_product] int foreign key references product(id), [quantity] int, [added_to_stock] date);" +
            "create table [ids_of_product_addons] ([id] int primary key identity(1,1), [id_product] int foreign key references product(id), [id_product_addons] int foreign key references product_addons(id));" +
            "create table [ids_of_observation] ([id] int primary key identity(1,1), [id_product] int foreign key references product(id), [id_product_observation] int foreign key references product_observation(id));" +
            "create table [group_of_product] ([id] int primary key identity(1,1), [name] varchar(100), [description] varchar(100), [category] varchar(100), [cost_price] decimal, [sell_price] decimal, [created] date);" +
            "create table [ids_of_product_on_group] ([id] int primary key identity(1,1), [id_of_group_of_product] int foreign key references group_of_product(id), [id_product] int foreign key references product(id));" +
            "create table [promotions] ([id] int primary key identity(1,1), [id_product] int foreign key references product(id), [id_group_of_product] int foreign key references group_of_product(id), [name] varchar(100), [description] varchar(100), [sell_price] decimal, [category] varchar(100), [created] date);" +
            "create table [table] ([id] int primary key identity(1,1),[id_orders] int, [name] varchar(100), [usage_date] date, [initial_time] time, [time_spent] time);" +
            "create table [delivery] ([id] int primary key identity(1,1), [id_deliveryman_employee] int foreign key references employee(id), [id_orders] int, [id_client] int, [tax_value] decimal, [date] date, [time] time, [time_deliveryman_arrived] time, [schedule_date] date);" +
            "create table [order] ([id] int primary key identity(1,1), [id_table] int foreign key references [table](id), [id_delivery] int foreign key references delivery(id), [id_payment_value] int, [client_name_note] varchar(100), [observation] varchar(100));" +
            "create table [id_orders] ([id] int primary key identity(1,1), [id_table] int foreign key references [table](id), [id_delivery] int foreign key references delivery(id), [id_order] int foreign key references [order](id));" +
            "create table [payment_method] ([id] int primary key identity(1,1), [type] varchar(100), [name] varchar(100));" +
            "create table [payment_value] ([id] int primary key identity(1,1), [id_payment_method] int foreign key references payment_method(id), [value] decimal);" +
            "create table [transaction] ([id] int primary key identity(1,1), [id_payment_method] int foreign key references payment_method(id), [id_order] int foreign key references [order](id), [date] date, [time] time);" +
            "create table [client] ([id] int primary key identity(1,1), [name] varchar(200), [cpf] varchar(11), [birthday] date, [rg] varchar(9), [modified_date] date, [creation_date] date, [credit_on_establishment] decimal, [debit_on_establishment] decimal);" +
            "create table [client_address] ([id] int primary key identity(1,1), [street_name] varchar (200), [cep] varchar(8), [complement] varchar (200), [reference] varchar (200), [number] varchar(10), [description] varchar (200), [creation_date] date, [modified_date] date);" +
            "create table [client_telephone] ([id] int primary key identity(1,1), [number] varchar(13), [description] varchar (200), [creation_date] date, [modified_date] date);" +
            "create table [id_client_address] ([id] int primary key identity(1,1), [id_client] int foreign key references client(id), [id_address] int foreign key references client_address(id));" +
            "create table [id_client_telephones] ([id] int primary key identity(1,1), [id_client] int foreign key references client(id), [id_telephones] int foreign key references client_telephone(id));" +
            "alter table [table] add constraint fk_id_orders foreign key (id_orders) references id_orders(id);" +
            "alter table [delivery] add constraint fk_id_orders_delivery foreign key (id_orders) references id_orders(id);" +
            "alter table [delivery] add constraint fk_id_client_delivery foreign key (id_client) references client(id);" +
            "alter table [order] add constraint fk_id_payment_value_order foreign key (id_payment_value) references payment_value(id);";       
    }
}
