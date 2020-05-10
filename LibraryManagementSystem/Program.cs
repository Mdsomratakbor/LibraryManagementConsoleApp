using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Program
    {
        public static string connectionString = @"Data Source =DESKTOP-NAVD66F\SA;User ID =sa; password=007;Database= LibraryManagement; Integrated Security = True; Trusted_Connection=True;";
        public static string sqlQuery;
        static void Main(string[] args)
        {
            Console.Write("===How many operation you creat please enter this number===== :");
            int userInput = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < userInput; i++)
            {
                Console.Write("===Please write your operation==== : StudentSave, studentlist, BookSave, BookList, BookIssuSave");
                string userString = Console.ReadLine();
                if (userString == "StudentSave")
                {
                    Student student = new Student();
                    Console.Write("Student Name :");
                    student.StudentName = Console.ReadLine();

                    Console.Write("Student Roll :");
                    student.StudentRoll = Int32.Parse(Console.ReadLine());

                    Console.Write("Student Department :");
                    student.StudentDepartment = Console.ReadLine();
                    SaveStudent(student);
                }
                else if (userString == "studentlist")
                {
                    List<Student> myStudentList = new List<Student>();
                    myStudentList = StudentList();
                    foreach (var value in myStudentList)
                    {
                        Console.WriteLine("Student Id :" + value.StudentId);
                        Console.WriteLine("Student Name :" + value.StudentName);
                        Console.WriteLine("Student Roll :" + value.StudentRoll);
                        Console.WriteLine("Student Department :" + value.StudentDepartment);
                    }
                }
                else if (userString == "BookSave")
                {
                    Book book = new Book();
                    Console.Write("Book Name :");
                    book.BookName = Console.ReadLine();

                    Console.Write("Book Type :");
                    book.BookType = Console.ReadLine();

                    Console.Write("Book Code :");
                    book.BookCode = Console.ReadLine();
                    SaveBook(book);
                }
                else if(userString == "BookList")
                {
                    List<Book> myBook = new List<Book>();
                    myBook = BookList();
                    foreach (var value in myBook)
                    {
                        Console.WriteLine("Book Id :" + value.BookId);
                        Console.WriteLine("Book Name :" + value.BookName);
                        Console.WriteLine("Book Type :" + value.BookType);
                        Console.WriteLine("Book Code :" + value.BookCode);
                    }
                }
                else if(userString=="BookIssuSave")
                {
                    BookIssue bookissue = new BookIssue();
                    Console.Write("Book Id :");
                    bookissue.BookId =Convert.ToInt32(Console.ReadLine());

                    Console.Write("Student Id :");
                    bookissue.StudentId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Book Issue Date :");
                    bookissue.dtBookIssue = Convert.ToDateTime(Console.ReadLine());
                    BookIssueSave(bookissue);
                }
                else
                {
                    List<BookIssue> IssueList = new List<BookIssue>();
                    IssueList = BookIssueList();
                    foreach (var value in IssueList)
                    {
                        Console.WriteLine("Book Id :"+value.BookId);
                        Console.WriteLine("Book Issue Date :"+value.dtBookIssue);
                        Console.WriteLine("Student Id :"+value.StudentId);
                        
                    }


                }
                

            }
            Console.Read();
        }


        //================Start: STUDENT SAVE METHOD=======================//
        public static void SaveStudent(Student model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                sqlQuery = "INSERT INTO tbl_Student(StudentRoll, StudentName, StudentDepartment)Values('"+model.StudentRoll+"','"+model.StudentName+"','"+model.StudentDepartment+"')";
                SqlCommand cmd = new SqlCommand(sqlQuery,connection);
                connection.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected == 1)
                {
                    Console.WriteLine("==============Student Data Save Successfull=============");
                }
                else
                {
                    Console.WriteLine("=============Student Data Save Unsuccessfull============");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        //===============End: Student Save Method===================//

        //===============Start: Student List Method=================//
        public static List<Student> StudentList()
        {
           SqlConnection connection = new SqlConnection(connectionString);
            List<Student> studentList = new List<Student>();
           try
            {
                sqlQuery = "SELECT * FROM tbl_Student";
                SqlCommand cmd = new SqlCommand(sqlQuery,connection);
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var student = new Student();
                    student.StudentId = Convert.ToInt32(reader["StudentId"]);
                    student.StudentName = reader["StudentName"].ToString();
                    student.StudentRoll = Convert.ToInt32(reader["StudentRoll"]);
                    student.StudentDepartment = reader["StudentDepartment"].ToString();
                    studentList.Add(student);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return studentList;
        }
        //===============End: Student List Method===================//
        //===============Start: Book Save Method==================//
        public static void SaveBook(Book model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                sqlQuery = "INSERT INTO tbl_Book(BookName, BookType, BookCode)Values('" + model.BookName + "','" + model.BookType + "','" + model.BookCode + "')";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected == 1)
                {
                    Console.WriteLine("=======Book Data Save Successfull========");
                }
                else
                {
                    Console.WriteLine("=======Book Data Save Unsuccessfull========");
                }

            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //===============End: Book Save Method=================//
        //===============Start: Book List======================//
        public static List<Book> BookList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            List<Book> bookList = new List<Book>();
            try
            {
                sqlQuery = "SELECT * FROM tbl_Book";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Book book = new Book();
                    book.BookId = Convert.ToInt32(reader["BookId"]);
                    book.BookName = reader["BookName"].ToString();
                    book.BookType = reader["BookType"].ToString();
                    book.BookCode = reader["BookCode"].ToString();
                    bookList.Add(book);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return bookList;
        }
        //===============End: Book List=====================//
        //==============Start: BookIssue Save==============//
        public static void BookIssueSave(BookIssue model)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                sqlQuery = "INSERT INTO tbl_Book_Issue(BookId, StudentId, dtBookIssue)VALUES('"+model.BookId+"','"+model.StudentId+"','"+model.dtBookIssue+"')";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery,connection);
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected == 1)
                {
                    Console.WriteLine("============Book Issue Successsfull===========");
                }
                else
                {
                    Console.WriteLine("============Book Issue Unsuccessfull===========");
                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        //==============End: BookIssue Save===============//
        //==============Start: BookIssue List=============//
        public static List<BookIssue> BookIssueList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            List<BookIssue> BookIssueList = new List<BookIssue>();
            try
            {
                sqlQuery = "SELECT * FROM tbl_Book_Issue";
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    BookIssue bookIssue = new BookIssue();
                    bookIssue.BookId = Convert.ToInt32(read["BookId"]);
                    bookIssue.dtBookIssue = Convert.ToDateTime(read["dtBookIssue"]);
                    bookIssue.StudentId = Convert.ToInt32(read["StudentId"]);
                    BookIssueList.Add(bookIssue);

                }
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
            }
            finally{
                connection.Close();
            }
            return BookIssueList;
        }
        //==============End: BookIssue List==============//






        //===============Error Message Print======================//
        public static void ErrorMessage(string message)
        {
            Console.WriteLine(message);
        }

    }
}
