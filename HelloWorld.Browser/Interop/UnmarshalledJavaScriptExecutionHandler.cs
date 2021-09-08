using DotNetForHtml5;
using Microsoft.JSInterop;
using Microsoft.JSInterop.WebAssembly;
using System;
using System.Runtime.InteropServices;

namespace HelloWorld.Browser.Interop
{
    public class UnmarshalledJavaScriptExecutionHandler : IJavaScriptExecutionHandler
    {
        private const string MethodName = "callJSUnmarshalled";
        private readonly WebAssemblyJSRuntime _runtime;

        private IJSUnmarshalledObjectReference jsUnmarshalledReference;

        private void CheckUnmarshalledRuntime()
        {
            if (jsUnmarshalledReference != null)
                return;

            Console.WriteLine("Initialize jsUnmarshalledReference");

            jsUnmarshalledReference = _runtime
                .InvokeUnmarshalled<IJSUnmarshalledObjectReference>(
                    "returnObjectReference");
        }

        private void CallJSUnmarshalledForBoolean()
        {
            CheckUnmarshalledRuntime();

            bool callResultForBoolean =
                jsUnmarshalledReference.InvokeUnmarshalled<InteropStruct, bool>(
                    "unmarshalledFunctionReturnBoolean", GetStruct());

            //Console.WriteLine($"CallJSUnmarshalledForBoolean {callResultForBoolean}");
        }

        private void CallJSUnmarshalledForString()
        {
            CheckUnmarshalledRuntime();

            string callResultForString =
                jsUnmarshalledReference.InvokeUnmarshalled<InteropStruct, string>(
                    "unmarshalledFunctionReturnString", GetStruct());

            //Console.WriteLine($"CallJSUnmarshalledForString {callResultForString}");
        }

        private InteropStruct GetStruct()
        {
            return new InteropStruct
            {
                Name = "Brigadier Alistair Gordon Lethbridge-Stewart",
                //Name = " try { 		document.jsSimulatorObjectReferences[\"25\"] = eval(\"document.body.appendChild(document.createElement('div'))\");                     } 	catch (error) { 		document.errorCallback(error, 17); 	}",
                Year = 1968,
            };
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InteropStruct
        {
            [FieldOffset(0)]
            public string Name;

            [FieldOffset(8)]
            public int Year;
        }

        public UnmarshalledJavaScriptExecutionHandler(IJSRuntime runtime)
        {
            _runtime = runtime as WebAssemblyJSRuntime;
        }

        public void ExecuteJavaScript(string javaScriptToExecute)
        {
            //global::System.Diagnostics.Debug.WriteLine("UnmarshalledJavaScriptExecutionHandler ExecuteJavaScript");
            _runtime.InvokeUnmarshalled<string, object>(MethodName, javaScriptToExecute);
        }

        public object ExecuteJavaScriptWithResult(string javaScriptToExecute)
        {
            //global::System.Diagnostics.Debug.WriteLine("UnmarshalledJavaScriptExecutionHandler ExecuteJavaScriptWithResult");
            return _runtime.InvokeUnmarshalled<string, object>(MethodName, javaScriptToExecute);
        }

        public void AddMouseEnterListenerJavaScript(string id, int callbackId)
        {
            _runtime.InvokeUnmarshalled<string, string, object>("addMouseEnterEventListener", id, callbackId.ToString());
            return;
        }
        public void RemoveMouseEnterListenerJavaScript(string id, int callbackId)
        {
            _runtime.InvokeUnmarshalled<string, string, object>("removeMouseEnterEventListener", id, callbackId.ToString());
            return;
        }

        public void SetDomStyleProperty(string id, string propertyName, string value)
        {
            _runtime.InvokeUnmarshalled<string, string, string, object>("setDomStyleProperty", id, propertyName, value);
        }

        public object ExecuteCreateElement(int errCallbackId)
        {
            //global::System.Diagnostics.Debug.WriteLine("UnmarshalledJavaScriptExecutionHandler ExecuteCreateElement");
            string javascriptToExecute = " try { 		document.jsSimulatorObjectReferences[\"25\"] = eval(\"document.body.appendChild(document.createElement('div'))\");                     } 	catch (error) { 		document.errorCallback(error, 17); 	}";
            _runtime.InvokeUnmarshalled<string, object>("callCreateDiv", javascriptToExecute);

            //CallJSUnmarshalledForBoolean();
            //CallJSUnmarshalledForString();

            return null;
        }


        [StructLayout(LayoutKind.Explicit)]
        public struct CreateDivStruct
        {
            [FieldOffset(0)]
            public int refIdx;

            [FieldOffset(4)]
            public int errIndex;

            [FieldOffset(8)]
            public string javascript;
        }

        private CreateDivStruct GetCreateDivStruct()
        {
            return new CreateDivStruct
            {
                refIdx = 10,
                errIndex = 16,
                javascript = " try { 		document.jsSimulatorObjectReferences[\"25\"] = eval(\"document.body.appendChild(document.createElement('div'))\");                     } 	catch (error) { 		document.errorCallback(error, 17); 	}"
            };
        }

        public object ExecuteUnmarshalled(string funcName, object fields)
        {
            CheckUnmarshalledRuntime();

            return CallUnmarshalled(funcName, GetCreateDivStruct());
            /*
            bool callResultForBoolean =
                jsUnmarshalledReference.InvokeUnmarshalled<CreateDivStruct, bool>(
                    funcName, GetCreateDivStruct());

            return callResultForBoolean;
            */
        }

        private object CallUnmarshalled(string funcName, object fields)
        {
            bool callResultForBoolean =
                jsUnmarshalledReference.InvokeUnmarshalled<CreateDivStruct, bool>(
                    funcName, (CreateDivStruct)fields);

            return callResultForBoolean;
        }
    }
}
