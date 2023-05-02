//This is a namespace that groups a set of related classes for better organization and to avoid naming conflicts
namespace LINQandPLINQsnippets {
  
  //This is a class named Person which represents a person with properties such as FirstName, LastName, Age and IsImportant
  internal class Person {
    // The FirstName property represents the person's first name and it can be accessed and set by other classes
    public string FirstName { get; set; } = "";
    
    // The LastName property represents the person's last name and it can be accessed and set by other classes
    public string LastName { get; set; } = "";
    
    // The Age property represents the person's age as an integer value and it can be accessed and set by other classes
    public int Age { get; set; }
    
    // The IsImportant property represents whether or not the person is important and it can be accessed and set by other classes
    public bool IsImportant { get; set; }
  }
}