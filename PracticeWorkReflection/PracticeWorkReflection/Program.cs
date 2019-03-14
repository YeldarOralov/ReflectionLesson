using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PracticeWorkReflection
{
    class Program
    {
        static void Main(string[] args)
        {

            //Assembly assembly = Assembly.LoadFile(@"C:\Users\оралове\Source\Repos\ReflectionLesson\ReflectionLesson\ReflectionLesson\bin\Debug\ReflectionLesson.exe");
            //foreach (var type in assembly.GetTypes())
            //{
            //    foreach (var memberInfo in type.GetMembers())
            //    {
            //        Console.WriteLine($"{memberInfo.MemberType} {memberInfo.Name}");
            //        if (memberInfo is ConstructorInfo)
            //        {
            //            var constructor = memberInfo as ConstructorInfo;
            //            Console.WriteLine($"{constructor.GetParameters()}");
            //        }
            //        if (memberInfo is MethodInfo && memberInfo.Name == "SendMessage")
            //        {
            //            object smsService = Activator.CreateInstance(type, "Message");
            //            (memberInfo as MethodInfo).Invoke(smsService, new object[] { "MessageText", "To someone" });
            //        }
            
            Type type = typeof(string);
            MethodInfo substring = type.GetMethod("Substring", new Type[] {typeof(int), typeof(int)});
            object result = substring.Invoke("Message", new object[] { 2, 4 });
            Console.WriteLine($"{substring}\n{result}");

            var list = typeof(List<>);
            foreach(var memberInfo in list.GetMembers())
            {
                if(memberInfo is ConstructorInfo)
                {
                    var constructor = memberInfo as ConstructorInfo;
                    if (constructor.GetParameters().Length > 0)
                    {
                        for(int i = 0; i< constructor.GetParameters().Length; i++)
                        {
                            Console.WriteLine($"{memberInfo.Name}  {memberInfo.MemberType}\n{constructor.GetParameters()[i]}");
                        }
                    }                    
                }
            }

            //foreach (var memberInfo in type.GetMembers())
            //{
            //    if (memberInfo is MethodInfo && memberInfo.Name == "Substring")
            //    {
            //        Console.WriteLine($"{memberInfo.MemberType} {memberInfo.Name}");
            //        object str = Activator.CreateInstance(type, new string[] { "Message" });
            //        object result = memberInfo.Inv
            //    }
            //    Console.WriteLine($"{memberInfo.MemberType} {memberInfo.Name}");
            //}


            Console.Read();
        }
    }
}
