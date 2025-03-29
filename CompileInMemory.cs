using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;

namespace InMemoryCompiler {
    internal class Program {
        /// <summary>
        /// Compiles and executes a C# payload dynamically in memory.
        /// </summary>
        /// <param name="code">The source code to compile, either as a raw string or a byte array.</param>
        /// <param name="namespaceName">The namespace of the payload.</param>
        /// <param name="className">The class name within the namespace.</param>
        /// <param name="methodName">The method to execute once compiled.</param>
        public static void CompileAndExecute(string code, string namespaceName, string className, string methodName){
            using (var provider = new CSharpCodeProvider()){
                var compilerParams = new CompilerParameters{
                    GenerateInMemory = true,
                    TreatWarningsAsErrors = false
                };

                CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, code);

                if (results.Errors.HasErrors){
                    StringBuilder errorMessages = new StringBuilder("Compilation failed:\n");
                    foreach (CompilerError error in results.Errors){
                        errorMessages.AppendLine(error.ToString());
                    }
                    throw new Exception(errorMessages.ToString());
                }

                try{
                    Assembly assembly = results.CompiledAssembly;
                    Type targetType = assembly.GetType($"{namespaceName}.{className}");
                    MethodInfo targetMethod = targetType?.GetMethod(methodName);

                    if (targetMethod == null){
                        throw new MissingMethodException($"Method '{methodName}' not found in class '{className}'.");
                    }

                    targetMethod.Invoke(null, null);
                }
                catch (Exception ex){
                    Console.WriteLine($"Execution error: {ex.Message}");
                }
            }
        }

        private static readonly byte[] helloWorldBytes ={
            117, 115, 105, 110, 103, 32, 83, 121, 115, 116, 101, 109, 59, 110, 97, 109, 101, 115, 112,
            97, 99, 101, 32, 72, 101, 108, 108, 111, 87, 111, 114, 108, 100, 32, 123, 32, 112, 117,
            98, 108, 105, 99, 32, 99, 108, 97, 115, 115, 32, 72, 101, 108, 108, 111, 87, 111, 114,
            108, 100, 67, 108, 97, 115, 115, 32, 123, 32, 112, 117, 98, 108, 105, 99, 32, 115, 116,
            97, 116, 105, 99, 32, 118, 111, 105, 100, 32, 77, 97, 105, 110, 40, 41, 32, 123, 32,
            67, 111, 110, 115, 111, 108, 101, 46, 70, 111, 114, 101, 103, 114, 111, 117, 110, 100,
            67, 111, 108, 111, 114, 32, 61, 32, 67, 111, 110, 115, 111, 108, 101, 67, 111, 108, 111,
            114, 46, 82, 101, 100, 59, 32, 67, 111, 110, 115, 111, 108, 101, 46, 87, 114, 105, 116,
            101, 76, 105, 110, 101, 40, 34, 72, 101, 108, 108, 111, 44, 32, 87, 111, 114, 108, 100,
            33, 34, 41, 59, 32, 125, 32, 125, 32, 125
        };

        private static void Main(){
            try{
                CompileAndExecute(
                    code: Encoding.ASCII.GetString(helloWorldBytes),
                    namespaceName: "HelloWorld",
                    className: "HelloWorldClass",
                    methodName: "Main"
                );
            }
            catch (Exception ex){
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
