using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Lab16Final.Model;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using System.Net.Http;


namespace Lab16Final.Data
{
    public class RestService : IRestService
    {
        private HttpClient _httpClient;

        private List<Student> Students { get; set; }

        public RestService()
        {
            _httpClient = new HttpClient(
                DependencyService
                    .Get<IHttpClientHandlerService>()
                    .GetInsecureHandler()
                    
            );
        }
        
        public async Task<List<Student>> RefreshDataAsync()
        {
            Students = new List<Student>();
            String method = "all";
            var uri = new Uri(string.Format(Constant.URL, method));
            try
            {
                var response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    Students = JsonConvert.DeserializeObject<List<Student>>(content);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"°\tError {0}", e.Message);
                throw;
            }
            return Students;
        }

        public async Task SaveStudentAsync(Student student, bool isNew)
        {
            try
            {
                var json = JsonConvert.SerializeObject(student);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNew)
                {
                    var uri = new Uri(string.Format(Constant.URL, "add"));
                    response = await _httpClient.PostAsync(uri, content);
                }
                else
                {
                    var uri = new Uri(string.Format(Constant.URL, "update"));
                    response = await _httpClient.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"°\tError {0}", e.Message);
                throw;
            }
        }

        public async Task DeleteStudentAsync(string id)
        {
            var uri = new Uri(string.Format(Constant.URL, id));

            try
            {
                var response = await _httpClient.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted. ");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"°\tError {0}", e.Message);
                throw;
            }
        }
    }
}
