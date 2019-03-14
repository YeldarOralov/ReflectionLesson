using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ReflectionLesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.LoadFile(@"C:\Users\оралове\Source\Repos\ReflectionLesson\ReflectionLesson\ReflectionLesson\bin\Debug\ReflectionLesson.exe");
            foreach(var type in assembly.GetTypes())
            {
                foreach(var memberInfo in type.GetMembers())
                {
                    Console.WriteLine($"{memberInfo.MemberType} {memberInfo.Name}");
                    if(memberInfo is ConstructorInfo)
                    {
                        var constructor = memberInfo as ConstructorInfo;
                        Console.WriteLine($"{constructor.GetParameters()}");
                    }
                    if (memberInfo is MethodInfo && memberInfo.Name=="SendMessage")
                    {
                        object smsService = Activator.CreateInstance(type, "Message");
                        (memberInfo as MethodInfo).Invoke(smsService, new object[] { "MessageText", "To someone" });
                    }


                    
                    
                    //if (memberInfo.GetType() == typeof(ConstructorInfo))
                    //{                    //} второй вариант на проверку
                }
            }
            Console.Read();
        }
    }
}
