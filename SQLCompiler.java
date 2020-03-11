import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class SQLCompiler {
	
	private Connection DBConnection;
	
	public ResultSet executeQuery(String query) {
		OpenConnection();
		ResultSet rs = null;
		
		try {
			Statement SQLquery =  DBConnection.createStatement();
			String queryStatement = query;
			rs = SQLquery.executeQuery(queryStatement);
			SQLquery.close();
			CloseConnection();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return rs;
	}
	
	public void OpenConnection(){
		try {
			DBConnection = DriverManager.getConnection("jdbc:mysql://localhost:3306/NHS_Meeting","NHSMeet","vyfz5MFEw1ipD5QE");
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} 
	}
	
	public void CloseConnection(){
		try {
			DBConnection.close();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
