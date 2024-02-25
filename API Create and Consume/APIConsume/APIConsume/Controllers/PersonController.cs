using APIConsume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APIConsume.Controllers
{
    public class PersonController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:15888");
        private readonly HttpClient _client;

        public PersonController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        #region GetAll
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<PersonModel> persons = new List<PersonModel>();
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "api/Person");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeAnonymousType(data, new { status = false, message = "", data = new List<PersonModel>() });

                if (responseObject.status)
                {
                    persons = responseObject.data;
                }
            }
            return View(persons);
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> DeleteByPersonID(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync(_client.BaseAddress + "api/Person/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddEdit(int id)
        {
            PersonModel model = new PersonModel();
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    return View(model);
                }
                else
                {
                    HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "api/Person/" + id);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        var responseObject = JsonConvert.DeserializeAnonymousType(data, new { status = false, message = "", data = new PersonModel() });
                        model = responseObject.data;
                        return View(model);
                    }
                    else
                    {
                        TempData["message"] = "No Person Found";
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SaveForAddEdit(PersonModel employee)
        {
            HttpResponseMessage response;

            if (employee.PersonId == 0)
            {
                response = await _client.PostAsJsonAsync(_client.BaseAddress + "api/Person", employee);
            }
            else
            {
                response = await _client.PutAsJsonAsync(_client.BaseAddress + "api/Person", employee);
            }
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("AddEdit", employee);
            }
        }

        public async Task<IActionResult> PersonDetails(int id)
        {
            PersonModel model = new PersonModel();
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "api/Person/" + id);
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                var responseObject = JsonConvert.DeserializeAnonymousType(data, new { status = false, message = "", data = new PersonModel() });
                if (responseObject.status)
                {
                    model = responseObject.data;
                    return View(model);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
