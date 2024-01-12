using EstablishmentManagerLibrary.ClientRelated;
using EstablishmentManagerLibrary.InventoryRelated;
using EstablishmentManagerLibrary.MoneyRelated;
using EstablishmentManagerLibrary.OrdersRelated;
using EstablishmentManagerLibrary.UserRelated;

namespace EstablishmentManagerLibrary.Database.CRUD
{
    public class Insert
    {
        // Client
        public static void Client(Client client)
        {
            string query = $"insert into [client] " +
                $"([name], [cpf], [birthday], [rg], [modified_date], [creation_date], [credit_on_establishment], [debit_on_establishment]) " +
                $"values ('{client.Name}', '{client.Cpf}', '{client.Birthday}', '{client.Rg}', '{client.Modified_date}', '{client.Creation_date}', " +
                $"'{client.Credit_on_establishment}', '{client.Debit_on_establishment}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        public static void Client_Address(Client_address client_address)
        {
            string query = $"insert into [client_address] " +
                $"([street_name], [cep], [complement], [reference], [number], [description], [creation_date], [modified_date]) " +
                $"values ('{client_address.Street_name}', '{client_address.Cep}','{client_address.Complement}', '{client_address.Reference}', " +
                $"'{client_address.Number}, '{client_address.Description}', '{client_address.Creation_date}', '{client_address.Modified_date}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        public static void Client_Telephone(Client_telephone client_telephone)
        {
            string query = $"insert into [client_telephone] " +
                $"([number], [description], [creation_date], [modified_date]) " +
                $"values ('{client_telephone.Number}', '{client_telephone.Description}','{client_telephone.Creation_date}', '{client_telephone.Modified_date}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        //Inventory
        public static void Group_Of_Product(Group_of_product group_of_product)
        {
            string query = $"insert into [group_of_product] " +
                $"([name], [description], [category], [cost_price], [sell_price], [sell_price], [created]) " +
                $"values ('{group_of_product.Name}', '{group_of_product.Description}','{group_of_product.Category}', '{group_of_product.Cost_price}', " +
                $"'{group_of_product.Sell_price}, '{group_of_product.Created}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        public static void Product(Product product)
        {
            string query = $"insert into [product] " +
                $"([name], [description], [category], [cost_price], [sell_price], [sell_price], [created]) " +
                $"values ('{product.Name}', '{product.Description}','{product.Category}', '{product.Cost_price}', " +
                $"'{product.Sell_price}, '{product.Created}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        public static void Product_Addons(Product_addons product_addons)
        {
            string query = $"insert into [product_addons] " +
                $"([name], [description], [category], [cost_price], [sell_price], [sell_price], [created]) " +
                $"values ('{product_addons.Name}', '{product_addons.Description}','{product_addons.Category}', '{product_addons.Cost_price}', " +
                $"'{product_addons.Sell_price}, '{product_addons.Created}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        public static void Promotion(Promotion promotion)
        {
            string query = $"insert into [promotion] " +
                $"([id_product], [id_group_of_product], [name], [description], [sell_price], [category], [created]) " +
                $"values ('{promotion.Id_product}', '{promotion.Id_group_od_product}','{promotion.Name}', '{promotion.Description}', " +
                $"'{promotion.Sell_price}, '{promotion.Created}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        public static void Stock(Stock stock)
        {
            string query = $"insert into [stock] " +
                $"([id_product], [quantity], [added_to_stock]) " +
                $"values ('{stock.Id_product}', '{stock.Quantity}','{stock.Added_to_stock}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        //Money related
        public static void Payment_Method(Payment_method payment_method)
        {
            string query = $"insert into [payment_method] " +
                $"([type], [name]) " +
                $"values ('{payment_method.Type}', '{payment_method.Name}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        public static void Payment_Value(Payment_value payment_value)
        {
            string query = $"insert into [payment_value] " +
                $"([id_payment_method], [value]) " +
                $"values ('{payment_value.Id_payment_method}', '{payment_value.Value}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        public static void Transaction(Transaction transaction)
        {
            string query = $"insert into [transaction] " +
                $"([id_payment_method], [id_order], [date], [hour]) " +
                $"values ('{transaction.Id_payment_method}', '{transaction.Id_order}', '{transaction.Date}', '{transaction.Hour}',);";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        //OrdersRelated

        public static void Delivery(Delivery delivery)
        {
            string query = $"insert into [delivery] " +
                $"([id_deliveryman_employee], [id_orders], [id_client], [tax_value], [creation_date], " +
                $"[creation_time], [time_deliveryman_arrived], [schedule_date]) " +
                $"values ('{delivery.Id_deliveryman_employee}', '{delivery.Id_orders}', '{delivery.Id_client}', '{delivery.Tax_value}', " +
                $"'{delivery.Creation_date}, '{delivery.Creation_time}', '{delivery.Time_deliveryman_arrived}', '{delivery.Schedule_date}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        public static void Order(Order order)
        {
            string query = $"insert into [order] " +
                $"([id_table], [id_delivery], [id_payment_value], [client_name_note], [observation]) " +
                $"values ('{order.Id_table}', '{order.Id_delivery}', '{order.Id_payment_value}', '{order.Client_name_note}', '{order.Observation}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        public static void Table(Table table)
        {
            string query = $"insert into [table] " +
                $"([id_orders], [name], [usage_date], [initial_time], [time_spent]) " +
                $"values ('{table.Id_orders}', '{table.Name}', '{table.Usage_date}', '{table.Initial_time}', '{table.Time_spent}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        //User

        public static void Employee(Employee employee)
        {
            string query = $"insert into [employee] " +
                $"([id_user], [birthday], [name], [cpf], [created]) " +
                $"values ('{employee.Id_user}', '{employee.Birthday}', '{employee.Name}', '{employee.Cpf}', '{employee.Created}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        public static void Permission(Permission permission)
        {
            string query = $"insert into [permission] " +
                $"([level]) " +
                $"values ('{permission.Level}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }

        public static void User(User user)
        {
            string query = $"insert into [user] " +
                $"([id_permission], [login], [password]) " +
                $"values ('{user.Id_permission}', '{user.Login}', '{user.Password}');";
            QueryFunction.Execute(query, Database_query_strings.Establishment_connection_string);
        }
    }
}
