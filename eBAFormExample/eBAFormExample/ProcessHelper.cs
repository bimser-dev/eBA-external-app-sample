using eBAFormExample.Models.Response;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using eBAFormExample.Models.Request;
using eBAFormExample.Models;

namespace eBAFormExample
{
    public class ProcessHelper
    {
        private static readonly string User = "admin";
        private static readonly string Password = "J%3pP5*j";
        private static readonly string Language = "Turkish";
        public static IntegrationQueryResponse ExecuteIntegrationQuery(string connection, string query, List<IntegrationQueryParameter> parameters = null)
        {
            HttpClient client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(new IntegrationQueryRequest
            {
                Token = Authentication().Token,
                ConnectionName = connection,
                QueryName = query,
                Parameters = parameters != null ? parameters : new List<IntegrationQueryParameter>()
            }), Encoding.UTF8, "application/json");

            var response = client.PostAsync("http://localhost/ebarestapi/api/Queries/Execute", content).Result;
            return JsonConvert.DeserializeObject<IntegrationQueryResponse>(response.Content.ReadAsStringAsync().Result);
        }

        private static StartProcessResponse CreateProcess(string processName, List<StartProcessParameter> parameters = null)
        {
            HttpClient client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(new StartProcessRequest
            {
                UserId = User,
                Password = Password,
                Language = Language,
                Process = processName,
                Parameters = parameters != null ? parameters : new List<StartProcessParameter>()
            }), Encoding.UTF8, "application/json");

            var response = client.PostAsync("http://localhost/ebarestapi/api/ProcessEvents/StartProcess", content).Result;
            return JsonConvert.DeserializeObject<StartProcessResponse>(response.Content.ReadAsStringAsync().Result);
        }

        private static void SaveFormData(int processId, MainFormData mainFormData)
        {
            HttpClient client = new HttpClient();
            var a = JsonConvert.SerializeObject(CreateSaveDocumentDataRequest(processId, mainFormData));
            var content = new StringContent(JsonConvert.SerializeObject(CreateSaveDocumentDataRequest(processId, mainFormData)), Encoding.UTF8, "application/json");

            client.PostAsync("http://localhost/ebarestapi/api/Documents/SaveDocumentData", content);
        }

        public static void StartProcess(string processName, MainFormData mainFormData) => SaveFormData(CreateProcess(processName).ProcessId, mainFormData);

        public static void ContinueProcess(int processId, int requestId, int eventId, MainFormData mainFormData)
        {
            HttpClient client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(new ContinueProcessRequest
            {
                Token = Authentication().Token,
                ProcessId = processId,
                RequestId = requestId,
                EventId = eventId,
                HasSigned = false,
                EventFormId = 0,
                ReasonText = string.Empty
            }), Encoding.UTF8, "application/json");
            client.PostAsync("http://localhost/ebarestapi/api/ProcessEvents/Continue", content);
            SaveFormData(processId, mainFormData);
        }


        public static GetProcessEventsResponse GetProcessEvents(int processId, int requestId)
        {
            HttpClient client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(new GetProcessEventsRequest
            {
                Token = Authentication().Token,
                ProcessId = processId,
                RequestId = requestId
            }), Encoding.UTF8, "application/json");

            var response = client.PostAsync("http://localhost/ebarestapi/api/ProcessEvents/Events", content).Result;
            return JsonConvert.DeserializeObject<GetProcessEventsResponse>(response.Content.ReadAsStringAsync().Result);
        }

        private static LoginResponse Authentication()
        {
            HttpClient client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(new LoginRequest
            {
                Id = User,
                Password = Password,
                Language = Language,
                Domain = null
            }), Encoding.UTF8, "application/json");

            var response = client.PostAsync("http://localhost/ebarestapi/api/Login/Login", content).Result;
            return JsonConvert.DeserializeObject<LoginResponse>(response.Content.ReadAsStringAsync().Result);
        }

        private static SaveDocumentDataRequest CreateSaveDocumentDataRequest(int processId, MainFormData mainFormData)
        {
            return new SaveDocumentDataRequest
            {
                Token = Authentication().Token,
                ProcessId = processId,
                Forms = new List<Form>
                {
                    new Form
                    {
                        Name="FORM",
                        Controls = new List<Control>
                        {
                            new Control
                            {
                                Type = "ComboBox",
                                Name="CMBDEPARTMAN",
                                Value=new ObjectItem
                                {
                                    Key=mainFormData.Department.Key,
                                    Value=mainFormData.Department.Value,
                                }
                            },
                            new Control
                            {
                                Type = "TextBox",
                                Name="TXTAD",
                                Value=mainFormData.Name
                            },
                            new Control
                            {
                                Type = "TextBox",
                                Name="TXTSOYAD",
                                Value=mainFormData.Surname
                            },
                            new Control
                            {
                                Type = "CheckBox",
                                Name="ACIKMI",
                                Value=mainFormData.IsOpen
                            },
                            new Control
                            {
                                Type = "RadioList",
                                Name="RDLSTCINSIYET",
                                Value=new ObjectItem{
                                    Key=mainFormData.Gender.Key,
                                    Value=mainFormData.Gender.Value
                                }
                            },
                            new Control
                            {
                                Type = "RadioButton",
                                Name= mainFormData.OptionName,
                                Value=true
                            },
                            new Control
                            {
                                Type = "ListBox",
                                Name="LSTMEYVELER",
                                Value=mainFormData.Fruits
                            },
                            new Control
                            {
                                Type="DetailsGrid",
                                Name="DTGKAYITLIKULLANICILAR",
                                Value=mainFormData.DetailsGridItem
                            },
                            new Control
                            {
                                Type="Table",
                                Name="TBLPERSONELLER",
                                Value=mainFormData.TableItem
                            },
                            new Control
                            {
                                Type="Details",
                                Name="DTENVANTER",
                                Value=mainFormData.Details
                            }
                        }
                    }
                }
            };
        }
    }
}
