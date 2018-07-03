using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using iPremium.Models;
using iPremium.Models.ApiModel;
using Newtonsoft.Json;

namespace iPremium.Services
{
    public class ApiService
    {
        const string BaseApiUrl = "http://ipremium.pt/umbraco/Api/";

        const string UmbracoMemberTypeCustomer = "Customer";

        const string UmbracoMemberTypeAdmin = "Admin";

        static ApiService _instance;
        public static ApiService Instance{
            get { return _instance == null ? _instance = new ApiService() : _instance; }
        }

        HttpClient _client;

        public List<Schedule> _bookings { get; private set; }
        public List<Feed> _services { get; private set; }

        public ApiService()
        {
            _client = new HttpClient();
            _client.MaxResponseContentBufferSize = 256000;
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
        }

        /// <summary>
        /// Cancels the booking.
        /// </summary>
        public async Task<bool> CancelBooking(Schedule booking)
        {
            booking.Status = BookingStatus.Cancelado.ToString();

            var uri = new Uri(BaseApiUrl + "BookingApi/Save");

            try
            {
                var stringContent = JsonConvert.SerializeObject(booking);
                var response = await _client.PostAsync(uri, new StringContent(stringContent, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                Debug.WriteLine(@"BAD RESPONSE FROM API");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"CREATE BOOKING ERROR {0}", ex.Message);
                return false;
            }
        }


        /// <summary>
        /// Will Create a new booking record for the customer 
        /// </summary>
        public async Task<bool> SaveBooking(CreateBookingModel model)
        {
            var uri = new Uri(BaseApiUrl + "BookingApi/Save");

            try
            {
                var stringContent = JsonConvert.SerializeObject((NewBookingModel)model);
                var response = await _client.PostAsync(uri, new StringContent(stringContent, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                Debug.WriteLine(@"BAD RESPONSE FROM API");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"CREATE BOOKING ERROR {0}", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Gets all the bookings for a particular customer 
        /// </summary>
        public async Task<List<Schedule>> GetBookingsForCustomer(string email)
        {
            var start = DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd");
            var end = DateTime.Now.AddMonths(6).ToString("yyyy-MM-dd");

            var bookings = await GetBookingsByStartEndDate(start, end);
            bookings = bookings.Where(x => x.Email == email).ToList();

            return bookings;
        }


        /// <summary>
        /// Gets the appointments.
        /// </summary>
        public async Task<List<Schedule>> GetBookingsByStartEndDate(string dateFrom, string dateTo)
        {
            var requestUrl = $"BookingApi/get?start={dateFrom}&end={dateTo}";
            var uri = new Uri(BaseApiUrl + requestUrl);

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _bookings = JsonConvert.DeserializeObject<List<Schedule>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"GET BOOKINGS ERROR {0}", ex.Message);
            }

            return _bookings;
        }

        /// <summary>
        /// Gets the booking by date.
        /// </summary>
        /// <returns>The booking.</returns>
        public async Task<Schedule> GetBooking(string date)
        {
            Schedule booking;

            var requestUrl = $"BookingApi/GetByDay/{date}";
            var uri = new Uri(BaseApiUrl + requestUrl);

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    booking = JsonConvert.DeserializeObject<Schedule>(content);
                    return booking;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"GET BOOKINGS ERROR {0}", ex.Message);
            }

            return null;
        }

        public async Task<byte[]> DownloadImageAsync(string imageUrl)
        {
            var httpclient = new HttpClient();
            Task<byte[]> contentsTask = httpclient.GetByteArrayAsync(imageUrl);

            return await contentsTask;
        }


        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <returns>The services.</returns>
        public async Task<List<Feed>> GetServices()
        {
            var requestUrl = "ServiceApi/GetServices";
            var uri = new Uri(BaseApiUrl + requestUrl);

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    _services = JsonConvert.DeserializeObject<List<Feed>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"GET SERVICES ERROR {0}", ex.Message);
            }

            return _services;
        }

        /// <summary>
        /// Gets a single service by ID.
        /// </summary>
        public async Task<Feed> GetService(int id)
        {
            Feed service;

            var requestUrl = $"ServiceApi/Get/{id}";
            var uri = new Uri(BaseApiUrl + requestUrl);

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    service = JsonConvert.DeserializeObject<Feed>(content);
                    return service;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"GET SERVICE BY ID ERROR {0}", ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Handles the member registration.
        /// </summary>
        public async Task<Account> HandleMemberRegistration(string username, string password, string name, string phone)
        {
            var account = new Account()
            {
                Username = username,
                Password = password,
                Name = name,
                MemberType = MemberType.Member,
                Phone = phone
            };

            var requestUrl = $"AccountApi/Register/";
            var uri = new Uri(BaseApiUrl + requestUrl);

            try
            {
                var stringContent = JsonConvert.SerializeObject(account);
                var response = await _client.PostAsync(uri, new StringContent(stringContent, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    account.Success = true;
                    return account;
                }
                else
                    return new Account
                    {
                        Success = false,
                        Message = await response.Content.ReadAsStringAsync() // read the message from server anyway!
                    };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"GET SERVICE BY ID ERROR {0}", ex.Message);
            }
            return null;
        }

        public async Task<bool> HandleMemberLogin(string username, string password)
        {
            var requestUrl = $"AccountApi/Login/";
            var uri = new Uri(BaseApiUrl + requestUrl);

            try
            {
                var loginModel = new LoginModel { Username = username, Password = password };
                var content = JsonConvert.SerializeObject(loginModel);

                var response = await _client.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"LOGIN API ERROR {0}", ex.Message);
            }

            return false;
        }

        /// <summary>
        /// Gets the member by username.
        /// </summary>
        public async Task<Account> GetMember(string username)
        {
            Account account;

            var requestUrl = $"AccountApi/MemberData/";
            var uri = new Uri(BaseApiUrl + requestUrl);

            try
            {
                var accountModel = new AccountModel { Username = username };
                var content = JsonConvert.SerializeObject(accountModel);

                var response = await _client.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/json"));
                if (response.IsSuccessStatusCode)
                {
                    var member = await response.Content.ReadAsStringAsync();
                    account = JsonConvert.DeserializeObject<Account>(member);
                    return account;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"GET MEMBER ERROR {0}", ex.Message);
            }

            return null;
        }
    }
}
