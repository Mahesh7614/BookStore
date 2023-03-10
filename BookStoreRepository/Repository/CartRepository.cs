
using BookStoreModel;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using BookStoreRepository.Interface;

namespace BookStoreRepository.Repository
{
    public class CartRepository : ICartRepository
    {
        private string? connectionString;
        public CartRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("UserDBConnection");
        }
        public CartModel AddToCart(CartModel cartModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SPAddCart", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Cart_Quantity", cartModel.Cart_Quantity);
                    command.Parameters.AddWithValue("@BookID", cartModel.BookID);
                    command.Parameters.AddWithValue("@UserID", cartModel.UserID);

                    connection.Open();
                    int AddOrNot = command.ExecuteNonQuery();

                    if (AddOrNot >= 1)
                    {
                        return cartModel;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public CartModel UpdateCart(CartModel cartModel)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SPUpdateCart", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CartID", cartModel.CartID);
                    command.Parameters.AddWithValue("@Cart_Quantity", cartModel.Cart_Quantity);
                    command.Parameters.AddWithValue("@UserID", cartModel.UserID);
           

                    connection.Open();
                    int UpdateOrNot = command.ExecuteNonQuery();

                    if (UpdateOrNot >= 1)
                    {
                        return cartModel;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public bool DeleteCart(int CartID, int UserID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SPDeleteCart", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CartID", CartID);
                    command.Parameters.AddWithValue("@UserID", UserID);

                    connection.Open();
                    int DeleteOrNot = command.ExecuteNonQuery();

                    if (DeleteOrNot >= 1)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public List<CartModel> GetAllCart(int UserID)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                List<CartModel> cart = new List<CartModel>();
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SPGetAllCart", connection);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", UserID);


                    connection.Open();
                    SqlDataReader Reader = command.ExecuteReader();

                    if (Reader.HasRows)
                    {
                        while (Reader.Read())
                        {
                            CartModel book = new CartModel()
                            {
                                CartID = Reader.IsDBNull("CartID") ? 0 : Reader.GetInt32("CartID"),
                                Cart_Quantity = Reader.IsDBNull("Cart_Quantity") ? 0 : Reader.GetInt32("Cart_Quantity"),
                                BookID = Reader.IsDBNull("BookID") ? 0 : Reader.GetInt32("BookID"),
                                UserID = Reader.IsDBNull("UserID") ? 0 : Reader.GetInt32("UserID"),
                               
                            };
                            cart.Add(book);
                        }
                        return cart;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
