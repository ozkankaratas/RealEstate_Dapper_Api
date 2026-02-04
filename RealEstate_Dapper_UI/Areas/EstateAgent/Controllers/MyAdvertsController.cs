using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.LocationDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MyAdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        public MyAdvertsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> ActiveAdverts()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Products/ActiveProductAdvertsListByEmployee?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> PassiveAdverts()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Products/PassiveProductAdvertsListByEmployee?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAdvert()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44338/api/Categories");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.categories = categoryValues;
            var model = new CreateProductDto
            {
                Date = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdvert(CreateProductDto createProductDto, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var extension = Path.GetExtension(file.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/productImages/", newImageName);
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/productImages/");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                createProductDto.CoverImage = "/productImages/" + newImageName;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(createProductDto.CoverImage))
                {
                    createProductDto.CoverImage = "/productImages/default.png";
                }
            }
            createProductDto.DealOfTheDay = false;
            createProductDto.Date = DateTime.Now;
            createProductDto.Status = true;
            var id = _loginService.GetUserId;
            createProductDto.AppUserId = int.Parse(id);

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44338/api/Products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ActiveAdverts", "MyAdverts", new { area = "EstateAgent" });
            }
            return View();
        }

        public async Task<IActionResult> DeleteAdvert(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44338/api/Products/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ActiveAdverts", "MyAdverts", new { area = "EstateAgent" });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAdvert(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage1 = await client.GetAsync($"https://localhost:44338/api/Products/GetProductById?id={id}");
            if (!responseMessage1.IsSuccessStatusCode) return RedirectToAction("ActiveAdverts", "MyAdverts", new { area = "EstateAgent" });
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData1);

            
            var responseMessage2 = await client.GetAsync($"https://localhost:44338/api/Categories/");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);

            ViewBag.categories = values2.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString(),
                Selected = x.CategoryID == values1.ProductCategory
            }).ToList();

        
            var responseMessage3 = await client.GetAsync("https://localhost:44338/api/Locations/cities");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            var values3 = JsonConvert.DeserializeObject<List<ResultCityDto>>(jsonData3);

            ViewBag.cities = values3.Select(x => new SelectListItem
            {
                Text = x.CityName,
                Value = x.CityID.ToString(),
                Selected = x.CityID.ToString() == values1.City
            }).ToList();

            if (!string.IsNullOrEmpty(values1.City))
            {
                var responseMessage4 = await client.GetAsync($"https://localhost:44338/api/Locations/GetDistricts/{values1.City}");
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<List<ResultDistrictDto>>(jsonData4);

                ViewBag.districts = values4.Select(x => new SelectListItem
                {
                    Text = x.DistrictName,
                    Value = x.DistrictID.ToString(),
                    Selected = x.DistrictID.ToString() == values1.District 
                }).ToList();
            }
            else { ViewBag.districts = new List<SelectListItem>(); }

            if (!string.IsNullOrEmpty(values1.District))
            {
                var responseMessage5 = await client.GetAsync($"https://localhost:44338/api/Locations/GetSemts/{values1.District}");
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<List<ResultSemtDto>>(jsonData5);

                ViewBag.semtler = values5.Select(x => new SelectListItem
                {
                    Text = x.SemtName,
                    Value = x.SemtID.ToString(),
                    Selected = x.SemtID.ToString() == values1.Semt
                }).ToList();
            }
            else { ViewBag.semtler = new List<SelectListItem>(); }

            if (!string.IsNullOrEmpty(values1.Semt))
            {
                var responseMessage6 = await client.GetAsync($"https://localhost:44338/api/Locations/GetNeighborhoods/{values1.Semt}");
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<List<ResultNeighborhoodDto>>(jsonData6);

                ViewBag.neighborhoods = values6.Select(x => new SelectListItem
                {
                    Text = x.NeighborhoodName,
                    Value = x.NeighborhoodID.ToString(),
                    Selected = x.NeighborhoodID.ToString() == values1.Neighborhood 
                }).ToList();
            }
            else { ViewBag.neighborhoods = new List<SelectListItem>(); }

            return View(values1);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAdvert(UpdateProductDto updateProductDto, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var extension = Path.GetExtension(file.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/productImages/", newImageName);
                var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/productImages/");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                using (var stream = new FileStream(location, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                updateProductDto.CoverImage = "/productImages/" + newImageName;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(updateProductDto.CoverImage))
                {
                    updateProductDto.CoverImage = "/productImages/default.png";
                }
            }

            updateProductDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44338/api/Products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ActiveAdverts", "MyAdverts", new { area = "EstateAgent" });
            }
            return View();
        }

        public async Task<IActionResult> ChangeStatusToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsync($"https://localhost:44338/api/Products/ChangeStatusToFalse/{id}", null);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ActiveAdverts", "MyAdverts", new { area = "EstateAgent" });
            }
            return View();

        }

        public async Task<IActionResult> ChangeStatusToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.PutAsync($"https://localhost:44338/api/Products/ChangeStatusToTrue/{id}", null);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("PassiveAdverts", "MyAdverts", new { area = "EstateAgent" });
            }
            return View();
        }
    }
}
