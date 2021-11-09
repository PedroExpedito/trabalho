using System.Data;
using Microsoft.Data.Sqlite;

namespace trabalho
{
  public static class Connection 
  {

    private static SqliteConnection
      connection = new SqliteConnection("Data Source=hello.db");

    public static SqliteConnection getConnection() {
      if(connection != null && connection.State == ConnectionState.Closed) {
        connection.Open();
      }
      return connection;
    }
  }
}


