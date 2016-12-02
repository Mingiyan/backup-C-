/*
 * Created by SharpDevelop.
 * User: mdordzhiev
 * Date: 18.11.2016
 * Time: 14:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Threading;


namespace backup
{
	class Program
	{
		
		public static void Main(string[] args)
		{
			
			for (int i = 0; i < args.Length - 2; i++)
			{
			
				SqlConnection conn = new SqlConnection("Data Source=" + args[0] + "," + args[1] + ";Network Library=DBMSSOCN;User ID=sa;Password=p@ssw0rd");
            		try
            		{
                		//try to connect
               			conn.Open();
                		Console.WriteLine("Connection successfull");
            		}
            		catch (SqlException se)
            		{
                		Console.WriteLine("Connection error:{0}",se.Message);
                		return;
            		}
 
            
            		string fileName = String.Format(args[2] + "_{0}", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
       
               
			SqlCommand cmdBackup = new SqlCommand("BACKUP DATABASE " + args[2] + " TO DISK ='C:\\backupsql\\" + fileName + ".bak';", conn);
			//send inquiry

			try
			{
				cmdBackup.ExecuteNonQuery();
			}
			catch 
			{
				Console.WriteLine("Error creating backup");
				return;
			}

			Console.WriteLine("Backup " + fileName + ".bak created successfully");
			//close connection
			conn.Close();
			conn.Dispose();
               
              		}
		}
	}
}
	
