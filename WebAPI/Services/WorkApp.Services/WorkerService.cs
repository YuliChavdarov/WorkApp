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
    public class WorkerService : IWorkerService
    {
        private readonly IDeletableEntityRepository<Worker> workersRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public WorkerService(IDeletableEntityRepository<Worker> workersRepository, UserManager<ApplicationUser> userManager)
        {
            this.workersRepository = workersRepository;
            this.userManager = userManager;
        }

        public async Task RegisterWorker(RegisterWorkerInputModel inputModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = inputModel.FirstName,
                LastName = inputModel.LastName,
                UserName = inputModel.Email,
                Email = inputModel.Email,
            };

            var result = await userManager.CreateAsync(user, inputModel.Password);

            if(result.Succeeded)
            {
                var worker = new Worker()
                {
                    Address = inputModel.Address,
                    Description = inputModel.Description,
                    HourlyPayment = (decimal)inputModel.HourlyPayment,
                    User = user,
                };

                await workersRepository.AddAsync(worker);
                await workersRepository.SaveChangesAsync();
            }
            else
            {
                string errors = string.Join('\n', result.Errors.Select(x => x.Description));
                throw new Exception("Could not create user.\n" + errors);
            }
        }
    }
}