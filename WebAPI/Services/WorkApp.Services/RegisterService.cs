using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkApp.Data.Models;
using WorkApp.Data.Repositories;
using WorkApp.Services.Data;

namespace WorkApp.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IDeletableEntityRepository<Worker> workersRepository;
        private readonly IDeletableEntityRepository<Client> clientsRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public RegisterService(IDeletableEntityRepository<Worker> workersRepository,
            IDeletableEntityRepository<Client> clientsRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.workersRepository = workersRepository;
            this.clientsRepository = clientsRepository;
            this.userManager = userManager;
        }

        public async Task RegisterWorker(RegisterWorkerInputModel inputModel)
        {
            string createdUserId = await CreateUser(inputModel.FirstName, inputModel.LastName, inputModel.Email, inputModel.Password);

            var worker = new Worker()
            {
                Address = inputModel.Address,
                Description = inputModel.Description,
                HourlyPayment = (decimal)inputModel.HourlyPayment,
                UserId = createdUserId,
            };

            await workersRepository.AddAsync(worker);
            await workersRepository.SaveChangesAsync();
        }

        public async Task RegisterClient(RegisterClientInputModel inputModel)
        {
            string createdUserId = await CreateUser(inputModel.FirstName, inputModel.LastName, inputModel.Email, inputModel.Password);

            var client = new Client()
            {
                CompanyName = inputModel.CompanyName,
                UserId = createdUserId,
            };

            await clientsRepository.AddAsync(client);
            await clientsRepository.SaveChangesAsync();
        }

        private async Task<string> CreateUser(string firstName, string lastName, string email, string password)
        {
            var user = new ApplicationUser()
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = email,
                Email = email,
            };

            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return user.Id;
            }

            string errors = string.Join('\n', result.Errors.Select(x => x.Description));
            throw new Exception("Could not create user.\n" + errors);
        }
    }
}
