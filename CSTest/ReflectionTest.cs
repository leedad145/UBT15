// using System.Reflection;

// class Program
// {
//     static void Main()
//     {
//         Monster1 mon = new Monster1();
//         Type type = mon.GetType();
//         FieldInfo[] info = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
//         foreach(FieldInfo field in info)
//         {
//             string access = "protected";
//             if(field.IsPublic)
//                 access = "public";
//             else if (field.IsPrivate)
//                 access = "private";
//             Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");
//             var attributes = field.GetCustomAttributes();
//             foreach(var attibute in attributes)
//             {
//                 Important important = attibute as Important;
//                 if(important != null)
//                 {
//                     Console.WriteLine(important.message);
//                 }
//             }
//         }
//     }
// }
// class Important : Attribute
// {
//     public string message;
//     public Important(string message)
//     {
//         this.message = message;
//     }
// }
// class Monster1
// {
//     [Important("메시지")]
//     public int hp;
//     protected int atk;
//     private float speed;
//     public void functionAAB(){}
// }