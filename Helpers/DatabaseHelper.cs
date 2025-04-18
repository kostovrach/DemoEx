using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using DemoEx.Models;

namespace DemoEx.Helpers
{
    public static class DatabaseHelper
    {
        private static string dbFile = "AppData.db";
        private static string connString = $"Data Source={dbFile};Version=3;";

        static DatabaseHelper()
        {
            InitializeDatabase();
        }

        public static void InitializeDatabase()
        {
            if (!File.Exists(dbFile))
                SQLiteConnection.CreateFile(dbFile);

            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                string sql = @"
                    CREATE TABLE IF NOT EXISTS Items (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Text TEXT NOT NULL
                    );";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<ItemModel> GetItems()
        {
            var list = new List<ItemModel>();
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT Id, Text FROM Items", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ItemModel
                        {
                            Id = reader.GetInt32(0),
                            Text = reader.GetString(1)
                        });
                    }
                }
            }
            return list;
        }

        public static void AddItem(ItemModel item)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("INSERT INTO Items (Text) VALUES (@text); SELECT last_insert_rowid();", conn);
                cmd.Parameters.AddWithValue("@text", item.Text);
                item.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public static void UpdateItem(ItemModel item, string newText)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("UPDATE Items SET Text = @text WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@text", newText);
                cmd.Parameters.AddWithValue("@id", item.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteItems(List<ItemModel> items)
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                foreach (var item in items)
                {
                    var cmd = new SQLiteCommand("DELETE FROM Items WHERE Id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", item.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ClearItems()
        {
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("DELETE FROM Items", conn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
